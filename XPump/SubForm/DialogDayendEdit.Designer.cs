﻿namespace XPump.SubForm
{
    partial class DialogDayendEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStkcod = new System.Windows.Forms.Label();
            this.lblStkdes = new System.Windows.Forms.Label();
            this.dgv = new CC.XDatagrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dayend_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_daysttak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.inline_qty = new CC.XNumEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.numDother = new CC.XNumEdit();
            this.txtDothertxt = new CC.XTextEdit();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblEndbal = new System.Windows.Forms.Label();
            this.lblBegbal = new System.Windows.Forms.Label();
            this.lblRcvqty = new System.Windows.Forms.Label();
            this.lblSalqty = new System.Windows.Forms.Label();
            this.lblAccbal = new System.Windows.Forms.Label();
            this.lblDifqty = new System.Windows.Forms.Label();
            this.lblBegdif = new System.Windows.Forms.Label();
            this.lblTotalDif = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSaldat = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(15, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสสินค้า :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "รายละเอียด :";
            // 
            // lblStkcod
            // 
            this.lblStkcod.AutoSize = true;
            this.lblStkcod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblStkcod.Location = new System.Drawing.Point(99, 49);
            this.lblStkcod.Name = "lblStkcod";
            this.lblStkcod.Size = new System.Drawing.Size(51, 16);
            this.lblStkcod.TabIndex = 0;
            this.lblStkcod.Text = "stkcod";
            // 
            // lblStkdes
            // 
            this.lblStkdes.AutoSize = true;
            this.lblStkdes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblStkdes.Location = new System.Drawing.Point(100, 75);
            this.lblStkdes.Name = "lblStkdes";
            this.lblStkdes.Size = new System.Drawing.Size(51, 16);
            this.lblStkdes.TabIndex = 0;
            this.lblStkdes.Text = "stkdes";
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv.ColumnHeadersHeight = 28;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_tank_name,
            this.col_section_name,
            this.col_qty,
            this.col_dayend_id,
            this.col_section_id,
            this.col_daysttak});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle12;
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
            this.dgv.Size = new System.Drawing.Size(419, 129);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_tank_name
            // 
            this.col_tank_name.DataPropertyName = "tank_name";
            this.col_tank_name.HeaderText = "รหัสแท๊งค์";
            this.col_tank_name.MinimumWidth = 140;
            this.col_tank_name.Name = "col_tank_name";
            this.col_tank_name.ReadOnly = true;
            this.col_tank_name.Width = 140;
            // 
            // col_section_name
            // 
            this.col_section_name.DataPropertyName = "section_name";
            this.col_section_name.HeaderText = "เลขที่ถัง";
            this.col_section_name.MinimumWidth = 140;
            this.col_section_name.Name = "col_section_name";
            this.col_section_name.ReadOnly = true;
            this.col_section_name.Width = 140;
            // 
            // col_qty
            // 
            this.col_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_qty.DataPropertyName = "qty";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.col_qty.DefaultCellStyle = dataGridViewCellStyle11;
            this.col_qty.HeaderText = "ปริมาณที่ตรวจวัดได้";
            this.col_qty.Name = "col_qty";
            this.col_qty.ReadOnly = true;
            // 
            // col_dayend_id
            // 
            this.col_dayend_id.DataPropertyName = "dayend_id";
            this.col_dayend_id.HeaderText = "Dayend Id";
            this.col_dayend_id.Name = "col_dayend_id";
            this.col_dayend_id.ReadOnly = true;
            this.col_dayend_id.Visible = false;
            // 
            // col_section_id
            // 
            this.col_section_id.DataPropertyName = "section_id";
            this.col_section_id.HeaderText = "Section Id";
            this.col_section_id.Name = "col_section_id";
            this.col_section_id.ReadOnly = true;
            this.col_section_id.Visible = false;
            // 
            // col_daysttak
            // 
            this.col_daysttak.DataPropertyName = "daysttak";
            this.col_daysttak.HeaderText = "Sttak";
            this.col_daysttak.Name = "col_daysttak";
            this.col_daysttak.ReadOnly = true;
            this.col_daysttak.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(4, 104);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(427, 158);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.inline_qty);
            this.tabPage1.Controls.Add(this.dgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(419, 129);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. ปริมาณน้ำมันสะสมในถังวัดได้จริงสิ้นงวด";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.inline_qty.Location = new System.Drawing.Point(280, 34);
            this.inline_qty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_qty.Name = "inline_qty";
            this.inline_qty.Size = new System.Drawing.Size(136, 23);
            this.inline_qty.TabIndex = 1;
            this.inline_qty.Visible = false;
            this.inline_qty._ValueChanged += new System.EventHandler(this.inline_qty__ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "2. รวมยอดน้ำมันวัดได้จริงสิ้นงวด";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "3. น้ำมันที่วัดได้จริงต้นงวด";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "4. ";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(27, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "บวก";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(55, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "ยอดรับน้ำมัน";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 354);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "5.";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(27, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "หัก";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(55, 354);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(177, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "น้ำมันที่ขายผ่านมิเตอร์ระหว่างวัน";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(27, 381);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "หัก";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(55, 381);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "อื่น ๆ ระบุ";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 407);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "6. น้ำมันคงเหลือในบัญชี (3+4-5)";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 435);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(160, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "7. ผลต่างน้ำมันปัจจุบัน (2-6)";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 461);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "8.";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label18.Location = new System.Drawing.Point(27, 461);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 16);
            this.label18.TabIndex = 0;
            this.label18.Text = "บวก";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.Location = new System.Drawing.Point(55, 461);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 16);
            this.label19.TabIndex = 0;
            this.label19.Text = "ผลต่างสะสมยกมา";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 489);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(194, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "9. ผลต่างสะสมปัจจุบันยกไป (7+8)";
            // 
            // numDother
            // 
            this.numDother._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDother._DecimalDigit = 2;
            this.numDother._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.numDother._MaxLength = 30;
            this.numDother._ReadOnly = true;
            this.numDother._SelectionLength = 0;
            this.numDother._SelectionStart = 4;
            this.numDother._Text = "0.00";
            this.numDother._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDother._UseThoundsandSeparate = true;
            this.numDother._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.numDother.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numDother.BackColor = System.Drawing.Color.White;
            this.numDother.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDother.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numDother.Location = new System.Drawing.Point(298, 377);
            this.numDother.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numDother.Name = "numDother";
            this.numDother.Size = new System.Drawing.Size(127, 23);
            this.numDother.TabIndex = 3;
            this.numDother._ValueChanged += new System.EventHandler(this.numDother__ValueChanged);
            this.numDother._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // txtDothertxt
            // 
            this.txtDothertxt._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDothertxt._MaxLength = 30;
            this.txtDothertxt._ReadOnly = true;
            this.txtDothertxt._Text = "";
            this.txtDothertxt._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDothertxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDothertxt.BackColor = System.Drawing.Color.White;
            this.txtDothertxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDothertxt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDothertxt.Location = new System.Drawing.Point(114, 376);
            this.txtDothertxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDothertxt.Name = "txtDothertxt";
            this.txtDothertxt.Size = new System.Drawing.Size(114, 23);
            this.txtDothertxt.TabIndex = 2;
            this.txtDothertxt._TextChanged += new System.EventHandler(this.txtDothertxt__TextChanged);
            this.txtDothertxt._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Enabled = false;
            this.btnOK.Image = global::XPump.Properties.Resources.save_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(84, 531);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new System.Windows.Forms.Padding(5, 3, 34, 3);
            this.btnOK.Size = new System.Drawing.Size(130, 34);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "บันทึก";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblEndbal
            // 
            this.lblEndbal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEndbal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblEndbal.Location = new System.Drawing.Point(298, 273);
            this.lblEndbal.Name = "lblEndbal";
            this.lblEndbal.Size = new System.Drawing.Size(127, 16);
            this.lblEndbal.TabIndex = 0;
            this.lblEndbal.Text = "0.00";
            this.lblEndbal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBegbal
            // 
            this.lblBegbal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBegbal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBegbal.Location = new System.Drawing.Point(298, 300);
            this.lblBegbal.Name = "lblBegbal";
            this.lblBegbal.Size = new System.Drawing.Size(127, 16);
            this.lblBegbal.TabIndex = 0;
            this.lblBegbal.Text = "0.00";
            this.lblBegbal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRcvqty
            // 
            this.lblRcvqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRcvqty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRcvqty.Location = new System.Drawing.Point(298, 327);
            this.lblRcvqty.Name = "lblRcvqty";
            this.lblRcvqty.Size = new System.Drawing.Size(127, 16);
            this.lblRcvqty.TabIndex = 0;
            this.lblRcvqty.Text = "0.00";
            this.lblRcvqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSalqty
            // 
            this.lblSalqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSalqty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSalqty.Location = new System.Drawing.Point(298, 354);
            this.lblSalqty.Name = "lblSalqty";
            this.lblSalqty.Size = new System.Drawing.Size(127, 16);
            this.lblSalqty.TabIndex = 0;
            this.lblSalqty.Text = "0.00";
            this.lblSalqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAccbal
            // 
            this.lblAccbal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAccbal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAccbal.Location = new System.Drawing.Point(298, 407);
            this.lblAccbal.Name = "lblAccbal";
            this.lblAccbal.Size = new System.Drawing.Size(127, 16);
            this.lblAccbal.TabIndex = 0;
            this.lblAccbal.Text = "0.00";
            this.lblAccbal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDifqty
            // 
            this.lblDifqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDifqty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDifqty.Location = new System.Drawing.Point(298, 435);
            this.lblDifqty.Name = "lblDifqty";
            this.lblDifqty.Size = new System.Drawing.Size(127, 16);
            this.lblDifqty.TabIndex = 0;
            this.lblDifqty.Text = "0.00";
            this.lblDifqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBegdif
            // 
            this.lblBegdif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBegdif.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBegdif.Location = new System.Drawing.Point(298, 461);
            this.lblBegdif.Name = "lblBegdif";
            this.lblBegdif.Size = new System.Drawing.Size(127, 16);
            this.lblBegdif.TabIndex = 0;
            this.lblBegdif.Text = "0.00";
            this.lblBegdif.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDif
            // 
            this.lblTotalDif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalDif.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTotalDif.Location = new System.Drawing.Point(298, 489);
            this.lblTotalDif.Name = "lblTotalDif";
            this.lblTotalDif.Size = new System.Drawing.Size(127, 16);
            this.lblTotalDif.TabIndex = 0;
            this.lblTotalDif.Text = "0.00";
            this.lblTotalDif.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(15, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "วันที่ :";
            // 
            // lblSaldat
            // 
            this.lblSaldat.AutoSize = true;
            this.lblSaldat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSaldat.Location = new System.Drawing.Point(99, 21);
            this.lblSaldat.Name = "lblSaldat";
            this.lblSaldat.Size = new System.Drawing.Size(48, 16);
            this.lblSaldat.TabIndex = 0;
            this.lblSaldat.Text = "saldat";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Image = global::XPump.Properties.Resources.stop_16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(220, 531);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.btnCancel.Size = new System.Drawing.Size(130, 34);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "ยกเลิกการแก้ไข";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DialogDayendEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 583);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numDother);
            this.Controls.Add(this.txtDothertxt);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblTotalDif);
            this.Controls.Add(this.lblBegdif);
            this.Controls.Add(this.lblDifqty);
            this.Controls.Add(this.lblAccbal);
            this.Controls.Add(this.lblSalqty);
            this.Controls.Add(this.lblRcvqty);
            this.Controls.Add(this.lblBegbal);
            this.Controls.Add(this.lblEndbal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStkdes);
            this.Controls.Add(this.lblSaldat);
            this.Controls.Add(this.lblStkcod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogDayendEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "แก้ไขข้อมูลปิดยอดขายประจำวัน";
            this.Load += new System.EventHandler(this.DialogDayendEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStkcod;
        private System.Windows.Forms.Label lblStkdes;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private CC.XNumEdit numDother;
        private CC.XTextEdit txtDothertxt;
        private System.Windows.Forms.Button btnOK;
        private CC.XNumEdit inline_qty;
        private System.Windows.Forms.Label lblEndbal;
        private System.Windows.Forms.Label lblBegbal;
        private System.Windows.Forms.Label lblRcvqty;
        private System.Windows.Forms.Label lblSalqty;
        private System.Windows.Forms.Label lblAccbal;
        private System.Windows.Forms.Label lblDifqty;
        private System.Windows.Forms.Label lblBegdif;
        private System.Windows.Forms.Label lblTotalDif;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dayend_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_daysttak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSaldat;
        private System.Windows.Forms.Button btnCancel;
    }
}