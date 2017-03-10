namespace XPump.SubForm
{
    partial class FormShiftTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShiftTransaction));
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
            this.btnSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.btnInquiryAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInquiryRest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnPrintALandscape = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintAPortrait = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnItemF8 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnItemF7 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSalesSummary = new CC.XDatagrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_totqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_unitpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_totval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ddisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_netval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dtest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dother = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dothertxt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_salvat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_purvat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shift_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stmas_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pricelist_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shiftsales_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shift_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shift_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shift_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_salessummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.inline_btnSaleshistory = new System.Windows.Forms.Button();
            this.inline_btnEdit = new System.Windows.Forms.Button();
            this.brShift = new CC.XBrowseBox();
            this.dtSaldat = new CC.XDatePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.inline_qty = new CC.XNumEdit();
            this.dgvSttak = new CC.XDatagrid();
            this.col_sttak_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_takdat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_section_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_tank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_section_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_sttak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblDayEnded = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesSummary)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSttak)).BeginInit();
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
            this.btnSearch,
            this.toolStripSeparator2,
            this.btnPrint,
            this.toolStripSeparator4,
            this.btnItem,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(911, 43);
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
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintALandscape,
            this.btnPrintAPortrait});
            this.btnPrint.Image = global::XPump.Properties.Resources.printer;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnPrint.Size = new System.Drawing.Size(51, 40);
            this.btnPrint.Text = "พิมพ์รายงานส่วน ก.";
            // 
            // btnPrintALandscape
            // 
            this.btnPrintALandscape.Name = "btnPrintALandscape";
            this.btnPrintALandscape.Size = new System.Drawing.Size(296, 22);
            this.btnPrintALandscape.Text = "พิมพ์รายงานส่วน ก. กระดาษแนวนอน (12 หัวจ่าย)";
            this.btnPrintALandscape.ToolTipText = "พิมพ์รายงานส่วน ก.";
            this.btnPrintALandscape.Click += new System.EventHandler(this.btnPrintALandscape_Click);
            // 
            // btnPrintAPortrait
            // 
            this.btnPrintAPortrait.Name = "btnPrintAPortrait";
            this.btnPrintAPortrait.Size = new System.Drawing.Size(296, 22);
            this.btnPrintAPortrait.Text = "พิมพ์รายงานส่วน ก. กระดาษแนวตั้ง (30 หัวจ่าย)";
            this.btnPrintAPortrait.Click += new System.EventHandler(this.btnPrintAPortrait_Click);
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
            // 
            // btnItemF8
            // 
            this.btnItemF8.Name = "btnItemF8";
            this.btnItemF8.Size = new System.Drawing.Size(267, 22);
            this.btnItemF8.Text = "บันทึกรายการขาย <F8>";
            this.btnItemF8.Click += new System.EventHandler(this.btnItemF8_Click);
            // 
            // btnItemF7
            // 
            this.btnItemF7.Name = "btnItemF7";
            this.btnItemF7.Size = new System.Drawing.Size(267, 22);
            this.btnItemF7.Text = "บันทึกปริมาณน้ำมันที่ตรวจนับได้จริง <F7>";
            this.btnItemF7.Click += new System.EventHandler(this.btnItemF7_Click);
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
            this.label5.Location = new System.Drawing.Point(40, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "วันที่";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "ผลัด";
            // 
            // dgvSalesSummary
            // 
            this.dgvSalesSummary.AllowSortByColumnHeaderClicked = false;
            this.dgvSalesSummary.AllowUserToAddRows = false;
            this.dgvSalesSummary.AllowUserToDeleteRows = false;
            this.dgvSalesSummary.AllowUserToResizeColumns = false;
            this.dgvSalesSummary.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesSummary.ColumnHeadersHeight = 28;
            this.dgvSalesSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSalesSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_stkcod,
            this.col_stkdes,
            this.col_totqty,
            this.col_unitpr,
            this.col_totval,
            this.col_ddisc,
            this.col_netval,
            this.col_dtest,
            this.col_dother,
            this.col_dothertxt,
            this.col_salvat,
            this.col_purvat,
            this.col_shift_id,
            this.col_stmas_id,
            this.col_pricelist_id,
            this.col_shiftsales_id,
            this.col_shift_name,
            this.col_shift_start,
            this.col_shift_end,
            this.col_price_date,
            this.saldat,
            this.col_total,
            this.col_salessummary});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesSummary.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSalesSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSalesSummary.EnableHeadersVisualStyles = false;
            this.dgvSalesSummary.FillEmptyRow = false;
            this.dgvSalesSummary.FocusedRowBorderRedLine = true;
            this.dgvSalesSummary.Location = new System.Drawing.Point(0, 0);
            this.dgvSalesSummary.MultiSelect = false;
            this.dgvSalesSummary.Name = "dgvSalesSummary";
            this.dgvSalesSummary.ReadOnly = true;
            this.dgvSalesSummary.RowHeadersVisible = false;
            this.dgvSalesSummary.RowTemplate.Height = 26;
            this.dgvSalesSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesSummary.Size = new System.Drawing.Size(897, 363);
            this.dgvSalesSummary.StandardTab = true;
            this.dgvSalesSummary.TabIndex = 0;
            this.dgvSalesSummary.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgvSalesSummary.CurrentCellChanged += new System.EventHandler(this.dgvSalesSummary_CurrentCellChanged);
            this.dgvSalesSummary.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgv_Scroll);
            this.dgvSalesSummary.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            this.dgvSalesSummary.Resize += new System.EventHandler(this.dgv_Resize);
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_stkcod
            // 
            this.col_stkcod.DataPropertyName = "stkcod";
            this.col_stkcod.HeaderText = "รหัสสินค้า";
            this.col_stkcod.MinimumWidth = 160;
            this.col_stkcod.Name = "col_stkcod";
            this.col_stkcod.ReadOnly = true;
            this.col_stkcod.Width = 160;
            // 
            // col_stkdes
            // 
            this.col_stkdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_stkdes.DataPropertyName = "stkdes";
            this.col_stkdes.HeaderText = "รายละเอียด";
            this.col_stkdes.MinimumWidth = 90;
            this.col_stkdes.Name = "col_stkdes";
            this.col_stkdes.ReadOnly = true;
            // 
            // col_totqty
            // 
            this.col_totqty.DataPropertyName = "totqty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_totqty.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_totqty.HeaderText = "ปริมาณขาย(ลิตร)";
            this.col_totqty.MinimumWidth = 120;
            this.col_totqty.Name = "col_totqty";
            this.col_totqty.ReadOnly = true;
            this.col_totqty.Width = 120;
            // 
            // col_unitpr
            // 
            this.col_unitpr.DataPropertyName = "unitpr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_unitpr.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_unitpr.HeaderText = "ราคาขาย/ลิตร";
            this.col_unitpr.MinimumWidth = 120;
            this.col_unitpr.Name = "col_unitpr";
            this.col_unitpr.ReadOnly = true;
            this.col_unitpr.Width = 120;
            // 
            // col_totval
            // 
            this.col_totval.DataPropertyName = "totval";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_totval.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_totval.HeaderText = "มูลค่าขาย(บาท)";
            this.col_totval.MinimumWidth = 120;
            this.col_totval.Name = "col_totval";
            this.col_totval.ReadOnly = true;
            this.col_totval.Width = 120;
            // 
            // col_ddisc
            // 
            this.col_ddisc.DataPropertyName = "ddisc";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_ddisc.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_ddisc.HeaderText = "ส่วนลดหน้าลาน(บาท)";
            this.col_ddisc.MinimumWidth = 140;
            this.col_ddisc.Name = "col_ddisc";
            this.col_ddisc.ReadOnly = true;
            this.col_ddisc.Width = 140;
            // 
            // col_netval
            // 
            this.col_netval.DataPropertyName = "netval";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.col_netval.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_netval.HeaderText = "มูลค่าขายสุทธิ(บาท)";
            this.col_netval.MinimumWidth = 140;
            this.col_netval.Name = "col_netval";
            this.col_netval.ReadOnly = true;
            this.col_netval.Width = 140;
            // 
            // col_dtest
            // 
            this.col_dtest.DataPropertyName = "dtest";
            this.col_dtest.HeaderText = "Deduct Testing Product";
            this.col_dtest.Name = "col_dtest";
            this.col_dtest.ReadOnly = true;
            this.col_dtest.Visible = false;
            // 
            // col_dother
            // 
            this.col_dother.DataPropertyName = "dother";
            this.col_dother.HeaderText = "Deduct Other";
            this.col_dother.Name = "col_dother";
            this.col_dother.ReadOnly = true;
            this.col_dother.Visible = false;
            // 
            // col_dothertxt
            // 
            this.col_dothertxt.DataPropertyName = "dothertxt";
            this.col_dothertxt.HeaderText = "Deduct Other Text";
            this.col_dothertxt.Name = "col_dothertxt";
            this.col_dothertxt.ReadOnly = true;
            this.col_dothertxt.Visible = false;
            // 
            // col_salvat
            // 
            this.col_salvat.DataPropertyName = "salvat";
            this.col_salvat.HeaderText = "Salvat";
            this.col_salvat.Name = "col_salvat";
            this.col_salvat.ReadOnly = true;
            this.col_salvat.Visible = false;
            // 
            // col_purvat
            // 
            this.col_purvat.DataPropertyName = "purvat";
            this.col_purvat.HeaderText = "Purvat";
            this.col_purvat.Name = "col_purvat";
            this.col_purvat.ReadOnly = true;
            this.col_purvat.Visible = false;
            // 
            // col_shift_id
            // 
            this.col_shift_id.DataPropertyName = "shift_id";
            this.col_shift_id.HeaderText = "Shift ID";
            this.col_shift_id.Name = "col_shift_id";
            this.col_shift_id.ReadOnly = true;
            this.col_shift_id.Visible = false;
            // 
            // col_stmas_id
            // 
            this.col_stmas_id.DataPropertyName = "stmas_id";
            this.col_stmas_id.HeaderText = "Stmas ID";
            this.col_stmas_id.Name = "col_stmas_id";
            this.col_stmas_id.ReadOnly = true;
            this.col_stmas_id.Visible = false;
            // 
            // col_pricelist_id
            // 
            this.col_pricelist_id.DataPropertyName = "pricelist_id";
            this.col_pricelist_id.HeaderText = "Price List ID";
            this.col_pricelist_id.Name = "col_pricelist_id";
            this.col_pricelist_id.ReadOnly = true;
            this.col_pricelist_id.Visible = false;
            // 
            // col_shiftsales_id
            // 
            this.col_shiftsales_id.DataPropertyName = "shiftsales_id";
            this.col_shiftsales_id.HeaderText = "Shift Sales ID";
            this.col_shiftsales_id.Name = "col_shiftsales_id";
            this.col_shiftsales_id.ReadOnly = true;
            this.col_shiftsales_id.Visible = false;
            // 
            // col_shift_name
            // 
            this.col_shift_name.DataPropertyName = "shift_name";
            this.col_shift_name.HeaderText = "Shift Name";
            this.col_shift_name.Name = "col_shift_name";
            this.col_shift_name.ReadOnly = true;
            this.col_shift_name.Visible = false;
            // 
            // col_shift_start
            // 
            this.col_shift_start.DataPropertyName = "shift_start";
            this.col_shift_start.HeaderText = "Shift Start Time";
            this.col_shift_start.Name = "col_shift_start";
            this.col_shift_start.ReadOnly = true;
            this.col_shift_start.Visible = false;
            // 
            // col_shift_end
            // 
            this.col_shift_end.DataPropertyName = "shift_end";
            this.col_shift_end.HeaderText = "Shift End Time";
            this.col_shift_end.Name = "col_shift_end";
            this.col_shift_end.ReadOnly = true;
            this.col_shift_end.Visible = false;
            // 
            // col_price_date
            // 
            this.col_price_date.DataPropertyName = "price_date";
            this.col_price_date.HeaderText = "Price Date";
            this.col_price_date.Name = "col_price_date";
            this.col_price_date.ReadOnly = true;
            this.col_price_date.Visible = false;
            // 
            // saldat
            // 
            this.saldat.DataPropertyName = "saldat";
            this.saldat.HeaderText = "Sale Date";
            this.saldat.Name = "saldat";
            this.saldat.ReadOnly = true;
            this.saldat.Visible = false;
            // 
            // col_total
            // 
            this.col_total.DataPropertyName = "total";
            this.col_total.HeaderText = "Total";
            this.col_total.Name = "col_total";
            this.col_total.ReadOnly = true;
            this.col_total.Visible = false;
            // 
            // col_salessummary
            // 
            this.col_salessummary.DataPropertyName = "salessummary";
            this.col_salessummary.HeaderText = "Sales Summary";
            this.col_salessummary.Name = "col_salessummary";
            this.col_salessummary.ReadOnly = true;
            this.col_salessummary.Visible = false;
            // 
            // inline_btnSaleshistory
            // 
            this.inline_btnSaleshistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_btnSaleshistory.Image = global::XPump.Properties.Resources.edit_list_16;
            this.inline_btnSaleshistory.Location = new System.Drawing.Point(257, 29);
            this.inline_btnSaleshistory.Name = "inline_btnSaleshistory";
            this.inline_btnSaleshistory.Size = new System.Drawing.Size(23, 25);
            this.inline_btnSaleshistory.TabIndex = 19;
            this.toolTip1.SetToolTip(this.inline_btnSaleshistory, "บันทึกปริมาณการขาย <Ctrl+Space>");
            this.inline_btnSaleshistory.UseVisualStyleBackColor = true;
            this.inline_btnSaleshistory.Visible = false;
            this.inline_btnSaleshistory.Click += new System.EventHandler(this.inline_btnSaleshistory_Click);
            // 
            // inline_btnEdit
            // 
            this.inline_btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_btnEdit.Image = global::XPump.Properties.Resources.edit_16;
            this.inline_btnEdit.Location = new System.Drawing.Point(376, 29);
            this.inline_btnEdit.Name = "inline_btnEdit";
            this.inline_btnEdit.Size = new System.Drawing.Size(23, 25);
            this.inline_btnEdit.TabIndex = 19;
            this.toolTip1.SetToolTip(this.inline_btnEdit, "แก้ไขราคาขาย <Alt+E>");
            this.inline_btnEdit.UseVisualStyleBackColor = true;
            this.inline_btnEdit.Visible = false;
            this.inline_btnEdit.Click += new System.EventHandler(this.inline_unitpr_Click);
            // 
            // brShift
            // 
            this.brShift._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brShift._ReadOnly = false;
            this.brShift._Text = "";
            this.brShift._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.brShift._UseImage = true;
            this.brShift.BackColor = System.Drawing.Color.White;
            this.brShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brShift.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.brShift.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.brShift.Location = new System.Drawing.Point(83, 85);
            this.brShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.brShift.Name = "brShift";
            this.brShift.Size = new System.Drawing.Size(178, 23);
            this.brShift.TabIndex = 1;
            this.brShift._ButtonClick += new System.EventHandler(this.brShift__ButtonClick);
            this.brShift._Leave += new System.EventHandler(this.brShift__Leave);
            this.brShift._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // dtSaldat
            // 
            this.dtSaldat._ReadOnly = false;
            this.dtSaldat._SelectedDate = null;
            this.dtSaldat.BackColor = System.Drawing.Color.White;
            this.dtSaldat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtSaldat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtSaldat.Location = new System.Drawing.Point(83, 59);
            this.dtSaldat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtSaldat.Name = "dtSaldat";
            this.dtSaldat.Size = new System.Drawing.Size(103, 23);
            this.dtSaldat.TabIndex = 0;
            this.dtSaldat._SelectedDateChanged += new System.EventHandler(this.dtSaldat__SelectedDateChanged);
            this.dtSaldat._Leave += new System.EventHandler(this.dtSaldat__Leave);
            this.dtSaldat._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(4, 122);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(905, 392);
            this.tabControl1.TabIndex = 21;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.inline_btnSaleshistory);
            this.tabPage1.Controls.Add(this.inline_btnEdit);
            this.tabPage1.Controls.Add(this.dgvSalesSummary);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(897, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "บันทึกรายการขาย <F8>";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.inline_qty);
            this.tabPage2.Controls.Add(this.dgvSttak);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(897, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "บันทึกปริมาณน้ำมันที่ตรวจนับได้จริง <F7>";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // inline_qty
            // 
            this.inline_qty._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_qty._DecimalDigit = 2;
            this.inline_qty._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.inline_qty._MaxLength = 30;
            this.inline_qty._ReadOnly = false;
            this.inline_qty._SelectionLength = 0;
            this.inline_qty._SelectionStart = 1;
            this.inline_qty._Text = "0";
            this.inline_qty._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inline_qty._UseThoundsandSeparate = true;
            this.inline_qty._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inline_qty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_qty.BackColor = System.Drawing.Color.White;
            this.inline_qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_qty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_qty.Location = new System.Drawing.Point(756, 37);
            this.inline_qty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_qty.Name = "inline_qty";
            this.inline_qty.Size = new System.Drawing.Size(140, 23);
            this.inline_qty.TabIndex = 1;
            this.inline_qty.Visible = false;
            this.inline_qty._ValueChanged += new System.EventHandler(this.inline_qty__ValueChanged);
            // 
            // dgvSttak
            // 
            this.dgvSttak.AllowSortByColumnHeaderClicked = false;
            this.dgvSttak.AllowUserToAddRows = false;
            this.dgvSttak.AllowUserToDeleteRows = false;
            this.dgvSttak.AllowUserToResizeColumns = false;
            this.dgvSttak.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSttak.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSttak.ColumnHeadersHeight = 28;
            this.dgvSttak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSttak.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_sttak_id,
            this.col_sttak_takdat,
            this.col_sttak_section_id,
            this.col_sttak_stkcod,
            this.col_sttak_stkdes,
            this.col_sttak_tank_name,
            this.col_sttak_section_name,
            this.col_sttak_qty,
            this.col_sttak_sttak});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSttak.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSttak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSttak.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSttak.EnableHeadersVisualStyles = false;
            this.dgvSttak.FillEmptyRow = false;
            this.dgvSttak.FocusedRowBorderRedLine = true;
            this.dgvSttak.Location = new System.Drawing.Point(0, 0);
            this.dgvSttak.MultiSelect = false;
            this.dgvSttak.Name = "dgvSttak";
            this.dgvSttak.ReadOnly = true;
            this.dgvSttak.RowHeadersVisible = false;
            this.dgvSttak.RowTemplate.Height = 26;
            this.dgvSttak.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSttak.Size = new System.Drawing.Size(897, 363);
            this.dgvSttak.StandardTab = true;
            this.dgvSttak.TabIndex = 0;
            this.dgvSttak.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSttak_CellClick);
            this.dgvSttak.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSttak_CellDoubleClick);
            this.dgvSttak.CurrentCellChanged += new System.EventHandler(this.dgvSttak_CurrentCellChanged);
            this.dgvSttak.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvSttak_Scroll);
            this.dgvSttak.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvSttak_MouseClick);
            this.dgvSttak.Resize += new System.EventHandler(this.dgvSttak_Resize);
            // 
            // col_sttak_id
            // 
            this.col_sttak_id.DataPropertyName = "id";
            this.col_sttak_id.HeaderText = "ID";
            this.col_sttak_id.Name = "col_sttak_id";
            this.col_sttak_id.ReadOnly = true;
            this.col_sttak_id.Visible = false;
            // 
            // col_sttak_takdat
            // 
            this.col_sttak_takdat.DataPropertyName = "takdat";
            this.col_sttak_takdat.HeaderText = "วันที่";
            this.col_sttak_takdat.MinimumWidth = 80;
            this.col_sttak_takdat.Name = "col_sttak_takdat";
            this.col_sttak_takdat.ReadOnly = true;
            this.col_sttak_takdat.Visible = false;
            this.col_sttak_takdat.Width = 80;
            // 
            // col_sttak_section_id
            // 
            this.col_sttak_section_id.DataPropertyName = "section_id";
            this.col_sttak_section_id.HeaderText = "Section ID";
            this.col_sttak_section_id.Name = "col_sttak_section_id";
            this.col_sttak_section_id.ReadOnly = true;
            this.col_sttak_section_id.Visible = false;
            // 
            // col_sttak_stkcod
            // 
            this.col_sttak_stkcod.DataPropertyName = "stkcod";
            this.col_sttak_stkcod.HeaderText = "รหัสสินค้า";
            this.col_sttak_stkcod.MinimumWidth = 140;
            this.col_sttak_stkcod.Name = "col_sttak_stkcod";
            this.col_sttak_stkcod.ReadOnly = true;
            this.col_sttak_stkcod.Width = 140;
            // 
            // col_sttak_stkdes
            // 
            this.col_sttak_stkdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_sttak_stkdes.DataPropertyName = "stkdes";
            this.col_sttak_stkdes.HeaderText = "รายละเอียด";
            this.col_sttak_stkdes.Name = "col_sttak_stkdes";
            this.col_sttak_stkdes.ReadOnly = true;
            // 
            // col_sttak_tank_name
            // 
            this.col_sttak_tank_name.DataPropertyName = "tank_name";
            this.col_sttak_tank_name.HeaderText = "รหัสแท๊งค์";
            this.col_sttak_tank_name.MinimumWidth = 140;
            this.col_sttak_tank_name.Name = "col_sttak_tank_name";
            this.col_sttak_tank_name.ReadOnly = true;
            this.col_sttak_tank_name.Width = 140;
            // 
            // col_sttak_section_name
            // 
            this.col_sttak_section_name.DataPropertyName = "section_name";
            this.col_sttak_section_name.HeaderText = "เลขที่ถัง";
            this.col_sttak_section_name.MinimumWidth = 140;
            this.col_sttak_section_name.Name = "col_sttak_section_name";
            this.col_sttak_section_name.ReadOnly = true;
            this.col_sttak_section_name.Width = 140;
            // 
            // col_sttak_qty
            // 
            this.col_sttak_qty.DataPropertyName = "qty";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.col_sttak_qty.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_sttak_qty.HeaderText = "ปริมาณที่วัดได้ (ลิตร)";
            this.col_sttak_qty.MinimumWidth = 140;
            this.col_sttak_qty.Name = "col_sttak_qty";
            this.col_sttak_qty.ReadOnly = true;
            this.col_sttak_qty.Width = 140;
            // 
            // col_sttak_sttak
            // 
            this.col_sttak_sttak.DataPropertyName = "sttak";
            this.col_sttak_sttak.HeaderText = "Sttak";
            this.col_sttak_sttak.Name = "col_sttak_sttak";
            this.col_sttak_sttak.ReadOnly = true;
            this.col_sttak_sttak.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exclaimation_16.png");
            // 
            // lblDayEnded
            // 
            this.lblDayEnded.ForeColor = System.Drawing.Color.Red;
            this.lblDayEnded.Image = global::XPump.Properties.Resources.lock_16;
            this.lblDayEnded.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDayEnded.Location = new System.Drawing.Point(192, 61);
            this.lblDayEnded.Name = "lblDayEnded";
            this.lblDayEnded.Size = new System.Drawing.Size(160, 18);
            this.lblDayEnded.TabIndex = 20;
            this.lblDayEnded.Text = "ปิดยอดขายประจำวันแล้ว";
            this.lblDayEnded.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDayEnded.Visible = false;
            // 
            // FormShiftTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 517);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblDayEnded);
            this.Controls.Add(this.brShift);
            this.Controls.Add(this.dtSaldat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(660, 300);
            this.Name = "FormShiftTransaction";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "บันทึกรายการประจำผลัด";
            this.Load += new System.EventHandler(this.FormShiftTransaction_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesSummary)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSttak)).EndInit();
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
        private CC.XDatePicker dtSaldat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private CC.XBrowseBox brShift;
        private CC.XDatagrid dgvSalesSummary;
        private System.Windows.Forms.Button inline_btnEdit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_totqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unitpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_totval;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ddisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_netval;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dtest;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dother;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dothertxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_salvat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_purvat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shift_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stmas_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pricelist_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shiftsales_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shift_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shift_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shift_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_salessummary;
        private System.Windows.Forms.Button inline_btnSaleshistory;
        private System.Windows.Forms.ToolStripDropDownButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem btnPrintALandscape;
        private System.Windows.Forms.ToolStripMenuItem btnPrintAPortrait;
        private System.Windows.Forms.Label lblDayEnded;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
        private CC.XDatagrid dgvSttak;
        private CC.XNumEdit inline_qty;
        private System.Windows.Forms.ToolStripDropDownButton btnItem;
        private System.Windows.Forms.ToolStripMenuItem btnItemF8;
        private System.Windows.Forms.ToolStripMenuItem btnItemF7;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_takdat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_section_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_tank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_section_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_sttak;
    }
}