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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvStmas = new CC.XDatagrid();
            this.dgvNozzle = new CC.XDatagrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.inline_unitpr = new CC.XNumEdit();
            this.inline_mit_end = new CC.XNumEdit();
            this.inline_mit_start = new CC.XNumEdit();
            this.xBrowseBox1 = new CC.XBrowseBox();
            this.label4 = new System.Windows.Forms.Label();
            this.xDatePicker1 = new CC.XDatePicker();
            this.col_stmas_stmas_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stmas_price_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stmas_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stmas_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stmas_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stmas_unitpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.xTextEdit1 = new CC.XTextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.xNumEdit1 = new CC.XNumEdit();
            this.xNumEdit2 = new CC.XNumEdit();
            this.xNumEdit3 = new CC.XNumEdit();
            this.xNumEdit4 = new CC.XNumEdit();
            this.xNumEdit5 = new CC.XNumEdit();
            this.xNumEdit6 = new CC.XNumEdit();
            this.xNumEdit7 = new CC.XNumEdit();
            this.xNumEdit8 = new CC.XNumEdit();
            this.xNumEdit9 = new CC.XNumEdit();
            this.xNumEdit10 = new CC.XNumEdit();
            this.xNumEdit11 = new CC.XNumEdit();
            this.xNumEdit12 = new CC.XNumEdit();
            this.xNumEdit13 = new CC.XNumEdit();
            this.xNumEdit14 = new CC.XNumEdit();
            this.xNumEdit15 = new CC.XNumEdit();
            this.xNumEdit16 = new CC.XNumEdit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStmas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNozzle)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.inline_unitpr);
            this.panel1.Controls.Add(this.dgvStmas);
            this.panel1.Location = new System.Drawing.Point(12, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 477);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.inline_mit_start);
            this.panel2.Controls.Add(this.inline_mit_end);
            this.panel2.Controls.Add(this.dgvNozzle);
            this.panel2.Location = new System.Drawing.Point(327, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 248);
            this.panel2.TabIndex = 0;
            // 
            // dgvStmas
            // 
            this.dgvStmas.AllowSortByColumnHeaderClicked = false;
            this.dgvStmas.AllowUserToAddRows = false;
            this.dgvStmas.AllowUserToDeleteRows = false;
            this.dgvStmas.AllowUserToResizeColumns = false;
            this.dgvStmas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStmas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStmas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_stmas_stmas_id,
            this.col_stmas_price_id,
            this.col_stmas_date,
            this.col_stmas_stkcod,
            this.col_stmas_stkdes,
            this.col_stmas_unitpr});
            this.dgvStmas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStmas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvStmas.EnableHeadersVisualStyles = false;
            this.dgvStmas.FillEmptyRow = false;
            this.dgvStmas.FocusedRowBorderRedLine = false;
            this.dgvStmas.Location = new System.Drawing.Point(0, 0);
            this.dgvStmas.MultiSelect = false;
            this.dgvStmas.Name = "dgvStmas";
            this.dgvStmas.ReadOnly = true;
            this.dgvStmas.RowHeadersVisible = false;
            this.dgvStmas.RowTemplate.Height = 26;
            this.dgvStmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStmas.Size = new System.Drawing.Size(309, 477);
            this.dgvStmas.StandardTab = true;
            this.dgvStmas.TabIndex = 0;
            this.dgvStmas.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvStmas_DataBindingComplete);
            // 
            // dgvNozzle
            // 
            this.dgvNozzle.AllowSortByColumnHeaderClicked = false;
            this.dgvNozzle.AllowUserToAddRows = false;
            this.dgvNozzle.AllowUserToDeleteRows = false;
            this.dgvNozzle.AllowUserToResizeColumns = false;
            this.dgvNozzle.AllowUserToResizeRows = false;
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
            this.dgvNozzle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNozzle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvNozzle.EnableHeadersVisualStyles = false;
            this.dgvNozzle.FillEmptyRow = false;
            this.dgvNozzle.FocusedRowBorderRedLine = false;
            this.dgvNozzle.Location = new System.Drawing.Point(0, 0);
            this.dgvNozzle.MultiSelect = false;
            this.dgvNozzle.Name = "dgvNozzle";
            this.dgvNozzle.ReadOnly = true;
            this.dgvNozzle.RowHeadersVisible = false;
            this.dgvNozzle.RowTemplate.Height = 26;
            this.dgvNozzle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNozzle.Size = new System.Drawing.Size(488, 248);
            this.dgvNozzle.StandardTab = true;
            this.dgvNozzle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "2. เลือกรายการสินค้า";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(324, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "3. บันทึกปริมาณการขายแต่ละหัวจ่าย";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "1. ระบุผลัด";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Image = global::XPump.Properties.Resources.save_16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(311, 584);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(3);
            this.button1.Size = new System.Drawing.Size(110, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "บันทึกข้อมูล";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = global::XPump.Properties.Resources.stop_16;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(427, 584);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(3);
            this.button2.Size = new System.Drawing.Size(80, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "ยกเลิก";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // inline_unitpr
            // 
            this.inline_unitpr._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_unitpr._DecimalDigit = 2;
            this.inline_unitpr._MaximumValue = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.inline_unitpr._MaxLength = 30;
            this.inline_unitpr._ReadOnly = false;
            this.inline_unitpr._SelectionLength = 0;
            this.inline_unitpr._SelectionStart = 0;
            this.inline_unitpr._Text = "0.00";
            this.inline_unitpr._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inline_unitpr._UseThoundsandSeparate = true;
            this.inline_unitpr._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inline_unitpr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_unitpr.BackColor = System.Drawing.Color.White;
            this.inline_unitpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_unitpr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_unitpr.Location = new System.Drawing.Point(216, 450);
            this.inline_unitpr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_unitpr.Name = "inline_unitpr";
            this.inline_unitpr.Size = new System.Drawing.Size(90, 23);
            this.inline_unitpr.TabIndex = 4;
            // 
            // inline_mit_end
            // 
            this.inline_mit_end._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_mit_end._DecimalDigit = 2;
            this.inline_mit_end._MaximumValue = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.inline_mit_end._MaxLength = 30;
            this.inline_mit_end._ReadOnly = false;
            this.inline_mit_end._SelectionLength = 0;
            this.inline_mit_end._SelectionStart = 4;
            this.inline_mit_end._Text = "0.00";
            this.inline_mit_end._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inline_mit_end._UseThoundsandSeparate = true;
            this.inline_mit_end._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inline_mit_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_mit_end.BackColor = System.Drawing.Color.White;
            this.inline_mit_end.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_mit_end.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_mit_end.Location = new System.Drawing.Point(395, 221);
            this.inline_mit_end.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_mit_end.Name = "inline_mit_end";
            this.inline_mit_end.Size = new System.Drawing.Size(90, 23);
            this.inline_mit_end.TabIndex = 4;
            // 
            // inline_mit_start
            // 
            this.inline_mit_start._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_mit_start._DecimalDigit = 2;
            this.inline_mit_start._MaximumValue = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.inline_mit_start._MaxLength = 30;
            this.inline_mit_start._ReadOnly = false;
            this.inline_mit_start._SelectionLength = 0;
            this.inline_mit_start._SelectionStart = 4;
            this.inline_mit_start._Text = "0.00";
            this.inline_mit_start._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inline_mit_start._UseThoundsandSeparate = true;
            this.inline_mit_start._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inline_mit_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_mit_start.BackColor = System.Drawing.Color.White;
            this.inline_mit_start.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_mit_start.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_mit_start.Location = new System.Drawing.Point(299, 221);
            this.inline_mit_start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_mit_start.Name = "inline_mit_start";
            this.inline_mit_start.Size = new System.Drawing.Size(90, 23);
            this.inline_mit_start.TabIndex = 4;
            // 
            // xBrowseBox1
            // 
            this.xBrowseBox1._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xBrowseBox1._ReadOnly = false;
            this.xBrowseBox1._Text = null;
            this.xBrowseBox1._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.xBrowseBox1._UseImage = true;
            this.xBrowseBox1.BackColor = System.Drawing.Color.White;
            this.xBrowseBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xBrowseBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.xBrowseBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xBrowseBox1.Location = new System.Drawing.Point(86, 20);
            this.xBrowseBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xBrowseBox1.Name = "xBrowseBox1";
            this.xBrowseBox1.Size = new System.Drawing.Size(129, 23);
            this.xBrowseBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(233, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "วันที่";
            // 
            // xDatePicker1
            // 
            this.xDatePicker1._ReadOnly = false;
            this.xDatePicker1._SelectedDate = null;
            this.xDatePicker1.BackColor = System.Drawing.Color.White;
            this.xDatePicker1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xDatePicker1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xDatePicker1.Location = new System.Drawing.Point(269, 20);
            this.xDatePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xDatePicker1.Name = "xDatePicker1";
            this.xDatePicker1.Size = new System.Drawing.Size(103, 23);
            this.xDatePicker1.TabIndex = 5;
            // 
            // col_stmas_stmas_id
            // 
            this.col_stmas_stmas_id.DataPropertyName = "stmas_id";
            this.col_stmas_stmas_id.HeaderText = "Stmas ID";
            this.col_stmas_stmas_id.Name = "col_stmas_stmas_id";
            this.col_stmas_stmas_id.ReadOnly = true;
            this.col_stmas_stmas_id.Visible = false;
            // 
            // col_stmas_price_id
            // 
            this.col_stmas_price_id.DataPropertyName = "price_id";
            this.col_stmas_price_id.HeaderText = "Price ID";
            this.col_stmas_price_id.Name = "col_stmas_price_id";
            this.col_stmas_price_id.ReadOnly = true;
            this.col_stmas_price_id.Visible = false;
            // 
            // col_stmas_date
            // 
            this.col_stmas_date.DataPropertyName = "date";
            this.col_stmas_date.HeaderText = "Date";
            this.col_stmas_date.Name = "col_stmas_date";
            this.col_stmas_date.ReadOnly = true;
            this.col_stmas_date.Visible = false;
            // 
            // col_stmas_stkcod
            // 
            this.col_stmas_stkcod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_stmas_stkcod.DataPropertyName = "stkcod";
            this.col_stmas_stkcod.HeaderText = "รหัสสินค้า";
            this.col_stmas_stkcod.MinimumWidth = 140;
            this.col_stmas_stkcod.Name = "col_stmas_stkcod";
            this.col_stmas_stkcod.ReadOnly = true;
            // 
            // col_stmas_stkdes
            // 
            this.col_stmas_stkdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_stmas_stkdes.DataPropertyName = "stkdes";
            this.col_stmas_stkdes.HeaderText = "รายละเอียด";
            this.col_stmas_stkdes.Name = "col_stmas_stkdes";
            this.col_stmas_stkdes.ReadOnly = true;
            this.col_stmas_stkdes.Visible = false;
            // 
            // col_stmas_unitpr
            // 
            this.col_stmas_unitpr.DataPropertyName = "unitpr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_stmas_unitpr.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_stmas_unitpr.HeaderText = "ราคาขาย/ลิตร";
            this.col_stmas_unitpr.MinimumWidth = 120;
            this.col_stmas_unitpr.Name = "col_stmas_unitpr";
            this.col_stmas_unitpr.ReadOnly = true;
            this.col_stmas_unitpr.Width = 120;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(404, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "1. รวม";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(439, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "ยอดขายน้ำมันทดสอบ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(418, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "หัก";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(439, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "อื่น ๆ ระบุ";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(418, 402);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "หัก";
            // 
            // xTextEdit1
            // 
            this.xTextEdit1._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xTextEdit1._MaxLength = 32767;
            this.xTextEdit1._ReadOnly = false;
            this.xTextEdit1._Text = "";
            this.xTextEdit1._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.xTextEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xTextEdit1.BackColor = System.Drawing.Color.White;
            this.xTextEdit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xTextEdit1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xTextEdit1.Location = new System.Drawing.Point(497, 399);
            this.xTextEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xTextEdit1.Name = "xTextEdit1";
            this.xTextEdit1.Size = new System.Drawing.Size(90, 23);
            this.xTextEdit1.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(403, 375);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "2.";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(403, 429);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "3. รวมยอดขายประจำวัน";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(403, 456);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "4.";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(439, 456);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "ส่วนลดการค้าหน้าลาน";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(418, 456);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 1;
            this.label14.Text = "หัก";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.Location = new System.Drawing.Point(403, 483);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 16);
            this.label15.TabIndex = 1;
            this.label15.Text = "5. ยอดขายสุทธิ";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.Location = new System.Drawing.Point(403, 512);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 16);
            this.label16.TabIndex = 1;
            this.label16.Text = "6. ภาษีขาย";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label17.Location = new System.Drawing.Point(467, 514);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "((5) x 7)/107)";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label18.Location = new System.Drawing.Point(404, 538);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(163, 16);
            this.label18.TabIndex = 1;
            this.label18.Text = "7. ภาษีซื้อของน้ำมันเชื้อเพลิง";
            // 
            // xNumEdit1
            // 
            this.xNumEdit1._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit1._DecimalDigit = 2;
            this.xNumEdit1._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit1._MaxLength = 30;
            this.xNumEdit1._ReadOnly = false;
            this.xNumEdit1._SelectionLength = 0;
            this.xNumEdit1._SelectionStart = 0;
            this.xNumEdit1._Text = "0.00";
            this.xNumEdit1._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit1._UseThoundsandSeparate = true;
            this.xNumEdit1._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit1.BackColor = System.Drawing.Color.White;
            this.xNumEdit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit1.Location = new System.Drawing.Point(714, 345);
            this.xNumEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit1.Name = "xNumEdit1";
            this.xNumEdit1.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit1.TabIndex = 7;
            // 
            // xNumEdit2
            // 
            this.xNumEdit2._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit2._DecimalDigit = 2;
            this.xNumEdit2._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit2._MaxLength = 30;
            this.xNumEdit2._ReadOnly = false;
            this.xNumEdit2._SelectionLength = 0;
            this.xNumEdit2._SelectionStart = 4;
            this.xNumEdit2._Text = "0.00";
            this.xNumEdit2._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit2._UseThoundsandSeparate = true;
            this.xNumEdit2._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit2.BackColor = System.Drawing.Color.White;
            this.xNumEdit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit2.Location = new System.Drawing.Point(714, 372);
            this.xNumEdit2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit2.Name = "xNumEdit2";
            this.xNumEdit2.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit2.TabIndex = 7;
            // 
            // xNumEdit3
            // 
            this.xNumEdit3._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit3._DecimalDigit = 2;
            this.xNumEdit3._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit3._MaxLength = 30;
            this.xNumEdit3._ReadOnly = false;
            this.xNumEdit3._SelectionLength = 0;
            this.xNumEdit3._SelectionStart = 4;
            this.xNumEdit3._Text = "0.00";
            this.xNumEdit3._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit3._UseThoundsandSeparate = true;
            this.xNumEdit3._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit3.BackColor = System.Drawing.Color.White;
            this.xNumEdit3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit3.Location = new System.Drawing.Point(714, 399);
            this.xNumEdit3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit3.Name = "xNumEdit3";
            this.xNumEdit3.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit3.TabIndex = 7;
            // 
            // xNumEdit4
            // 
            this.xNumEdit4._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit4._DecimalDigit = 2;
            this.xNumEdit4._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit4._MaxLength = 30;
            this.xNumEdit4._ReadOnly = false;
            this.xNumEdit4._SelectionLength = 0;
            this.xNumEdit4._SelectionStart = 4;
            this.xNumEdit4._Text = "0.00";
            this.xNumEdit4._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit4._UseThoundsandSeparate = true;
            this.xNumEdit4._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit4.BackColor = System.Drawing.Color.White;
            this.xNumEdit4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit4.Location = new System.Drawing.Point(714, 426);
            this.xNumEdit4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit4.Name = "xNumEdit4";
            this.xNumEdit4.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit4.TabIndex = 7;
            // 
            // xNumEdit5
            // 
            this.xNumEdit5._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit5._DecimalDigit = 2;
            this.xNumEdit5._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit5._MaxLength = 30;
            this.xNumEdit5._ReadOnly = false;
            this.xNumEdit5._SelectionLength = 0;
            this.xNumEdit5._SelectionStart = 4;
            this.xNumEdit5._Text = "0.00";
            this.xNumEdit5._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit5._UseThoundsandSeparate = true;
            this.xNumEdit5._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit5.BackColor = System.Drawing.Color.White;
            this.xNumEdit5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit5.Location = new System.Drawing.Point(714, 453);
            this.xNumEdit5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit5.Name = "xNumEdit5";
            this.xNumEdit5.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit5.TabIndex = 7;
            // 
            // xNumEdit6
            // 
            this.xNumEdit6._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit6._DecimalDigit = 2;
            this.xNumEdit6._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit6._MaxLength = 30;
            this.xNumEdit6._ReadOnly = false;
            this.xNumEdit6._SelectionLength = 0;
            this.xNumEdit6._SelectionStart = 4;
            this.xNumEdit6._Text = "0.00";
            this.xNumEdit6._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit6._UseThoundsandSeparate = true;
            this.xNumEdit6._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit6.BackColor = System.Drawing.Color.White;
            this.xNumEdit6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit6.Location = new System.Drawing.Point(714, 480);
            this.xNumEdit6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit6.Name = "xNumEdit6";
            this.xNumEdit6.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit6.TabIndex = 7;
            // 
            // xNumEdit7
            // 
            this.xNumEdit7._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit7._DecimalDigit = 2;
            this.xNumEdit7._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit7._MaxLength = 30;
            this.xNumEdit7._ReadOnly = false;
            this.xNumEdit7._SelectionLength = 0;
            this.xNumEdit7._SelectionStart = 4;
            this.xNumEdit7._Text = "0.00";
            this.xNumEdit7._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit7._UseThoundsandSeparate = true;
            this.xNumEdit7._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit7.BackColor = System.Drawing.Color.White;
            this.xNumEdit7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit7.Location = new System.Drawing.Point(714, 507);
            this.xNumEdit7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit7.Name = "xNumEdit7";
            this.xNumEdit7.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit7.TabIndex = 7;
            // 
            // xNumEdit8
            // 
            this.xNumEdit8._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit8._DecimalDigit = 2;
            this.xNumEdit8._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit8._MaxLength = 30;
            this.xNumEdit8._ReadOnly = false;
            this.xNumEdit8._SelectionLength = 0;
            this.xNumEdit8._SelectionStart = 4;
            this.xNumEdit8._Text = "0.00";
            this.xNumEdit8._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit8._UseThoundsandSeparate = true;
            this.xNumEdit8._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit8.BackColor = System.Drawing.Color.White;
            this.xNumEdit8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit8.Location = new System.Drawing.Point(714, 534);
            this.xNumEdit8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit8.Name = "xNumEdit8";
            this.xNumEdit8.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit8.TabIndex = 7;
            // 
            // xNumEdit9
            // 
            this.xNumEdit9._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit9._DecimalDigit = 2;
            this.xNumEdit9._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit9._MaxLength = 30;
            this.xNumEdit9._ReadOnly = false;
            this.xNumEdit9._SelectionLength = 0;
            this.xNumEdit9._SelectionStart = 4;
            this.xNumEdit9._Text = "0.00";
            this.xNumEdit9._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit9._UseThoundsandSeparate = true;
            this.xNumEdit9._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit9.BackColor = System.Drawing.Color.White;
            this.xNumEdit9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit9.Location = new System.Drawing.Point(610, 345);
            this.xNumEdit9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit9.Name = "xNumEdit9";
            this.xNumEdit9.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit9.TabIndex = 7;
            // 
            // xNumEdit10
            // 
            this.xNumEdit10._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit10._DecimalDigit = 2;
            this.xNumEdit10._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit10._MaxLength = 30;
            this.xNumEdit10._ReadOnly = false;
            this.xNumEdit10._SelectionLength = 0;
            this.xNumEdit10._SelectionStart = 4;
            this.xNumEdit10._Text = "0.00";
            this.xNumEdit10._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit10._UseThoundsandSeparate = true;
            this.xNumEdit10._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit10.BackColor = System.Drawing.Color.White;
            this.xNumEdit10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit10.Location = new System.Drawing.Point(610, 372);
            this.xNumEdit10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit10.Name = "xNumEdit10";
            this.xNumEdit10.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit10.TabIndex = 7;
            // 
            // xNumEdit11
            // 
            this.xNumEdit11._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit11._DecimalDigit = 2;
            this.xNumEdit11._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit11._MaxLength = 30;
            this.xNumEdit11._ReadOnly = false;
            this.xNumEdit11._SelectionLength = 0;
            this.xNumEdit11._SelectionStart = 4;
            this.xNumEdit11._Text = "0.00";
            this.xNumEdit11._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit11._UseThoundsandSeparate = true;
            this.xNumEdit11._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit11.BackColor = System.Drawing.Color.White;
            this.xNumEdit11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit11.Location = new System.Drawing.Point(610, 453);
            this.xNumEdit11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit11.Name = "xNumEdit11";
            this.xNumEdit11.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit11.TabIndex = 7;
            // 
            // xNumEdit12
            // 
            this.xNumEdit12._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit12._DecimalDigit = 2;
            this.xNumEdit12._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit12._MaxLength = 30;
            this.xNumEdit12._ReadOnly = false;
            this.xNumEdit12._SelectionLength = 0;
            this.xNumEdit12._SelectionStart = 4;
            this.xNumEdit12._Text = "0.00";
            this.xNumEdit12._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit12._UseThoundsandSeparate = true;
            this.xNumEdit12._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit12.BackColor = System.Drawing.Color.White;
            this.xNumEdit12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit12.Location = new System.Drawing.Point(610, 399);
            this.xNumEdit12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit12.Name = "xNumEdit12";
            this.xNumEdit12.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit12.TabIndex = 7;
            // 
            // xNumEdit13
            // 
            this.xNumEdit13._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit13._DecimalDigit = 2;
            this.xNumEdit13._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit13._MaxLength = 30;
            this.xNumEdit13._ReadOnly = false;
            this.xNumEdit13._SelectionLength = 0;
            this.xNumEdit13._SelectionStart = 4;
            this.xNumEdit13._Text = "0.00";
            this.xNumEdit13._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit13._UseThoundsandSeparate = true;
            this.xNumEdit13._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit13.BackColor = System.Drawing.Color.White;
            this.xNumEdit13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit13.Location = new System.Drawing.Point(610, 480);
            this.xNumEdit13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit13.Name = "xNumEdit13";
            this.xNumEdit13.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit13.TabIndex = 7;
            // 
            // xNumEdit14
            // 
            this.xNumEdit14._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit14._DecimalDigit = 2;
            this.xNumEdit14._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit14._MaxLength = 30;
            this.xNumEdit14._ReadOnly = false;
            this.xNumEdit14._SelectionLength = 0;
            this.xNumEdit14._SelectionStart = 4;
            this.xNumEdit14._Text = "0.00";
            this.xNumEdit14._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit14._UseThoundsandSeparate = true;
            this.xNumEdit14._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit14.BackColor = System.Drawing.Color.White;
            this.xNumEdit14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit14.Location = new System.Drawing.Point(610, 426);
            this.xNumEdit14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit14.Name = "xNumEdit14";
            this.xNumEdit14.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit14.TabIndex = 7;
            // 
            // xNumEdit15
            // 
            this.xNumEdit15._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit15._DecimalDigit = 2;
            this.xNumEdit15._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit15._MaxLength = 30;
            this.xNumEdit15._ReadOnly = false;
            this.xNumEdit15._SelectionLength = 0;
            this.xNumEdit15._SelectionStart = 4;
            this.xNumEdit15._Text = "0.00";
            this.xNumEdit15._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit15._UseThoundsandSeparate = true;
            this.xNumEdit15._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit15.BackColor = System.Drawing.Color.White;
            this.xNumEdit15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit15.Location = new System.Drawing.Point(610, 507);
            this.xNumEdit15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit15.Name = "xNumEdit15";
            this.xNumEdit15.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit15.TabIndex = 7;
            // 
            // xNumEdit16
            // 
            this.xNumEdit16._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit16._DecimalDigit = 2;
            this.xNumEdit16._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.xNumEdit16._MaxLength = 30;
            this.xNumEdit16._ReadOnly = false;
            this.xNumEdit16._SelectionLength = 0;
            this.xNumEdit16._SelectionStart = 4;
            this.xNumEdit16._Text = "0.00";
            this.xNumEdit16._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xNumEdit16._UseThoundsandSeparate = true;
            this.xNumEdit16._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.xNumEdit16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xNumEdit16.BackColor = System.Drawing.Color.White;
            this.xNumEdit16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumEdit16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.xNumEdit16.Location = new System.Drawing.Point(610, 534);
            this.xNumEdit16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xNumEdit16.Name = "xNumEdit16";
            this.xNumEdit16.Size = new System.Drawing.Size(100, 23);
            this.xNumEdit16.TabIndex = 7;
            // 
            // FormShiftTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(827, 633);
            this.Controls.Add(this.xNumEdit16);
            this.Controls.Add(this.xNumEdit8);
            this.Controls.Add(this.xNumEdit15);
            this.Controls.Add(this.xNumEdit7);
            this.Controls.Add(this.xNumEdit14);
            this.Controls.Add(this.xNumEdit4);
            this.Controls.Add(this.xNumEdit13);
            this.Controls.Add(this.xNumEdit6);
            this.Controls.Add(this.xNumEdit12);
            this.Controls.Add(this.xNumEdit3);
            this.Controls.Add(this.xNumEdit11);
            this.Controls.Add(this.xNumEdit5);
            this.Controls.Add(this.xNumEdit10);
            this.Controls.Add(this.xNumEdit2);
            this.Controls.Add(this.xNumEdit9);
            this.Controls.Add(this.xNumEdit1);
            this.Controls.Add(this.xTextEdit1);
            this.Controls.Add(this.xDatePicker1);
            this.Controls.Add(this.xBrowseBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(580, 350);
            this.Name = "FormShiftTransaction";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "บันทึกรายการขายประจำผลัด";
            this.Load += new System.EventHandler(this.FormShiftTransaction_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStmas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNozzle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CC.XDatagrid dgvStmas;
        private CC.XDatagrid dgvNozzle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CC.XNumEdit inline_unitpr;
        private CC.XNumEdit inline_mit_start;
        private CC.XNumEdit inline_mit_end;
        private CC.XBrowseBox xBrowseBox1;
        private System.Windows.Forms.Label label4;
        private CC.XDatePicker xDatePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stmas_stmas_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stmas_price_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stmas_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stmas_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stmas_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stmas_unitpr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private CC.XTextEdit xTextEdit1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private CC.XNumEdit xNumEdit1;
        private CC.XNumEdit xNumEdit2;
        private CC.XNumEdit xNumEdit3;
        private CC.XNumEdit xNumEdit4;
        private CC.XNumEdit xNumEdit5;
        private CC.XNumEdit xNumEdit6;
        private CC.XNumEdit xNumEdit7;
        private CC.XNumEdit xNumEdit8;
        private CC.XNumEdit xNumEdit9;
        private CC.XNumEdit xNumEdit10;
        private CC.XNumEdit xNumEdit11;
        private CC.XNumEdit xNumEdit12;
        private CC.XNumEdit xNumEdit13;
        private CC.XNumEdit xNumEdit14;
        private CC.XNumEdit xNumEdit15;
        private CC.XNumEdit xNumEdit16;
    }
}