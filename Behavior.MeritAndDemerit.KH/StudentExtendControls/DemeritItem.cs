﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevComponents.DotNetBar;
using Framework.Security;
using Framework;
using JHSchool.Behavior;
using JHSchool.Behavior.Editor;
using JHSchool.Behavior.StudentExtendControls;
using FCode = Framework.Security.FeatureCodeAttribute;
using JHSchool.Data;
using FISCA.LogAgent;

namespace JHSchool.Behavior.MeritAndDemerit_KH
{
    [FCode("JHSchool.Student.Detail0040", "懲戒記錄")]
    internal partial class DemeritItem : DetailContentBase
    {
        //public static string FeatureCode = (Attribute.GetCustomAttribute( typeof(DemeritItem), typeof(FeatureCodeAttribute)) as FeatureCodeAttribute).FeatureCode;
        internal static FeatureAce UserPermission;
        private List<K12.Data.DemeritRecord> _records = new List<K12.Data.DemeritRecord>();

        BackgroundWorker BGW = new BackgroundWorker();
        bool BkWBool = false;

        public DemeritItem()
        {
            InitializeComponent();

            BGW.DoWork += new DoWorkEventHandler(BkW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BkW_RunWorkerCompleted);

            //Demerit.Instance.ItemUpdated += new EventHandler<ItemUpdatedEventArgs>(this.refreshUIData); //當 Cache Manager 中的資料有被更新時就重新更新畫面。

            this.Group = "懲戒記錄";    //設定毛毛蟲顯示的 Title ，如不設定會有 Exception。

            K12.Data.Demerit.AfterInsert += new EventHandler<K12.Data.DataChangedEventArgs>(JHMerit_Changed);
            K12.Data.Demerit.AfterDelete += new EventHandler<K12.Data.DataChangedEventArgs>(JHMerit_Changed);
            K12.Data.Demerit.AfterUpdate += new EventHandler<K12.Data.DataChangedEventArgs>(JHMerit_Changed);

            //暫解ItemUpdated問題
            Demerit.Instance.ItemUpdated += new EventHandler<ItemUpdatedEventArgs>(Instance_ItemUpdated);

            UserPermission = User.Acl[FCode.GetCode(GetType())];

            btnInsert.Visible = UserPermission.Editable;
            btnUpdate.Visible = UserPermission.Editable;
            btnDelete.Visible = UserPermission.Editable;
            btnClear.Visible = UserPermission.Editable;
            btnView.Visible = UserPermission.Viewable & !UserPermission.Editable;
        }

        //暫解ItemUpdated問題
        void Instance_ItemUpdated(object sender, ItemUpdatedEventArgs e)
        {
            if (!BGW.IsBusy)
                BGW.RunWorkerAsync();
        }

        void JHMerit_Changed(object sender, K12.Data.DataChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, K12.Data.DataChangedEventArgs>(JHMerit_Changed), sender, e);
            }
            else
            {
                if (this.PrimaryKey != "")
                {
                    this.Loading = true;

                    if (BGW.IsBusy)
                    {
                        BkWBool = true;
                    }
                    else
                    {
                        BGW.RunWorkerAsync();
                    }
                }
            }
        }

        /// <summary>
        /// 當主畫面檢視不同學生時，此毛毛蟲就被指定新的學生ID，就會呼叫此方法。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            //this.Loading = true;    //畫面會呈現資料下載中的狀態(圓圈一直轉)
            //Demerit.Instance.SyncDataBackground(this.PrimaryKey);   //SyncDataBackground 方法後會觸發 Demerit.Instance.ItemUpdateed 事件

            this.Loading = true;

            if (BGW.IsBusy)
            {
                BkWBool = true;
            }
            else
            {
                BGW.RunWorkerAsync();
            }
        }

        void BkW_DoWork(object sender, DoWorkEventArgs e)
        {
            _records.Clear();
            _records = K12.Data.Demerit.SelectByStudentIDs(new string[] { this.PrimaryKey });
        }

        void BkW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (BkWBool)
            {
                BkWBool = false;
                BGW.RunWorkerAsync();
                return;
            }

            refreshUIData();

            this.Loading = false;
        }

        private void refreshUIData()
        {
            if (!this.SaveButtonVisible && !this.CancelButtonVisible && this.PrimaryKey.Contains(PrimaryKey))
            {
                //從Cache Manager 找到該學生的懲戒記錄，並更新到畫面上。

                //dataGridViewX1.Rows.Clear();
                //editors.Clear();
                this.listView.Items.Clear();

                _records.Sort(new Comparison<K12.Data.DemeritRecord>(SchoolYearComparer));

                foreach (K12.Data.DemeritRecord item in _records)
                {
                    #region 填值

                    ListViewItem itm = new ListViewItem(item.SchoolYear.ToString());
                    itm.SubItems.Add(item.Semester.ToString());
                    itm.SubItems.Add(item.OccurDate.ToShortDateString());
                    itm.SubItems.Add(item.DemeritA.ToString());
                    itm.SubItems.Add(item.DemeritB.ToString());
                    itm.SubItems.Add(item.DemeritC.ToString());
                    itm.SubItems.Add(item.Reason);
                    itm.SubItems.Add(item.Cleared);         //是否銷過
                    itm.SubItems.Add(item.ClearDate.HasValue ? item.ClearDate.Value.ToShortDateString() : "");
                    itm.SubItems.Add(item.ClearReason);     //銷過事由
                    itm.SubItems.Add(item.RegisterDate.HasValue ? item.RegisterDate.Value.ToShortDateString() : ""); //登錄日期
                    itm.SubItems.Add(item.Remark); //備註 2020/1/6 新增
                    //將資料加入ListView
                    itm.Tag = item;          //把 DemeritRecord 物件塞到 ListViewItem 物件的 Tag 屬性中，方便日後取出。
                    listView.Items.Add(itm);
                    #endregion

                }
                //this.Loading = false;
                this.CancelButtonVisible = false;
                this.SaveButtonVisible = false;
                this.ContentValidated = true;
            }

            this.Loading = false;   //畫面就會呈現資料已下載完成的畫面
        }

        //private string chengDateTime(DateTime x)
        //{
        //    if (x == null)
        //        return "";
        //    string time = x.ToString();
        //    int y = time.IndexOf(' ');
        //    return time.Remove(y);
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MsgBox.Show("請先選擇一筆您要修改的資料");
                return;
            }
            if (listView.SelectedItems.Count > 1)
            {
                MsgBox.Show("選擇資料筆數過多，一次只能修改一筆資料");
                return;
            }

            K12.Data.DemeritRecord record = (K12.Data.DemeritRecord)this.listView.SelectedItems[0].Tag;
            DemeritEditForm editForm = new DemeritEditForm(record, UserPermission); //此編輯表單在修改模式下，一次只能對一位學生的某一筆懲戒記錄進行修改，所以 Constructor 就傳入一個 Editor 物件。
            editForm.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            List<K12.Data.StudentRecord> studs = new List<K12.Data.StudentRecord>();
            studs.Add(K12.Data.Student.SelectByID(this.PrimaryKey));
            DemeritEditForm editForm = new DemeritEditForm(studs);  //此編輯表單在新增模式下允許一次對多位學生新增相同的懲戒記錄，所以 Constructor 要傳入學生的集合。
            editForm.ShowDialog();
        }


        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //1. 如果有選到一筆懲戒記錄，且該筆不是留校察看，銷過按鈕會 Enabled
            //2. 如果該筆記錄不是留校察看，且未銷過，則按鈕的文字為『銷過』
            //3. 如果該筆記錄不是留校察看，但已經銷過，則按鈕的文字為『取消銷過』            

            this.btnClear.Enabled = false;

            if (this.listView.SelectedItems.Count == 1)
            {
                K12.Data.DemeritRecord dr = (K12.Data.DemeritRecord)this.listView.SelectedItems[0].Tag;

                this.btnClear.Enabled = true;

                this.btnClear.Text = (string.IsNullOrEmpty(dr.Cleared) ? "銷過" : "取消銷過");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MsgBox.Show("必須選擇一筆以上資料!!");
                return;
            }

            List<K12.Data.DemeritRecord> DemeritList = new List<K12.Data.DemeritRecord>();


            if (MsgBox.Show("確定將刪除所選擇之懲戒資料?", "確認", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            foreach (ListViewItem item in listView.SelectedItems)
            {
                K12.Data.DemeritRecord editor = item.Tag as K12.Data.DemeritRecord;
                DemeritList.Add(editor);
            }

            try
            {
                K12.Data.Demerit.Delete(DemeritList);
            }
            catch (Exception ex)
            {
                MsgBox.Show("刪除懲戒資料失敗: \n" + ex.Message);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("學生「" + K12.Data.Student.SelectByID(this.PrimaryKey).Name + "」");
            foreach (K12.Data.DemeritRecord demerit in DemeritList)
            {
                sb.AppendLine("學年度「" + demerit.SchoolYear + "」");
                sb.AppendLine("學期「" + demerit.Semester + "」");
                sb.AppendLine("日期「" + demerit.OccurDate.ToShortDateString() + "」");

                int a = demerit.DemeritA.HasValue ? demerit.DemeritA.Value : 0;
                int b = demerit.DemeritB.HasValue ? demerit.DemeritB.Value : 0;
                int c = demerit.DemeritC.HasValue ? demerit.DemeritC.Value : 0;
                sb.AppendLine(string.Format("支數「大過：{0} 小過：{1} 警告：{2}」", a, b, c));

                sb.AppendLine("事由「" + demerit.Reason + "」");
                sb.AppendLine("備註「" + demerit.Remark + "」");
            }
            sb.AppendLine("懲戒資料已被刪除。");

            ApplicationLog.Log("學務系統.懲戒資料", "刪除學生懲戒資料", "student", this.PrimaryKey, sb.ToString());
            
            MsgBox.Show("刪除懲戒資料成功");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count == 1)
            {
                K12.Data.DemeritRecord dr = (K12.Data.DemeritRecord)this.listView.SelectedItems[0].Tag;

                if (this.btnClear.Text == "銷過")
                {
                    ClearDemeritForm editForm = new ClearDemeritForm(dr);
                    editForm.ShowDialog();
                }
                else   //取消銷過
                {
                    if (MsgBox.Show("您要將此筆銷過紀錄恢復成未銷過狀態嗎?", "確定", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dr.ClearDate = null;
                        dr.ClearReason = "";
                        dr.Cleared = "";
                        try
                        {
                            K12.Data.Demerit.Update(dr);
                            //MsgBox.Show("取消銷過完成!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MsgBox.Show("取消銷過失敗： \n" + ex.Message);
                            return;
                        }

                        ApplicationLog.Log("學務系統.懲戒資料", "取消銷過", "student", dr.Student.ID, "學生「" + dr.Student.Name + "」於「" + dr.OccurDate.ToShortDateString() + "」日，懲戒資料的「銷過狀態」已被取消。");
                        
                        MsgBox.Show("取消銷過成功!");
                    }
                }

            }
        }

        private int SchoolYearComparer(K12.Data.DemeritRecord x, K12.Data.DemeritRecord y)
        {
            return y.OccurDate.CompareTo(x.OccurDate);
            //string xx = x.SchoolYear.ToString() + x.Semester.ToString();
            //string yy = y.SchoolYear.ToString() + y.Semester.ToString();
            //return xx.CompareTo(yy);
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                DemeritEditForm editor = new DemeritEditForm(listView.SelectedItems[0].Tag as K12.Data.DemeritRecord, UserPermission);
                editor.ShowDialog();
            }
        }
    }
}
