﻿namespace JHSchool.Behavior.MeritAndDemerit_KH
{
    partial class DisciplineUnifytForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDemeritClear = new DevComponents.DotNetBar.ButtonX();
            this.dgvDemerit = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listViewDemerit = new JHSchool.Behavior.Legacy.ListViewEx();
            this.CHBDemeritDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHBDEmeritA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHBDEmeritB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHBDEmeritC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHBReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHBCleared = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHBClearedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHBClearedReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHBRegisterDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarkDemerit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDemeritDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnDemeritEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.btnDemeritNew = new DevComponents.DotNetBar.ButtonX();
            this.btnExitAll = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveDemeritStatistics = new DevComponents.DotNetBar.ButtonX();
            this.lbHelp3 = new DevComponents.DotNetBar.LabelX();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lbHelp2 = new DevComponents.DotNetBar.LabelX();
            this.dgvMerit = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveMeritStatistics = new DevComponents.DotNetBar.ButtonX();
            this.listViewMerit = new JHSchool.Behavior.Legacy.ListViewEx();
            this.CHAMeritDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHAMeritA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHAMeritB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHAMeritC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHAReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHARegisterDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarkMerit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnMeritNew = new DevComponents.DotNetBar.ButtonX();
            this.btnMeritDelete = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.btnMeritEdit = new DevComponents.DotNetBar.ButtonX();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.lbHelp1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemerit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDemeritClear
            // 
            this.btnDemeritClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDemeritClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDemeritClear.BackColor = System.Drawing.Color.Transparent;
            this.btnDemeritClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDemeritClear.Enabled = false;
            this.btnDemeritClear.Location = new System.Drawing.Point(181, 221);
            this.btnDemeritClear.Name = "btnDemeritClear";
            this.btnDemeritClear.Size = new System.Drawing.Size(75, 23);
            this.btnDemeritClear.TabIndex = 3;
            this.btnDemeritClear.Text = "銷過作業";
            this.btnDemeritClear.Click += new System.EventHandler(this.btnDemeritClear_Click);
            // 
            // dgvDemerit
            // 
            this.dgvDemerit.AllowUserToAddRows = false;
            this.dgvDemerit.AllowUserToDeleteRows = false;
            this.dgvDemerit.AllowUserToResizeRows = false;
            this.dgvDemerit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDemerit.BackgroundColor = System.Drawing.Color.White;
            this.dgvDemerit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDemerit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDemerit.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDemerit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDemerit.Location = new System.Drawing.Point(18, 262);
            this.dgvDemerit.Name = "dgvDemerit";
            this.dgvDemerit.RowHeadersVisible = false;
            this.dgvDemerit.RowTemplate.Height = 24;
            this.dgvDemerit.Size = new System.Drawing.Size(543, 120);
            this.dgvDemerit.TabIndex = 0;
            this.dgvDemerit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDemerit_CellEndEdit);
            this.dgvDemerit.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDemerit_CurrentCellDirtyStateChanged);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "統計類型";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "大過";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 140;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "小過";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "警告";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 140;
            // 
            // listViewDemerit
            // 
            this.listViewDemerit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listViewDemerit.Border.Class = "ListViewBorder";
            this.listViewDemerit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewDemerit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHBDemeritDate,
            this.CHBDEmeritA,
            this.CHBDEmeritB,
            this.CHBDEmeritC,
            this.CHBReason,
            this.CHBCleared,
            this.CHBClearedDate,
            this.CHBClearedReason,
            this.CHBRegisterDate,
            this.colRemarkDemerit});
            this.listViewDemerit.FullRowSelect = true;
            this.listViewDemerit.HideSelection = false;
            this.listViewDemerit.Location = new System.Drawing.Point(18, 17);
            this.listViewDemerit.Name = "listViewDemerit";
            this.listViewDemerit.Size = new System.Drawing.Size(543, 198);
            this.listViewDemerit.TabIndex = 0;
            this.listViewDemerit.UseCompatibleStateImageBehavior = false;
            this.listViewDemerit.View = System.Windows.Forms.View.Details;
            this.listViewDemerit.SelectedIndexChanged += new System.EventHandler(this.listViewDemerit_SelectedIndexChanged);
            this.listViewDemerit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewDemerit_MouseDoubleClick);
            // 
            // CHBDemeritDate
            // 
            this.CHBDemeritDate.Text = "懲戒日期";
            this.CHBDemeritDate.Width = 110;
            // 
            // CHBDEmeritA
            // 
            this.CHBDEmeritA.Text = "大過";
            this.CHBDEmeritA.Width = 48;
            // 
            // CHBDEmeritB
            // 
            this.CHBDEmeritB.Text = "小過";
            this.CHBDEmeritB.Width = 49;
            // 
            // CHBDEmeritC
            // 
            this.CHBDEmeritC.Text = "警告";
            this.CHBDEmeritC.Width = 48;
            // 
            // CHBReason
            // 
            this.CHBReason.Text = "事由";
            this.CHBReason.Width = 140;
            // 
            // CHBCleared
            // 
            this.CHBCleared.Text = "銷過";
            this.CHBCleared.Width = 48;
            // 
            // CHBClearedDate
            // 
            this.CHBClearedDate.Text = "銷過日期";
            this.CHBClearedDate.Width = 90;
            // 
            // CHBClearedReason
            // 
            this.CHBClearedReason.Text = "銷過事由";
            this.CHBClearedReason.Width = 120;
            // 
            // CHBRegisterDate
            // 
            this.CHBRegisterDate.Text = "登錄日期";
            this.CHBRegisterDate.Width = 100;
            // 
            // colRemarkDemerit
            // 
            this.colRemarkDemerit.Text = "備註";
            this.colRemarkDemerit.Width = 100;
            // 
            // btnDemeritDelete
            // 
            this.btnDemeritDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDemeritDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDemeritDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDemeritDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDemeritDelete.Location = new System.Drawing.Point(262, 221);
            this.btnDemeritDelete.Name = "btnDemeritDelete";
            this.btnDemeritDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDemeritDelete.TabIndex = 4;
            this.btnDemeritDelete.Text = "刪除懲戒";
            this.btnDemeritDelete.Click += new System.EventHandler(this.btnDemeritDelete_Click);
            // 
            // btnDemeritEdit
            // 
            this.btnDemeritEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDemeritEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDemeritEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnDemeritEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDemeritEdit.Location = new System.Drawing.Point(100, 221);
            this.btnDemeritEdit.Name = "btnDemeritEdit";
            this.btnDemeritEdit.Size = new System.Drawing.Size(75, 23);
            this.btnDemeritEdit.TabIndex = 2;
            this.btnDemeritEdit.Text = "修改懲戒";
            this.btnDemeritEdit.Click += new System.EventHandler(this.btnDemeritEdit_Click);
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnView.BackColor = System.Drawing.Color.Transparent;
            this.btnView.Location = new System.Drawing.Point(19, 221);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "檢視";
            // 
            // btnDemeritNew
            // 
            this.btnDemeritNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDemeritNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDemeritNew.BackColor = System.Drawing.Color.Transparent;
            this.btnDemeritNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDemeritNew.Location = new System.Drawing.Point(19, 221);
            this.btnDemeritNew.Name = "btnDemeritNew";
            this.btnDemeritNew.Size = new System.Drawing.Size(75, 23);
            this.btnDemeritNew.TabIndex = 1;
            this.btnDemeritNew.Text = "新增懲戒";
            this.btnDemeritNew.Click += new System.EventHandler(this.btnDemeritNew_Click);
            // 
            // btnExitAll
            // 
            this.btnExitAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExitAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitAll.BackColor = System.Drawing.Color.Transparent;
            this.btnExitAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExitAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExitAll.Location = new System.Drawing.Point(483, 503);
            this.btnExitAll.Name = "btnExitAll";
            this.btnExitAll.Size = new System.Drawing.Size(103, 23);
            this.btnExitAll.TabIndex = 0;
            this.btnExitAll.Text = "離開";
            this.btnExitAll.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveDemeritStatistics
            // 
            this.btnSaveDemeritStatistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveDemeritStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveDemeritStatistics.AutoSize = true;
            this.btnSaveDemeritStatistics.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveDemeritStatistics.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveDemeritStatistics.Location = new System.Drawing.Point(19, 390);
            this.btnSaveDemeritStatistics.Name = "btnSaveDemeritStatistics";
            this.btnSaveDemeritStatistics.Size = new System.Drawing.Size(158, 25);
            this.btnSaveDemeritStatistics.TabIndex = 1;
            this.btnSaveDemeritStatistics.Text = "儲存懲戒手動調整統計值";
            this.btnSaveDemeritStatistics.Click += new System.EventHandler(this.btnSaveDemeritStatistics_Click);
            // 
            // lbHelp3
            // 
            this.lbHelp3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbHelp3.AutoSize = true;
            this.lbHelp3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbHelp3.BackgroundStyle.Class = "";
            this.lbHelp3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbHelp3.Location = new System.Drawing.Point(188, 392);
            this.lbHelp3.Name = "lbHelp3";
            this.lbHelp3.Size = new System.Drawing.Size(181, 21);
            this.lbHelp3.TabIndex = 2;
            this.lbHelp3.Text = "說明：白色欄位為可調整內容";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Location = new System.Drawing.Point(7, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 462);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.lbHelp3);
            this.tabControlPanel2.Controls.Add(this.listViewDemerit);
            this.tabControlPanel2.Controls.Add(this.dgvDemerit);
            this.tabControlPanel2.Controls.Add(this.btnSaveDemeritStatistics);
            this.tabControlPanel2.Controls.Add(this.btnDemeritClear);
            this.tabControlPanel2.Controls.Add(this.btnDemeritNew);
            this.tabControlPanel2.Controls.Add(this.btnDemeritDelete);
            this.tabControlPanel2.Controls.Add(this.btnDemeritEdit);
            this.tabControlPanel2.Controls.Add(this.btnView);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 29);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(579, 433);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 0;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "懲戒";
            this.tabItem2.TextColor = System.Drawing.Color.Red;
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.listViewMerit);
            this.tabControlPanel1.Controls.Add(this.btnMeritNew);
            this.tabControlPanel1.Controls.Add(this.lbHelp2);
            this.tabControlPanel1.Controls.Add(this.btnMeritDelete);
            this.tabControlPanel1.Controls.Add(this.dgvMerit);
            this.tabControlPanel1.Controls.Add(this.buttonX4);
            this.tabControlPanel1.Controls.Add(this.btnSaveMeritStatistics);
            this.tabControlPanel1.Controls.Add(this.btnMeritEdit);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 29);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(579, 433);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 0;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // lbHelp2
            // 
            this.lbHelp2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbHelp2.AutoSize = true;
            this.lbHelp2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbHelp2.BackgroundStyle.Class = "";
            this.lbHelp2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbHelp2.Location = new System.Drawing.Point(188, 391);
            this.lbHelp2.Name = "lbHelp2";
            this.lbHelp2.Size = new System.Drawing.Size(181, 21);
            this.lbHelp2.TabIndex = 2;
            this.lbHelp2.Text = "說明：白色欄位為可調整內容";
            // 
            // dgvMerit
            // 
            this.dgvMerit.AllowUserToAddRows = false;
            this.dgvMerit.AllowUserToDeleteRows = false;
            this.dgvMerit.AllowUserToResizeRows = false;
            this.dgvMerit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMerit.BackgroundColor = System.Drawing.Color.White;
            this.dgvMerit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMerit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMerit.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMerit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvMerit.Location = new System.Drawing.Point(18, 261);
            this.dgvMerit.Name = "dgvMerit";
            this.dgvMerit.RowHeadersVisible = false;
            this.dgvMerit.RowTemplate.Height = 24;
            this.dgvMerit.Size = new System.Drawing.Size(543, 120);
            this.dgvMerit.TabIndex = 0;
            this.dgvMerit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerit_CellEndEdit);
            this.dgvMerit.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvMerit_CurrentCellDirtyStateChanged);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "統計類型";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "大功";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "小功";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "嘉獎";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // btnSaveMeritStatistics
            // 
            this.btnSaveMeritStatistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveMeritStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveMeritStatistics.AutoSize = true;
            this.btnSaveMeritStatistics.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveMeritStatistics.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveMeritStatistics.Location = new System.Drawing.Point(19, 389);
            this.btnSaveMeritStatistics.Name = "btnSaveMeritStatistics";
            this.btnSaveMeritStatistics.Size = new System.Drawing.Size(158, 25);
            this.btnSaveMeritStatistics.TabIndex = 1;
            this.btnSaveMeritStatistics.Text = "儲存獎勵手動調整統計值";
            this.btnSaveMeritStatistics.Click += new System.EventHandler(this.btnSaveMeritStatistics_Click);
            // 
            // listViewMerit
            // 
            this.listViewMerit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listViewMerit.Border.Class = "ListViewBorder";
            this.listViewMerit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewMerit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHAMeritDate,
            this.CHAMeritA,
            this.CHAMeritB,
            this.CHAMeritC,
            this.CHAReason,
            this.CHARegisterDate,
            this.colRemarkMerit});
            this.listViewMerit.FullRowSelect = true;
            this.listViewMerit.HideSelection = false;
            this.listViewMerit.Location = new System.Drawing.Point(17, 18);
            this.listViewMerit.Name = "listViewMerit";
            this.listViewMerit.Size = new System.Drawing.Size(543, 197);
            this.listViewMerit.TabIndex = 0;
            this.listViewMerit.UseCompatibleStateImageBehavior = false;
            this.listViewMerit.View = System.Windows.Forms.View.Details;
            this.listViewMerit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMerit_MouseDoubleClick);
            // 
            // CHAMeritDate
            // 
            this.CHAMeritDate.Text = "獎勵日期";
            this.CHAMeritDate.Width = 110;
            // 
            // CHAMeritA
            // 
            this.CHAMeritA.Text = "大功";
            this.CHAMeritA.Width = 48;
            // 
            // CHAMeritB
            // 
            this.CHAMeritB.Text = "小功";
            this.CHAMeritB.Width = 49;
            // 
            // CHAMeritC
            // 
            this.CHAMeritC.Text = "嘉獎";
            this.CHAMeritC.Width = 48;
            // 
            // CHAReason
            // 
            this.CHAReason.Text = "事由";
            this.CHAReason.Width = 140;
            // 
            // CHARegisterDate
            // 
            this.CHARegisterDate.Text = "登錄日期";
            this.CHARegisterDate.Width = 130;
            // 
            // colRemarkMerit
            // 
            this.colRemarkMerit.Text = "備註";
            this.colRemarkMerit.Width = 100;
            // 
            // btnMeritNew
            // 
            this.btnMeritNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMeritNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMeritNew.BackColor = System.Drawing.Color.Transparent;
            this.btnMeritNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMeritNew.Location = new System.Drawing.Point(19, 221);
            this.btnMeritNew.Name = "btnMeritNew";
            this.btnMeritNew.Size = new System.Drawing.Size(75, 23);
            this.btnMeritNew.TabIndex = 1;
            this.btnMeritNew.Text = "新增獎勵";
            this.btnMeritNew.Click += new System.EventHandler(this.btnMeritNew_Click);
            // 
            // btnMeritDelete
            // 
            this.btnMeritDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMeritDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMeritDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnMeritDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMeritDelete.Location = new System.Drawing.Point(181, 221);
            this.btnMeritDelete.Name = "btnMeritDelete";
            this.btnMeritDelete.Size = new System.Drawing.Size(75, 23);
            this.btnMeritDelete.TabIndex = 3;
            this.btnMeritDelete.Text = "刪除獎勵";
            this.btnMeritDelete.Click += new System.EventHandler(this.btnMeritDelete_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonX4.BackColor = System.Drawing.Color.Transparent;
            this.buttonX4.Location = new System.Drawing.Point(19, 221);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(75, 23);
            this.buttonX4.TabIndex = 5;
            this.buttonX4.Text = "檢視";
            // 
            // btnMeritEdit
            // 
            this.btnMeritEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMeritEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMeritEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnMeritEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMeritEdit.Location = new System.Drawing.Point(100, 221);
            this.btnMeritEdit.Name = "btnMeritEdit";
            this.btnMeritEdit.Size = new System.Drawing.Size(75, 23);
            this.btnMeritEdit.TabIndex = 2;
            this.btnMeritEdit.Text = "修改獎勵";
            this.btnMeritEdit.Click += new System.EventHandler(this.btnMeritEdit_Click);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "獎勵";
            this.tabItem1.TextColor = System.Drawing.Color.Blue;
            // 
            // lbHelp1
            // 
            this.lbHelp1.AutoSize = true;
            this.lbHelp1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbHelp1.BackgroundStyle.Class = "";
            this.lbHelp1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbHelp1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbHelp1.Location = new System.Drawing.Point(7, 4);
            this.lbHelp1.Name = "lbHelp1";
            this.lbHelp1.Size = new System.Drawing.Size(82, 26);
            this.lbHelp1.TabIndex = 0;
            this.lbHelp1.Text = "基本說明..";
            // 
            // DisciplineUnifytForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 532);
            this.Controls.Add(this.lbHelp1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExitAll);
            this.DoubleBuffered = true;
            this.MaximizeBox = true;
            this.Name = "DisciplineUnifytForm";
            this.Text = "獎勵 / 懲戒學期統計";
            this.Load += new System.EventHandler(this.DemeritUnifytForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemerit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnDemeritClear;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDemerit;
        private JHSchool.Behavior.Legacy.ListViewEx listViewDemerit;
        private System.Windows.Forms.ColumnHeader CHBDemeritDate;
        private System.Windows.Forms.ColumnHeader CHBDEmeritA;
        private System.Windows.Forms.ColumnHeader CHBDEmeritB;
        private System.Windows.Forms.ColumnHeader CHBDEmeritC;
        private System.Windows.Forms.ColumnHeader CHBReason;
        private System.Windows.Forms.ColumnHeader CHBCleared;
        private System.Windows.Forms.ColumnHeader CHBClearedDate;
        private System.Windows.Forms.ColumnHeader CHBClearedReason;
        private System.Windows.Forms.ColumnHeader CHBRegisterDate;
        private DevComponents.DotNetBar.ButtonX btnDemeritDelete;
        private DevComponents.DotNetBar.ButtonX btnDemeritEdit;
        private DevComponents.DotNetBar.ButtonX btnView;
        private DevComponents.DotNetBar.ButtonX btnDemeritNew;
        private DevComponents.DotNetBar.ButtonX btnExitAll;
        private DevComponents.DotNetBar.ButtonX btnSaveDemeritStatistics;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMerit;
        private DevComponents.DotNetBar.ButtonX btnSaveMeritStatistics;
        private JHSchool.Behavior.Legacy.ListViewEx listViewMerit;
        private System.Windows.Forms.ColumnHeader CHAMeritDate;
        private System.Windows.Forms.ColumnHeader CHAMeritA;
        private System.Windows.Forms.ColumnHeader CHAMeritB;
        private System.Windows.Forms.ColumnHeader CHAMeritC;
        private System.Windows.Forms.ColumnHeader CHAReason;
        private System.Windows.Forms.ColumnHeader CHARegisterDate;
        private DevComponents.DotNetBar.ButtonX btnMeritNew;
        private DevComponents.DotNetBar.ButtonX btnMeritDelete;
        private DevComponents.DotNetBar.ButtonX btnMeritEdit;
        private DevComponents.DotNetBar.LabelX lbHelp2;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.LabelX lbHelp1;
        private DevComponents.DotNetBar.LabelX lbHelp3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ColumnHeader colRemarkDemerit;
        private System.Windows.Forms.ColumnHeader colRemarkMerit;
    }
}