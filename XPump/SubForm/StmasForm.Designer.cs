namespace XPump.SubForm
{
    partial class StmasForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new CC.XTextEdit();
            this.txtDescription = new CC.XTextEdit();
            this.txtName = new CC.XTextEdit();
            this.dgvTank = new CC.XDatagrid();
            this.dgvNozzle = new CC.XDatagrid();
            this.dgvPrice = new CC.XDatagrid();
            this.chkCurrTank = new System.Windows.Forms.CheckBox();
            this.chkCurrNozzle = new System.Windows.Forms.CheckBox();
            this.chkCurrPrice = new System.Windows.Forms.CheckBox();
            this.col_nozzle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_nozzle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle__isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_tank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank__isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price_unitpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNozzle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).BeginInit();
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
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(664, 43);
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 134);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 301);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkCurrTank);
            this.tabPage1.Controls.Add(this.dgvTank);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(645, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "แท๊งค์เก็บน้ำมันชนิดนี้";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkCurrNozzle);
            this.tabPage2.Controls.Add(this.dgvNozzle);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(645, 272);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "หัวจ่ายสำหรับน้ำมันชนิดนี้";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkCurrPrice);
            this.tabPage3.Controls.Add(this.dgvPrice);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(645, 272);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ราคาขายน้ำมันชนิดนี้";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.txtRemark._MaxLength = 50;
            this.txtRemark._ReadOnly = false;
            this.txtRemark._Text = null;
            this.txtRemark.BackColor = System.Drawing.Color.White;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(91, 104);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(466, 23);
            this.txtRemark.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription._MaxLength = 50;
            this.txtDescription._ReadOnly = false;
            this.txtDescription._Text = null;
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDescription.Location = new System.Drawing.Point(91, 78);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(466, 23);
            this.txtDescription.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName._MaxLength = 20;
            this.txtName._ReadOnly = false;
            this.txtName._Text = null;
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtName.Location = new System.Drawing.Point(91, 52);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 23);
            this.txtName.TabIndex = 5;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTank.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tank_id,
            this.col_tank_name,
            this.col_tank_desc,
            this.col_tank_remark,
            this.col_tank_isactive,
            this.col_tank_tank,
            this.col_tank__isactive});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTank.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTank.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTank.EnableHeadersVisualStyles = false;
            this.dgvTank.FillEmptyRow = false;
            this.dgvTank.FocusedRowBorderRedLine = false;
            this.dgvTank.Location = new System.Drawing.Point(6, 34);
            this.dgvTank.MultiSelect = false;
            this.dgvTank.Name = "dgvTank";
            this.dgvTank.ReadOnly = true;
            this.dgvTank.RowHeadersVisible = false;
            this.dgvTank.RowTemplate.Height = 26;
            this.dgvTank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTank.Size = new System.Drawing.Size(633, 232);
            this.dgvTank.StandardTab = true;
            this.dgvTank.TabIndex = 0;
            // 
            // dgvNozzle
            // 
            this.dgvNozzle.AllowSortByColumnHeaderClicked = false;
            this.dgvNozzle.AllowUserToAddRows = false;
            this.dgvNozzle.AllowUserToDeleteRows = false;
            this.dgvNozzle.AllowUserToResizeColumns = false;
            this.dgvNozzle.AllowUserToResizeRows = false;
            this.dgvNozzle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNozzle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNozzle.ColumnHeadersHeight = 28;
            this.dgvNozzle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNozzle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_nozzle_id,
            this.col_nozzle_name,
            this.col_nozzle_description,
            this.col_nozzle_remark,
            this.col_nozzle_isactive,
            this.col_nozzle_nozzle,
            this.col_nozzle__isactive});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNozzle.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNozzle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNozzle.EnableHeadersVisualStyles = false;
            this.dgvNozzle.FillEmptyRow = false;
            this.dgvNozzle.FocusedRowBorderRedLine = false;
            this.dgvNozzle.Location = new System.Drawing.Point(6, 34);
            this.dgvNozzle.MultiSelect = false;
            this.dgvNozzle.Name = "dgvNozzle";
            this.dgvNozzle.ReadOnly = true;
            this.dgvNozzle.RowHeadersVisible = false;
            this.dgvNozzle.RowTemplate.Height = 26;
            this.dgvNozzle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNozzle.Size = new System.Drawing.Size(633, 232);
            this.dgvNozzle.StandardTab = true;
            this.dgvNozzle.TabIndex = 1;
            // 
            // dgvPrice
            // 
            this.dgvPrice.AllowSortByColumnHeaderClicked = false;
            this.dgvPrice.AllowUserToAddRows = false;
            this.dgvPrice.AllowUserToDeleteRows = false;
            this.dgvPrice.AllowUserToResizeColumns = false;
            this.dgvPrice.AllowUserToResizeRows = false;
            this.dgvPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPrice.ColumnHeadersHeight = 28;
            this.dgvPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_price_id,
            this.col_price_date,
            this.col_price_time,
            this.col_price_unitpr});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPrice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPrice.EnableHeadersVisualStyles = false;
            this.dgvPrice.FillEmptyRow = false;
            this.dgvPrice.FocusedRowBorderRedLine = false;
            this.dgvPrice.Location = new System.Drawing.Point(6, 34);
            this.dgvPrice.MultiSelect = false;
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.ReadOnly = true;
            this.dgvPrice.RowHeadersVisible = false;
            this.dgvPrice.RowTemplate.Height = 26;
            this.dgvPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrice.Size = new System.Drawing.Size(633, 232);
            this.dgvPrice.StandardTab = true;
            this.dgvPrice.TabIndex = 2;
            // 
            // chkCurrTank
            // 
            this.chkCurrTank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCurrTank.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCurrTank.AutoSize = true;
            this.chkCurrTank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkCurrTank.Location = new System.Drawing.Point(533, 6);
            this.chkCurrTank.Name = "chkCurrTank";
            this.chkCurrTank.Size = new System.Drawing.Size(106, 23);
            this.chkCurrTank.TabIndex = 2;
            this.chkCurrTank.Text = "เฉพาะข้อมูลปัจจุบัน";
            this.chkCurrTank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCurrTank.UseVisualStyleBackColor = true;
            this.chkCurrTank.CheckedChanged += new System.EventHandler(this.chkCurrTank_CheckedChanged);
            // 
            // chkCurrNozzle
            // 
            this.chkCurrNozzle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCurrNozzle.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCurrNozzle.AutoSize = true;
            this.chkCurrNozzle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkCurrNozzle.Location = new System.Drawing.Point(533, 6);
            this.chkCurrNozzle.Name = "chkCurrNozzle";
            this.chkCurrNozzle.Size = new System.Drawing.Size(106, 23);
            this.chkCurrNozzle.TabIndex = 3;
            this.chkCurrNozzle.Text = "เฉพาะข้อมูลปัจจุบัน";
            this.chkCurrNozzle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCurrNozzle.UseVisualStyleBackColor = true;
            this.chkCurrNozzle.CheckedChanged += new System.EventHandler(this.chkCurrNozzle_CheckedChanged);
            // 
            // chkCurrPrice
            // 
            this.chkCurrPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCurrPrice.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCurrPrice.AutoSize = true;
            this.chkCurrPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkCurrPrice.Location = new System.Drawing.Point(533, 6);
            this.chkCurrPrice.Name = "chkCurrPrice";
            this.chkCurrPrice.Size = new System.Drawing.Size(106, 23);
            this.chkCurrPrice.TabIndex = 3;
            this.chkCurrPrice.Text = "เฉพาะข้อมูลปัจจุบัน";
            this.chkCurrPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCurrPrice.UseVisualStyleBackColor = true;
            this.chkCurrPrice.CheckedChanged += new System.EventHandler(this.chkCurrPrice_CheckedChanged);
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
            this.col_nozzle_name.HeaderText = "รหัส";
            this.col_nozzle_name.Name = "col_nozzle_name";
            this.col_nozzle_name.ReadOnly = true;
            // 
            // col_nozzle_description
            // 
            this.col_nozzle_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_nozzle_description.DataPropertyName = "description";
            this.col_nozzle_description.HeaderText = "รายละเอียด";
            this.col_nozzle_description.Name = "col_nozzle_description";
            this.col_nozzle_description.ReadOnly = true;
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
            this.col_nozzle__isactive.HeaderText = "_IsActive";
            this.col_nozzle__isactive.Name = "col_nozzle__isactive";
            this.col_nozzle__isactive.ReadOnly = true;
            this.col_nozzle__isactive.Visible = false;
            // 
            // col_tank_id
            // 
            this.col_tank_id.DataPropertyName = "id";
            this.col_tank_id.HeaderText = "ID";
            this.col_tank_id.Name = "col_tank_id";
            this.col_tank_id.ReadOnly = true;
            this.col_tank_id.Visible = false;
            // 
            // col_tank_name
            // 
            this.col_tank_name.DataPropertyName = "name";
            this.col_tank_name.HeaderText = "รหัส";
            this.col_tank_name.Name = "col_tank_name";
            this.col_tank_name.ReadOnly = true;
            // 
            // col_tank_desc
            // 
            this.col_tank_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_tank_desc.DataPropertyName = "description";
            this.col_tank_desc.HeaderText = "รายละเอียด";
            this.col_tank_desc.Name = "col_tank_desc";
            this.col_tank_desc.ReadOnly = true;
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
            this.col_tank_isactive.HeaderText = "IsActive";
            this.col_tank_isactive.Name = "col_tank_isactive";
            this.col_tank_isactive.ReadOnly = true;
            this.col_tank_isactive.Visible = false;
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
            this.col_tank__isactive.HeaderText = "_IsActive";
            this.col_tank__isactive.Name = "col_tank__isactive";
            this.col_tank__isactive.ReadOnly = true;
            this.col_tank__isactive.Visible = false;
            // 
            // col_price_id
            // 
            this.col_price_id.HeaderText = "ID";
            this.col_price_id.Name = "col_price_id";
            this.col_price_id.ReadOnly = true;
            this.col_price_id.Visible = false;
            // 
            // col_price_date
            // 
            this.col_price_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_price_date.DataPropertyName = "date";
            this.col_price_date.HeaderText = "วันที่";
            this.col_price_date.Name = "col_price_date";
            this.col_price_date.ReadOnly = true;
            // 
            // col_price_time
            // 
            this.col_price_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_price_time.DataPropertyName = "time";
            this.col_price_time.HeaderText = "เวลา";
            this.col_price_time.Name = "col_price_time";
            this.col_price_time.ReadOnly = true;
            // 
            // col_price_unitpr
            // 
            this.col_price_unitpr.DataPropertyName = "unitpr";
            this.col_price_unitpr.HeaderText = "ราคาขาย/ลิตร";
            this.col_price_unitpr.Name = "col_price_unitpr";
            this.col_price_unitpr.ReadOnly = true;
            // 
            // StmasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 441);
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
            this.Name = "StmasForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "รายละเอียดสินค้า";
            this.Load += new System.EventHandler(this.StmasForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNozzle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private CC.XTextEdit txtName;
        private System.Windows.Forms.Label label2;
        private CC.XTextEdit txtDescription;
        private System.Windows.Forms.Label label3;
        private CC.XTextEdit txtRemark;
        private CC.XDatagrid dgvTank;
        private CC.XDatagrid dgvNozzle;
        private CC.XDatagrid dgvPrice;
        private System.Windows.Forms.CheckBox chkCurrTank;
        private System.Windows.Forms.CheckBox chkCurrNozzle;
        private System.Windows.Forms.CheckBox chkCurrPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_isactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_tank;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank__isactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_isactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_nozzle;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle__isactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price_unitpr;
    }
}