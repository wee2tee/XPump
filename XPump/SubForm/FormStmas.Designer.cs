namespace XPump.SubForm
{
    partial class FormStmas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStmas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChgCode = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvSales = new CC.XDatagrid();
            this.col_sales_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_saldat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_tank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_section_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_nozzle_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_salqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_salval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_btn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_sales_nozzle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_stmas_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new CC.XTextEdit();
            this.txtDescription = new CC.XTextEdit();
            this.txtName = new CC.XTextEdit();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
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
            this.toolStripSeparator5,
            this.btnChgCode,
            this.btnRefresh,
            this.toolStripSeparator4,
            this.btnImport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(839, 43);
            this.toolStrip1.TabIndex = 2;
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 43);
            // 
            // btnChgCode
            // 
            this.btnChgCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChgCode.Image = ((System.Drawing.Image)(resources.GetObject("btnChgCode.Image")));
            this.btnChgCode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnChgCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChgCode.Name = "btnChgCode";
            this.btnChgCode.Size = new System.Drawing.Size(36, 40);
            this.btnChgCode.Text = "เปลี่ยนรหัสสินค้า <Ctrl+G>";
            this.btnChgCode.Click += new System.EventHandler(this.btnRename_Click);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImport.Image = global::XPump.Properties.Resources.db_import;
            this.btnImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(36, 40);
            this.btnImport.Text = "นำเข้าข้อมูลสินค้าจาก Express";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(4, 140);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(833, 393);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvSales);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(825, 364);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ประวัติรายการขาย";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowSortByColumnHeaderClicked = false;
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.AllowUserToResizeColumns = false;
            this.dgvSales.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSales.ColumnHeadersHeight = 28;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_sales_id,
            this.col_sales_saldat,
            this.col_sales_tank_name,
            this.col_sales_section_name,
            this.col_sales_nozzle_name,
            this.col_sales_salqty,
            this.col_sales_salval,
            this.col_sales_btn,
            this.col_sales_nozzle_id,
            this.col_sales_stmas_id,
            this.col_sales_stkcod,
            this.col_sales_stkdes,
            this.col_sales_working_express_db});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSales.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSales.EnableHeadersVisualStyles = false;
            this.dgvSales.FillEmptyRow = false;
            this.dgvSales.FocusedRowBorderRedLine = true;
            this.dgvSales.Location = new System.Drawing.Point(3, 3);
            this.dgvSales.MultiSelect = false;
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSales.RowTemplate.Height = 26;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(819, 358);
            this.dgvSales.StandardTab = true;
            this.dgvSales.TabIndex = 2;
            this.dgvSales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSales_CellClick);
            this.dgvSales.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSales_CellMouseMove);
            this.dgvSales.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSales_CellPainting);
            // 
            // col_sales_id
            // 
            this.col_sales_id.DataPropertyName = "id";
            this.col_sales_id.HeaderText = "ID";
            this.col_sales_id.Name = "col_sales_id";
            this.col_sales_id.ReadOnly = true;
            this.col_sales_id.Visible = false;
            // 
            // col_sales_saldat
            // 
            this.col_sales_saldat.DataPropertyName = "saldat";
            dataGridViewCellStyle7.Format = "dd/MM/yyyy";
            this.col_sales_saldat.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_sales_saldat.HeaderText = "วันที่";
            this.col_sales_saldat.MinimumWidth = 90;
            this.col_sales_saldat.Name = "col_sales_saldat";
            this.col_sales_saldat.ReadOnly = true;
            this.col_sales_saldat.Width = 90;
            // 
            // col_sales_tank_name
            // 
            this.col_sales_tank_name.DataPropertyName = "tank_name";
            this.col_sales_tank_name.HeaderText = "Tank Name";
            this.col_sales_tank_name.Name = "col_sales_tank_name";
            this.col_sales_tank_name.ReadOnly = true;
            this.col_sales_tank_name.Visible = false;
            // 
            // col_sales_section_name
            // 
            this.col_sales_section_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_sales_section_name.DataPropertyName = "section_name";
            this.col_sales_section_name.HeaderText = "เลขที่ถัง";
            this.col_sales_section_name.Name = "col_sales_section_name";
            this.col_sales_section_name.ReadOnly = true;
            // 
            // col_sales_nozzle_name
            // 
            this.col_sales_nozzle_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_sales_nozzle_name.DataPropertyName = "nozzle_name";
            this.col_sales_nozzle_name.HeaderText = "เลขที่หัวจ่าย";
            this.col_sales_nozzle_name.MinimumWidth = 120;
            this.col_sales_nozzle_name.Name = "col_sales_nozzle_name";
            this.col_sales_nozzle_name.ReadOnly = true;
            // 
            // col_sales_salqty
            // 
            this.col_sales_salqty.DataPropertyName = "salqty";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.col_sales_salqty.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_sales_salqty.HeaderText = "ปริมาณขาย(ลิตร)";
            this.col_sales_salqty.MinimumWidth = 140;
            this.col_sales_salqty.Name = "col_sales_salqty";
            this.col_sales_salqty.ReadOnly = true;
            this.col_sales_salqty.Width = 140;
            // 
            // col_sales_salval
            // 
            this.col_sales_salval.DataPropertyName = "salval";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.col_sales_salval.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_sales_salval.HeaderText = "มูลค่าขาย";
            this.col_sales_salval.MinimumWidth = 140;
            this.col_sales_salval.Name = "col_sales_salval";
            this.col_sales_salval.ReadOnly = true;
            this.col_sales_salval.Width = 140;
            // 
            // col_sales_btn
            // 
            this.col_sales_btn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_sales_btn.HeaderText = "";
            this.col_sales_btn.MinimumWidth = 25;
            this.col_sales_btn.Name = "col_sales_btn";
            this.col_sales_btn.ReadOnly = true;
            this.col_sales_btn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_sales_btn.Text = "ดูรายละเอียด";
            this.col_sales_btn.UseColumnTextForButtonValue = true;
            this.col_sales_btn.Width = 25;
            // 
            // col_sales_nozzle_id
            // 
            this.col_sales_nozzle_id.DataPropertyName = "nozzle_id";
            this.col_sales_nozzle_id.HeaderText = "Nozzle Id";
            this.col_sales_nozzle_id.Name = "col_sales_nozzle_id";
            this.col_sales_nozzle_id.ReadOnly = true;
            this.col_sales_nozzle_id.Visible = false;
            // 
            // col_sales_stmas_id
            // 
            this.col_sales_stmas_id.DataPropertyName = "stmas_id";
            this.col_sales_stmas_id.HeaderText = "Stmas Id";
            this.col_sales_stmas_id.Name = "col_sales_stmas_id";
            this.col_sales_stmas_id.ReadOnly = true;
            this.col_sales_stmas_id.Visible = false;
            // 
            // col_sales_stkcod
            // 
            this.col_sales_stkcod.DataPropertyName = "stkcod";
            this.col_sales_stkcod.HeaderText = "Stkcod";
            this.col_sales_stkcod.Name = "col_sales_stkcod";
            this.col_sales_stkcod.ReadOnly = true;
            this.col_sales_stkcod.Visible = false;
            // 
            // col_sales_stkdes
            // 
            this.col_sales_stkdes.DataPropertyName = "stkdes";
            this.col_sales_stkdes.HeaderText = "StkDes";
            this.col_sales_stkdes.Name = "col_sales_stkdes";
            this.col_sales_stkdes.ReadOnly = true;
            this.col_sales_stkdes.Visible = false;
            // 
            // col_sales_working_express_db
            // 
            this.col_sales_working_express_db.DataPropertyName = "working_express_db";
            this.col_sales_working_express_db.HeaderText = "Working Express DB";
            this.col_sales_working_express_db.Name = "col_sales_working_express_db";
            this.col_sales_working_express_db.ReadOnly = true;
            this.col_sales_working_express_db.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "รายละเอียด";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "หมายเหตุ";
            // 
            // txtRemark
            // 
            this.txtRemark._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark._MaxLength = 50;
            this.txtRemark._ReadOnly = false;
            this.txtRemark._Text = "";
            this.txtRemark._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRemark.BackColor = System.Drawing.Color.White;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(91, 104);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(466, 23);
            this.txtRemark.TabIndex = 2;
            this.txtRemark._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // txtDescription
            // 
            this.txtDescription._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription._MaxLength = 50;
            this.txtDescription._ReadOnly = false;
            this.txtDescription._Text = "";
            this.txtDescription._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDescription.Location = new System.Drawing.Point(91, 78);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(466, 23);
            this.txtDescription.TabIndex = 1;
            this.txtDescription._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // txtName
            // 
            this.txtName._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName._MaxLength = 20;
            this.txtName._ReadOnly = false;
            this.txtName._Text = "";
            this.txtName._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtName.Location = new System.Drawing.Point(91, 52);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 23);
            this.txtName.TabIndex = 0;
            this.txtName._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "รหัส";
            // 
            // FormStmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 536);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(580, 250);
            this.Name = "FormStmas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "StockFile";
            this.Text = "รายละเอียดสินค้า";
            this.Load += new System.EventHandler(this.StmasForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
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
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private CC.XTextEdit txtName;
        private System.Windows.Forms.Label label2;
        private CC.XTextEdit txtDescription;
        private System.Windows.Forms.Label label3;
        private CC.XTextEdit txtRemark;
        private CC.XDatagrid dgvSales;
        private System.Windows.Forms.ToolStripSplitButton btnSearch;
        private System.Windows.Forms.ToolStripMenuItem btnInquiryAll;
        private System.Windows.Forms.ToolStripMenuItem btnInquiryRest;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripButton btnChgCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_saldat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_tank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_section_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_nozzle_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_salqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_salval;
        private System.Windows.Forms.DataGridViewButtonColumn col_sales_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_nozzle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_stmas_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_working_express_db;
    }
}