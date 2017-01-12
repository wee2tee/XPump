namespace XPump.SubForm
{
    partial class FormTankSetup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.btnInquiryAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInquiryRest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtEndDate = new CC.XDatePicker();
            this.dtStartDate = new CC.XDatePicker();
            this.dgvSection = new CC.XDatagrid();
            this.dgvNozzle = new CC.XDatagrid();
            this.col_nozzle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_nozzle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle__isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddIsactive = new CC.XDropdownList();
            this.txtRemark = new CC.XTextEdit();
            this.txtDesc = new CC.XTextEdit();
            this.txtName = new CC.XTextEdit();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnItemF8 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnItemF7 = new System.Windows.Forms.ToolStripMenuItem();
            this.col_section_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_tank_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_stmas_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNozzle)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(949, 43);
            this.toolStrip1.TabIndex = 3;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "รหัส";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "รายละเอียด";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "หมายเหตุ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "ใช้งาน";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 212);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2MinSize = 150;
            this.splitContainer1.Size = new System.Drawing.Size(946, 299);
            this.splitContainer1.SplitterDistance = 621;
            this.splitContainer1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "เริ่มใช้วันที่";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "ถึงวันที่";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "(ปล่อยว่างไว้ = ถึงปัจจุบัน)";
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
            this.btnSearch.Text = "toolStripSplitButton1";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(4, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "ช่องเก็บน้ำมัน <F8>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(4, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "หัวจ่ายน้ำมัน <F7>";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvSection);
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 269);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvNozzle);
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 269);
            this.panel2.TabIndex = 1;
            // 
            // dtEndDate
            // 
            this.dtEndDate._ReadOnly = false;
            this.dtEndDate._SelectedDate = null;
            this.dtEndDate.BackColor = System.Drawing.Color.White;
            this.dtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtEndDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtEndDate.Location = new System.Drawing.Point(104, 130);
            this.dtEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(103, 23);
            this.dtEndDate.TabIndex = 14;
            // 
            // dtStartDate
            // 
            this.dtStartDate._ReadOnly = false;
            this.dtStartDate._SelectedDate = null;
            this.dtStartDate.BackColor = System.Drawing.Color.White;
            this.dtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtStartDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtStartDate.Location = new System.Drawing.Point(104, 104);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(103, 23);
            this.dtStartDate.TabIndex = 14;
            // 
            // dgvSection
            // 
            this.dgvSection.AllowSortByColumnHeaderClicked = false;
            this.dgvSection.AllowUserToAddRows = false;
            this.dgvSection.AllowUserToDeleteRows = false;
            this.dgvSection.AllowUserToResizeColumns = false;
            this.dgvSection.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSection.ColumnHeadersHeight = 28;
            this.dgvSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_section_id,
            this.col_section_name,
            this.col_section_stkcod,
            this.col_section_stkdes,
            this.col_section_capacity,
            this.col_section_tank_id,
            this.col_section_section,
            this.col_section_stmas_id});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSection.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.dgvSection.Size = new System.Drawing.Size(615, 269);
            this.dgvSection.StandardTab = true;
            this.dgvSection.TabIndex = 0;
            this.dgvSection.SelectionChanged += new System.EventHandler(this.dgvSection_SelectionChanged);
            // 
            // dgvNozzle
            // 
            this.dgvNozzle.AllowSortByColumnHeaderClicked = false;
            this.dgvNozzle.AllowUserToAddRows = false;
            this.dgvNozzle.AllowUserToDeleteRows = false;
            this.dgvNozzle.AllowUserToResizeColumns = false;
            this.dgvNozzle.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNozzle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNozzle.ColumnHeadersHeight = 28;
            this.dgvNozzle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNozzle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_nozzle_id,
            this.col_nozzle_name,
            this.col_nozzle_desc,
            this.col_nozzle_remark,
            this.col_nozzle_isactive,
            this.col_nozzle_nozzle,
            this.col_nozzle__isactive});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNozzle.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNozzle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNozzle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNozzle.EnableHeadersVisualStyles = false;
            this.dgvNozzle.FillEmptyRow = false;
            this.dgvNozzle.FocusedRowBorderRedLine = true;
            this.dgvNozzle.Location = new System.Drawing.Point(0, 0);
            this.dgvNozzle.MultiSelect = false;
            this.dgvNozzle.Name = "dgvNozzle";
            this.dgvNozzle.ReadOnly = true;
            this.dgvNozzle.RowHeadersVisible = false;
            this.dgvNozzle.RowTemplate.Height = 26;
            this.dgvNozzle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNozzle.Size = new System.Drawing.Size(315, 269);
            this.dgvNozzle.StandardTab = true;
            this.dgvNozzle.TabIndex = 0;
            // 
            // col_nozzle_id
            // 
            this.col_nozzle_id.DataPropertyName = "id";
            this.col_nozzle_id.HeaderText = "ID";
            this.col_nozzle_id.Name = "col_nozzle_id";
            this.col_nozzle_id.ReadOnly = true;
            this.col_nozzle_id.Visible = false;
            // 
            // col_nozzle_name
            // 
            this.col_nozzle_name.DataPropertyName = "name";
            this.col_nozzle_name.HeaderText = "หัวจ่าย";
            this.col_nozzle_name.MinimumWidth = 100;
            this.col_nozzle_name.Name = "col_nozzle_name";
            this.col_nozzle_name.ReadOnly = true;
            // 
            // col_nozzle_desc
            // 
            this.col_nozzle_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_nozzle_desc.DataPropertyName = "description";
            this.col_nozzle_desc.HeaderText = "รายละเอียด";
            this.col_nozzle_desc.Name = "col_nozzle_desc";
            this.col_nozzle_desc.ReadOnly = true;
            // 
            // col_nozzle_remark
            // 
            this.col_nozzle_remark.DataPropertyName = "remark";
            this.col_nozzle_remark.HeaderText = "Remark";
            this.col_nozzle_remark.Name = "col_nozzle_remark";
            this.col_nozzle_remark.ReadOnly = true;
            this.col_nozzle_remark.Visible = false;
            // 
            // col_nozzle_isactive
            // 
            this.col_nozzle_isactive.DataPropertyName = "isactive";
            this.col_nozzle_isactive.HeaderText = "IsActive";
            this.col_nozzle_isactive.Name = "col_nozzle_isactive";
            this.col_nozzle_isactive.ReadOnly = true;
            this.col_nozzle_isactive.Visible = false;
            // 
            // col_nozzle_nozzle
            // 
            this.col_nozzle_nozzle.DataPropertyName = "nozzle";
            this.col_nozzle_nozzle.HeaderText = "Nozzle";
            this.col_nozzle_nozzle.Name = "col_nozzle_nozzle";
            this.col_nozzle_nozzle.ReadOnly = true;
            this.col_nozzle_nozzle.Visible = false;
            // 
            // col_nozzle__isactive
            // 
            this.col_nozzle__isactive.DataPropertyName = "_isactive";
            this.col_nozzle__isactive.HeaderText = "_Isactive";
            this.col_nozzle__isactive.Name = "col_nozzle__isactive";
            this.col_nozzle__isactive.ReadOnly = true;
            this.col_nozzle__isactive.Visible = false;
            // 
            // ddIsactive
            // 
            this.ddIsactive._ReadOnly = true;
            this.ddIsactive._SelectedItem = null;
            this.ddIsactive.BackColor = System.Drawing.Color.White;
            this.ddIsactive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ddIsactive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddIsactive.Location = new System.Drawing.Point(104, 182);
            this.ddIsactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddIsactive.Name = "ddIsactive";
            this.ddIsactive.Size = new System.Drawing.Size(103, 23);
            this.ddIsactive.TabIndex = 10;
            this.ddIsactive.TabStop = false;
            this.ddIsactive.DoubleClick += new System.EventHandler(this.PerformEdit);
            // 
            // txtRemark
            // 
            this.txtRemark._MaxLength = 50;
            this.txtRemark._ReadOnly = true;
            this.txtRemark._Text = null;
            this.txtRemark.BackColor = System.Drawing.Color.White;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(104, 156);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(472, 23);
            this.txtRemark.TabIndex = 6;
            this.txtRemark.DoubleClick += new System.EventHandler(this.PerformEdit);
            // 
            // txtDesc
            // 
            this.txtDesc._MaxLength = 50;
            this.txtDesc._ReadOnly = true;
            this.txtDesc._Text = null;
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDesc.Location = new System.Drawing.Point(104, 78);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(472, 23);
            this.txtDesc.TabIndex = 6;
            this.txtDesc.DoubleClick += new System.EventHandler(this.PerformEdit);
            // 
            // txtName
            // 
            this.txtName._MaxLength = 20;
            this.txtName._ReadOnly = true;
            this.txtName._Text = null;
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtName.Location = new System.Drawing.Point(104, 52);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(184, 23);
            this.txtName.TabIndex = 6;
            this.txtName.DoubleClick += new System.EventHandler(this.PerformEdit);
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
            this.btnItemF8,
            this.btnItemF7});
            this.btnItem.Image = global::XPump.Properties.Resources.item;
            this.btnItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItem.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(45, 40);
            this.btnItem.Text = "toolStripDropDownButton1";
            // 
            // btnItemF8
            // 
            this.btnItemF8.Name = "btnItemF8";
            this.btnItemF8.Size = new System.Drawing.Size(168, 22);
            this.btnItemF8.Text = "ช่องเก็บน้ำมัน <F8>";
            this.btnItemF8.Click += new System.EventHandler(this.btnItemF8_Click);
            // 
            // btnItemF7
            // 
            this.btnItemF7.Name = "btnItemF7";
            this.btnItemF7.Size = new System.Drawing.Size(168, 22);
            this.btnItemF7.Text = "หัวจ่ายน้ำมัน <F7>";
            this.btnItemF7.Click += new System.EventHandler(this.btnItemF7_Click);
            // 
            // col_section_id
            // 
            this.col_section_id.DataPropertyName = "id";
            this.col_section_id.HeaderText = "ID";
            this.col_section_id.Name = "col_section_id";
            this.col_section_id.ReadOnly = true;
            this.col_section_id.Visible = false;
            // 
            // col_section_name
            // 
            this.col_section_name.DataPropertyName = "name";
            this.col_section_name.HeaderText = "รหัสช่องเก็บน้ำมัน";
            this.col_section_name.MinimumWidth = 120;
            this.col_section_name.Name = "col_section_name";
            this.col_section_name.ReadOnly = true;
            this.col_section_name.Width = 120;
            // 
            // col_section_stkcod
            // 
            this.col_section_stkcod.DataPropertyName = "stkcod";
            this.col_section_stkcod.HeaderText = "รหัสสินค้า";
            this.col_section_stkcod.MinimumWidth = 150;
            this.col_section_stkcod.Name = "col_section_stkcod";
            this.col_section_stkcod.ReadOnly = true;
            this.col_section_stkcod.Width = 150;
            // 
            // col_section_stkdes
            // 
            this.col_section_stkdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_section_stkdes.DataPropertyName = "stkdes";
            this.col_section_stkdes.HeaderText = "รายละเอียด";
            this.col_section_stkdes.Name = "col_section_stkdes";
            this.col_section_stkdes.ReadOnly = true;
            // 
            // col_section_capacity
            // 
            this.col_section_capacity.DataPropertyName = "capacity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.col_section_capacity.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_section_capacity.HeaderText = "ปริมาตร(ลิตร)";
            this.col_section_capacity.MinimumWidth = 100;
            this.col_section_capacity.Name = "col_section_capacity";
            this.col_section_capacity.ReadOnly = true;
            // 
            // col_section_tank_id
            // 
            this.col_section_tank_id.DataPropertyName = "tank_id";
            this.col_section_tank_id.HeaderText = "Tank_id";
            this.col_section_tank_id.Name = "col_section_tank_id";
            this.col_section_tank_id.ReadOnly = true;
            this.col_section_tank_id.Visible = false;
            // 
            // col_section_section
            // 
            this.col_section_section.DataPropertyName = "section";
            this.col_section_section.HeaderText = "Section";
            this.col_section_section.Name = "col_section_section";
            this.col_section_section.ReadOnly = true;
            this.col_section_section.Visible = false;
            // 
            // col_section_stmas_id
            // 
            this.col_section_stmas_id.DataPropertyName = "stmas_id";
            this.col_section_stmas_id.HeaderText = "Stmas_id";
            this.col_section_stmas_id.Name = "col_section_stmas_id";
            this.col_section_stmas_id.ReadOnly = true;
            this.col_section_stmas_id.Visible = false;
            // 
            // FormTankSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(949, 513);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ddIsactive);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTankSetup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "กำหนดแท๊งค์เก็บน้ำมัน";
            this.Load += new System.EventHandler(this.FormTank_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNozzle)).EndInit();
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
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private CC.XTextEdit txtName;
        private System.Windows.Forms.Label label1;
        private CC.XDatagrid dgvSection;
        private System.Windows.Forms.Label label2;
        private CC.XTextEdit txtDesc;
        private System.Windows.Forms.Label label3;
        private CC.XTextEdit txtRemark;
        private System.Windows.Forms.Label label4;
        private CC.XDropdownList ddIsactive;
        private CC.XDatagrid dgvNozzle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private CC.XDatePicker dtStartDate;
        private System.Windows.Forms.Label label6;
        private CC.XDatePicker dtEndDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_isactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_nozzle;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle__isactive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton btnItem;
        private System.Windows.Forms.ToolStripMenuItem btnItemF8;
        private System.Windows.Forms.ToolStripMenuItem btnItemF7;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_tank_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_section;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_stmas_id;
    }
}