namespace XPump.SubForm
{
    partial class FormIstab
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
            this.inline_isdayend = new CC.XDropdownList();
            this.inline_isshiftsales = new CC.XDropdownList();
            this.inline_typdes2 = new CC.XTextEdit();
            this.inline_typdes = new CC.XTextEdit();
            this.inline_shortnam2 = new CC.XTextEdit();
            this.inline_shortnam = new CC.XTextEdit();
            this.inline_typcod = new CC.XTextEdit();
            this.dgv = new CC.XDatagrid();
            this.col_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_istab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tabtyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_typcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shortnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shortnam2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_typdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_typdes2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_is_shiftsales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_is_dayend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_creby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cretime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStrip1.Size = new System.Drawing.Size(859, 43);
            this.toolStrip1.TabIndex = 5;
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
            this.btnFirst.Enabled = false;
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
            this.btnPrevious.Enabled = false;
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
            this.btnNext.Enabled = false;
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
            this.btnLast.Enabled = false;
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
            this.toolStripSeparator2.Visible = false;
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
            this.panel1.Controls.Add(this.inline_isdayend);
            this.panel1.Controls.Add(this.inline_isshiftsales);
            this.panel1.Controls.Add(this.inline_typdes2);
            this.panel1.Controls.Add(this.inline_typdes);
            this.panel1.Controls.Add(this.inline_shortnam2);
            this.panel1.Controls.Add(this.inline_shortnam);
            this.panel1.Controls.Add(this.inline_typcod);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 436);
            this.panel1.TabIndex = 6;
            // 
            // inline_isdayend
            // 
            this.inline_isdayend._ReadOnly = false;
            this.inline_isdayend._SelectedItem = null;
            this.inline_isdayend._Text = "";
            this.inline_isdayend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_isdayend.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_isdayend.Location = new System.Drawing.Point(800, 50);
            this.inline_isdayend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_isdayend.Name = "inline_isdayend";
            this.inline_isdayend.Size = new System.Drawing.Size(58, 23);
            this.inline_isdayend.TabIndex = 6;
            this.inline_isdayend._SelectedItemChanged += new System.EventHandler(this.inline_isdayend__SelectedItemChanged);
            // 
            // inline_isshiftsales
            // 
            this.inline_isshiftsales._ReadOnly = false;
            this.inline_isshiftsales._SelectedItem = null;
            this.inline_isshiftsales._Text = "";
            this.inline_isshiftsales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_isshiftsales.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_isshiftsales.Location = new System.Drawing.Point(740, 50);
            this.inline_isshiftsales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_isshiftsales.Name = "inline_isshiftsales";
            this.inline_isshiftsales.Size = new System.Drawing.Size(58, 23);
            this.inline_isshiftsales.TabIndex = 5;
            this.inline_isshiftsales._SelectedItemChanged += new System.EventHandler(this.inline_isshiftsales__SelectedItemChanged);
            // 
            // inline_typdes2
            // 
            this.inline_typdes2._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typdes2._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_typdes2._MaxLength = 50;
            this.inline_typdes2._ReadOnly = false;
            this.inline_typdes2._Text = "";
            this.inline_typdes2._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_typdes2.BackColor = System.Drawing.Color.White;
            this.inline_typdes2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typdes2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_typdes2.Location = new System.Drawing.Point(532, 50);
            this.inline_typdes2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_typdes2.Name = "inline_typdes2";
            this.inline_typdes2.Size = new System.Drawing.Size(207, 23);
            this.inline_typdes2.TabIndex = 4;
            this.inline_typdes2._TextChanged += new System.EventHandler(this.inline_typdes2__TextChanged);
            // 
            // inline_typdes
            // 
            this.inline_typdes._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typdes._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_typdes._MaxLength = 50;
            this.inline_typdes._ReadOnly = false;
            this.inline_typdes._Text = "";
            this.inline_typdes._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_typdes.BackColor = System.Drawing.Color.White;
            this.inline_typdes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typdes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_typdes.Location = new System.Drawing.Point(325, 50);
            this.inline_typdes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_typdes.Name = "inline_typdes";
            this.inline_typdes.Size = new System.Drawing.Size(205, 23);
            this.inline_typdes.TabIndex = 3;
            this.inline_typdes._TextChanged += new System.EventHandler(this.inline_typdes__TextChanged);
            // 
            // inline_shortnam2
            // 
            this.inline_shortnam2._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_shortnam2._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_shortnam2._MaxLength = 15;
            this.inline_shortnam2._ReadOnly = false;
            this.inline_shortnam2._Text = "";
            this.inline_shortnam2._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_shortnam2.BackColor = System.Drawing.Color.White;
            this.inline_shortnam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_shortnam2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_shortnam2.Location = new System.Drawing.Point(193, 50);
            this.inline_shortnam2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_shortnam2.Name = "inline_shortnam2";
            this.inline_shortnam2.Size = new System.Drawing.Size(129, 23);
            this.inline_shortnam2.TabIndex = 2;
            this.inline_shortnam2._TextChanged += new System.EventHandler(this.inline_shortnam2__TextChanged);
            // 
            // inline_shortnam
            // 
            this.inline_shortnam._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_shortnam._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_shortnam._MaxLength = 15;
            this.inline_shortnam._ReadOnly = false;
            this.inline_shortnam._Text = "";
            this.inline_shortnam._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_shortnam.BackColor = System.Drawing.Color.White;
            this.inline_shortnam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_shortnam.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_shortnam.Location = new System.Drawing.Point(66, 50);
            this.inline_shortnam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_shortnam.Name = "inline_shortnam";
            this.inline_shortnam.Size = new System.Drawing.Size(124, 23);
            this.inline_shortnam.TabIndex = 1;
            this.inline_shortnam._TextChanged += new System.EventHandler(this.inline_shortnam__TextChanged);
            // 
            // inline_typcod
            // 
            this.inline_typcod._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typcod._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_typcod._MaxLength = 4;
            this.inline_typcod._ReadOnly = false;
            this.inline_typcod._Text = "";
            this.inline_typcod._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_typcod.BackColor = System.Drawing.Color.White;
            this.inline_typcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_typcod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_typcod.Location = new System.Drawing.Point(3, 50);
            this.inline_typcod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_typcod.Name = "inline_typcod";
            this.inline_typcod.Size = new System.Drawing.Size(60, 23);
            this.inline_typcod.TabIndex = 0;
            this.inline_typcod._TextChanged += new System.EventHandler(this.inline_typcod__TextChanged);
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
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_working_express_db,
            this.col_istab,
            this.col_id,
            this.col_tabtyp,
            this.col_typcod,
            this.col_shortnam,
            this.col_shortnam2,
            this.col_typdes,
            this.col_typdes2,
            this.col_is_shiftsales,
            this.col_is_dayend,
            this.col_creby,
            this.col_cretime,
            this.col_chgby,
            this.col_chgtime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.dgv.Size = new System.Drawing.Size(859, 436);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
            // 
            // col_working_express_db
            // 
            this.col_working_express_db.DataPropertyName = "working_express_db";
            this.col_working_express_db.HeaderText = "Working Express DB";
            this.col_working_express_db.Name = "col_working_express_db";
            this.col_working_express_db.ReadOnly = true;
            this.col_working_express_db.Visible = false;
            // 
            // col_istab
            // 
            this.col_istab.DataPropertyName = "istab";
            this.col_istab.HeaderText = "Istab";
            this.col_istab.Name = "col_istab";
            this.col_istab.ReadOnly = true;
            this.col_istab.Visible = false;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_tabtyp
            // 
            this.col_tabtyp.DataPropertyName = "tabtyp";
            this.col_tabtyp.HeaderText = "Tabtyp";
            this.col_tabtyp.Name = "col_tabtyp";
            this.col_tabtyp.ReadOnly = true;
            this.col_tabtyp.Visible = false;
            // 
            // col_typcod
            // 
            this.col_typcod.DataPropertyName = "typcod";
            this.col_typcod.HeaderText = "รหัส";
            this.col_typcod.MinimumWidth = 60;
            this.col_typcod.Name = "col_typcod";
            this.col_typcod.ReadOnly = true;
            this.col_typcod.Width = 60;
            // 
            // col_shortnam
            // 
            this.col_shortnam.DataPropertyName = "shortnam";
            this.col_shortnam.HeaderText = "ชื่อย่อ(ไทย)";
            this.col_shortnam.MinimumWidth = 130;
            this.col_shortnam.Name = "col_shortnam";
            this.col_shortnam.ReadOnly = true;
            this.col_shortnam.Width = 130;
            // 
            // col_shortnam2
            // 
            this.col_shortnam2.DataPropertyName = "shortnam2";
            this.col_shortnam2.HeaderText = "ชื่อย่อ(Eng.)";
            this.col_shortnam2.MinimumWidth = 130;
            this.col_shortnam2.Name = "col_shortnam2";
            this.col_shortnam2.ReadOnly = true;
            this.col_shortnam2.Width = 130;
            // 
            // col_typdes
            // 
            this.col_typdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_typdes.DataPropertyName = "typdes";
            this.col_typdes.HeaderText = "ชื่อเต็ม(ไทย)";
            this.col_typdes.Name = "col_typdes";
            this.col_typdes.ReadOnly = true;
            // 
            // col_typdes2
            // 
            this.col_typdes2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_typdes2.DataPropertyName = "typdes2";
            this.col_typdes2.HeaderText = "ชื่อเต็ม(Eng.)";
            this.col_typdes2.Name = "col_typdes2";
            this.col_typdes2.ReadOnly = true;
            // 
            // col_is_shiftsales
            // 
            this.col_is_shiftsales.DataPropertyName = "is_shiftsales";
            this.col_is_shiftsales.HeaderText = "Is For Shiftsales";
            this.col_is_shiftsales.MinimumWidth = 60;
            this.col_is_shiftsales.Name = "col_is_shiftsales";
            this.col_is_shiftsales.ReadOnly = true;
            this.col_is_shiftsales.Width = 60;
            // 
            // col_is_dayend
            // 
            this.col_is_dayend.DataPropertyName = "is_dayend";
            this.col_is_dayend.HeaderText = "Is For Dayend";
            this.col_is_dayend.MinimumWidth = 60;
            this.col_is_dayend.Name = "col_is_dayend";
            this.col_is_dayend.ReadOnly = true;
            this.col_is_dayend.Width = 60;
            // 
            // col_creby
            // 
            this.col_creby.DataPropertyName = "creby";
            this.col_creby.HeaderText = "Creted By";
            this.col_creby.Name = "col_creby";
            this.col_creby.ReadOnly = true;
            this.col_creby.Visible = false;
            // 
            // col_cretime
            // 
            this.col_cretime.DataPropertyName = "cretime";
            this.col_cretime.HeaderText = "Created Time";
            this.col_cretime.Name = "col_cretime";
            this.col_cretime.ReadOnly = true;
            this.col_cretime.Visible = false;
            // 
            // col_chgby
            // 
            this.col_chgby.DataPropertyName = "chgby";
            this.col_chgby.HeaderText = "Changed By";
            this.col_chgby.Name = "col_chgby";
            this.col_chgby.ReadOnly = true;
            this.col_chgby.Visible = false;
            // 
            // col_chgtime
            // 
            this.col_chgtime.DataPropertyName = "chgtime";
            this.col_chgtime.HeaderText = "Changed Time";
            this.col_chgtime.Name = "col_chgtime";
            this.col_chgtime.ReadOnly = true;
            this.col_chgtime.Visible = false;
            // 
            // FormIstab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 479);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(610, 200);
            this.Name = "FormIstab";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ตารางข้อมูล";
            this.Load += new System.EventHandler(this.FormIstab_Load);
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
        private System.Windows.Forms.Panel panel1;
        private CC.XDatagrid dgv;
        private CC.XTextEdit inline_typdes2;
        private CC.XTextEdit inline_typdes;
        private CC.XTextEdit inline_shortnam2;
        private CC.XTextEdit inline_shortnam;
        private CC.XTextEdit inline_typcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_istab;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tabtyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_typcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shortnam;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shortnam2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_typdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_typdes2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_is_shiftsales;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_is_dayend;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_creby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cretime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgtime;
        private CC.XDropdownList inline_isdayend;
        private CC.XDropdownList inline_isshiftsales;
    }
}