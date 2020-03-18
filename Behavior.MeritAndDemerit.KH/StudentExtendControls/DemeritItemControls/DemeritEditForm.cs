using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using SmartSchool.StudentRelated.RibbonBars.AttendanceEditor;
using System.Xml;
using DevComponents.DotNetBar;
using SmartSchool.Common;
using Framework;
using JHSchool.Legacy;
using Framework.Feature;
using JHSchool.Behavior.Legacy;
using JHSchool.Behavior.Editor;
using FISCA.DSAUtil;
using JHSchool.Data;
using FISCA.LogAgent;
//using SmartSchool.ApplicationLog;

namespace JHSchool.Behavior.MeritAndDemerit_KH
{
    /// <summary>
    /// �s�W�έק��g�ٸ�ƪ��e���C
    /// �ק�ɡA�]���u��ק�@�Ӿǥͪ��Y�@�����g��ơA�ҥH�u�n�ǤJ�@�� DemeritRecordEditor ����Y�i
    /// �s�W�ɡA�i�H�P�ɹ�h��ǥͼW�[�ۦP���g�٬����A�ҥH�n�ǤJ�h��ǥͪ���ơA�����ǤJDemeritRecordEditor ����A������|�b�x�s�ɥѨC��ǥͰO�����o�C
    /// </summary>
    public partial class DemeritEditForm : FISCA.Presentation.Controls.BaseForm
    {
        private List<K12.Data.StudentRecord> _students;
        private ErrorProvider _errorProvider;
        private K12.Data.DemeritRecord _demeritRecordEditor;
        private Dictionary<string, string> dicReason = new Dictionary<string, string>();

        private Dictionary<string, string> ResonDic = new Dictionary<string, string>();

        //Log
        private Dictionary<string, string> DicBeforeData = new Dictionary<string, string>();

        /// <summary>
        /// Constructor�A�s�W�ɨϥΡC
        /// </summary>
        /// <param name="students"></param>
        public DemeritEditForm(List<K12.Data.StudentRecord> students)
        {
            #region �s�W
            this._students = students;
            Initialize();
            dateTimeInput1.Value = DateTime.Today;
            dateTimeInput2.Value = DateTime.Today;
            if (this._students.Count > 1)
            {
                Text = string.Format("�g�ٺ޲z �i �s�W�G{0} ... ���@ {1} �� �j", this._students[0].Name, this._students.Count.ToString()); ;
            }
            else if (this._students.Count == 1)
            {
                Text = string.Format("�g�ٺ޲z �i �s�W�G{0} �j", this._students[0].Name); ;
            }
            #endregion
        }

        public DemeritEditForm(List<K12.Data.StudentRecord> students, string SchoolYear, string Semester)
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
            if (this._students.Count > 1)
            {
                Text = string.Format("�g�ٺ޲z �i �s�W�G{0} ... ���@ {1} �� �j", this._students[0].Name, this._students.Count.ToString()); ;
            }
            else if (this._students.Count == 1)
            {
                Text = string.Format("�g�ٺ޲z �i �s�W�G{0} �j", this._students[0].Name); ;
            }
            #endregion
        }

        //�h���غc�l
        public DemeritEditForm(List<K12.Data.StudentRecord> students, string SchoolYear, string Semester, bool LockMode)
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
            if (this._students.Count > 1)
            {
                Text = string.Format("�g�ٺ޲z �i �s�W�G{0} ... ���@ {1} �� �j", this._students[0].Name, this._students.Count.ToString()); ;
            }
            else if (this._students.Count == 1)
            {
                Text = string.Format("�g�ٺ޲z �i �s�W�G{0} �j", this._students[0].Name); ;
            }
            #endregion
        }

        /// <summary>
        /// Constructor�A�ק�ɨϥ�
        /// </summary>
        /// <param name="_demeritRecordEditor"></param>
        public DemeritEditForm(K12.Data.DemeritRecord demeritRecordEditor, Framework.Security.FeatureAce permission)
        {
            #region �ק�
            this._demeritRecordEditor = demeritRecordEditor;

            #region Log��

            if (demeritRecordEditor.DemeritA.HasValue)
            {
                DicBeforeData.Add("�j�L", demeritRecordEditor.DemeritA.Value.ToString());
            }
            if (demeritRecordEditor.DemeritB.HasValue)
            {
                DicBeforeData.Add("�p�L", demeritRecordEditor.DemeritB.Value.ToString());
            }
            if (demeritRecordEditor.DemeritC.HasValue)
            {
                DicBeforeData.Add("ĵ�i", demeritRecordEditor.DemeritC.Value.ToString());
            }
            DicBeforeData.Add("�ƥ�", demeritRecordEditor.Reason);
            DicBeforeData.Add("�Ƶ�", demeritRecordEditor.Remark);
            #endregion

            this._students = new List<K12.Data.StudentRecord>();
            this._students.Add(K12.Data.Student.SelectByID(demeritRecordEditor.RefStudentID));

            Initialize();

            if (permission.Editable)
                Text = string.Format("�g�ٺ޲z �i �ק�G{0}�A{1} �j", K12.Data.Student.SelectByID(demeritRecordEditor.RefStudentID).Name, demeritRecordEditor.OccurDate.ToShortDateString());
            else
                Text = string.Format("�g�ٺ޲z �i �˵��G{0}�A{1} �j", K12.Data.Student.SelectByID(demeritRecordEditor.RefStudentID).Name, demeritRecordEditor.OccurDate.ToShortDateString());

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

        private void DemeritEditor_Load(object sender, EventArgs e)
        {
            #region Load


            //cbRemark

            List<string> remarkList = tool.GerRemarkTitle("0");
            cbRemark.Items.AddRange(remarkList.ToArray());

            //���o�g�٪��N�X�M��]�M��A�é�� �ƥѥN�X ���U�Ԧ�������C
            DSResponse dsrsp = Config.GetDisciplineReasonList();
            cboReasonRef.SelectedItem = null;
            cboReasonRef.Items.Clear();
            dicReason.Clear();
            DSXmlHelper helper = dsrsp.GetContent();
            KeyValuePair<string, string> fkvp = new KeyValuePair<string, string>("", "");
            cboReasonRef.Items.Add(fkvp);

            foreach (XmlElement element in helper.GetElements("Reason"))
            {
                if (element.GetAttribute("Type") == "�g��" || element.GetAttribute("Type") == "�g�|")
                {
                    dicReason.Add(element.GetAttribute("Code"), element.GetAttribute("Description"));
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
            if (this._demeritRecordEditor != null)
            {
                txtReason.Text = _demeritRecordEditor.Reason;
                txt1.Text = _demeritRecordEditor.DemeritA.ToString();
                txt2.Text = _demeritRecordEditor.DemeritB.ToString();
                txt3.Text = _demeritRecordEditor.DemeritC.ToString();
                dateTimeInput1.Value = _demeritRecordEditor.OccurDate;
                intSchoolYear.Text = _demeritRecordEditor.SchoolYear.ToString();
                intSemester.Text = _demeritRecordEditor.Semester.ToString();

                if (_demeritRecordEditor.RegisterDate.HasValue)
                {
                    int SetIndex = _demeritRecordEditor.RegisterDate.ToString().IndexOf(' ');
                    string SetRegisterDate = _demeritRecordEditor.RegisterDate.ToString().Remove(SetIndex);
                    dateTimeInput2.Value = _demeritRecordEditor.RegisterDate.Value;
                }
                else
                {
                    dateTimeInput2.Text = "";
                }

                cbRemark.Text = _demeritRecordEditor.Remark;
            }
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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

            if (this._demeritRecordEditor == null) //�s�W�g��
            {
                List<K12.Data.DemeritRecord> LogDemeritList = new List<K12.Data.DemeritRecord>();

                try
                {
                    LogDemeritList = Insert();
                    K12.Data.Demerit.Insert(LogDemeritList);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("�s�W�g�ٰO���ɵo�Ϳ��~: \n" + ex.Message);
                    return;
                }

                if (_students.Count == 1)
                {
                    #region �浧�s�WLog
                    StringBuilder sb = new StringBuilder();
                    sb.Append("�ǥ͡u" + LogDemeritList[0].Student.Name + "�v");
                    sb.Append("����u" + LogDemeritList[0].OccurDate.ToShortDateString() + "�v");
                    sb.AppendLine("�s�W�@���g�ٸ�ơC");
                    sb.AppendLine("�ԲӸ�ơG");
                    if (LogDemeritList[0].DemeritA.HasValue)
                    {
                        sb.Append("�j�L�u" + LogDemeritList[0].DemeritA.Value.ToString() + "�v");
                    }
                    if (LogDemeritList[0].DemeritB.HasValue)
                    {
                        sb.Append("�p�L�u" + LogDemeritList[0].DemeritB.Value.ToString() + "�v");
                    }
                    if (LogDemeritList[0].DemeritC.HasValue)
                    {
                        sb.AppendLine("ĵ�i�u" + LogDemeritList[0].DemeritC.Value.ToString() + "�v");
                    }
                    sb.AppendLine("�g�٨ƥѡu" + LogDemeritList[0].Reason + "�v");
                    sb.AppendLine("�Ƶ��u" + LogDemeritList[0].Remark + "�v");
                    ApplicationLog.Log("�ǰȨt��.�g�ٸ��", "�s�W�ǥ��g�ٸ��", "student", _students[0].ID, sb.ToString());
                    #endregion
                    FISCA.Presentation.Controls.MsgBox.Show("�s�W�g�ٸ�Ʀ��\!");
                }
                else if (_students.Count > 1)
                {
                    #region �妸�s�WLog
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("�妸�s�W�g�ٸ��");
                    sb.AppendLine("����u" + LogDemeritList[0].OccurDate.ToShortDateString() + "�v");
                    sb.AppendLine("�@�u" + LogDemeritList.Count + "�v�W�ǥ͡A");
                    sb.AppendLine("�ԲӸ�ơG");
                    if (LogDemeritList[0].DemeritA.HasValue)
                    {
                        sb.Append("�j�L�u" + LogDemeritList[0].DemeritB.Value.ToString() + "�v");
                    }
                    if (LogDemeritList[0].DemeritB.HasValue)
                    {
                        sb.Append("�p�L�u" + LogDemeritList[0].DemeritB.Value.ToString() + "�v");
                    }
                    if (LogDemeritList[0].DemeritC.HasValue)
                    {
                        sb.AppendLine("ĵ�i�u" + LogDemeritList[0].DemeritC.Value.ToString() + "�v");
                    }
                    sb.AppendLine("�g�٨ƥѡu" + LogDemeritList[0].Reason + "�v");
                    sb.AppendLine("�Ƶ��u" + LogDemeritList[0].Remark + "�v");

                    sb.AppendLine("�ǥ͸ԲӸ�ơG");
                    foreach (K12.Data.DemeritRecord each in LogDemeritList)
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

                    ApplicationLog.Log("�ǰȨt��.�g�ٸ��", "�妸�s�W�ǥ��g�ٸ��", sb.ToString());
                    #endregion
                    FISCA.Presentation.Controls.MsgBox.Show("�妸�s�W�g�ٸ�Ʀ��\!");
                }
            }
            else
            {
                try
                {
                    Modify();
                    K12.Data.Demerit.Update(this._demeritRecordEditor);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("�ק��g�ٰO���ɵo�Ϳ��~: \n" + ex.Message);
                }

                #region �ק�Log
                StringBuilder sb = new StringBuilder();
                sb.Append("�ǥ͡u" + this._demeritRecordEditor.Student.Name + "�v");
                sb.AppendLine("����u" + this._demeritRecordEditor.OccurDate.ToShortDateString() + "�v�g�ٸ�Ƥw�ק�C");
                sb.AppendLine("�ԲӸ�ơG");
                sb.AppendLine("�j�L�u" + DicBeforeData["�j�L"] + "�v�ܧ󬰡u" + this._demeritRecordEditor.DemeritA.Value + "�v");
                sb.AppendLine("�p�L�u" + DicBeforeData["�p�L"] + "�v�ܧ󬰡u" + this._demeritRecordEditor.DemeritB.Value + "�v");
                sb.AppendLine("ĵ�i�u" + DicBeforeData["ĵ�i"] + "�v�ܧ󬰡u" + this._demeritRecordEditor.DemeritC.Value + "�v");
                sb.AppendLine("�g�٨ƥѡu" + DicBeforeData["�ƥ�"] + "�v�ܧ󬰡u" + this._demeritRecordEditor.Reason + "�v");
                sb.AppendLine("�Ƶ��u" + DicBeforeData["�Ƶ�"] + "�v�ܧ󬰡u" + this._demeritRecordEditor.Remark + "�v");
                ApplicationLog.Log("�ǰȨt��.�g�ٸ��", "�ק�ǥ��g�ٸ��", "student", this._demeritRecordEditor.Student.ID, sb.ToString());
                #endregion
                FISCA.Presentation.Controls.MsgBox.Show("�ק��g�ٸ�Ʀ��\!");
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

        //�NTextBox�������ʧ@�X����@�B�z�{��
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

        //�e�����}
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //�ƥѱ���b�Q���ܮ�
        private void cboReasonRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReasonRef.SelectedItem == null) return;
            KeyValuePair<string, string> kvp = (KeyValuePair<string, string>)cboReasonRef.SelectedItem;
            txtReason.Text = kvp.Value;
        }

        private string GetTextValue(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "0";
            return text;
        }

        private void Modify()
        {
            //��e������ƶ�^ DemeritRecordEditor ����
            this.FillDataToEditor(this._demeritRecordEditor);
        }

        private List<K12.Data.DemeritRecord> Insert()
        {
            List<K12.Data.DemeritRecord> newEditors = new List<K12.Data.DemeritRecord>();

            //��Ҧ��ǥ͡A���ǳƦn������ DemeritRecordEditor����
            foreach (K12.Data.StudentRecord sr in this._students)
            {
                K12.Data.DemeritRecord dre = new K12.Data.DemeritRecord();
                dre.RefStudentID = sr.ID;
                this.FillDataToEditor(dre);
                newEditors.Add(dre);
            }

            return newEditors;

        }

        //��e����ƶ�� Editor ���C
        private void FillDataToEditor(K12.Data.DemeritRecord editor)
        {
            #region ��e����ƶ�� Editor ��
            //��e������ƶ�^ DemeritRecordEditor ����
            editor.SchoolYear = intSchoolYear.Value;
            editor.Semester = intSemester.Value;
            editor.DemeritA = ChangeInt(txt1.Text);
            editor.DemeritB = ChangeInt(txt2.Text);
            editor.DemeritC = ChangeInt(txt3.Text);
            editor.Reason = txtReason.Text;
            editor.Remark = cbRemark.Text;
            editor.OccurDate = dateTimeInput1.Value;
            if (dateTimeInput2.Text != "")
            {
                editor.RegisterDate = dateTimeInput2.Value;
            }
            #endregion
        }

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