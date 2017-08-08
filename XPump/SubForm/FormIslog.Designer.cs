namespace XPump.SubForm
{
    partial class FormIslog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dgv = new CC.XDatagrid();
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
            this.btnSearchByDate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearchByCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPrintAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.btnItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnApprove = new System.Windows.Forms.ToolStripButton();
            this.btnUnApprove = new System.Windows.Forms.ToolStripButton();
            this.btnApproveMulti = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cretime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_logcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_expressdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xpumpdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xpumpuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_modcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_docnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_islog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.btnApprove,
            this.btnUnApprove,
            this.btnApproveMulti,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(851, 43);
            this.toolStrip1.TabIndex = 6;
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
            this.toolStripSeparator1.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            this.toolStripSeparator4.Visible = false;
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 28;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_cretime,
            this.col_logcode,
            this.col_expressdata,
            this.col_xpumpdata,
            this.col_xpumpuser,
            this.col_modcod,
            this.col_docnum,
            this.col_description,
            this.col_username,
            this.col_islog});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.FillEmptyRow = false;
            this.dgv.FocusedRowBorderRedLine = true;
            this.dgv.Location = new System.Drawing.Point(0, 43);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 26;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(851, 447);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 7;
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = global::XPump.Properties.Resources.add;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 40);
            this.btnAdd.Text = "เพิ่มข้อมูล <Alt+A>";
            this.btnAdd.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit;
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(36, 40);
            this.btnEdit.Text = "แก้ไขข้อมูล <Alt+E>";
            this.btnEdit.Visible = false;
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
            this.btnStop.Enabled = false;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            this.btnStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 40);
            this.btnStop.Text = "ยกเลิกการเพิ่ม/แก้ไขข้อมูล <Esc>";
            this.btnStop.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 40);
            this.btnSave.Text = "บันทึกข้อมูล <F9>";
            this.btnSave.Visible = false;
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
            this.btnFirst.Visible = false;
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
            this.btnPrevious.Visible = false;
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
            this.btnNext.Visible = false;
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
            this.btnLast.Visible = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.DropDownButtonWidth = 12;
            this.btnSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchByDate,
            this.btnSearchByCondition});
            this.btnSearch.Image = global::XPump.Properties.Resources.search;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 40);
            this.btnSearch.Text = "ค้นหารายการวันที่ <Alt + S>";
            this.btnSearch.ButtonClick += new System.EventHandler(this.btnSearch_ButtonClick);
            // 
            // btnSearchByDate
            // 
            this.btnSearchByDate.Name = "btnSearchByDate";
            this.btnSearchByDate.Size = new System.Drawing.Size(251, 22);
            this.btnSearchByDate.Text = "ค้นหารายการ วันที่... <Alt + S>";
            this.btnSearchByDate.Click += new System.EventHandler(this.btnSearchByDate_Click);
            // 
            // btnSearchByCondition
            // 
            this.btnSearchByCondition.Name = "btnSearchByCondition";
            this.btnSearchByCondition.Size = new System.Drawing.Size(251, 22);
            this.btnSearchByCondition.Text = "เรียกดูข้อมูล โดยระบุเงื่อนไข <Alt+K>";
            this.btnSearchByCondition.Click += new System.EventHandler(this.btnSearchByCondition_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.DropDownButtonWidth = 12;
            this.btnPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintAll,
            this.btnPrintCondition});
            this.btnPrint.Image = global::XPump.Properties.Resources.printer;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(49, 40);
            this.btnPrint.Text = "พิมพ์รายงานบันทึกการทำงานทั้งหมดในช่วงวันที่ <Alt + P>";
            this.btnPrint.ButtonClick += new System.EventHandler(this.btnPrint_ButtonClick);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(351, 22);
            this.btnPrintAll.Text = "พิมพ์รายงานบันทึกการทำงานทั้งหมดในช่วงวันที่... <Alt + P>";
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnPrintCondition
            // 
            this.btnPrintCondition.Name = "btnPrintCondition";
            this.btnPrintCondition.Size = new System.Drawing.Size(351, 22);
            this.btnPrintCondition.Text = "พิมพ์รายงานบันทึกการทำงานโดยกำหนดเงื่อนไข <Ctrl + P>";
            this.btnPrintCondition.Click += new System.EventHandler(this.btnPrintCondition_Click);
            // 
            // btnItem
            // 
            this.btnItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItem.Enabled = false;
            this.btnItem.Image = global::XPump.Properties.Resources.item;
            this.btnItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItem.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(45, 40);
            this.btnItem.Visible = false;
            // 
            // btnApprove
            // 
            this.btnApprove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApprove.Enabled = false;
            this.btnApprove.Image = global::XPump.Properties.Resources.approve;
            this.btnApprove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(36, 40);
            this.btnApprove.Text = "toolStripButton1";
            this.btnApprove.ToolTipText = "รับรองรายการ <Alt+O>";
            this.btnApprove.Visible = false;
            // 
            // btnUnApprove
            // 
            this.btnUnApprove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnApprove.Enabled = false;
            this.btnUnApprove.Image = global::XPump.Properties.Resources.unapprove;
            this.btnUnApprove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUnApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnApprove.Name = "btnUnApprove";
            this.btnUnApprove.Size = new System.Drawing.Size(36, 40);
            this.btnUnApprove.Text = "toolStripButton2";
            this.btnUnApprove.ToolTipText = "ยกเลิกการรับรองรายการ <Ctrl+O>";
            this.btnUnApprove.Visible = false;
            // 
            // btnApproveMulti
            // 
            this.btnApproveMulti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApproveMulti.Enabled = false;
            this.btnApproveMulti.Image = global::XPump.Properties.Resources.approve_multiple;
            this.btnApproveMulti.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnApproveMulti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApproveMulti.Name = "btnApproveMulti";
            this.btnApproveMulti.Size = new System.Drawing.Size(36, 40);
            this.btnApproveMulti.Text = "toolStripButton1";
            this.btnApproveMulti.ToolTipText = "รับรองรายการเป็นช่วง <Alt+Shift+O>";
            this.btnApproveMulti.Visible = false;
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
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.MinimumWidth = 30;
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            this.col_id.Width = 30;
            // 
            // col_cretime
            // 
            this.col_cretime.DataPropertyName = "cretime";
            dataGridViewCellStyle2.Format = "dd/MM/yy HH:mm:ss";
            dataGridViewCellStyle2.NullValue = null;
            this.col_cretime.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_cretime.HeaderText = "Log Time";
            this.col_cretime.MinimumWidth = 140;
            this.col_cretime.Name = "col_cretime";
            this.col_cretime.ReadOnly = true;
            this.col_cretime.Width = 140;
            // 
            // col_logcode
            // 
            this.col_logcode.DataPropertyName = "logcode";
            this.col_logcode.HeaderText = "Log Code";
            this.col_logcode.MinimumWidth = 70;
            this.col_logcode.Name = "col_logcode";
            this.col_logcode.ReadOnly = true;
            this.col_logcode.Width = 70;
            // 
            // col_expressdata
            // 
            this.col_expressdata.DataPropertyName = "expressdata";
            this.col_expressdata.HeaderText = "Express Data";
            this.col_expressdata.MinimumWidth = 120;
            this.col_expressdata.Name = "col_expressdata";
            this.col_expressdata.ReadOnly = true;
            this.col_expressdata.Width = 120;
            // 
            // col_xpumpdata
            // 
            this.col_xpumpdata.DataPropertyName = "xpumpdata";
            this.col_xpumpdata.HeaderText = "MySQL DB.";
            this.col_xpumpdata.MinimumWidth = 160;
            this.col_xpumpdata.Name = "col_xpumpdata";
            this.col_xpumpdata.ReadOnly = true;
            this.col_xpumpdata.Visible = false;
            this.col_xpumpdata.Width = 160;
            // 
            // col_xpumpuser
            // 
            this.col_xpumpuser.DataPropertyName = "xpumpuser";
            this.col_xpumpuser.HeaderText = "Xpump User";
            this.col_xpumpuser.Name = "col_xpumpuser";
            this.col_xpumpuser.ReadOnly = true;
            this.col_xpumpuser.Visible = false;
            // 
            // col_modcod
            // 
            this.col_modcod.DataPropertyName = "modcod";
            this.col_modcod.HeaderText = "Module";
            this.col_modcod.MinimumWidth = 70;
            this.col_modcod.Name = "col_modcod";
            this.col_modcod.ReadOnly = true;
            this.col_modcod.Width = 70;
            // 
            // col_docnum
            // 
            this.col_docnum.DataPropertyName = "docnum";
            this.col_docnum.HeaderText = "Doc. Number";
            this.col_docnum.MinimumWidth = 120;
            this.col_docnum.Name = "col_docnum";
            this.col_docnum.ReadOnly = true;
            this.col_docnum.Visible = false;
            this.col_docnum.Width = 120;
            // 
            // col_description
            // 
            this.col_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_description.DataPropertyName = "description";
            this.col_description.HeaderText = "Description";
            this.col_description.MinimumWidth = 60;
            this.col_description.Name = "col_description";
            this.col_description.ReadOnly = true;
            // 
            // col_username
            // 
            this.col_username.DataPropertyName = "username";
            this.col_username.HeaderText = "User Name";
            this.col_username.MinimumWidth = 80;
            this.col_username.Name = "col_username";
            this.col_username.ReadOnly = true;
            this.col_username.Width = 80;
            // 
            // col_islog
            // 
            this.col_islog.DataPropertyName = "islog";
            this.col_islog.HeaderText = "Islog";
            this.col_islog.Name = "col_islog";
            this.col_islog.ReadOnly = true;
            this.col_islog.Visible = false;
            // 
            // FormIslog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 490);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormIslog";
            this.ShowIcon = false;
            this.Text = "แฟ้มบันทึกเหตุการณ์ทำงาน";
            this.Load += new System.EventHandler(this.FormIslog_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton btnItem;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripButton btnUnApprove;
        private System.Windows.Forms.ToolStripButton btnApproveMulti;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.ToolStripSplitButton btnSearch;
        private System.Windows.Forms.ToolStripMenuItem btnSearchByDate;
        private System.Windows.Forms.ToolStripMenuItem btnSearchByCondition;
        private System.Windows.Forms.ToolStripSplitButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem btnPrintAll;
        private System.Windows.Forms.ToolStripMenuItem btnPrintCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cretime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_logcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_expressdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xpumpdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xpumpuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_modcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_docnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_islog;
    }
}