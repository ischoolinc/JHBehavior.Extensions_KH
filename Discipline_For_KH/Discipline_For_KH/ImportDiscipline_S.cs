using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using JHSchool.Data;
using SmartSchool.API.PlugIn;
using System.Text;

namespace Discipline_For_KH
{
    class ImportDiscipline_S : SmartSchool.API.PlugIn.Import.Importer
    {
        public ImportDiscipline_S()
        {
            this.Image = null;
            this.Text = "匯入獎勵記錄(For高雄)";
        }

        public override void InitializeImport(SmartSchool.API.PlugIn.Import.ImportWizard wizard)
        {
            Dictionary<string, JHMeritRecord> CacheDiscipline = new Dictionary<string, JHMeritRecord>();

            VirtualRadioButton chose1 = new VirtualRadioButton("比對事由變更獎勵次數", false);
            VirtualRadioButton chose2 = new VirtualRadioButton("比對獎勵次數變更事由", false);
            chose1.CheckedChanged += delegate
            {
                if (chose1.Checked)
                {
                    wizard.RequiredFields.Clear();
                    wizard.RequiredFields.AddRange("學年度", "學期", "日期", "事由");
                }
            };
            chose2.CheckedChanged += delegate
            {
                if (chose2.Checked)
                {
                    wizard.RequiredFields.Clear();
                    wizard.RequiredFields.AddRange("學年度", "學期", "日期", "大功", "小功", "嘉獎");
                }
            };
            wizard.ImportableFields.AddRange("學年度", "學期", "日期", "大功", "小功", "嘉獎", "登錄日期");
            wizard.Options.AddRange(chose1, chose2);
            chose1.Checked = true;
            wizard.PackageLimit = 1000;
            bool allPass = true;
            wizard.ValidateStart += delegate(object sender, SmartSchool.API.PlugIn.Import.ValidateStartEventArgs e)
            {
                foreach (JHMeritRecord record in JHMerit.SelectByStudentIDs(e.List))
                    if (!CacheDiscipline.ContainsKey(record.ID))
                        CacheDiscipline.Add(record.ID, record);

                allPass = true;
            };
            int insertRecords = 0;
            int updataRecords = 0;
            wizard.ValidateRow += delegate(object sender, SmartSchool.API.PlugIn.Import.ValidateRowEventArgs e)
            {
                #region 驗證資料
                bool pass = true;
                int schoolYear, semester;
                DateTime occurdate;
                bool isInsert = false;
                bool isUpdata = false;
                #region 驗共同必填欄位
                if (!int.TryParse(e.Data["學年度"], out schoolYear))
                {
                    e.ErrorFields.Add("學年度", "必需輸入數字");
                    pass = false;
                }
                if (!int.TryParse(e.Data["學期"], out semester))
                {
                    e.ErrorFields.Add("學期", "必需輸入數字");
                    pass = false;
                }
                // 2016/6/21 穎驊修改，因有學校反映在匯入獎懲資料時，會將日期打成民國年計算(應該要西元)，此舉會造成系統後續錯誤，
                // 經過討論，決定新增提示訊息，以後只要輸入民國年、空白年，會在錯誤報告Excel中標示提醒，
                // 下面運作的邏輯是:
                //1. 假如資料為null、型別錯誤 使得TryParse失敗 會中止
                //2. 假如TryParse成功，轉換輸出到occurdate，但其來源明顯是民國年(EX:105/6/6)，按它原本的邏輯會把他當成西元105/6/6
                //所以在此就另外加一個判斷，假如此年份比1911小，就視為使用者輸入的是民國年，後續程序會擋住他，放入錯誤報告Excel中，
                // 能夠如此大膽設條件，建立在兩個前提之下:1. 我們的正常資料不會有西元1911年前的資料 2.我們的資料也不會有民國1911後的資料
                // 如果能等到民國1911年 還要再來處理這個Bug，那我也覺得心滿意足了哈哈


                if (!DateTime.TryParse(e.Data["日期"], out occurdate)|| occurdate.Year <1911)
                {
                    e.ErrorFields.Add("日期", "輸入格式為 西元年//月//日");
                    pass = false;
                }
                #endregion
                if (!pass)
                {
                    allPass = false;
                    return;
                }
                if (chose1.Checked)
                {
                    #region 以事由為Key更新
                    string reason = e.Data["事由"];
                    int match = 0;
                    foreach (JHMeritRecord rewardInfo in CacheDiscipline.Values.Where(x => x.RefStudentID == e.Data.ID))
                    {
                        if (rewardInfo.SchoolYear == schoolYear && rewardInfo.Semester == semester && rewardInfo.OccurDate == occurdate && rewardInfo.Reason == reason)
                            match++;
                    }
                    if (match > 1)
                    {
                        e.ErrorMessage = "系統發現此事由在同一天中存在兩筆重複資料，無法進行更新，建議您手動處裡此筆變更。";
                        pass = false;
                    }
                    if (match == 0)
                    {
                        isInsert = true;
                    }
                    else
                    {
                        isUpdata = true;
                    }
                    #endregion
                }
                if (chose2.Checked)
                {
                    #region 以次數為Key更新
                    int awardA = 0;
                    int awardB = 0;
                    int awardC = 0;
                    #region 驗證必填欄位
                    if (e.Data["大功"] != "" && !int.TryParse(e.Data["大功"], out awardA))
                    {
                        e.ErrorFields.Add("大功", "必需輸入數字");
                        pass = false;
                    }
                    if (e.Data["小功"] != "" && !int.TryParse(e.Data["小功"], out awardB))
                    {
                        e.ErrorFields.Add("小功", "必需輸入數字");
                        pass = false;
                    }
                    if (e.Data["嘉獎"] != "" && !int.TryParse(e.Data["嘉獎"], out awardC))
                    {
                        e.ErrorFields.Add("嘉獎", "必需輸入數字");
                        pass = false;
                    }
                    #endregion
                    if (!pass)
                    {
                        return;
                    }
                    int match = 0;
                    #region 檢查重複
                    foreach (JHMeritRecord rewardInfo in CacheDiscipline.Values.Where(x => x.RefStudentID == e.Data.ID))
                    {
                        int MeritA = rewardInfo.MeritA.HasValue ? rewardInfo.MeritA.Value : 0;
                        int MeritB = rewardInfo.MeritB.HasValue ? rewardInfo.MeritB.Value : 0;
                        int MeritC = rewardInfo.MeritC.HasValue ? rewardInfo.MeritC.Value : 0;

                        if (rewardInfo.SchoolYear == schoolYear &&
                            rewardInfo.Semester == semester &&
                            rewardInfo.OccurDate == occurdate &&
                            MeritA == awardA &&
                            MeritB == awardB &&
                            MeritC == awardC)
                            match++;
                    }
                    #endregion

                    if (match > 1)
                    {
                        e.ErrorMessage = "系統發現此獎勵次數在同一天中存在兩筆重複資料，無法進行更新，建議您手動處裡此筆變更。";
                        pass = false;
                    }

                    if (match == 0)
                    {
                        isInsert = true;
                    }
                    else
                    {
                        isUpdata = true;
                    }
                    #endregion
                }
                if (!pass)
                {
                    allPass = false;
                    return;
                }
                #region 驗證可選則欄位值
                int integer;
                DateTime dateTime;
                bool hasAward = false, IsErrorAward = true;
                foreach (string field in e.SelectFields)
                {
                    switch (field)
                    {
                        #region field
                        case "大功":
                        case "小功":
                        case "嘉獎":
                            if (e.Data[field] != "") //當欄位內有值
                            {
                                if (!int.TryParse(e.Data[field], out integer)) //欄位內的不是數字
                                {
                                    e.ErrorFields.Add(field, "必需輸入數字");
                                    pass = false;
                                }
                                else
                                {
                                    if (integer < 0) //小於0
                                    {
                                        e.ErrorFields.Add(field, "不可為負數");
                                        pass = false;

                                    }
                                    else
                                    {
                                        IsErrorAward = false;
                                        hasAward |= integer > 0;
                                    }
                                }
                            }
                            break;

                        // 2016/6/21 穎驊修改，因有學校反映在匯入獎懲資料時，會將日期打成民國年計算(應該要西元)，此舉會造成系統後續錯誤，
                        // 經過討論，決定新增提示訊息，以後只要輸入民國年、空白年，會在錯誤報告Excel中標示提醒，
                        // 下面運作的邏輯是:
                        //1. 假如資料為null、型別錯誤 使得TryParse失敗 會中止
                        //2. 假如TryParse成功，轉換輸出到occurdate，但其來源明顯是民國年(EX:105/6/6)，按它原本的邏輯會把他當成西元105/6/6
                        //所以在此就另外加一個判斷，假如此年份比1911小，就視為使用者輸入的是民國年，後續程序會擋住他，放入錯誤報告Excel中，
                        // 能夠如此大膽設條件，建立在兩個前提之下:1. 我們的正常資料不會有西元1911年前的資料 2.我們的資料也不會有民國1911後的資料
                        // 如果能等到民國1911年 還要再來處理這個Bug，那我也覺得心滿意足了哈哈

                        case "登錄日期":
                            if (e.Data[field] != "")
                            {
                                if (!DateTime.TryParse(e.Data[field], out dateTime)|| dateTime.Year<1911)
                                {
                                    e.ErrorFields.Add(field, "輸入格式為 西元年//月//日");
                                    pass = false;
                                }
                                break;
                            }
                            break;
                        #endregion
                    }
                }

                #region 檢查是否獎懲都是0

                bool 檢查是否獎都是0 = false;
                bool 檢查獎是空值 = false;
                int 大功A = 0;
                int 小功A = 0;
                int 嘉獎A = 0;
                if (e.SelectFields.Contains("大功") && e.SelectFields.Contains("小功") && e.SelectFields.Contains("嘉獎"))
                {
                    #region 獎
                    //是否是空值
                    if (!string.IsNullOrEmpty(e.Data["大功"]) || !string.IsNullOrEmpty(e.Data["小功"]) || !string.IsNullOrEmpty(e.Data["嘉獎"]))
                    {
                        //是否是數字
                        int.TryParse(e.Data["大功"], out 大功A);
                        int.TryParse(e.Data["小功"], out 小功A);
                        int.TryParse(e.Data["嘉獎"], out 嘉獎A);

                        //相加是否為0
                        if (大功A + 小功A + 嘉獎A == 0)
                        {
                            檢查是否獎都是0 = true;
                        }

                    }
                    else
                    {
                        檢查獎是空值 = true;
                    }
                    #endregion
                }

                if (檢查是否獎都是0)
                {
                    e.WarningFields["日期"] = "將建立隻數為0的獎勵資料";
                }

                if (檢查獎是空值)
                {
                    e.ErrorMessage = "無法新增沒有支數的記錄。";
                    pass = false;
                }

                #endregion

                if (pass && isInsert)
                    insertRecords++;
                if (pass && isUpdata)
                    updataRecords++;

                #endregion
                if (!pass)
                {
                    allPass = false;
                }
                #endregion
            };
            wizard.ValidateComplete += delegate
            {
                StringBuilder sb = new StringBuilder();
                if (allPass && insertRecords > 0)
                {
                    sb.AppendLine("新增" + insertRecords + "筆獎勵記錄");
                }

                if (allPass && updataRecords > 0)
                {
                    sb.AppendLine("更新" + updataRecords + "筆獎勵記錄");
                }

                if (sb.ToString() != "")
                {
                    sb.AppendLine("\n因為目前無法批次刪除獎勵，\n如與資料筆數不符請勿繼續。");
                    MsgBox.Show(sb.ToString(), "新增與更新獎勵", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            };
            wizard.ImportComplete += (sender, e) => MessageBox.Show("匯入完成!");
            wizard.ImportPackage += delegate(object sender, SmartSchool.API.PlugIn.Import.ImportPackageEventArgs e)
            {
                bool hasUpdate = false, hasInsert = false;

                List<JHMeritRecord> updateDisciplines = new List<JHMeritRecord>();
                List<JHMeritRecord> insertDisciplines = new List<JHMeritRecord>();

                //2014/2/27日新增Log記錄
                StringBuilder Log_sb = new StringBuilder();
                if (chose1.Checked)
                {
                    Log_sb.AppendLine("以事由更新獎勵記錄：");
                }
                if (chose2.Checked)
                {
                    Log_sb.AppendLine("以次數更新獎勵記錄：");
                }


                foreach (RowData row in e.Items)
                {
                    int schoolYear = int.Parse(row["學年度"]);
                    int semester = int.Parse(row["學期"]);
                    DateTime occurdate = DateTime.Parse(row["日期"]);
                    if (chose1.Checked)
                    {
                        #region 以事由為Key更新
                        bool isAward;
                        int awardA = 0;
                        int awardB = 0;
                        int awardC = 0;
                        DateTime? registerdate = null;
                        bool ultimateAdmonition = false;

                        if (row.ContainsKey("大功"))
                            awardA = (row["大功"] == "") ? 0 : int.Parse(row["大功"]);
                        if (row.ContainsKey("小功"))
                            awardB = (row["小功"] == "") ? 0 : int.Parse(row["小功"]);
                        if (row.ContainsKey("嘉獎"))
                            awardC = (row["嘉獎"] == "") ? 0 : int.Parse(row["嘉獎"]);

                        if (e.ImportFields.Contains("登錄日期") && row["登錄日期"] != "")
                            registerdate = DateTime.Parse(row["登錄日期"]);
                        //else 
                        //    registerdate = DateTime.Now;                        

                        string reason = row["事由"];
                        bool match = false;
                        foreach (JHMeritRecord rewardInfo in CacheDiscipline.Values.Where(x => x.RefStudentID == row.ID))
                        {
                            if (rewardInfo.SchoolYear == schoolYear && rewardInfo.Semester == semester && rewardInfo.OccurDate == occurdate && rewardInfo.Reason.Equals(reason))
                            {
                                match = true;
                                #region 其他項目

                                if (e.ImportFields.Contains("登錄日期"))
                                    registerdate = row["登錄日期"] != "" ? K12.Data.DateTimeHelper.Parse(row["登錄日期"]) : null;
                                else
                                    registerdate = rewardInfo.RegisterDate;

                                #endregion
                                JHMeritRecord record = new JHMeritRecord();

                                record.MeritA = awardA;
                                record.MeritB = awardB;
                                record.MeritC = awardC;

                                record.MeritFlag = "1";
                                record.RefStudentID = row.ID;
                                record.SchoolYear = schoolYear;
                                record.Semester = semester;
                                record.OccurDate = occurdate;
                                record.RegisterDate = registerdate;
                                record.Reason = reason;
                                record.ID = rewardInfo.ID;

                                updateDisciplines.Add(record);

                                hasUpdate = true;
                                break;
                            }
                        }
                        if (!match)
                        {

                            JHMeritRecord record = new JHMeritRecord();

                            record.MeritA = awardA;
                            record.MeritB = awardB;
                            record.MeritC = awardC;

                            record.MeritFlag = "1";
                            record.RefStudentID = row.ID;
                            record.SchoolYear = schoolYear;
                            record.Semester = semester;
                            record.OccurDate = occurdate;
                            record.Reason = reason;
                            record.RegisterDate = registerdate;

                            insertDisciplines.Add(record);

                            hasInsert = true;
                        }
                        #endregion
                    }
                    if (chose2.Checked)
                    {
                        #region 以次數為Key更新
                        bool isAward;
                        int awardA = 0;
                        int awardB = 0;
                        int awardC = 0;
                        DateTime? registerdate = null;
                        bool ultimateAdmonition = false;
                        string reason = row.ContainsKey("事由") ? row["事由"] : "";

                        if (row.ContainsKey("大功"))
                            awardA = (row["大功"] == "") ? 0 : int.Parse(row["大功"]);
                        if (row.ContainsKey("小功"))
                            awardB = (row["小功"] == "") ? 0 : int.Parse(row["小功"]);
                        if (row.ContainsKey("嘉獎"))
                            awardC = (row["嘉獎"] == "") ? 0 : int.Parse(row["嘉獎"]);

                        if (e.ImportFields.Contains("登錄日期") && row["登錄日期"] != "")
                            registerdate = K12.Data.DateTimeHelper.Parse(row["登錄日期"]);

                        bool match = false;
                        foreach (JHMeritRecord rewardInfo in CacheDiscipline.Values.Where(x => x.RefStudentID == row.ID))
                        {
                            int MeritA = rewardInfo.MeritA.HasValue ? rewardInfo.MeritA.Value : 0;
                            int MeritB = rewardInfo.MeritB.HasValue ? rewardInfo.MeritB.Value : 0;
                            int MeritC = rewardInfo.MeritC.HasValue ? rewardInfo.MeritC.Value : 0;

                            if (rewardInfo.SchoolYear == schoolYear &&
                                rewardInfo.Semester == semester &&
                                rewardInfo.OccurDate == occurdate &&
                                MeritA == awardA &&
                                MeritB == awardB &&
                                MeritC == awardC)
                            {
                                match = true;
                                #region 其他項目
                                reason = e.ImportFields.Contains("事由") ? row["事由"] : rewardInfo.Reason;

                                if (e.ImportFields.Contains("登錄日期"))
                                    registerdate = row["登錄日期"] != "" ? K12.Data.DateTimeHelper.Parse(row["登錄日期"]) : null;
                                else
                                    registerdate = rewardInfo.RegisterDate;

                                //ultimateAdmonition = e.ImportFields.Contains("留校察看") ?
                                //    ((row["留校察看"] == "是") ? true : false) :l
                                //    rewardInfo.UltimateAdmonition;
                                #endregion

                                JHMeritRecord record = new JHMeritRecord();

                                record.MeritA = awardA;
                                record.MeritB = awardB;
                                record.MeritC = awardC;

                                record.MeritFlag = "1";
                                record.RefStudentID = row.ID;
                                record.SchoolYear = schoolYear;
                                record.Semester = semester;
                                record.OccurDate = occurdate;
                                record.RegisterDate = registerdate;
                                record.Reason = reason;
                                record.ID = rewardInfo.ID;

                                updateDisciplines.Add(record);

                                hasUpdate = true;
                                break;
                            }
                        }
                        if (!match)
                        {

                            JHMeritRecord record = new JHMeritRecord();

                            record.MeritA = awardA;
                            record.MeritB = awardB;
                            record.MeritC = awardC;

                            record.MeritFlag = "1";
                            record.RefStudentID = row.ID;
                            record.SchoolYear = schoolYear;
                            record.Semester = semester;
                            record.OccurDate = occurdate;
                            record.RegisterDate = registerdate;
                            record.Reason = reason;

                            insertDisciplines.Add(record);

                            hasInsert = true;
                        }
                        #endregion
                    }
                }

                if (hasUpdate)
                {
                    JHMerit.Update(updateDisciplines);
                    Dictionary<string, K12.Data.StudentRecord> StudentDic = GetStudent(updateDisciplines);
                    foreach (JHMeritRecord record in updateDisciplines)
                    {
                        if (StudentDic.ContainsKey(record.RefStudentID))
                            Log_sb.AppendLine(GetLogContext(record, StudentDic[record.RefStudentID], "更新獎勵記錄"));
                    }
                }
                if (hasInsert)
                {
                    JHMerit.Insert(insertDisciplines);
                    Dictionary<string, K12.Data.StudentRecord> StudentDic = GetStudent(insertDisciplines);
                    foreach (JHMeritRecord record in insertDisciplines)
                    {
                        if (StudentDic.ContainsKey(record.RefStudentID))
                            Log_sb.AppendLine(GetLogContext(record, StudentDic[record.RefStudentID], "新增獎勵記錄"));
                    }
                }
                if (hasUpdate || hasInsert)
                {
                    FISCA.LogAgent.ApplicationLog.Log("匯入獎勵記錄(For高雄)", "新增或更新", Log_sb.ToString());
                }
            };
        }

        private string GetLogContext(JHMeritRecord record, K12.Data.StudentRecord studentRecord, string flag)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("學生「" + studentRecord.Name + "」" + flag + ",日期「" + record.OccurDate.ToShortDateString() + "」");
            return sb.ToString();
        }

        /// <summary>
        /// 取得學生清單
        /// </summary>
        private Dictionary<string, K12.Data.StudentRecord> GetStudent(List<JHMeritRecord> updateDisciplines)
        {
            Dictionary<string, K12.Data.StudentRecord> StudentDic = new Dictionary<string, K12.Data.StudentRecord>();
            List<string> StudentIDList = new List<string>();
            foreach (JHMeritRecord dis in updateDisciplines)
            {
                if (!StudentIDList.Contains(dis.RefStudentID))
                    StudentIDList.Add(dis.RefStudentID);
            }
            List<K12.Data.StudentRecord> StudentRecordList = K12.Data.Student.SelectByIDs(StudentIDList);
            foreach (K12.Data.StudentRecord stud in StudentRecordList)
            {
                if (!StudentDic.ContainsKey(stud.ID))
                {
                    StudentDic.Add(stud.ID, stud);
                }
            }
            return StudentDic;
        }
    }
}