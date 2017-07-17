namespace XPump.SubForm
{
    partial class FormSecure
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.inline_approve = new CC.XDropdownList();
            this.inline_print = new CC.XDropdownList();
            this.inline_delete = new CC.XDropdownList();
            this.inline_edit = new CC.XDropdownList();
            this.inline_add = new CC.XDropdownList();
            this.inline_read = new CC.XDropdownList();
            this.inline_menu = new CC.XBrowseBox();
            this.inline_datacod = new CC.XBrowseBox();
            this.xDatagrid1 = new CC.XDatagrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_datacod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_menu_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_menu_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_read = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_add = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_edit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_print = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_approve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.txtSecure = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUserGroup = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xDatagrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(868, 43);
            this.toolStrip1.TabIndex = 6;
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
            this.btnDelete.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            this.toolStripSeparator3.Visible = false;
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
            // 
            // btnInquiryAll
            // 
            this.btnInquiryAll.Name = "btnInquiryAll";
            this.btnInquiryAll.Size = new System.Drawing.Size(245, 22);
            this.btnInquiryAll.Text = "เรียกดูข้อมูล ตั้งแต่ต้น <Ctrl+L>";
            // 
            // btnInquiryRest
            // 
            this.btnInquiryRest.Name = "btnInquiryRest";
            this.btnInquiryRest.Size = new System.Drawing.Size(245, 22);
            this.btnInquiryRest.Text = "เรียกดูข้อมูล ตั้งแต่รายการนี้ <Alt+L>";
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
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 230);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(862, 337);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.inline_approve);
            this.tabPage1.Controls.Add(this.inline_print);
            this.tabPage1.Controls.Add(this.inline_delete);
            this.tabPage1.Controls.Add(this.inline_edit);
            this.tabPage1.Controls.Add(this.inline_add);
            this.tabPage1.Controls.Add(this.inline_read);
            this.tabPage1.Controls.Add(this.inline_menu);
            this.tabPage1.Controls.Add(this.inline_datacod);
            this.tabPage1.Controls.Add(this.xDatagrid1);
            this.tabPage1.Controls.Add(this.btnDeleteItem);
            this.tabPage1.Controls.Add(this.btnEditItem);
            this.tabPage1.Controls.Add(this.btnAddItem);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(854, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "เมนูที่อนุญาตให้ผู้ใช้รายนี้";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // inline_approve
            // 
            this.inline_approve._ReadOnly = false;
            this.inline_approve._SelectedItem = null;
            this.inline_approve._Text = "";
            this.inline_approve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_approve.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_approve.Location = new System.Drawing.Point(801, 40);
            this.inline_approve.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_approve.Name = "inline_approve";
            this.inline_approve.Size = new System.Drawing.Size(48, 23);
            this.inline_approve.TabIndex = 3;
            // 
            // inline_print
            // 
            this.inline_print._ReadOnly = false;
            this.inline_print._SelectedItem = null;
            this.inline_print._Text = "";
            this.inline_print.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_print.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_print.Location = new System.Drawing.Point(751, 40);
            this.inline_print.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_print.Name = "inline_print";
            this.inline_print.Size = new System.Drawing.Size(48, 23);
            this.inline_print.TabIndex = 3;
            // 
            // inline_delete
            // 
            this.inline_delete._ReadOnly = false;
            this.inline_delete._SelectedItem = null;
            this.inline_delete._Text = "";
            this.inline_delete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_delete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_delete.Location = new System.Drawing.Point(701, 40);
            this.inline_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_delete.Name = "inline_delete";
            this.inline_delete.Size = new System.Drawing.Size(48, 23);
            this.inline_delete.TabIndex = 3;
            // 
            // inline_edit
            // 
            this.inline_edit._ReadOnly = false;
            this.inline_edit._SelectedItem = null;
            this.inline_edit._Text = "";
            this.inline_edit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_edit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_edit.Location = new System.Drawing.Point(650, 40);
            this.inline_edit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_edit.Name = "inline_edit";
            this.inline_edit.Size = new System.Drawing.Size(48, 23);
            this.inline_edit.TabIndex = 3;
            // 
            // inline_add
            // 
            this.inline_add._ReadOnly = false;
            this.inline_add._SelectedItem = null;
            this.inline_add._Text = "";
            this.inline_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_add.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_add.Location = new System.Drawing.Point(600, 40);
            this.inline_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_add.Name = "inline_add";
            this.inline_add.Size = new System.Drawing.Size(48, 23);
            this.inline_add.TabIndex = 3;
            // 
            // inline_read
            // 
            this.inline_read._ReadOnly = false;
            this.inline_read._SelectedItem = null;
            this.inline_read._Text = "";
            this.inline_read.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_read.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_read.Location = new System.Drawing.Point(550, 40);
            this.inline_read.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_read.Name = "inline_read";
            this.inline_read.Size = new System.Drawing.Size(48, 23);
            this.inline_read.TabIndex = 3;
            // 
            // inline_menu
            // 
            this.inline_menu._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_menu._ReadOnly = false;
            this.inline_menu._Text = "";
            this.inline_menu._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_menu._UseImage = true;
            this.inline_menu.BackColor = System.Drawing.Color.White;
            this.inline_menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_menu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inline_menu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_menu.Location = new System.Drawing.Point(126, 40);
            this.inline_menu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_menu.Name = "inline_menu";
            this.inline_menu.Size = new System.Drawing.Size(139, 23);
            this.inline_menu.TabIndex = 2;
            // 
            // inline_datacod
            // 
            this.inline_datacod._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_datacod._ReadOnly = false;
            this.inline_datacod._Text = "";
            this.inline_datacod._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_datacod._UseImage = true;
            this.inline_datacod.BackColor = System.Drawing.Color.White;
            this.inline_datacod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_datacod.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inline_datacod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_datacod.Location = new System.Drawing.Point(5, 40);
            this.inline_datacod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_datacod.Name = "inline_datacod";
            this.inline_datacod.Size = new System.Drawing.Size(120, 23);
            this.inline_datacod.TabIndex = 1;
            // 
            // xDatagrid1
            // 
            this.xDatagrid1.AllowSortByColumnHeaderClicked = false;
            this.xDatagrid1.AllowUserToAddRows = false;
            this.xDatagrid1.AllowUserToDeleteRows = false;
            this.xDatagrid1.AllowUserToResizeColumns = false;
            this.xDatagrid1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.xDatagrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.xDatagrid1.ColumnHeadersHeight = 28;
            this.xDatagrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.xDatagrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_username,
            this.col_datacod,
            this.col_menu_id,
            this.col_menu_desc,
            this.col_read,
            this.col_add,
            this.col_edit,
            this.col_delete,
            this.col_print,
            this.col_approve});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.xDatagrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.xDatagrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xDatagrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.xDatagrid1.EnableHeadersVisualStyles = false;
            this.xDatagrid1.FillEmptyRow = false;
            this.xDatagrid1.FocusedRowBorderRedLine = false;
            this.xDatagrid1.Location = new System.Drawing.Point(3, 3);
            this.xDatagrid1.MultiSelect = false;
            this.xDatagrid1.Name = "xDatagrid1";
            this.xDatagrid1.ReadOnly = true;
            this.xDatagrid1.RowHeadersVisible = false;
            this.xDatagrid1.RowTemplate.Height = 26;
            this.xDatagrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.xDatagrid1.Size = new System.Drawing.Size(848, 302);
            this.xDatagrid1.StandardTab = true;
            this.xDatagrid1.TabIndex = 0;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_username
            // 
            this.col_username.DataPropertyName = "username";
            this.col_username.HeaderText = "User Name";
            this.col_username.Name = "col_username";
            this.col_username.ReadOnly = true;
            this.col_username.Visible = false;
            // 
            // col_datacod
            // 
            this.col_datacod.DataPropertyName = "datacod";
            this.col_datacod.HeaderText = "รหัสข้อมูล";
            this.col_datacod.MinimumWidth = 120;
            this.col_datacod.Name = "col_datacod";
            this.col_datacod.ReadOnly = true;
            this.col_datacod.Width = 120;
            // 
            // col_menu_id
            // 
            this.col_menu_id.DataPropertyName = "menu_id";
            this.col_menu_id.HeaderText = "เมนู";
            this.col_menu_id.MinimumWidth = 140;
            this.col_menu_id.Name = "col_menu_id";
            this.col_menu_id.ReadOnly = true;
            this.col_menu_id.Width = 140;
            // 
            // col_menu_desc
            // 
            this.col_menu_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_menu_desc.HeaderText = "";
            this.col_menu_desc.MinimumWidth = 120;
            this.col_menu_desc.Name = "col_menu_desc";
            this.col_menu_desc.ReadOnly = true;
            // 
            // col_read
            // 
            this.col_read.DataPropertyName = "read";
            this.col_read.HeaderText = "อ่าน";
            this.col_read.MinimumWidth = 50;
            this.col_read.Name = "col_read";
            this.col_read.ReadOnly = true;
            this.col_read.Width = 50;
            // 
            // col_add
            // 
            this.col_add.DataPropertyName = "add";
            this.col_add.HeaderText = "เพิ่ม";
            this.col_add.MinimumWidth = 50;
            this.col_add.Name = "col_add";
            this.col_add.ReadOnly = true;
            this.col_add.Width = 50;
            // 
            // col_edit
            // 
            this.col_edit.DataPropertyName = "edit";
            this.col_edit.HeaderText = "แก้ไข";
            this.col_edit.MinimumWidth = 50;
            this.col_edit.Name = "col_edit";
            this.col_edit.ReadOnly = true;
            this.col_edit.Width = 50;
            // 
            // col_delete
            // 
            this.col_delete.DataPropertyName = "delete";
            this.col_delete.HeaderText = "ลบ";
            this.col_delete.MinimumWidth = 50;
            this.col_delete.Name = "col_delete";
            this.col_delete.ReadOnly = true;
            this.col_delete.Width = 50;
            // 
            // col_print
            // 
            this.col_print.DataPropertyName = "print";
            this.col_print.HeaderText = "พิมพ์";
            this.col_print.MinimumWidth = 50;
            this.col_print.Name = "col_print";
            this.col_print.ReadOnly = true;
            this.col_print.Width = 50;
            // 
            // col_approve
            // 
            this.col_approve.DataPropertyName = "approve";
            this.col_approve.HeaderText = "รับรอง";
            this.col_approve.MinimumWidth = 50;
            this.col_approve.Name = "col_approve";
            this.col_approve.ReadOnly = true;
            this.col_approve.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "รหัสผู้ใช้";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "กลุ่มของผู้ใช้";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "ระดับอนุมัติ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "สถานะผู้ใช้";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "ตรวจสอบสิทธิ";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(116, 58);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(90, 23);
            this.txtUserId.TabIndex = 9;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(210, 58);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(285, 23);
            this.txtUserName.TabIndex = 9;
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(116, 83);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.ReadOnly = true;
            this.txtGroup.Size = new System.Drawing.Size(90, 23);
            this.txtGroup.TabIndex = 9;
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(116, 108);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(25, 23);
            this.txtLevel.TabIndex = 9;
            // 
            // txtSecure
            // 
            this.txtSecure.Location = new System.Drawing.Point(116, 133);
            this.txtSecure.Name = "txtSecure";
            this.txtSecure.ReadOnly = true;
            this.txtSecure.Size = new System.Drawing.Size(150, 23);
            this.txtSecure.TabIndex = 9;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(116, 158);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(150, 23);
            this.txtStatus.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(20, 184);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5);
            this.label6.Size = new System.Drawing.Size(475, 35);
            this.label6.TabIndex = 10;
            this.label6.Text = "หมายเหตุ : รหัสผู้ใช้งาน และ รายละเอียดต่าง ๆ นี้ถูกกำหนดไว้ในโปรแกรมเอ็กซ์เพรส";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserGroup
            // 
            this.lblUserGroup.AutoSize = true;
            this.lblUserGroup.Location = new System.Drawing.Point(212, 86);
            this.lblUserGroup.Name = "lblUserGroup";
            this.lblUserGroup.Size = new System.Drawing.Size(26, 16);
            this.lblUserGroup.TabIndex = 8;
            this.lblUserGroup.Text = "xxx";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(212, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(274, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "[ 0=พนักงาน  5=หัวหน้าแผนก  9=ผู้จัดการระบบ ]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "เมนูเป็นภาษา";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(439, 158);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.ReadOnly = true;
            this.txtLanguage.Size = new System.Drawing.Size(56, 23);
            this.txtLanguage.TabIndex = 9;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(307, 40);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(45, 22);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(358, 40);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(45, 22);
            this.btnEditItem.TabIndex = 4;
            this.btnEditItem.Text = "Edit";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(409, 40);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(53, 22);
            this.btnDeleteItem.TabIndex = 4;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // FormSecure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 570);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtSecure);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblUserGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSecure";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "กำหนดสิทธิ์ผู้ใช้งาน";
            this.Load += new System.EventHandler(this.FormSecure_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xDatagrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private System.Windows.Forms.ToolStripSplitButton btnSearch;
        private System.Windows.Forms.ToolStripMenuItem btnInquiryAll;
        private System.Windows.Forms.ToolStripMenuItem btnInquiryRest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.TextBox txtSecure;
        private System.Windows.Forms.TextBox txtStatus;
        private CC.XDatagrid xDatagrid1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUserGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_datacod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_menu_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_menu_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_read;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_approve;
        private CC.XBrowseBox inline_menu;
        private CC.XBrowseBox inline_datacod;
        private CC.XDropdownList inline_approve;
        private CC.XDropdownList inline_print;
        private CC.XDropdownList inline_delete;
        private CC.XDropdownList inline_edit;
        private CC.XDropdownList inline_add;
        private CC.XDropdownList inline_read;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnAddItem;
    }
}