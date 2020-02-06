using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevComponents.DotNetBar;
using Framework;
using Framework.Security;
//using SmartSchool.ApplicationLog;
//using SmartSchool.AccessControl;

using JHSchool.Behavior.Editor;
using FCode = Framework.Security.FeatureCodeAttribute;
using JHSchool.Data;
using FISCA.LogAgent;

namespace JHSchool.Behavior.MeritAndDemerit_KH
{
    //[FeatureCode("Content0070")]
    [FCode("JHSchool.Student.Detail0030", "���y�O��")]
    internal partial class MeritItem : DetailContentBase
    {

        //public static string FeatureCode = (Attribute.GetCustomAttribute(typeof(MeritItem), typeof(FeatureCodeAttribute)) as FeatureCodeAttribute).FeatureCode;
        //private FeatureAce _permission;

        internal static FeatureAce UserPermission;
        private List<K12.Data.MeritRecord> _records = new List<K12.Data.MeritRecord>();

        BackgroundWorker BgW = new BackgroundWorker();
        bool BkWBool = false;

        public MeritItem()
        {
            InitializeComponent();

            BgW.DoWork += new DoWorkEventHandler(BkW_DoWork);
            BgW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BkW_RunWorkerCompleted);

            K12.Data.Merit.AfterInsert += new EventHandler<K12.Data.DataChangedEventArgs>(JHMerit_Changed);
            K12.Data.Merit.AfterDelete += new EventHandler<K12.Data.DataChangedEventArgs>(JHMerit_Changed);
            K12.Data.Merit.AfterUpdate += new EventHandler<K12.Data.DataChangedEventArgs>(JHMerit_Changed);

            //�ȸѪk
            Merit.Instance.ItemUpdated += new EventHandler<ItemUpdatedEventArgs>(Instance_ItemUpdated);

            //Merit.Instance.ItemUpdated += new EventHandler<ItemUpdatedEventArgs>(this.refreshUIData); //�� Cache Manager ������Ʀ��Q��s�ɴN���s��s�e���C

            this.Group = "���y�O��";    //�]�w�������ܪ� Title �A�p���]�w�|�� Exception�C

            UserPermission = User.Acl[FCode.GetCode(GetType())];

            btnInsert.Visible = UserPermission.Editable;
            btnUpdate.Visible = UserPermission.Editable;
            btnDelete.Visible = UserPermission.Editable;
            btnView.Visible = UserPermission.Viewable & !UserPermission.Editable;
        }

        //�ȸѪk
        void Instance_ItemUpdated(object sender, ItemUpdatedEventArgs e)
        {
            if (!BgW.IsBusy)
                BgW.RunWorkerAsync();
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
                    if (!BgW.IsBusy)
                        BgW.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// ��D�e���˵����P�ǥͮɡA������δN�Q���w�s���ǥ�ID�A�N�|�I�s����k�C
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            //this.Loading = true;    //�e���|�e�{��ƤU���������A(���@����)
            //Merit.Instance.SyncDataBackground(this.PrimaryKey);   //SyncDataBackground ��k��|Ĳ�o Demerit.Instance.ItemUpdateed �ƥ�

            this.Loading = true;

            if (BgW.IsBusy)
            {
                BkWBool = true;
            }
            else
            {
                BgW.RunWorkerAsync();
            }
        }

        void BkW_DoWork(object sender, DoWorkEventArgs e)
        {
            _records.Clear();
            _records = K12.Data.Merit.SelectByStudentIDs(new string[] { this.PrimaryKey });
        }

        void BkW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (BkWBool)
            {
                BkWBool = false;
                BgW.RunWorkerAsync();
                return;
            }

            refreshUIData();

            this.Loading = false;
        }

        private void refreshUIData()
        {
            if (!this.SaveButtonVisible && !this.CancelButtonVisible && this.PrimaryKey.Contains(PrimaryKey))
            {
                //�qCache Manager ���Ӿǥͪ��g�ٰO���A�ç�s��e���W�C
                this.listView.Items.Clear();

                _records.Sort(new Comparison<K12.Data.MeritRecord>(SchoolYearComparer));

                foreach (K12.Data.MeritRecord item in _records)
                {
                    #region ���

                    ListViewItem itm = new ListViewItem(item.SchoolYear.ToString());
                    itm.SubItems.Add(item.Semester.ToString());
                    itm.SubItems.Add(item.OccurDate.ToShortDateString());
                    itm.SubItems.Add(item.MeritA.ToString());
                    itm.SubItems.Add(item.MeritB.ToString());
                    itm.SubItems.Add(item.MeritC.ToString());
                    itm.SubItems.Add(item.Reason);
                    itm.SubItems.Add(item.RegisterDate.HasValue ? item.RegisterDate.Value.ToShortDateString() : "");
                    itm.SubItems.Add(item.Remark);

                    //�N��ƥ[�JListView
                    itm.Tag = item;
                    listView.Items.Add(itm);
                    #endregion

                }
                //this.Loading = false;
                this.CancelButtonVisible = false;
                this.SaveButtonVisible = false;
                this.ContentValidated = true;
            }

            this.Loading = false;   //�e���N�^�и�Ƥw�U���������e��
        }

        //private string chengDateTime(DateTime x)
        //{
        //    if (x == null)
        //        return "";
        //    string time = x.ToString();
        //    int y = time.IndexOf(' ');
        //    return time.Remove(y);
        //}

        private void btnInsert_Click(object sender, EventArgs e)
        {
            List<K12.Data.StudentRecord> studs = new List<K12.Data.StudentRecord>();
            studs.Add(K12.Data.Student.SelectByID(this.PrimaryKey));
            MeritEditForm editForm = new MeritEditForm(studs);  //���s����b�s�W�Ҧ��U���\�@����h��ǥͷs�W�ۦP���g�ٰO���A�ҥH Constructor �n�ǤJ�ǥͪ����X�C
            editForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MsgBox.Show("�Х���ܤ@���z�n�ק諸���");
                return;
            }
            if (listView.SelectedItems.Count > 1)
            {
                MsgBox.Show("��ܸ�Ƶ��ƹL�h�A�@���u��ק�@�����");
                return;
            }

            K12.Data.MeritRecord record = (K12.Data.MeritRecord)this.listView.SelectedItems[0].Tag;
            MeritEditForm editForm = new MeritEditForm(record, UserPermission); //���s����b�ק�Ҧ��U�A�@���u���@��ǥͪ��Y�@���g�ٰO���i��ק�A�ҥH Constructor �N�ǤJ�@�� Editor ����C
            editForm.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MsgBox.Show("������ܤ@���H�W���!!");
                return;
            }

            List<K12.Data.MeritRecord> MeritList = new List<K12.Data.MeritRecord>();

            if (MsgBox.Show("�T�w�N�R���ҿ�ܤ����y���?", "�T�{", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            foreach (ListViewItem item in listView.SelectedItems)
            {
                K12.Data.MeritRecord editor = item.Tag as K12.Data.MeritRecord;
                MeritList.Add(editor);
            }

            try
            {
                K12.Data.Merit.Delete(MeritList);
            }
            catch (Exception ex)
            {
                MsgBox.Show("�R�����y��ƥ���!" + ex.Message);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("�ǥ͡u" + JHStudent.SelectByID(this.PrimaryKey).Name + "�v");
            foreach (K12.Data.MeritRecord me in MeritList)
            {
                sb.AppendLine("����u" + me.OccurDate.ToShortDateString() + "�v");
            }
            sb.AppendLine("���y��Ƥw�Q�R���C");

            ApplicationLog.Log("�ǰȨt��.���y���", "�R���ǥͼ��y���", "student", this.PrimaryKey, sb.ToString());
            
            MsgBox.Show("�R�����y��Ʀ��\");
        }

        private int SchoolYearComparer(K12.Data.MeritRecord x, K12.Data.MeritRecord y)
        {
            return y.OccurDate.CompareTo(x.OccurDate);
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                MeritEditForm editor = new MeritEditForm(listView.SelectedItems[0].Tag as K12.Data.MeritRecord, UserPermission);
                editor.ShowDialog();
            }
        }
    }
}