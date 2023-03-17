using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevComponents.DotNetBar;
using FISCA.DSAUtil;
using SmartSchool.Common;
using Framework;
using JHSchool.Legacy;
using Framework.Feature;
using JHSchool.Behavior.Legacy;
using JHSchool.Behavior.Editor;
using JHSchool.Data;
using FISCA.LogAgent;
using DevComponents.DotNetBar.Validator;

namespace JHSchool.Behavior.MeritAndDemerit_KH
{
    /// <summary>
    /// �s�W�έק���y��ƪ��e���C
    /// �ק�ɡA�]���u��ק�@�Ӿǥͪ��Y�@�����y��ơA�ҥH�u�n�ǤJ�@�� MeritRecordEditor ����Y�i
    /// �s�W�ɡA�i�H�P�ɹ�h��ǥͼW�[�ۦP�����y�����A�ҥH�n�ǤJ�h��ǥͪ���ơA�����ǤJMeritRecordEditor ����A������|�b�x�s�ɥѨC��ǥͰO�����o�C
    /// </summary>
    public partial class MeritEditForm : FISCA.Presentation.Controls.BaseForm
    {
        private List<K12.Data.StudentRecord> _students;
        private ErrorProvider _errorProvider;
        private K12.Data.MeritRecord _meritRecordEditor;
        private Dictionary<string, string> ResonDic = new Dictionary<string, string>();

        //Log
        private Dictionary<string, string> DicBeforeData = new Dictionary<string, string>();

        /// <summary>
        /// Constructor�A�s�W�ɨϥΡC
        /// </summary>
        /// <param name="students"></param>
        public MeritEditForm(List<K12.Data.StudentRecord> students)
        {
            #region �s�W
            this._students = students;
            Initialize();
            dateTimeInput1.Value = DateTime.Today;
            dateTimeInput2.Value = DateTime.Today;
            Text = "���y�޲z";
            if (this._students.Count > 1)
            {
                Text = string.Format("���y�޲z �i �s�W�G{0} ... ���@ {1} �� �j", this._students[0].Name, this._students.Count.ToString()); ;
            }
            else if (this._students.Count == 1)
            {
                Text = string.Format("���y�޲z �i �s�W�G{0} �j", this._students[0].Name); ;
            }
            #endregion
        }

        public MeritEditForm(List<K12.Data.StudentRecord> students, string SchoolYear, string Semester)
        {
            #region �s�W
            this._students = students;

            #region �غc�l
            InitializeComponent();

            _errorProvider = new ErrorProvider();

            //�Ǧ~��
            intSchoolYear.Value = int.Parse(SchoolYear);
            intSemester.Value = int.Parse(Semester);
            #endregion


            dateTimeInput1.Value = DateTime.Today;
            dateTimeInput2.Value = DateTime.Today;
            Text = "���y�޲z";
            if (this._students.Count > 1)
            {
                Text = string.Format("���y�޲z �i �s�W�G{0} ... ���@ {1} �� �j", this._students[0].Name, this._students.Count.ToString()); ;
            }
            else if (this._students.Count == 1)
            {
                Text = string.Format("���y�޲z �i �s�W�G{0} �j", this._students[0].Name); ;
            }
            #endregion
        }

        //�h���غc�l
        public MeritEditForm(List<K12.Data.StudentRecord> students, string SchoolYear, string Semester,bool LockMode)
        {
            #region �s�W
            this._students = students;

            #region �غc�l
            InitializeComponent();

            _errorProvider = new ErrorProvider();

            //�Ǧ~��
            intSchoolYear.Value = int.Parse(SchoolYear);
            intSemester.Value = int.Parse(Semester);
            #endregion

            //LockMode���A���Ǧ~�׾Ǵ�
            if (LockMode)
            {
                intSchoolYear.Enabled = false;
                intSemester.Enabled = false;
            }

            dateTimeInput1.Value = DateTime.Today;
            dateTimeInput2.Value = DateTime.Today;
            Text = "���y�޲z";
            if (this._students.Count > 1)
            {
                Text = string.Format("���y�޲z �i �s�W�G{0} ... ���@ {1} �� �j", this._students[0].Name, this._students.Count.ToString()); ;
            }
            else if (this._students.Count == 1)
            {
                Text = string.Format("���y�޲z �i �s�W�G{0} �j", this._students[0].Name); ;
            }
            #endregion
        }

        /// <summary>
        /// Constructor�A�ק�ɨϥ�
        /// </summary>
        /// <param name="_demeritRecordEditor"></param>
        public MeritEditForm(K12.Data.MeritRecord meritRecordEditor, Framework.Security.FeatureAce permission)
        {
            #region �ק�
            this._meritRecordEditor = meritRecordEditor;

            #region Log��

            if (meritRecordEditor.MeritA.HasValue)
            {
                DicBeforeData.Add("�j�\", meritRecordEditor.MeritA.Value.ToString());
            }
            if (meritRecordEditor.MeritB.HasValue)
            {
                DicBeforeData.Add("�p�\", meritRecordEditor.MeritB.Value.ToString());
            }
            if (meritRecordEditor.MeritC.HasValue)
            {
                DicBeforeData.Add("�ż�", meritRecordEditor.MeritC.Value.ToString());
            }
            DicBeforeData.Add("�ƥ�", meritRecordEditor.Reason);

            DicBeforeData.Add("�Ƶ�", meritRecordEditor.Remark);
            #endregion

            this._students = new List<K12.Data.StudentRecord>();
            this._students.Add(K12.Data.Student.SelectByID(meritRecordEditor.RefStudentID));

            Initialize();

            if (permission.Editable)
                Text = string.Format("���y�޲z �i �ק�G{0}�A{1} �j", Student.Instance[meritRecordEditor.RefStudentID].Name, meritRecordEditor.OccurDate.ToShortDateString());
            else
                Text = string.Format("���y�޲z �i �˵��G{0}�A{1} �j", Student.Instance[meritRecordEditor.RefStudentID].Name, meritRecordEditor.OccurDate.ToShortDateString());

            btnSave.Visible = permission.Editable;
            cboReasonRef.Enabled = permission.Editable;
            intSchoolYear.Enabled = permission.Editable;
            intSemester.Enabled = permission.Editable;
            dateTimeInput1.Enabled = permission.Editable;
            dateTimeInput2.Enabled = permission.Editable;
            foreach (Control each in Controls)
            {
                if (each is DevComponents.DotNetBar.Controls.TextBoxX)
                    (each as DevComponents.DotNetBar.Controls.TextBoxX).ReadOnly = !permission.Editable;
            }
            #endregion
        }

        private void Initialize()
        {
            #region �غc�l
            InitializeComponent();

            _errorProvider = new ErrorProvider();

            //�Ǧ~��
            intSchoolYear.Value = int.Parse(K12.Data.School.DefaultSchoolYear);
            intSemester.Value = int.Parse(K12.Data.School.DefaultSemester);
            #endregion
        }

        private void MeritEditor_Load(object sender, EventArgs e)
        {
            #region Load

            List<string> remarkList = tool.GerRemarkTitle("1");
            cbRemark.Items.AddRange(remarkList.ToArray());

            //���o���y���N�X�M��]�M��A�é�� �ƥѥN�X ���U�Ԧ�������C
            DSResponse dsrsp = Config.GetDisciplineReasonList();
            cboReasonRef.SelectedItem = null;
            cboReasonRef.Items.Clear();
            DSXmlHelper helper = dsrsp.GetContent();
            KeyValuePair<string, string> fkvp = new KeyValuePair<string, string>("", "");
            cboReasonRef.Items.Add(fkvp);

            foreach (XmlElement element in helper.GetElements("Reason"))
            {
                if (element.GetAttribute("Type") == "���y")
                {
                    string k = element.GetAttribute("Code") + "-" + element.GetAttribute("Description");
                    string v = element.GetAttribute("Description");
                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(k, v);
                    cboReasonRef.Items.Add(kvp);

                    if (!ResonDic.ContainsKey("" + element.GetAttribute("Code")))
                    {
                        ResonDic.Add("" + element.GetAttribute("Code"), "" + element.GetAttribute("Description"));
                    }
                }
            }
            cboReasonRef.DisplayMember = "Key";
            cboReasonRef.ValueMember = "Value";
            cboReasonRef.SelectedIndex = 0;

            //�p�G�O�ק�Ҧ��A�h���ƶ��e���W�C
            if (this._meritRecordEditor != null)
            {
                txtReason.Text = _meritRecordEditor.Reason;
                txt1.Text = _meritRecordEditor.MeritA.ToString();
                txt2.Text = _meritRecordEditor.MeritB.ToString();
                txt3.Text = _meritRecordEditor.MeritC.ToString();
                intSchoolYear.Text = _meritRecordEditor.SchoolYear.ToString();
                intSemester.Text = _meritRecordEditor.Semester.ToString();

                dateTimeInput1.Value = _meritRecordEditor.OccurDate;

                if (_meritRecordEditor.RegisterDate != null)
                {
                    dateTimeInput2.Value = _meritRecordEditor.RegisterDate.Value;
                }
                else
                {
                    dateTimeInput2.Text = "";
                }
                cbRemark.Text = _meritRecordEditor.Remark;
            }
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //2023/3/14 - �W�[���ҨϥΪ̬O�_����J�ɶ�
            if (dateTimeInput1.Text == "0001/01/01 00:00:00" || dateTimeInput1.Text == "")
            {
                errorProvider1.SetError(dateTimeInput1, "�п�J�ɶ����");
                return;
            }
            else
            {
                errorProvider1.SetError(dateTimeInput1, "");
            }

            #region Save
            bool valid = true;
            foreach (Control control in this.Controls)
                if (!string.IsNullOrEmpty(_errorProvider.GetError(control)))
                    valid = false;

            if (!valid)
            {
                FISCA.Presentation.Controls.MsgBox.Show("������ҿ��~�A�Х��ץ���A���x�s");
                return;
            }

            //�ˬd�ϥΪ̬O�_�ѰO��J�\�L���ơC

            int sum = int.Parse(GetTextValue(txt1.Text)) + int.Parse(GetTextValue(txt2.Text)) + int.Parse(GetTextValue(txt3.Text));

            if (sum <= 0)
            {
                FISCA.Presentation.Controls.MsgBox.Show("�ЧO�ѤF��J�\�L���ơC");
                return;
            }

            if (txtReason.Text.Trim() == "")
            {
                DialogResult dr = FISCA.Presentation.Controls.MsgBox.Show("�ƥѥ���J�A�O�_�~��i���x�s�ާ@�H", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            //��������� + ���O��s�Ҧ� - 2013/11/25 - �����P�_
            //if (comboBoxEx1.SelectedIndex < 1 && _meritRecordEditor == null)
            //{
            //    DialogResult dr = FISCA.Presentation.Controls.MsgBox.Show("���������,�O�_�n�~��H", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
            //    if (dr == System.Windows.Forms.DialogResult.No)
            //    {
            //        return;
            //    }
            //}


            if (this._meritRecordEditor == null) //�s�W
            {

                List<K12.Data.MeritRecord> LogMeritList = new List<K12.Data.MeritRecord>();
                try
                {
                    LogMeritList = Insert();
                    K12.Data.Merit.Insert(LogMeritList);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("�s�W���y�O���ɵo�Ϳ��~: \n" + ex.Message);
                    return;
                }

                if (_students.Count == 1)
                {
                    #region �浧�s�WLog
                    StringBuilder sb = new StringBuilder();
                    sb.Append("�ǥ͡u" + LogMeritList[0].Student.Name + "�v");
                    sb.Append("����u" + LogMeritList[0].OccurDate.ToShortDateString() + "�v");
                    sb.AppendLine("�s�W�@�����y��ơC");
                    sb.AppendLine("�ԲӸ�ơG");
                    if (LogMeritList[0].MeritA.HasValue)
                    {
                        sb.Append("�j�\�u" + LogMeritList[0].MeritA.Value.ToString() + "�v");
                    }
                    if (LogMeritList[0].MeritB.HasValue)
                    {
                        sb.Append("�p�\�u" + LogMeritList[0].MeritB.Value.ToString() + "�v");
                    }
                    if (LogMeritList[0].MeritC.HasValue)
                    {
                        sb.AppendLine("�ż��u" + LogMeritList[0].MeritC.Value.ToString() + "�v");
                    }
                    sb.AppendLine("���y�ƥѡu" + LogMeritList[0].Reason + "�v");
                    sb.AppendLine("�Ƶ��u" + LogMeritList[0].Remark + "�v");
                    ApplicationLog.Log("�ǰȨt��.���y���", "�s�W�ǥͼ��y���", "student", _students[0].ID, sb.ToString());
                    #endregion
                    FISCA.Presentation.Controls.MsgBox.Show("�s�W���y��Ʀ��\!");
                }
                else if (_students.Count > 1)
                {
                    #region �妸�s�WLog
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("�妸�s�W���y���");
                    sb.AppendLine("����u" + LogMeritList[0].OccurDate.ToShortDateString() + "�v");
                    sb.AppendLine("�@�u" + LogMeritList.Count + "�v�W�ǥ͡A");
                    sb.AppendLine("�ԲӸ�ơG");
                    if (LogMeritList[0].MeritA.HasValue)
                    {
                        sb.Append("�j�\�u" + LogMeritList[0].MeritA.Value.ToString() + "�v");
                    }
                    if (LogMeritList[0].MeritB.HasValue)
                    {
                        sb.Append("�p�\�u" + LogMeritList[0].MeritB.Value.ToString() + "�v");
                    }
                    if (LogMeritList[0].MeritC.HasValue)
                    {
                        sb.AppendLine("�ż��u" + LogMeritList[0].MeritC.Value.ToString() + "�v");
                    }
                    sb.AppendLine("���y�ƥѡu" + LogMeritList[0].Reason + "�v");
                    sb.AppendLine("�Ƶ��u" + LogMeritList[0].Remark + "�v");
                    sb.AppendLine("�ǥ͸ԲӸ�ơG");
                    foreach (K12.Data.MeritRecord each in LogMeritList)
                    {
                        sb.Append("�ǥ͡u" + each.Student.Name + "�v");

                        if (each.Student.Class != null)
                        {
                            sb.Append("�Z�šu" + each.Student.Class.Name + "�v");
                        }
                        else
                        {
                            sb.Append("�Z�šu�v");
                        }

                        if (each.Student.SeatNo.HasValue)
                        {
                            sb.AppendLine("�y���u" + each.Student.SeatNo.Value.ToString() + "�v");
                        }
                        else
                        {
                            sb.AppendLine("�y���u�v");
                        }
                    }

                    ApplicationLog.Log("�ǰȨt��.���y���", "�妸�s�W�ǥͼ��y���", sb.ToString());
                    #endregion
                    FISCA.Presentation.Controls.MsgBox.Show("�妸�s�W���y��Ʀ��\!");
                }
            }
            else //�ק�
            {
                try
                {
                    Modify();
                    K12.Data.Merit.Update(this._meritRecordEditor);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("�ק���y�O���ɵo�Ϳ��~: \n" + ex.Message);
                    return;
                }

                #region �ק�Log
                StringBuilder sb = new StringBuilder();
                sb.Append("�ǥ͡u" + this._meritRecordEditor.Student.Name + "�v");
                sb.AppendLine("����u" + this._meritRecordEditor.OccurDate.ToShortDateString() + "�v���y��Ƥw�ק�C");
                sb.AppendLine("�ԲӸ�ơG");
                sb.AppendLine("�j�\�u" + DicBeforeData["�j�\"] + "�v�ܧ󬰡u" + this._meritRecordEditor.MeritA.Value + "�v");
                sb.AppendLine("�p�\�u" + DicBeforeData["�p�\"] + "�v�ܧ󬰡u" + this._meritRecordEditor.MeritB.Value + "�v");
                sb.AppendLine("�ż��u" + DicBeforeData["�ż�"] + "�v�ܧ󬰡u" + this._meritRecordEditor.MeritC.Value + "�v");
                sb.AppendLine("���y�ƥѡu" + DicBeforeData["�ƥ�"] + "�v�ܧ󬰡u" + this._meritRecordEditor.Reason + "�v");
                sb.AppendLine("�Ƶ��u" + DicBeforeData["�Ƶ�"] + "�v�ܧ󬰡u" + this._meritRecordEditor.Remark + "�v");
                ApplicationLog.Log("�ǰȨt��.���y���", "�ק�ǥͼ��y���", "student", this._meritRecordEditor.Student.ID, sb.ToString());
                #endregion
                FISCA.Presentation.Controls.MsgBox.Show("�ק���y��Ʀ��\!");
            }

            this.Close();
            #endregion
        }

        private void txt1_Validated(object sender, EventArgs e)
        {
            this.Text_Validate(this.txt1);
        }

        private void txt2_Validated(object sender, EventArgs e)
        {
            this.Text_Validate(this.txt2);
        }

        private void txt3_Validated(object sender, EventArgs e)
        {
            this.Text_Validate(this.txt3);
        }

        private void Text_Validate(DevComponents.DotNetBar.Controls.TextBoxX txt)
        {
            _errorProvider.SetError(txt, null);
            if (string.IsNullOrEmpty(txt.Text))
                return;
            int i = 0;
            if (!int.TryParse(txt.Text, out i))
                _errorProvider.SetError(txt, "��������ƼƦr");
            else
            {
                if (i < 0)
                    _errorProvider.SetError(txt, "�����J�t��");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboReasonRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, string> kvp = (KeyValuePair<string, string>)cboReasonRef.SelectedItem;
            txtReason.Text = kvp.Value;
        }

        private string GetTextValue(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "0";
            return text;
        }

        //private string chengDateTime(DateTime x)
        //{
        //    if (x == null)
        //        return "";
        //    string time = x.ToString();
        //    int y = time.IndexOf(' ');
        //    return time.Remove(y);
        //}

        private void Modify()
        {
            //��e������ƶ�^ MeritRecordEditor ����
            this.FillDataToEditor(this._meritRecordEditor);
        }

        private List<K12.Data.MeritRecord> Insert()
        {
            List<K12.Data.MeritRecord> newEditors = new List<K12.Data.MeritRecord>();

            //��Ҧ��ǥ͡A���ǳƦn������ MeritRecordEditor����
            foreach (K12.Data.StudentRecord sr in this._students)
            {
                K12.Data.MeritRecord dre = new K12.Data.MeritRecord();
                dre.RefStudentID = sr.ID;
                this.FillDataToEditor(dre);
                newEditors.Add(dre);
            }
            return newEditors;
        }

        //��e����ƶ�� Editor ���C�]���s�W�M�ק�Ҧ����|���o�ǵ{���X�A�Ҥw��X�Ӧ����@�Ө�ơA�H�קK�{���X���ơC
        private void FillDataToEditor(K12.Data.MeritRecord editor)
        {
            //��e������ƶ�^ MeritRecordEditor ����

            editor.SchoolYear = intSchoolYear.Value;
            editor.Semester = intSemester.Value;
            editor.MeritA = ChangeInt(txt1.Text);
            editor.MeritB = ChangeInt(txt2.Text);
            editor.MeritC = ChangeInt(txt3.Text);
            if (comboBoxEx1.SelectedIndex >= 1)
            {
                editor.Reason = "[" + comboBoxEx1.SelectedItem + "]" + txtReason.Text;
            }
            else
            {
                editor.Reason = txtReason.Text;
            }
            editor.Remark = cbRemark.Text;
            editor.OccurDate = dateTimeInput1.Value;
            if (dateTimeInput2.Text != "")
            {
                editor.RegisterDate = dateTimeInput2.Value;
            }
        }

        //�B�z��r��Ʀr
        private int ChangeInt(string txt)
        {
            int xParse;
            if (int.TryParse(txt, out xParse))
            {
                return xParse;
            }
            else
            {
                return 0;
            }
        }

        private void cboReasonRef_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReason.Focus();
                txtReason.Select(txtReason.Text.Length + 1, 0);
            }
        }

        private void txtReason_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string reasonValue = "";
                List<string> list = new List<string>();
                string[] reasonList = txtReason.Text.Split(',');
                foreach (string each in reasonList)
                {
                    string each1 = each.Replace("\r\n", "");
                    if (ResonDic.ContainsKey(each1))
                    {
                        list.Add(ResonDic[each1]);
                    }
                    else
                    {
                        list.Add(each1);
                    }
                }

                reasonValue = string.Join(",", list);

                txtReason.Text = reasonValue;
            }
        }
    }
}