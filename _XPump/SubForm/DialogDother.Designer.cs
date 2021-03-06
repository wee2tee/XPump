﻿namespace XPump.SubForm
{
    partial class DialogDother
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inline_nozzle = new CC.XBrowseBox();
            this.inline_qty = new CC.XNumEdit();
            this.inline_section = new CC.XDropdownList();
            this.inline_dother = new CC.XDropdownList();
            this.dgv = new CC.XDatagrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dother = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_typcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_creby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cretime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_istab_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_salessummary_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dayend_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_typdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.inline_nozzle);
            this.panel1.Controls.Add(this.inline_qty);
            this.panel1.Controls.Add(this.inline_section);
            this.panel1.Controls.Add(this.inline_dother);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 136);
            this.panel1.TabIndex = 0;
            // 
            // inline_nozzle
            // 
            this.inline_nozzle._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_nozzle._ReadOnly = false;
            this.inline_nozzle._Text = "";
            this.inline_nozzle._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inline_nozzle._UseImage = true;
            this.inline_nozzle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_nozzle.BackColor = System.Drawing.Color.White;
            this.inline_nozzle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_nozzle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inline_nozzle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_nozzle.Location = new System.Drawing.Point(1, 31);
            this.inline_nozzle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_nozzle.Name = "inline_nozzle";
            this.inline_nozzle.Size = new System.Drawing.Size(89, 23);
            this.inline_nozzle.TabIndex = 1;
            this.inline_nozzle._ButtonClick += new System.EventHandler(this.inline_nozzle__ButtonClick);
            this.inline_nozzle._Leave += new System.EventHandler(this.inline_nozzle__Leave);
            this.inline_nozzle._TextChanged += new System.EventHandler(this.inline_nozzle__TextChanged);
            // 
            // inline_qty
            // 
            this.inline_qty._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_qty._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_qty._DecimalDigit = 2;
            this.inline_qty._ForeColorReadOnlyState = System.Drawing.SystemColors.ControlText;
            this.inline_qty._MaximumValue = new decimal(new int[] {
            1410065407,
            2,
            0,
            262144});
            this.inline_qty._MaxLength = 30;
            this.inline_qty._ReadOnly = false;
            this.inline_qty._SelectionLength = 0;
            this.inline_qty._SelectionStart = 4;
            this.inline_qty._Text = "0.00";
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
            this.inline_qty.Location = new System.Drawing.Point(292, 31);
            this.inline_qty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_qty.Name = "inline_qty";
            this.inline_qty.Size = new System.Drawing.Size(98, 23);
            this.inline_qty.TabIndex = 4;
            this.inline_qty._ValueChanged += new System.EventHandler(this.inline_qty__ValueChanged);
            // 
            // inline_section
            // 
            this.inline_section._ReadOnly = false;
            this.inline_section._SelectedItem = null;
            this.inline_section._Text = "";
            this.inline_section.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_section.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_section.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_section.Location = new System.Drawing.Point(91, 31);
            this.inline_section.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_section.Name = "inline_section";
            this.inline_section.Size = new System.Drawing.Size(90, 23);
            this.inline_section.TabIndex = 2;
            this.inline_section._SelectedItemChanged += new System.EventHandler(this.inline_section__SelectedItemChanged);
            // 
            // inline_dother
            // 
            this.inline_dother._ReadOnly = false;
            this.inline_dother._SelectedItem = null;
            this.inline_dother._Text = "";
            this.inline_dother.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_dother.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_dother.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_dother.Location = new System.Drawing.Point(182, 31);
            this.inline_dother.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_dother.Name = "inline_dother";
            this.inline_dother.Size = new System.Drawing.Size(109, 23);
            this.inline_dother.TabIndex = 3;
            this.inline_dother._SelectedItemChanged += new System.EventHandler(this.inline_dother__SelectedItemChanged);
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv.ColumnHeadersHeight = 28;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_working_express_db,
            this.col_dother,
            this.col_typcod,
            this.col_creby,
            this.col_cretime,
            this.col_chgby,
            this.col_chgtime,
            this.col_istab_id,
            this.col_salessummary_id,
            this.col_dayend_id,
            this.col_section_id,
            this.col_nozzle_id,
            this.col_nozzle_name,
            this.col_section_name,
            this.col_typdes,
            this.col_qty});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle9;
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
            this.dgv.Size = new System.Drawing.Size(392, 136);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_working_express_db
            // 
            this.col_working_express_db.DataPropertyName = "working_express_db";
            this.col_working_express_db.HeaderText = "Working Express DB";
            this.col_working_express_db.Name = "col_working_express_db";
            this.col_working_express_db.ReadOnly = true;
            this.col_working_express_db.Visible = false;
            // 
            // col_dother
            // 
            this.col_dother.DataPropertyName = "dother";
            this.col_dother.HeaderText = "Dother";
            this.col_dother.Name = "col_dother";
            this.col_dother.ReadOnly = true;
            this.col_dother.Visible = false;
            // 
            // col_typcod
            // 
            this.col_typcod.DataPropertyName = "typcod";
            this.col_typcod.HeaderText = "Typcod";
            this.col_typcod.Name = "col_typcod";
            this.col_typcod.ReadOnly = true;
            this.col_typcod.Visible = false;
            // 
            // col_creby
            // 
            this.col_creby.DataPropertyName = "creby";
            this.col_creby.HeaderText = "Created By";
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
            // col_istab_id
            // 
            this.col_istab_id.DataPropertyName = "istab_id";
            this.col_istab_id.HeaderText = "Istab ID";
            this.col_istab_id.Name = "col_istab_id";
            this.col_istab_id.ReadOnly = true;
            this.col_istab_id.Visible = false;
            // 
            // col_salessummary_id
            // 
            this.col_salessummary_id.DataPropertyName = "salessummary_id";
            this.col_salessummary_id.HeaderText = "Salessummary ID";
            this.col_salessummary_id.Name = "col_salessummary_id";
            this.col_salessummary_id.ReadOnly = true;
            this.col_salessummary_id.Visible = false;
            // 
            // col_dayend_id
            // 
            this.col_dayend_id.DataPropertyName = "dayend_id";
            this.col_dayend_id.HeaderText = "Dayend ID";
            this.col_dayend_id.Name = "col_dayend_id";
            this.col_dayend_id.ReadOnly = true;
            this.col_dayend_id.Visible = false;
            // 
            // col_section_id
            // 
            this.col_section_id.DataPropertyName = "section_id";
            this.col_section_id.HeaderText = "Section ID";
            this.col_section_id.Name = "col_section_id";
            this.col_section_id.ReadOnly = true;
            this.col_section_id.Visible = false;
            // 
            // col_nozzle_id
            // 
            this.col_nozzle_id.DataPropertyName = "nozzle_id";
            this.col_nozzle_id.HeaderText = "Nozzle ID";
            this.col_nozzle_id.Name = "col_nozzle_id";
            this.col_nozzle_id.ReadOnly = true;
            this.col_nozzle_id.Visible = false;
            // 
            // col_nozzle_name
            // 
            this.col_nozzle_name.DataPropertyName = "nozzle_name";
            this.col_nozzle_name.HeaderText = "เลขที่หัวจ่าย";
            this.col_nozzle_name.MinimumWidth = 90;
            this.col_nozzle_name.Name = "col_nozzle_name";
            this.col_nozzle_name.ReadOnly = true;
            this.col_nozzle_name.Width = 90;
            // 
            // col_section_name
            // 
            this.col_section_name.DataPropertyName = "section_name";
            this.col_section_name.HeaderText = "เลขที่ถัง";
            this.col_section_name.MinimumWidth = 90;
            this.col_section_name.Name = "col_section_name";
            this.col_section_name.ReadOnly = true;
            this.col_section_name.Width = 90;
            // 
            // col_typdes
            // 
            this.col_typdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_typdes.DataPropertyName = "typdes";
            this.col_typdes.HeaderText = "รายละเอียด";
            this.col_typdes.Name = "col_typdes";
            this.col_typdes.ReadOnly = true;
            // 
            // col_qty
            // 
            this.col_qty.DataPropertyName = "qty";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.col_qty.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_qty.HeaderText = "ปริมาณ(ลิตร)";
            this.col_qty.MinimumWidth = 100;
            this.col_qty.Name = "col_qty";
            this.col_qty.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAdd.Image = global::XPump.Properties.Resources.add_16;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(0, 142);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(49, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnAdd, "เพิ่ม <Alt+A>");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDelete.Image = global::XPump.Properties.Resources.delete_16;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(237, 142);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(53, 24);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnDelete, "ลบ <Alt+D>");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEdit.Image = global::XPump.Properties.Resources.edit_16;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(51, 142);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnEdit.Size = new System.Drawing.Size(56, 24);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "แก้ไข";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnEdit, "แก้ไข <Alt+E>");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnStop.Image = global::XPump.Properties.Resources.stop_16;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(109, 142);
            this.btnStop.Name = "btnStop";
            this.btnStop.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnStop.Size = new System.Drawing.Size(63, 24);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "ยกเลิก";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnStop, "ยกเลิก <Esc>");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.Image = global::XPump.Properties.Resources.save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(174, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(61, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "บันทึก";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnSave, "บันทึก <F9>");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.Image = global::XPump.Properties.Resources.close_16;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(347, 142);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "ปิด";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnClose, "ปิด <Esc>");
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // DialogDother
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 169);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 160);
            this.Name = "DialogDother";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.DialogDother_Deactivate);
            this.Load += new System.EventHandler(this.DialogDother_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSave;
        private CC.XDatagrid dgv;
        private CC.XNumEdit inline_qty;
        private CC.XDropdownList inline_dother;
        private System.Windows.Forms.ToolTip toolTip1;
        private CC.XDropdownList inline_section;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dother;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_typcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_creby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cretime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_istab_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_salessummary_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dayend_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_typdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty;
        private CC.XBrowseBox inline_nozzle;
    }
}