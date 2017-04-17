namespace XPump.SubForm
{
    partial class FormTankConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.btnInquiryAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInquiryRest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.dtStartDate = new CC.XDatePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.xTextEdit1 = new CC.XTextEdit();
            this.dgvTank = new CC.XDatagrid();
            this.btnDeleteTank = new System.Windows.Forms.Button();
            this.btnEditTank = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddTank = new System.Windows.Forms.Button();
            this.dgvSection = new CC.XDatagrid();
            this.btnDeleteSection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEditSection = new System.Windows.Forms.Button();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.xTextEdit2 = new CC.XTextEdit();
            this.btnItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnTank = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSection = new System.Windows.Forms.ToolStripMenuItem();
            this.col_tank_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_startdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_tanksetup_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_tanksetup_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_tank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank__isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSection)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator3,
            this.btnStop,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnFirst,
            this.btnPrevious,
            this.btnNext,
            this.btnLast,
            this.toolStripSeparator2,
            this.btnSearch,
            this.toolStripSeparator4,
            this.btnItem,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(888, 43);
            this.toolStrip1.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::XPump.Properties.Resources.add;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 40);
            this.btnAdd.Text = "เพิ่มข้อมูล <Alt+A>";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit;
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(36, 40);
            this.btnEdit.Text = "แก้ไขข้อมูล <Alt+E>";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::XPump.Properties.Resources.trash;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(36, 40);
            this.btnDelete.Text = "ลบข้อมูล <Alt+D>";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            this.btnStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 40);
            this.btnStop.Text = "ยกเลิกการเพิ่ม/แก้ไขข้อมูล <Esc>";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 40);
            this.btnSave.Text = "บันทึกข้อมูล <F9>";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = global::XPump.Properties.Resources.first;
            this.btnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(36, 40);
            this.btnFirst.Text = "ข้อมูลแรก <Ctrl+Home>";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = global::XPump.Properties.Resources.previous;
            this.btnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(36, 40);
            this.btnPrevious.Text = "ข้อมูลที่แล้ว <PageUp>";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::XPump.Properties.Resources.next;
            this.btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 40);
            this.btnNext.Text = "ข้อมูลถัดไป <PageDown>";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = global::XPump.Properties.Resources.last;
            this.btnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(36, 40);
            this.btnLast.Text = "ข้อมูลสุดท้าย <Ctrl+End>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.DropDownButtonWidth = 15;
            this.btnSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInquiryAll,
            this.btnInquiryRest});
            this.btnSearch.Image = global::XPump.Properties.Resources.search;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 40);
            this.btnSearch.Text = "ค้นหา <Alt+S>";
            this.btnSearch.ButtonClick += new System.EventHandler(this.btnSearch_ButtonClick);
            // 
            // btnInquiryAll
            // 
            this.btnInquiryAll.Name = "btnInquiryAll";
            this.btnInquiryAll.Size = new System.Drawing.Size(296, 26);
            this.btnInquiryAll.Text = "เรียกดูข้อมูล ตั้งแต่ต้น <Ctrl+L>";
            this.btnInquiryAll.Click += new System.EventHandler(this.btnInquiryAll_Click);
            // 
            // btnInquiryRest
            // 
            this.btnInquiryRest.Name = "btnInquiryRest";
            this.btnInquiryRest.Size = new System.Drawing.Size(296, 26);
            this.btnInquiryRest.Text = "เรียกดูข้อมูล ตั้งแต่รายการนี้ <Alt+L>";
            this.btnInquiryRest.Click += new System.EventHandler(this.btnInquiryRest_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::XPump.Properties.Resources.refresh;
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(36, 40);
            this.btnRefresh.Text = "โหลดข้อมูลปัจจุบันใหม่ <Ctrl+F5>";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate._ReadOnly = false;
            this.dtStartDate._SelectedDate = null;
            this.dtStartDate.BackColor = System.Drawing.Color.White;
            this.dtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtStartDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtStartDate.Location = new System.Drawing.Point(97, 60);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(103, 23);
            this.dtStartDate.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "เริ่มใช้วันที่";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(5, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 439);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(872, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "แท๊งค์ / ถัง / หัวจ่ายน้ำมัน";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.xTextEdit1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvTank);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteTank);
            this.splitContainer1.Panel1.Controls.Add(this.btnEditTank);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddTank);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvSection);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteSection);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditSection);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddSection);
            this.splitContainer1.Size = new System.Drawing.Size(866, 401);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.TabIndex = 1;
            // 
            // xTextEdit1
            // 
            this.xTextEdit1._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xTextEdit1._MaxLength = 32767;
            this.xTextEdit1._ReadOnly = false;
            this.xTextEdit1._Text = "";
            this.xTextEdit1._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.xTextEdit1.BackColor = System.Drawing.Color.White;
            this.xTextEdit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xTextEdit1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xTextEdit1.Location = new System.Drawing.Point(7, 59);
            this.xTextEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xTextEdit1.Name = "xTextEdit1";
            this.xTextEdit1.Size = new System.Drawing.Size(133, 23);
            this.xTextEdit1.TabIndex = 9;
            // 
            // dgvTank
            // 
            this.dgvTank.AllowSortByColumnHeaderClicked = false;
            this.dgvTank.AllowUserToAddRows = false;
            this.dgvTank.AllowUserToDeleteRows = false;
            this.dgvTank.AllowUserToResizeColumns = false;
            this.dgvTank.AllowUserToResizeRows = false;
            this.dgvTank.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle57.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle57.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle57.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTank.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle57;
            this.dgvTank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tank_id,
            this.col_tank_working_express_db,
            this.col_tank_name,
            this.col_tank_description,
            this.col_tank_startdate,
            this.col_tank_end_date,
            this.col_tank_remark,
            this.col_tank_isactive,
            this.col_tank_tanksetup_id,
            this.col_tank_tanksetup_start_date,
            this.col_tank_tank,
            this.col_tank__isactive});
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle58.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle58.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle58.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTank.DefaultCellStyle = dataGridViewCellStyle58;
            this.dgvTank.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTank.EnableHeadersVisualStyles = false;
            this.dgvTank.FillEmptyRow = false;
            this.dgvTank.FocusedRowBorderRedLine = false;
            this.dgvTank.Location = new System.Drawing.Point(2, 25);
            this.dgvTank.MultiSelect = false;
            this.dgvTank.Name = "dgvTank";
            this.dgvTank.ReadOnly = true;
            this.dgvTank.RowHeadersVisible = false;
            this.dgvTank.RowTemplate.Height = 26;
            this.dgvTank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTank.Size = new System.Drawing.Size(278, 374);
            this.dgvTank.StandardTab = true;
            this.dgvTank.TabIndex = 0;
            this.dgvTank.CurrentCellChanged += new System.EventHandler(this.dgvTank_CurrentCellChanged);
            // 
            // btnDeleteTank
            // 
            this.btnDeleteTank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDeleteTank.Location = new System.Drawing.Point(166, 113);
            this.btnDeleteTank.Name = "btnDeleteTank";
            this.btnDeleteTank.Size = new System.Drawing.Size(72, 27);
            this.btnDeleteTank.TabIndex = 9;
            this.btnDeleteTank.Text = "delete_tank";
            this.btnDeleteTank.UseVisualStyleBackColor = true;
            this.btnDeleteTank.Click += new System.EventHandler(this.btnDeleteTank_Click);
            // 
            // btnEditTank
            // 
            this.btnEditTank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEditTank.Location = new System.Drawing.Point(92, 113);
            this.btnEditTank.Name = "btnEditTank";
            this.btnEditTank.Size = new System.Drawing.Size(68, 27);
            this.btnEditTank.TabIndex = 9;
            this.btnEditTank.Text = "edit_tank";
            this.btnEditTank.UseVisualStyleBackColor = true;
            this.btnEditTank.Click += new System.EventHandler(this.btnEditTank_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "แท๊งค์ <F8>";
            // 
            // btnAddTank
            // 
            this.btnAddTank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddTank.Location = new System.Drawing.Point(18, 113);
            this.btnAddTank.Name = "btnAddTank";
            this.btnAddTank.Size = new System.Drawing.Size(68, 27);
            this.btnAddTank.TabIndex = 9;
            this.btnAddTank.Text = "add_tank";
            this.btnAddTank.UseVisualStyleBackColor = true;
            this.btnAddTank.Click += new System.EventHandler(this.btnAddTank_Click);
            // 
            // dgvSection
            // 
            this.dgvSection.AllowSortByColumnHeaderClicked = false;
            this.dgvSection.AllowUserToAddRows = false;
            this.dgvSection.AllowUserToDeleteRows = false;
            this.dgvSection.AllowUserToResizeColumns = false;
            this.dgvSection.AllowUserToResizeRows = false;
            this.dgvSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle59;
            this.dgvSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle60.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle60.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSection.DefaultCellStyle = dataGridViewCellStyle60;
            this.dgvSection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSection.EnableHeadersVisualStyles = false;
            this.dgvSection.FillEmptyRow = false;
            this.dgvSection.FocusedRowBorderRedLine = false;
            this.dgvSection.Location = new System.Drawing.Point(2, 25);
            this.dgvSection.MultiSelect = false;
            this.dgvSection.Name = "dgvSection";
            this.dgvSection.ReadOnly = true;
            this.dgvSection.RowHeadersVisible = false;
            this.dgvSection.RowTemplate.Height = 26;
            this.dgvSection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSection.Size = new System.Drawing.Size(576, 374);
            this.dgvSection.StandardTab = true;
            this.dgvSection.TabIndex = 0;
            this.dgvSection.CurrentCellChanged += new System.EventHandler(this.dgvSection_CurrentCellChanged);
            // 
            // btnDeleteSection
            // 
            this.btnDeleteSection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDeleteSection.Location = new System.Drawing.Point(338, 87);
            this.btnDeleteSection.Name = "btnDeleteSection";
            this.btnDeleteSection.Size = new System.Drawing.Size(86, 27);
            this.btnDeleteSection.TabIndex = 9;
            this.btnDeleteSection.Text = "delete_section";
            this.btnDeleteSection.UseVisualStyleBackColor = true;
            this.btnDeleteSection.Click += new System.EventHandler(this.btnDeleteSection_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "ถังน้ำมัน <F7>";
            // 
            // btnEditSection
            // 
            this.btnEditSection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEditSection.Location = new System.Drawing.Point(258, 87);
            this.btnEditSection.Name = "btnEditSection";
            this.btnEditSection.Size = new System.Drawing.Size(74, 27);
            this.btnEditSection.TabIndex = 9;
            this.btnEditSection.Text = "edit_section";
            this.btnEditSection.UseVisualStyleBackColor = true;
            this.btnEditSection.Click += new System.EventHandler(this.btnEditSection_Click);
            // 
            // btnAddSection
            // 
            this.btnAddSection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddSection.Location = new System.Drawing.Point(178, 87);
            this.btnAddSection.Name = "btnAddSection";
            this.btnAddSection.Size = new System.Drawing.Size(74, 27);
            this.btnAddSection.TabIndex = 9;
            this.btnAddSection.Text = "add_section";
            this.btnAddSection.UseVisualStyleBackColor = true;
            this.btnAddSection.Click += new System.EventHandler(this.btnAddSection_Click);
            // 
            // xTextEdit2
            // 
            this.xTextEdit2._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xTextEdit2._MaxLength = 32767;
            this.xTextEdit2._ReadOnly = false;
            this.xTextEdit2._Text = "";
            this.xTextEdit2._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.xTextEdit2.BackColor = System.Drawing.Color.White;
            this.xTextEdit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xTextEdit2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xTextEdit2.Location = new System.Drawing.Point(371, 74);
            this.xTextEdit2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xTextEdit2.Name = "xTextEdit2";
            this.xTextEdit2.Size = new System.Drawing.Size(90, 23);
            this.xTextEdit2.TabIndex = 9;
            // 
            // btnItem
            // 
            this.btnItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTank,
            this.btnSection});
            this.btnItem.Image = global::XPump.Properties.Resources.item;
            this.btnItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItem.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(46, 40);
            this.btnItem.Text = "จัดการข้อมูลถังน้ำมัน <F8>";
            // 
            // btnTank
            // 
            this.btnTank.Name = "btnTank";
            this.btnTank.Size = new System.Drawing.Size(181, 26);
            this.btnTank.Text = "แท๊งค์ <F8>";
            this.btnTank.Click += new System.EventHandler(this.btnTank_Click);
            // 
            // btnSection
            // 
            this.btnSection.Name = "btnSection";
            this.btnSection.Size = new System.Drawing.Size(181, 26);
            this.btnSection.Text = "ถังน้ำมัน <F7>";
            this.btnSection.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // col_tank_id
            // 
            this.col_tank_id.DataPropertyName = "id";
            this.col_tank_id.HeaderText = "Tank Id";
            this.col_tank_id.Name = "col_tank_id";
            this.col_tank_id.ReadOnly = true;
            this.col_tank_id.Visible = false;
            // 
            // col_tank_working_express_db
            // 
            this.col_tank_working_express_db.DataPropertyName = "working_express_id";
            this.col_tank_working_express_db.HeaderText = "Working express db";
            this.col_tank_working_express_db.Name = "col_tank_working_express_db";
            this.col_tank_working_express_db.ReadOnly = true;
            this.col_tank_working_express_db.Visible = false;
            // 
            // col_tank_name
            // 
            this.col_tank_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_tank_name.DataPropertyName = "name";
            this.col_tank_name.HeaderText = "รหัสแท๊งค์";
            this.col_tank_name.Name = "col_tank_name";
            this.col_tank_name.ReadOnly = true;
            // 
            // col_tank_description
            // 
            this.col_tank_description.DataPropertyName = "description";
            this.col_tank_description.HeaderText = "Tank Description";
            this.col_tank_description.Name = "col_tank_description";
            this.col_tank_description.ReadOnly = true;
            this.col_tank_description.Visible = false;
            // 
            // col_tank_startdate
            // 
            this.col_tank_startdate.DataPropertyName = "start_date";
            this.col_tank_startdate.HeaderText = "Start date";
            this.col_tank_startdate.Name = "col_tank_startdate";
            this.col_tank_startdate.ReadOnly = true;
            this.col_tank_startdate.Visible = false;
            // 
            // col_tank_end_date
            // 
            this.col_tank_end_date.DataPropertyName = "enddate";
            this.col_tank_end_date.HeaderText = "End date";
            this.col_tank_end_date.Name = "col_tank_end_date";
            this.col_tank_end_date.ReadOnly = true;
            this.col_tank_end_date.Visible = false;
            // 
            // col_tank_remark
            // 
            this.col_tank_remark.DataPropertyName = "remark";
            this.col_tank_remark.HeaderText = "Remark";
            this.col_tank_remark.Name = "col_tank_remark";
            this.col_tank_remark.ReadOnly = true;
            this.col_tank_remark.Visible = false;
            // 
            // col_tank_isactive
            // 
            this.col_tank_isactive.DataPropertyName = "isactive";
            this.col_tank_isactive.HeaderText = "Is active";
            this.col_tank_isactive.Name = "col_tank_isactive";
            this.col_tank_isactive.ReadOnly = true;
            this.col_tank_isactive.Visible = false;
            // 
            // col_tank_tanksetup_id
            // 
            this.col_tank_tanksetup_id.DataPropertyName = "tanksetup_id";
            this.col_tank_tanksetup_id.HeaderText = "Tank Setup Id";
            this.col_tank_tanksetup_id.Name = "col_tank_tanksetup_id";
            this.col_tank_tanksetup_id.ReadOnly = true;
            this.col_tank_tanksetup_id.Visible = false;
            // 
            // col_tank_tanksetup_start_date
            // 
            this.col_tank_tanksetup_start_date.DataPropertyName = "tanksetup_startdate";
            this.col_tank_tanksetup_start_date.HeaderText = "Tanksetup start date";
            this.col_tank_tanksetup_start_date.Name = "col_tank_tanksetup_start_date";
            this.col_tank_tanksetup_start_date.ReadOnly = true;
            this.col_tank_tanksetup_start_date.Visible = false;
            // 
            // col_tank_tank
            // 
            this.col_tank_tank.DataPropertyName = "tank";
            this.col_tank_tank.HeaderText = "Tank";
            this.col_tank_tank.Name = "col_tank_tank";
            this.col_tank_tank.ReadOnly = true;
            this.col_tank_tank.Visible = false;
            // 
            // col_tank__isactive
            // 
            this.col_tank__isactive.DataPropertyName = "_isactive";
            this.col_tank__isactive.HeaderText = "Isactive";
            this.col_tank__isactive.Name = "col_tank__isactive";
            this.col_tank__isactive.ReadOnly = true;
            this.col_tank__isactive.Visible = false;
            // 
            // FormTankConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(888, 546);
            this.Controls.Add(this.xTextEdit2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTankConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "กำหนดแท๊งค์เก็บน้ำมัน";
            this.Load += new System.EventHandler(this.FormTankConfig_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton btnSearch;
        private System.Windows.Forms.ToolStripMenuItem btnInquiryAll;
        private System.Windows.Forms.ToolStripMenuItem btnInquiryRest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private CC.XDatePicker dtStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private CC.XDatagrid dgvTank;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CC.XDatagrid dgvSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTank;
        private System.Windows.Forms.Button btnEditTank;
        private System.Windows.Forms.Button btnDeleteTank;
        private System.Windows.Forms.Button btnAddSection;
        private System.Windows.Forms.Button btnEditSection;
        private System.Windows.Forms.Button btnDeleteSection;
        private CC.XTextEdit xTextEdit1;
        private CC.XTextEdit xTextEdit2;
        private System.Windows.Forms.ToolStripDropDownButton btnItem;
        private System.Windows.Forms.ToolStripMenuItem btnTank;
        private System.Windows.Forms.ToolStripMenuItem btnSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_startdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_isactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_tanksetup_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_tanksetup_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_tank;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank__isactive;
    }
}