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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnTank = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inline_tankname = new CC.XTextEdit();
            this.dgvTank = new CC.XDatagrid();
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
            this.col_tank_creby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_cretime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_chgby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_chgtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_tank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank__isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteTank = new System.Windows.Forms.Button();
            this.btnEditTank = new System.Windows.Forms.Button();
            this.btnAddTank = new System.Windows.Forms.Button();
            this.lblTank = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.inlineStkcod = new CC.XBrowseBox();
            this.inlineSectionName = new CC.XBrowseBox();
            this.inlineBegacc = new CC.XNumEdit();
            this.inlineBegtak = new CC.XNumEdit();
            this.inlineCapacity = new CC.XNumEdit();
            this.dgvSection = new CC.XDatagrid();
            this.col_sect_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_tank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_nozzlecount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_begtak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_begacc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_begdif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_totbal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_tank_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_stmas_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_loccod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sect_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteSection = new System.Windows.Forms.Button();
            this.lblSection = new System.Windows.Forms.Label();
            this.btnEditSection = new System.Windows.Forms.Button();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.dtStartDate = new CC.XDatePicker();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTank)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1023, 43);
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
            this.btnInquiryAll.Size = new System.Drawing.Size(245, 22);
            this.btnInquiryAll.Text = "เรียกดูข้อมูล ตั้งแต่ต้น <Ctrl+L>";
            this.btnInquiryAll.Click += new System.EventHandler(this.btnInquiryAll_Click);
            // 
            // btnInquiryRest
            // 
            this.btnInquiryRest.Name = "btnInquiryRest";
            this.btnInquiryRest.Size = new System.Drawing.Size(245, 22);
            this.btnInquiryRest.Text = "เรียกดูข้อมูล ตั้งแต่รายการนี้ <Alt+L>";
            this.btnInquiryRest.Click += new System.EventHandler(this.btnInquiryRest_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
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
            this.btnItem.Size = new System.Drawing.Size(45, 40);
            this.btnItem.Text = "จัดการข้อมูลถังน้ำมัน <F8>";
            // 
            // btnTank
            // 
            this.btnTank.Name = "btnTank";
            this.btnTank.Size = new System.Drawing.Size(142, 22);
            this.btnTank.Text = "แท๊งค์ <F8>";
            this.btnTank.Click += new System.EventHandler(this.btnTank_Click);
            // 
            // btnSection
            // 
            this.btnSection.Name = "btnSection";
            this.btnSection.Size = new System.Drawing.Size(142, 22);
            this.btnSection.Text = "ถังน้ำมัน <F7>";
            this.btnSection.Click += new System.EventHandler(this.btnSection_Click);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
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
            this.tabControl1.Size = new System.Drawing.Size(1015, 439);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1007, 410);
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.lblTank);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteSection);
            this.splitContainer1.Panel2.Controls.Add(this.lblSection);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditSection);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddSection);
            this.splitContainer1.Size = new System.Drawing.Size(1001, 404);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.inline_tankname);
            this.panel1.Controls.Add(this.dgvTank);
            this.panel1.Controls.Add(this.btnDeleteTank);
            this.panel1.Controls.Add(this.btnEditTank);
            this.panel1.Controls.Add(this.btnAddTank);
            this.panel1.Location = new System.Drawing.Point(3, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 376);
            this.panel1.TabIndex = 10;
            // 
            // inline_tankname
            // 
            this.inline_tankname._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_tankname._MaxLength = 32767;
            this.inline_tankname._ReadOnly = false;
            this.inline_tankname._Text = "";
            this.inline_tankname._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_tankname.BackColor = System.Drawing.Color.White;
            this.inline_tankname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_tankname.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_tankname.Location = new System.Drawing.Point(3, 58);
            this.inline_tankname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_tankname.Name = "inline_tankname";
            this.inline_tankname.Size = new System.Drawing.Size(178, 23);
            this.inline_tankname.TabIndex = 9;
            this.inline_tankname.Visible = false;
            this.inline_tankname._TextChanged += new System.EventHandler(this.inline_tankname__TextChanged);
            // 
            // dgvTank
            // 
            this.dgvTank.AllowSortByColumnHeaderClicked = false;
            this.dgvTank.AllowUserToAddRows = false;
            this.dgvTank.AllowUserToDeleteRows = false;
            this.dgvTank.AllowUserToResizeColumns = false;
            this.dgvTank.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTank.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTank.ColumnHeadersHeight = 28;
            this.dgvTank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            this.col_tank_creby,
            this.col_tank_cretime,
            this.col_tank_chgby,
            this.col_tank_chgtime,
            this.col_tank_tank,
            this.col_tank__isactive});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTank.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTank.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTank.EnableHeadersVisualStyles = false;
            this.dgvTank.FillEmptyRow = false;
            this.dgvTank.FocusedRowBorderRedLine = true;
            this.dgvTank.Location = new System.Drawing.Point(0, 0);
            this.dgvTank.MultiSelect = false;
            this.dgvTank.Name = "dgvTank";
            this.dgvTank.ReadOnly = true;
            this.dgvTank.RowHeadersVisible = false;
            this.dgvTank.RowTemplate.Height = 26;
            this.dgvTank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTank.Size = new System.Drawing.Size(198, 376);
            this.dgvTank.StandardTab = true;
            this.dgvTank.TabIndex = 0;
            this.dgvTank.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTank_CellDoubleClick);
            this.dgvTank.CurrentCellChanged += new System.EventHandler(this.dgvTank_CurrentCellChanged);
            this.dgvTank.SelectionChanged += new System.EventHandler(this.dgvTank_SelectionChanged);
            this.dgvTank.EnabledChanged += new System.EventHandler(this.dgvTank_EnabledChanged);
            this.dgvTank.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvTank_MouseClick);
            this.dgvTank.Resize += new System.EventHandler(this.dgvTank_Resize);
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
            this.col_tank_working_express_db.DataPropertyName = "working_express_db";
            this.col_tank_working_express_db.HeaderText = "Working Express Db";
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
            this.col_tank_startdate.DataPropertyName = "startdate";
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
            // col_tank_creby
            // 
            this.col_tank_creby.DataPropertyName = "creby";
            this.col_tank_creby.HeaderText = "Created by";
            this.col_tank_creby.Name = "col_tank_creby";
            this.col_tank_creby.ReadOnly = true;
            this.col_tank_creby.Visible = false;
            // 
            // col_tank_cretime
            // 
            this.col_tank_cretime.DataPropertyName = "cretime";
            this.col_tank_cretime.HeaderText = "Created time";
            this.col_tank_cretime.Name = "col_tank_cretime";
            this.col_tank_cretime.ReadOnly = true;
            this.col_tank_cretime.Visible = false;
            // 
            // col_tank_chgby
            // 
            this.col_tank_chgby.DataPropertyName = "chgby";
            this.col_tank_chgby.HeaderText = "Changed by";
            this.col_tank_chgby.Name = "col_tank_chgby";
            this.col_tank_chgby.ReadOnly = true;
            this.col_tank_chgby.Visible = false;
            // 
            // col_tank_chgtime
            // 
            this.col_tank_chgtime.DataPropertyName = "chgtime";
            this.col_tank_chgtime.HeaderText = "Changed time";
            this.col_tank_chgtime.Name = "col_tank_chgtime";
            this.col_tank_chgtime.ReadOnly = true;
            this.col_tank_chgtime.Visible = false;
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
            // btnDeleteTank
            // 
            this.btnDeleteTank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDeleteTank.Location = new System.Drawing.Point(161, 88);
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
            this.btnEditTank.Location = new System.Drawing.Point(87, 88);
            this.btnEditTank.Name = "btnEditTank";
            this.btnEditTank.Size = new System.Drawing.Size(68, 27);
            this.btnEditTank.TabIndex = 9;
            this.btnEditTank.Text = "edit_tank";
            this.btnEditTank.UseVisualStyleBackColor = true;
            this.btnEditTank.Click += new System.EventHandler(this.btnEditTank_Click);
            // 
            // btnAddTank
            // 
            this.btnAddTank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddTank.Location = new System.Drawing.Point(13, 88);
            this.btnAddTank.Name = "btnAddTank";
            this.btnAddTank.Size = new System.Drawing.Size(68, 27);
            this.btnAddTank.TabIndex = 9;
            this.btnAddTank.Text = "add_tank";
            this.btnAddTank.UseVisualStyleBackColor = true;
            this.btnAddTank.Click += new System.EventHandler(this.btnAddTank_Click);
            // 
            // lblTank
            // 
            this.lblTank.AutoSize = true;
            this.lblTank.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTank.Location = new System.Drawing.Point(3, 3);
            this.lblTank.Name = "lblTank";
            this.lblTank.Size = new System.Drawing.Size(81, 16);
            this.lblTank.TabIndex = 9;
            this.lblTank.Text = "แท๊งค์ <F8>";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.inlineStkcod);
            this.panel2.Controls.Add(this.inlineSectionName);
            this.panel2.Controls.Add(this.inlineBegacc);
            this.panel2.Controls.Add(this.inlineBegtak);
            this.panel2.Controls.Add(this.inlineCapacity);
            this.panel2.Controls.Add(this.dgvSection);
            this.panel2.Location = new System.Drawing.Point(3, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 376);
            this.panel2.TabIndex = 10;
            // 
            // inlineStkcod
            // 
            this.inlineStkcod._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineStkcod._ReadOnly = false;
            this.inlineStkcod._Text = "";
            this.inlineStkcod._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inlineStkcod._UseImage = true;
            this.inlineStkcod.BackColor = System.Drawing.Color.White;
            this.inlineStkcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineStkcod.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inlineStkcod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inlineStkcod.Location = new System.Drawing.Point(145, 58);
            this.inlineStkcod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inlineStkcod.Name = "inlineStkcod";
            this.inlineStkcod.Size = new System.Drawing.Size(137, 23);
            this.inlineStkcod.TabIndex = 10;
            this.inlineStkcod.Visible = false;
            this.inlineStkcod._ButtonClick += new System.EventHandler(this.inlineStkcod__ButtonClick);
            // 
            // inlineSectionName
            // 
            this.inlineSectionName._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineSectionName._ReadOnly = false;
            this.inlineSectionName._Text = "";
            this.inlineSectionName._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inlineSectionName._UseImage = true;
            this.inlineSectionName.BackColor = System.Drawing.Color.White;
            this.inlineSectionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineSectionName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inlineSectionName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inlineSectionName.Location = new System.Drawing.Point(3, 58);
            this.inlineSectionName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inlineSectionName.Name = "inlineSectionName";
            this.inlineSectionName.Size = new System.Drawing.Size(141, 23);
            this.inlineSectionName.TabIndex = 10;
            this.inlineSectionName.Visible = false;
            this.inlineSectionName._ButtonClick += new System.EventHandler(this.inlineSectionName__ButtonClick);
            // 
            // inlineBegacc
            // 
            this.inlineBegacc._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineBegacc._DecimalDigit = 2;
            this.inlineBegacc._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.inlineBegacc._MaxLength = 30;
            this.inlineBegacc._ReadOnly = false;
            this.inlineBegacc._SelectionLength = 0;
            this.inlineBegacc._SelectionStart = 4;
            this.inlineBegacc._Text = "0.00";
            this.inlineBegacc._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inlineBegacc._UseThoundsandSeparate = true;
            this.inlineBegacc._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inlineBegacc.BackColor = System.Drawing.Color.White;
            this.inlineBegacc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineBegacc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inlineBegacc.Location = new System.Drawing.Point(584, 58);
            this.inlineBegacc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inlineBegacc.Name = "inlineBegacc";
            this.inlineBegacc.Size = new System.Drawing.Size(113, 23);
            this.inlineBegacc.TabIndex = 10;
            this.inlineBegacc.Visible = false;
            this.inlineBegacc._ValueChanged += new System.EventHandler(this.inlineBegacc__ValueChanged);
            // 
            // inlineBegtak
            // 
            this.inlineBegtak._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineBegtak._DecimalDigit = 2;
            this.inlineBegtak._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.inlineBegtak._MaxLength = 30;
            this.inlineBegtak._ReadOnly = false;
            this.inlineBegtak._SelectionLength = 0;
            this.inlineBegtak._SelectionStart = 4;
            this.inlineBegtak._Text = "0.00";
            this.inlineBegtak._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inlineBegtak._UseThoundsandSeparate = true;
            this.inlineBegtak._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inlineBegtak.BackColor = System.Drawing.Color.White;
            this.inlineBegtak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineBegtak.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inlineBegtak.Location = new System.Drawing.Point(476, 58);
            this.inlineBegtak.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inlineBegtak.Name = "inlineBegtak";
            this.inlineBegtak.Size = new System.Drawing.Size(107, 23);
            this.inlineBegtak.TabIndex = 10;
            this.inlineBegtak.Visible = false;
            this.inlineBegtak._ValueChanged += new System.EventHandler(this.inlineBegtak__ValueChanged);
            // 
            // inlineCapacity
            // 
            this.inlineCapacity._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineCapacity._DecimalDigit = 2;
            this.inlineCapacity._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.inlineCapacity._MaxLength = 30;
            this.inlineCapacity._ReadOnly = false;
            this.inlineCapacity._SelectionLength = 0;
            this.inlineCapacity._SelectionStart = 4;
            this.inlineCapacity._Text = "0.00";
            this.inlineCapacity._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inlineCapacity._UseThoundsandSeparate = true;
            this.inlineCapacity._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inlineCapacity.BackColor = System.Drawing.Color.White;
            this.inlineCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inlineCapacity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inlineCapacity.Location = new System.Drawing.Point(376, 58);
            this.inlineCapacity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inlineCapacity.Name = "inlineCapacity";
            this.inlineCapacity.Size = new System.Drawing.Size(99, 23);
            this.inlineCapacity.TabIndex = 10;
            this.inlineCapacity.Visible = false;
            this.inlineCapacity._ValueChanged += new System.EventHandler(this.inlineCapacity__ValueChanged);
            // 
            // dgvSection
            // 
            this.dgvSection.AllowSortByColumnHeaderClicked = false;
            this.dgvSection.AllowUserToAddRows = false;
            this.dgvSection.AllowUserToDeleteRows = false;
            this.dgvSection.AllowUserToResizeColumns = false;
            this.dgvSection.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSection.ColumnHeadersHeight = 28;
            this.dgvSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_sect_working_express_db,
            this.col_sect_id,
            this.col_sect_tank_name,
            this.col_sect_name,
            this.col_sect_stkcod,
            this.col_sect_nozzlecount,
            this.col_sect_capacity,
            this.col_sect_begtak,
            this.col_sect_begacc,
            this.col_sect_begdif,
            this.col_sect_totbal,
            this.col_sect_tank_id,
            this.col_sect_stmas_id,
            this.col_sect_stkdes,
            this.col_sect_loccod,
            this.col_sect_start_date,
            this.col_sect_end_date,
            this.col_sect_section,
            this.col_sect_state});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSection.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSection.EnableHeadersVisualStyles = false;
            this.dgvSection.FillEmptyRow = false;
            this.dgvSection.FocusedRowBorderRedLine = true;
            this.dgvSection.Location = new System.Drawing.Point(0, 0);
            this.dgvSection.MultiSelect = false;
            this.dgvSection.Name = "dgvSection";
            this.dgvSection.ReadOnly = true;
            this.dgvSection.RowHeadersVisible = false;
            this.dgvSection.RowTemplate.Height = 26;
            this.dgvSection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSection.Size = new System.Drawing.Size(787, 376);
            this.dgvSection.StandardTab = true;
            this.dgvSection.TabIndex = 0;
            this.dgvSection.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSection_CellDoubleClick);
            this.dgvSection.CurrentCellChanged += new System.EventHandler(this.dgvSection_CurrentCellChanged);
            this.dgvSection.EnabledChanged += new System.EventHandler(this.dgvSection_EnabledChanged);
            this.dgvSection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvSection_MouseClick);
            this.dgvSection.Resize += new System.EventHandler(this.dgvSection_Resize);
            // 
            // col_sect_working_express_db
            // 
            this.col_sect_working_express_db.DataPropertyName = "working_express_db";
            this.col_sect_working_express_db.HeaderText = "Working Express db";
            this.col_sect_working_express_db.Name = "col_sect_working_express_db";
            this.col_sect_working_express_db.ReadOnly = true;
            this.col_sect_working_express_db.Visible = false;
            // 
            // col_sect_id
            // 
            this.col_sect_id.DataPropertyName = "id";
            this.col_sect_id.HeaderText = "Id";
            this.col_sect_id.Name = "col_sect_id";
            this.col_sect_id.ReadOnly = true;
            this.col_sect_id.Visible = false;
            // 
            // col_sect_tank_name
            // 
            this.col_sect_tank_name.DataPropertyName = "tank_name";
            this.col_sect_tank_name.HeaderText = "Tank name";
            this.col_sect_tank_name.Name = "col_sect_tank_name";
            this.col_sect_tank_name.ReadOnly = true;
            this.col_sect_tank_name.Visible = false;
            // 
            // col_sect_name
            // 
            this.col_sect_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_sect_name.DataPropertyName = "name";
            this.col_sect_name.HeaderText = "เลขที่ถัง";
            this.col_sect_name.MinimumWidth = 100;
            this.col_sect_name.Name = "col_sect_name";
            this.col_sect_name.ReadOnly = true;
            // 
            // col_sect_stkcod
            // 
            this.col_sect_stkcod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_sect_stkcod.DataPropertyName = "stkcod";
            this.col_sect_stkcod.HeaderText = "ชนิดน้ำมัน";
            this.col_sect_stkcod.MinimumWidth = 100;
            this.col_sect_stkcod.Name = "col_sect_stkcod";
            this.col_sect_stkcod.ReadOnly = true;
            // 
            // col_sect_nozzlecount
            // 
            this.col_sect_nozzlecount.DataPropertyName = "nozzlecount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.col_sect_nozzlecount.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_sect_nozzlecount.HeaderText = "จำนวนหัวจ่าย";
            this.col_sect_nozzlecount.MinimumWidth = 90;
            this.col_sect_nozzlecount.Name = "col_sect_nozzlecount";
            this.col_sect_nozzlecount.ReadOnly = true;
            this.col_sect_nozzlecount.Width = 90;
            // 
            // col_sect_capacity
            // 
            this.col_sect_capacity.DataPropertyName = "capacity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_sect_capacity.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_sect_capacity.HeaderText = "ความจุ(ลิตร)";
            this.col_sect_capacity.MinimumWidth = 100;
            this.col_sect_capacity.Name = "col_sect_capacity";
            this.col_sect_capacity.ReadOnly = true;
            // 
            // col_sect_begtak
            // 
            this.col_sect_begtak.DataPropertyName = "begtak";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.col_sect_begtak.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_sect_begtak.HeaderText = "ยกมา(ตรวจนับ)";
            this.col_sect_begtak.MinimumWidth = 110;
            this.col_sect_begtak.Name = "col_sect_begtak";
            this.col_sect_begtak.ReadOnly = true;
            this.col_sect_begtak.Width = 110;
            // 
            // col_sect_begacc
            // 
            this.col_sect_begacc.DataPropertyName = "begacc";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.col_sect_begacc.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_sect_begacc.HeaderText = "ยกมา(ตามบัญชี)";
            this.col_sect_begacc.MinimumWidth = 110;
            this.col_sect_begacc.Name = "col_sect_begacc";
            this.col_sect_begacc.ReadOnly = true;
            this.col_sect_begacc.Width = 110;
            // 
            // col_sect_begdif
            // 
            this.col_sect_begdif.DataPropertyName = "begdif";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.col_sect_begdif.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_sect_begdif.HeaderText = "ผลต่างยกมา";
            this.col_sect_begdif.MinimumWidth = 90;
            this.col_sect_begdif.Name = "col_sect_begdif";
            this.col_sect_begdif.ReadOnly = true;
            this.col_sect_begdif.Width = 90;
            // 
            // col_sect_totbal
            // 
            this.col_sect_totbal.DataPropertyName = "totbal";
            this.col_sect_totbal.HeaderText = "Totbal";
            this.col_sect_totbal.Name = "col_sect_totbal";
            this.col_sect_totbal.ReadOnly = true;
            this.col_sect_totbal.Visible = false;
            // 
            // col_sect_tank_id
            // 
            this.col_sect_tank_id.DataPropertyName = "tank_id";
            this.col_sect_tank_id.HeaderText = "Tank Id";
            this.col_sect_tank_id.Name = "col_sect_tank_id";
            this.col_sect_tank_id.ReadOnly = true;
            this.col_sect_tank_id.Visible = false;
            // 
            // col_sect_stmas_id
            // 
            this.col_sect_stmas_id.DataPropertyName = "stmas_id";
            this.col_sect_stmas_id.HeaderText = "Stmas Id";
            this.col_sect_stmas_id.Name = "col_sect_stmas_id";
            this.col_sect_stmas_id.ReadOnly = true;
            this.col_sect_stmas_id.Visible = false;
            // 
            // col_sect_stkdes
            // 
            this.col_sect_stkdes.DataPropertyName = "stkdes";
            this.col_sect_stkdes.HeaderText = "Stkdes";
            this.col_sect_stkdes.Name = "col_sect_stkdes";
            this.col_sect_stkdes.ReadOnly = true;
            this.col_sect_stkdes.Visible = false;
            // 
            // col_sect_loccod
            // 
            this.col_sect_loccod.DataPropertyName = "loccod";
            this.col_sect_loccod.HeaderText = "Loccod";
            this.col_sect_loccod.Name = "col_sect_loccod";
            this.col_sect_loccod.ReadOnly = true;
            this.col_sect_loccod.Visible = false;
            // 
            // col_sect_start_date
            // 
            this.col_sect_start_date.DataPropertyName = "start_date";
            this.col_sect_start_date.HeaderText = "Start date";
            this.col_sect_start_date.Name = "col_sect_start_date";
            this.col_sect_start_date.ReadOnly = true;
            this.col_sect_start_date.Visible = false;
            // 
            // col_sect_end_date
            // 
            this.col_sect_end_date.DataPropertyName = "end_date";
            this.col_sect_end_date.HeaderText = "End date";
            this.col_sect_end_date.Name = "col_sect_end_date";
            this.col_sect_end_date.ReadOnly = true;
            this.col_sect_end_date.Visible = false;
            // 
            // col_sect_section
            // 
            this.col_sect_section.DataPropertyName = "section";
            this.col_sect_section.HeaderText = "Section";
            this.col_sect_section.Name = "col_sect_section";
            this.col_sect_section.ReadOnly = true;
            this.col_sect_section.Visible = false;
            // 
            // col_sect_state
            // 
            this.col_sect_state.DataPropertyName = "state";
            this.col_sect_state.HeaderText = "State";
            this.col_sect_state.Name = "col_sect_state";
            this.col_sect_state.ReadOnly = true;
            this.col_sect_state.Visible = false;
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
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSection.Location = new System.Drawing.Point(3, 3);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(98, 16);
            this.lblSection.TabIndex = 9;
            this.lblSection.Text = "ถังน้ำมัน <F7>";
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
            // dtStartDate
            // 
            this.dtStartDate._ReadOnly = true;
            this.dtStartDate._SelectedDate = null;
            this.dtStartDate.BackColor = System.Drawing.Color.White;
            this.dtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtStartDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtStartDate.Location = new System.Drawing.Point(97, 60);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(103, 23);
            this.dtStartDate.TabIndex = 6;
            this.dtStartDate._SelectedDateChanged += new System.EventHandler(this.dtStartDate__SelectedDateChanged);
            // 
            // FormTankConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1023, 546);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTankConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ตั้งค่าแท๊งค์เก็บน้ำมัน";
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
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTank)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblTank;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Button btnAddTank;
        private System.Windows.Forms.Button btnEditTank;
        private System.Windows.Forms.Button btnDeleteTank;
        private System.Windows.Forms.Button btnAddSection;
        private System.Windows.Forms.Button btnEditSection;
        private System.Windows.Forms.Button btnDeleteSection;
        private CC.XTextEdit inline_tankname;
        private System.Windows.Forms.ToolStripDropDownButton btnItem;
        private System.Windows.Forms.ToolStripMenuItem btnTank;
        private System.Windows.Forms.ToolStripMenuItem btnSection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_creby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_cretime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_chgby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_chgtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_tank;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank__isactive;
        private CC.XBrowseBox inlineSectionName;
        private CC.XNumEdit inlineBegacc;
        private CC.XNumEdit inlineBegtak;
        private CC.XNumEdit inlineCapacity;
        private CC.XBrowseBox inlineStkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_tank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_nozzlecount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_begtak;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_begacc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_begdif;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_totbal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_tank_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_stmas_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_loccod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_section;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sect_state;
    }
}