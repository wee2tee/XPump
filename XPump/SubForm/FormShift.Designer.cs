namespace XPump.SubForm
{
    partial class FormShift
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.inline_siv = new CC.XDropdownList();
            this.inline_shs = new CC.XDropdownList();
            this.inline_sai = new CC.XDropdownList();
            this.inline_prr = new CC.XDropdownList();
            this.inline_php = new CC.XDropdownList();
            this.inline_pae = new CC.XDropdownList();
            this.inline_end = new CC.XTimePicker();
            this.inline_start = new CC.XTimePicker();
            this.inline_desc = new CC.XTextEdit();
            this.inline_name = new CC.XTextEdit();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.dgv = new CC.XDatagrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_paeprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_phpprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_prrprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_saiprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shsprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sivprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.toolStripSeparator2,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(928, 43);
            this.toolStrip1.TabIndex = 0;
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
            this.toolStripSeparator1.Visible = false;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.inline_siv);
            this.panel1.Controls.Add(this.inline_shs);
            this.panel1.Controls.Add(this.inline_sai);
            this.panel1.Controls.Add(this.inline_prr);
            this.panel1.Controls.Add(this.inline_php);
            this.panel1.Controls.Add(this.inline_pae);
            this.panel1.Controls.Add(this.inline_end);
            this.panel1.Controls.Add(this.inline_start);
            this.panel1.Controls.Add(this.inline_desc);
            this.panel1.Controls.Add(this.inline_name);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 457);
            this.panel1.TabIndex = 2;
            // 
            // inline_siv
            // 
            this.inline_siv._ReadOnly = false;
            this.inline_siv._SelectedItem = null;
            this.inline_siv._Text = "";
            this.inline_siv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_siv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_siv.Location = new System.Drawing.Point(857, 90);
            this.inline_siv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_siv.Name = "inline_siv";
            this.inline_siv.Size = new System.Drawing.Size(65, 23);
            this.inline_siv.TabIndex = 4;
            this.inline_siv.Visible = false;
            this.inline_siv._SelectedItemChanged += new System.EventHandler(this.inline_siv__SelectedItemChanged);
            // 
            // inline_shs
            // 
            this.inline_shs._ReadOnly = false;
            this.inline_shs._SelectedItem = null;
            this.inline_shs._Text = "";
            this.inline_shs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_shs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_shs.Location = new System.Drawing.Point(788, 90);
            this.inline_shs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_shs.Name = "inline_shs";
            this.inline_shs.Size = new System.Drawing.Size(65, 23);
            this.inline_shs.TabIndex = 4;
            this.inline_shs.Visible = false;
            this.inline_shs._SelectedItemChanged += new System.EventHandler(this.inline_shs__SelectedItemChanged);
            // 
            // inline_sai
            // 
            this.inline_sai._ReadOnly = false;
            this.inline_sai._SelectedItem = null;
            this.inline_sai._Text = "";
            this.inline_sai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_sai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_sai.Location = new System.Drawing.Point(718, 90);
            this.inline_sai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_sai.Name = "inline_sai";
            this.inline_sai.Size = new System.Drawing.Size(65, 23);
            this.inline_sai.TabIndex = 4;
            this.inline_sai.Visible = false;
            this.inline_sai._SelectedItemChanged += new System.EventHandler(this.inline_sai__SelectedItemChanged);
            // 
            // inline_prr
            // 
            this.inline_prr._ReadOnly = false;
            this.inline_prr._SelectedItem = null;
            this.inline_prr._Text = "";
            this.inline_prr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_prr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_prr.Location = new System.Drawing.Point(647, 90);
            this.inline_prr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_prr.Name = "inline_prr";
            this.inline_prr.Size = new System.Drawing.Size(65, 23);
            this.inline_prr.TabIndex = 4;
            this.inline_prr.Visible = false;
            this.inline_prr._SelectedItemChanged += new System.EventHandler(this.inline_prr__SelectedItemChanged);
            // 
            // inline_php
            // 
            this.inline_php._ReadOnly = false;
            this.inline_php._SelectedItem = null;
            this.inline_php._Text = "";
            this.inline_php.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_php.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_php.Location = new System.Drawing.Point(578, 90);
            this.inline_php.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_php.Name = "inline_php";
            this.inline_php.Size = new System.Drawing.Size(65, 23);
            this.inline_php.TabIndex = 4;
            this.inline_php.Visible = false;
            this.inline_php._SelectedItemChanged += new System.EventHandler(this.inline_php__SelectedItemChanged);
            // 
            // inline_pae
            // 
            this.inline_pae._ReadOnly = false;
            this.inline_pae._SelectedItem = null;
            this.inline_pae._Text = "";
            this.inline_pae.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_pae.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_pae.Location = new System.Drawing.Point(509, 90);
            this.inline_pae.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_pae.Name = "inline_pae";
            this.inline_pae.Size = new System.Drawing.Size(65, 23);
            this.inline_pae.TabIndex = 4;
            this.inline_pae.Visible = false;
            this.inline_pae._SelectedItemChanged += new System.EventHandler(this.inline_pae__SelectedItemChanged);
            // 
            // inline_end
            // 
            this.inline_end.CustomFormat = "HH:mm:ss";
            this.inline_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inline_end.Location = new System.Drawing.Point(276, 90);
            this.inline_end.Name = "inline_end";
            this.inline_end.ShowUpDown = true;
            this.inline_end.Size = new System.Drawing.Size(80, 23);
            this.inline_end.TabIndex = 3;
            this.inline_end.Visible = false;
            this.inline_end.ValueChanged += new System.EventHandler(this.inline_end_ValueChanged);
            // 
            // inline_start
            // 
            this.inline_start.CustomFormat = "HH:mm:ss";
            this.inline_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inline_start.Location = new System.Drawing.Point(193, 90);
            this.inline_start.Name = "inline_start";
            this.inline_start.ShowUpDown = true;
            this.inline_start.Size = new System.Drawing.Size(80, 23);
            this.inline_start.TabIndex = 3;
            this.inline_start.Visible = false;
            this.inline_start.ValueChanged += new System.EventHandler(this.inline_start_ValueChanged);
            // 
            // inline_desc
            // 
            this.inline_desc._BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inline_desc._MaxLength = 50;
            this.inline_desc._ReadOnly = false;
            this.inline_desc._Text = "";
            this.inline_desc._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_desc.BackColor = System.Drawing.Color.White;
            this.inline_desc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_desc.Location = new System.Drawing.Point(357, 90);
            this.inline_desc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_desc.Name = "inline_desc";
            this.inline_desc.Size = new System.Drawing.Size(149, 23);
            this.inline_desc.TabIndex = 2;
            this.inline_desc.Visible = false;
            this.inline_desc._TextChanged += new System.EventHandler(this.inline_desc__TextChanged);
            // 
            // inline_name
            // 
            this.inline_name._BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inline_name._MaxLength = 20;
            this.inline_name._ReadOnly = false;
            this.inline_name._Text = "";
            this.inline_name._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_name.BackColor = System.Drawing.Color.White;
            this.inline_name.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_name.Location = new System.Drawing.Point(94, 89);
            this.inline_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_name.Name = "inline_name";
            this.inline_name.Size = new System.Drawing.Size(97, 23);
            this.inline_name.TabIndex = 2;
            this.inline_name.Visible = false;
            this.inline_name._TextChanged += new System.EventHandler(this.inline_name__TextChanged);
            this.inline_name._Leave += new System.EventHandler(this.inline_name__Leave);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::XPump.Properties.Resources.up_16;
            this.btnUp.Location = new System.Drawing.Point(51, 90);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(18, 21);
            this.btnUp.TabIndex = 5;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Visible = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::XPump.Properties.Resources.down_16;
            this.btnDown.Location = new System.Drawing.Point(71, 90);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(18, 21);
            this.btnDown.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnDown, "เลื่อนลง");
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Visible = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = true;
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
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_seq,
            this.col_name,
            this.col_start,
            this.col_end,
            this.col_desc,
            this.col_paeprefix,
            this.col_phpprefix,
            this.col_prrprefix,
            this.col_saiprefix,
            this.col_shsprefix,
            this.col_sivprefix,
            this.col_remark,
            this.col_state,
            this.col_shift,
            this.col_working_express_db});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.FillEmptyRow = false;
            this.dgv.FocusedRowBorderRedLine = true;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 26;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(928, 457);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 1;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_seq
            // 
            this.col_seq.DataPropertyName = "seq";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.col_seq.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_seq.HeaderText = "ลำดับ";
            this.col_seq.MinimumWidth = 90;
            this.col_seq.Name = "col_seq";
            this.col_seq.ReadOnly = true;
            this.col_seq.Visible = false;
            this.col_seq.Width = 90;
            // 
            // col_name
            // 
            this.col_name.DataPropertyName = "name";
            this.col_name.HeaderText = "ชื่อผลัด";
            this.col_name.MinimumWidth = 100;
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            // 
            // col_start
            // 
            this.col_start.DataPropertyName = "starttime";
            dataGridViewCellStyle3.NullValue = null;
            this.col_start.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_start.HeaderText = "เวลาเริ่มต้น";
            this.col_start.MinimumWidth = 80;
            this.col_start.Name = "col_start";
            this.col_start.ReadOnly = true;
            this.col_start.Width = 80;
            // 
            // col_end
            // 
            this.col_end.DataPropertyName = "endtime";
            dataGridViewCellStyle4.NullValue = null;
            this.col_end.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_end.HeaderText = "เวลาสิ้นสุด";
            this.col_end.MinimumWidth = 80;
            this.col_end.Name = "col_end";
            this.col_end.ReadOnly = true;
            this.col_end.Width = 80;
            // 
            // col_desc
            // 
            this.col_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_desc.DataPropertyName = "description";
            this.col_desc.HeaderText = "รายละเอียด";
            this.col_desc.Name = "col_desc";
            this.col_desc.ReadOnly = true;
            // 
            // col_paeprefix
            // 
            this.col_paeprefix.DataPropertyName = "paeprefix";
            this.col_paeprefix.HeaderText = "จ่ายมัดจำ";
            this.col_paeprefix.MinimumWidth = 70;
            this.col_paeprefix.Name = "col_paeprefix";
            this.col_paeprefix.ReadOnly = true;
            this.col_paeprefix.Visible = false;
            this.col_paeprefix.Width = 70;
            // 
            // col_phpprefix
            // 
            this.col_phpprefix.DataPropertyName = "phpprefix";
            this.col_phpprefix.HeaderText = "ซื้อสด";
            this.col_phpprefix.MinimumWidth = 70;
            this.col_phpprefix.Name = "col_phpprefix";
            this.col_phpprefix.ReadOnly = true;
            this.col_phpprefix.Width = 70;
            // 
            // col_prrprefix
            // 
            this.col_prrprefix.DataPropertyName = "prrprefix";
            this.col_prrprefix.HeaderText = "ซื้อเชื่อ";
            this.col_prrprefix.MinimumWidth = 70;
            this.col_prrprefix.Name = "col_prrprefix";
            this.col_prrprefix.ReadOnly = true;
            this.col_prrprefix.Width = 70;
            // 
            // col_saiprefix
            // 
            this.col_saiprefix.DataPropertyName = "saiprefix";
            this.col_saiprefix.HeaderText = "รับมัดจำ";
            this.col_saiprefix.MinimumWidth = 70;
            this.col_saiprefix.Name = "col_saiprefix";
            this.col_saiprefix.ReadOnly = true;
            this.col_saiprefix.Visible = false;
            this.col_saiprefix.Width = 70;
            // 
            // col_shsprefix
            // 
            this.col_shsprefix.DataPropertyName = "shsprefix";
            this.col_shsprefix.HeaderText = "ขายสด";
            this.col_shsprefix.MinimumWidth = 70;
            this.col_shsprefix.Name = "col_shsprefix";
            this.col_shsprefix.ReadOnly = true;
            this.col_shsprefix.Width = 70;
            // 
            // col_sivprefix
            // 
            this.col_sivprefix.DataPropertyName = "sivprefix";
            this.col_sivprefix.HeaderText = "ขายเชื่อ";
            this.col_sivprefix.MinimumWidth = 70;
            this.col_sivprefix.Name = "col_sivprefix";
            this.col_sivprefix.ReadOnly = true;
            this.col_sivprefix.Width = 70;
            // 
            // col_remark
            // 
            this.col_remark.DataPropertyName = "remark";
            this.col_remark.HeaderText = "Remark";
            this.col_remark.Name = "col_remark";
            this.col_remark.ReadOnly = true;
            this.col_remark.Visible = false;
            // 
            // col_state
            // 
            this.col_state.DataPropertyName = "record_state";
            this.col_state.HeaderText = "Record State";
            this.col_state.Name = "col_state";
            this.col_state.ReadOnly = true;
            this.col_state.Visible = false;
            // 
            // col_shift
            // 
            this.col_shift.DataPropertyName = "shift";
            this.col_shift.HeaderText = "Shift";
            this.col_shift.Name = "col_shift";
            this.col_shift.ReadOnly = true;
            this.col_shift.Visible = false;
            // 
            // col_working_express_db
            // 
            this.col_working_express_db.DataPropertyName = "working_express_db";
            this.col_working_express_db.HeaderText = "Working Express DB";
            this.col_working_express_db.Name = "col_working_express_db";
            this.col_working_express_db.ReadOnly = true;
            this.col_working_express_db.Visible = false;
            // 
            // FormShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 200);
            this.Name = "FormShift";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "ShiftSetup";
            this.Text = "กำหนดผลัดพนักงาน";
            this.Load += new System.EventHandler(this.ShiftForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.Panel panel1;
        private CC.XTimePicker inline_end;
        private CC.XTimePicker inline_start;
        private CC.XTextEdit inline_desc;
        private CC.XTextEdit inline_name;
        private CC.XDropdownList inline_siv;
        private CC.XDropdownList inline_shs;
        private CC.XDropdownList inline_sai;
        private CC.XDropdownList inline_prr;
        private CC.XDropdownList inline_php;
        private CC.XDropdownList inline_pae;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_paeprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_phpprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_prrprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_saiprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shsprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sivprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shift;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_working_express_db;
    }
}