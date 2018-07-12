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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSecure));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.inline_approve = new CC.XDropdownList();
            this.inline_print = new CC.XDropdownList();
            this.inline_delete = new CC.XDropdownList();
            this.inline_datacod = new CC.XBrowseBox();
            this.inline_menu = new CC.XBrowseBox();
            this.inline_edit = new CC.XDropdownList();
            this.inline_add = new CC.XDropdownList();
            this.inline_read = new CC.XDropdownList();
            this.dgv = new CC.XDatagrid();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_datacod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_modcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_moddesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_moddesc_en = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_read = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_add = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_edit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_print = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_approve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_scacclv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_scmodul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_scmodul_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnItemF8 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnItemF7 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
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
            this.btnItem,
            this.btnRefresh});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.TabStop = false;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.inline_approve);
            this.tabPage1.Controls.Add(this.inline_print);
            this.tabPage1.Controls.Add(this.inline_delete);
            this.tabPage1.Controls.Add(this.inline_datacod);
            this.tabPage1.Controls.Add(this.inline_menu);
            this.tabPage1.Controls.Add(this.inline_edit);
            this.tabPage1.Controls.Add(this.inline_add);
            this.tabPage1.Controls.Add(this.inline_read);
            this.tabPage1.Controls.Add(this.dgv);
            this.tabPage1.Controls.Add(this.btnDeleteItem);
            this.tabPage1.Controls.Add(this.btnEditItem);
            this.tabPage1.Controls.Add(this.btnAddItem);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // inline_approve
            // 
            this.inline_approve._ReadOnly = false;
            this.inline_approve._SelectedItem = null;
            this.inline_approve._Text = "";
            resources.ApplyResources(this.inline_approve, "inline_approve");
            this.inline_approve.BackColor = System.Drawing.Color.White;
            this.inline_approve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_approve.Name = "inline_approve";
            this.inline_approve._SelectedItemChanged += new System.EventHandler(this.inline_approve__SelectedItemChanged);
            // 
            // inline_print
            // 
            this.inline_print._ReadOnly = false;
            this.inline_print._SelectedItem = null;
            this.inline_print._Text = "";
            resources.ApplyResources(this.inline_print, "inline_print");
            this.inline_print.BackColor = System.Drawing.Color.White;
            this.inline_print.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_print.Name = "inline_print";
            this.inline_print._SelectedItemChanged += new System.EventHandler(this.inline_print__SelectedItemChanged);
            // 
            // inline_delete
            // 
            this.inline_delete._ReadOnly = false;
            this.inline_delete._SelectedItem = null;
            this.inline_delete._Text = "";
            resources.ApplyResources(this.inline_delete, "inline_delete");
            this.inline_delete.BackColor = System.Drawing.Color.White;
            this.inline_delete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_delete.Name = "inline_delete";
            this.inline_delete._SelectedItemChanged += new System.EventHandler(this.inline_delete__SelectedItemChanged);
            // 
            // inline_datacod
            // 
            this.inline_datacod._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_datacod._CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inline_datacod._ReadOnly = false;
            this.inline_datacod._Text = "";
            this.inline_datacod._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_datacod._UseImage = true;
            resources.ApplyResources(this.inline_datacod, "inline_datacod");
            this.inline_datacod.BackColor = System.Drawing.Color.White;
            this.inline_datacod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_datacod.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inline_datacod.Name = "inline_datacod";
            this.inline_datacod._ButtonClick += new System.EventHandler(this.inline_datacod__ButtonClick);
            this.inline_datacod._Leave += new System.EventHandler(this.inline_datacod__Leave);
            this.inline_datacod._TextChanged += new System.EventHandler(this.inline_datacod__TextChanged);
            // 
            // inline_menu
            // 
            this.inline_menu._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_menu._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_menu._ReadOnly = false;
            this.inline_menu._Text = "";
            this.inline_menu._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_menu._UseImage = true;
            resources.ApplyResources(this.inline_menu, "inline_menu");
            this.inline_menu.BackColor = System.Drawing.Color.White;
            this.inline_menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_menu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inline_menu.Name = "inline_menu";
            this.inline_menu._ButtonClick += new System.EventHandler(this.inline_menu__ButtonClick);
            this.inline_menu._Leave += new System.EventHandler(this.inline_menu__Leave);
            this.inline_menu._TextChanged += new System.EventHandler(this.inline_menu__TextChanged);
            // 
            // inline_edit
            // 
            this.inline_edit._ReadOnly = false;
            this.inline_edit._SelectedItem = null;
            this.inline_edit._Text = "";
            resources.ApplyResources(this.inline_edit, "inline_edit");
            this.inline_edit.BackColor = System.Drawing.Color.White;
            this.inline_edit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_edit.Name = "inline_edit";
            this.inline_edit._SelectedItemChanged += new System.EventHandler(this.inline_edit__SelectedItemChanged);
            // 
            // inline_add
            // 
            this.inline_add._ReadOnly = false;
            this.inline_add._SelectedItem = null;
            this.inline_add._Text = "";
            resources.ApplyResources(this.inline_add, "inline_add");
            this.inline_add.BackColor = System.Drawing.Color.White;
            this.inline_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_add.Name = "inline_add";
            this.inline_add._SelectedItemChanged += new System.EventHandler(this.inline_add__SelectedItemChanged);
            // 
            // inline_read
            // 
            this.inline_read._ReadOnly = false;
            this.inline_read._SelectedItem = null;
            this.inline_read._Text = "";
            resources.ApplyResources(this.inline_read, "inline_read");
            this.inline_read.BackColor = System.Drawing.Color.White;
            this.inline_read.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_read.Name = "inline_read";
            this.inline_read._SelectedItemChanged += new System.EventHandler(this.inline_read__SelectedItemChanged);
            // 
            // dgv
            // 
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_username,
            this.col_datacod,
            this.col_modcod,
            this.col_moddesc,
            this.col_moddesc_en,
            this.col_read,
            this.col_add,
            this.col_edit,
            this.col_delete,
            this.col_print,
            this.col_approve,
            this.col_scacclv,
            this.col_scmodul,
            this.col_scmodul_id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.FillEmptyRow = false;
            this.dgv.FocusedRowBorderRedLine = true;
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 26;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.StandardTab = true;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            this.dgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
            // 
            // btnDeleteItem
            // 
            resources.ApplyResources(this.btnDeleteItem, "btnDeleteItem");
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.TabStop = false;
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnEditItem
            // 
            resources.ApplyResources(this.btnEditItem, "btnEditItem");
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.TabStop = false;
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnAddItem
            // 
            resources.ApplyResources(this.btnAddItem, "btnAddItem");
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.TabStop = false;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtUserId
            // 
            resources.ApplyResources(this.txtUserId, "txtUserId");
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.TabStop = false;
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.TabStop = false;
            // 
            // txtGroup
            // 
            resources.ApplyResources(this.txtGroup, "txtGroup");
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.ReadOnly = true;
            this.txtGroup.TabStop = false;
            // 
            // txtLevel
            // 
            resources.ApplyResources(this.txtLevel, "txtLevel");
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.TabStop = false;
            // 
            // txtSecure
            // 
            resources.ApplyResources(this.txtSecure, "txtSecure");
            this.txtSecure.Name = "txtSecure";
            this.txtSecure.ReadOnly = true;
            this.txtSecure.TabStop = false;
            // 
            // txtStatus
            // 
            resources.ApplyResources(this.txtStatus, "txtStatus");
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Name = "label6";
            // 
            // lblUserGroup
            // 
            resources.ApplyResources(this.lblUserGroup, "lblUserGroup");
            this.lblUserGroup.Name = "lblUserGroup";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtLanguage
            // 
            resources.ApplyResources(this.txtLanguage, "txtLanguage");
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.ReadOnly = true;
            this.txtLanguage.TabStop = false;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            resources.ApplyResources(this.col_id, "col_id");
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_username
            // 
            this.col_username.DataPropertyName = "username";
            resources.ApplyResources(this.col_username, "col_username");
            this.col_username.Name = "col_username";
            this.col_username.ReadOnly = true;
            // 
            // col_datacod
            // 
            this.col_datacod.DataPropertyName = "datacod";
            resources.ApplyResources(this.col_datacod, "col_datacod");
            this.col_datacod.Name = "col_datacod";
            this.col_datacod.ReadOnly = true;
            // 
            // col_modcod
            // 
            this.col_modcod.DataPropertyName = "modcod";
            resources.ApplyResources(this.col_modcod, "col_modcod");
            this.col_modcod.Name = "col_modcod";
            this.col_modcod.ReadOnly = true;
            // 
            // col_moddesc
            // 
            this.col_moddesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_moddesc.DataPropertyName = "moddesc";
            resources.ApplyResources(this.col_moddesc, "col_moddesc");
            this.col_moddesc.Name = "col_moddesc";
            this.col_moddesc.ReadOnly = true;
            // 
            // col_moddesc_en
            // 
            this.col_moddesc_en.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_moddesc_en.DataPropertyName = "moddesc_en";
            resources.ApplyResources(this.col_moddesc_en, "col_moddesc_en");
            this.col_moddesc_en.Name = "col_moddesc_en";
            this.col_moddesc_en.ReadOnly = true;
            // 
            // col_read
            // 
            this.col_read.DataPropertyName = "read";
            resources.ApplyResources(this.col_read, "col_read");
            this.col_read.Name = "col_read";
            this.col_read.ReadOnly = true;
            // 
            // col_add
            // 
            this.col_add.DataPropertyName = "add";
            resources.ApplyResources(this.col_add, "col_add");
            this.col_add.Name = "col_add";
            this.col_add.ReadOnly = true;
            // 
            // col_edit
            // 
            this.col_edit.DataPropertyName = "edit";
            resources.ApplyResources(this.col_edit, "col_edit");
            this.col_edit.Name = "col_edit";
            this.col_edit.ReadOnly = true;
            // 
            // col_delete
            // 
            this.col_delete.DataPropertyName = "delete";
            resources.ApplyResources(this.col_delete, "col_delete");
            this.col_delete.Name = "col_delete";
            this.col_delete.ReadOnly = true;
            // 
            // col_print
            // 
            this.col_print.DataPropertyName = "print";
            resources.ApplyResources(this.col_print, "col_print");
            this.col_print.Name = "col_print";
            this.col_print.ReadOnly = true;
            // 
            // col_approve
            // 
            this.col_approve.DataPropertyName = "approve";
            resources.ApplyResources(this.col_approve, "col_approve");
            this.col_approve.Name = "col_approve";
            this.col_approve.ReadOnly = true;
            // 
            // col_scacclv
            // 
            this.col_scacclv.DataPropertyName = "scacclv";
            resources.ApplyResources(this.col_scacclv, "col_scacclv");
            this.col_scacclv.Name = "col_scacclv";
            this.col_scacclv.ReadOnly = true;
            // 
            // col_scmodul
            // 
            this.col_scmodul.DataPropertyName = "scmodul";
            resources.ApplyResources(this.col_scmodul, "col_scmodul");
            this.col_scmodul.Name = "col_scmodul";
            this.col_scmodul.ReadOnly = true;
            // 
            // col_scmodul_id
            // 
            this.col_scmodul_id.DataPropertyName = "scmodul_id";
            resources.ApplyResources(this.col_scmodul_id, "col_scmodul_id");
            this.col_scmodul_id.Name = "col_scmodul_id";
            this.col_scmodul_id.ReadOnly = true;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::XPump.Properties.Resources.trash;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            this.btnStop.Name = "btnStop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFirst
            // 
            resources.ApplyResources(this.btnFirst, "btnFirst");
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = global::XPump.Properties.Resources.first;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            resources.ApplyResources(this.btnPrevious, "btnPrevious");
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = global::XPump.Properties.Resources.previous;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::XPump.Properties.Resources.next;
            this.btnNext.Name = "btnNext";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            resources.ApplyResources(this.btnLast, "btnLast");
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = global::XPump.Properties.Resources.last;
            this.btnLast.Name = "btnLast";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.DropDownButtonWidth = 15;
            this.btnSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInquiryAll,
            this.btnInquiryRest});
            this.btnSearch.Image = global::XPump.Properties.Resources.search;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ButtonClick += new System.EventHandler(this.btnSearch_ButtonClick);
            // 
            // btnInquiryAll
            // 
            resources.ApplyResources(this.btnInquiryAll, "btnInquiryAll");
            this.btnInquiryAll.Name = "btnInquiryAll";
            this.btnInquiryAll.Click += new System.EventHandler(this.btnInquiryAll_Click);
            // 
            // btnInquiryRest
            // 
            resources.ApplyResources(this.btnInquiryRest, "btnInquiryRest");
            this.btnInquiryRest.Name = "btnInquiryRest";
            this.btnInquiryRest.Click += new System.EventHandler(this.btnInquiryRest_Click);
            // 
            // btnItem
            // 
            resources.ApplyResources(this.btnItem, "btnItem");
            this.btnItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnItemF8,
            this.btnItemF7});
            this.btnItem.Image = global::XPump.Properties.Resources.item;
            this.btnItem.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.btnItem.Name = "btnItem";
            // 
            // btnItemF8
            // 
            resources.ApplyResources(this.btnItemF8, "btnItemF8");
            this.btnItemF8.Name = "btnItemF8";
            this.btnItemF8.Click += new System.EventHandler(this.btnItemF8_Click);
            // 
            // btnItemF7
            // 
            resources.ApplyResources(this.btnItemF7, "btnItemF7");
            this.btnItemF7.Name = "btnItemF7";
            this.btnItemF7.Click += new System.EventHandler(this.btnItemF7_Click);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::XPump.Properties.Resources.refresh;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormSecure
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.KeyPreview = true;
            this.Name = "FormSecure";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormSecure_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUserGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLanguage;
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
        private System.Windows.Forms.TabPage tabPage2;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.ToolStripDropDownButton btnItem;
        private System.Windows.Forms.ToolStripMenuItem btnItemF8;
        private System.Windows.Forms.ToolStripMenuItem btnItemF7;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_datacod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_modcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_moddesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_moddesc_en;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_read;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_approve;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_scacclv;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_scmodul;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_scmodul_id;
    }
}