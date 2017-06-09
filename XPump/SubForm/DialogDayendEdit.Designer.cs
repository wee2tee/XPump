namespace XPump.SubForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStkcod = new System.Windows.Forms.Label();
            this.lblStkdes = new System.Windows.Forms.Label();
            this.dgv = new CC.XDatagrid();
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
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblEndbal = new System.Windows.Forms.Label();
            this.lblAccbal = new System.Windows.Forms.Label();
            this.lblDifqty = new System.Windows.Forms.Label();
            this.lblTotalDif = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSaldat = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.numSalqty = new CC.XNumEdit();
            this.numRcvqty = new CC.XNumEdit();
            this.numBegbal = new CC.XNumEdit();
            this.numBegdif = new CC.XNumEdit();
            this.lblDother = new System.Windows.Forms.Label();
            this.btnDother = new System.Windows.Forms.Button();
            this.btnSyncRcvqty = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcvqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_accbal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_btn_rcvqty = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dayend_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_section_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_daysttak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_creby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cretime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chgtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_salqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dother = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.col_tank_name,
            this.col_section_name,
            this.col_rcvqty,
            this.col_accbal,
            this.col_btn_rcvqty,
            this.col_qty,
            this.col_dayend_id,
            this.col_section_id,
            this.col_daysttak,
            this.col_working_express_db,
            this.col_creby,
            this.col_cretime,
            this.col_chgby,
            this.col_chgtime,
            this.col_salqty,
            this.col_dother});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.dgv.Size = new System.Drawing.Size(444, 134);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgv_CellToolTipTextNeeded);
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
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
            this.tabControl1.Size = new System.Drawing.Size(452, 163);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.inline_qty);
            this.tabPage1.Controls.Add(this.dgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(444, 134);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. ปริมาณน้ำมันสะสมในถังวัดได้จริงสิ้นงวด";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // inline_qty
            // 
            this.inline_qty._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_qty._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
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
            this.inline_qty.Location = new System.Drawing.Point(285, 34);
            this.inline_qty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_qty.Name = "inline_qty";
            this.inline_qty.Size = new System.Drawing.Size(156, 23);
            this.inline_qty.TabIndex = 1;
            this.inline_qty._ValueChanged += new System.EventHandler(this.inline_qty__ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "2. รวมยอดน้ำมันวัดได้จริงสิ้นงวด";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "3. น้ำมันที่วัดได้จริงต้นงวด";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 350);
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
            this.label8.Location = new System.Drawing.Point(32, 350);
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
            this.label9.Location = new System.Drawing.Point(60, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "ยอดรับน้ำมัน";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 377);
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
            this.label11.Location = new System.Drawing.Point(32, 377);
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
            this.label12.Location = new System.Drawing.Point(60, 377);
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
            this.label13.Location = new System.Drawing.Point(32, 404);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "หัก";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 430);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "6. น้ำมันคงเหลือในบัญชี (3+4-5)";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 458);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(160, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "7. ผลต่างน้ำมันปัจจุบัน (2-6)";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 484);
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
            this.label18.Location = new System.Drawing.Point(32, 484);
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
            this.label19.Location = new System.Drawing.Point(60, 484);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 16);
            this.label19.TabIndex = 0;
            this.label19.Text = "ผลต่างสะสมยกมา";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 512);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(194, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "9. ผลต่างสะสมปัจจุบันยกไป (7+8)";
            // 
            // lblEndbal
            // 
            this.lblEndbal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndbal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblEndbal.Location = new System.Drawing.Point(30, 24);
            this.lblEndbal.Name = "lblEndbal";
            this.lblEndbal.Size = new System.Drawing.Size(125, 16);
            this.lblEndbal.TabIndex = 0;
            this.lblEndbal.Text = "0.00";
            this.lblEndbal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAccbal
            // 
            this.lblAccbal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccbal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAccbal.Location = new System.Drawing.Point(30, 158);
            this.lblAccbal.Name = "lblAccbal";
            this.lblAccbal.Size = new System.Drawing.Size(125, 16);
            this.lblAccbal.TabIndex = 0;
            this.lblAccbal.Text = "0.00";
            this.lblAccbal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDifqty
            // 
            this.lblDifqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDifqty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDifqty.Location = new System.Drawing.Point(30, 186);
            this.lblDifqty.Name = "lblDifqty";
            this.lblDifqty.Size = new System.Drawing.Size(125, 16);
            this.lblDifqty.TabIndex = 0;
            this.lblDifqty.Text = "0.00";
            this.lblDifqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDif
            // 
            this.lblTotalDif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDif.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTotalDif.Location = new System.Drawing.Point(30, 240);
            this.lblTotalDif.Name = "lblTotalDif";
            this.lblTotalDif.Size = new System.Drawing.Size(125, 16);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSyncRcvqty);
            this.panel1.Controls.Add(this.lblEndbal);
            this.panel1.Controls.Add(this.numSalqty);
            this.panel1.Controls.Add(this.numRcvqty);
            this.panel1.Controls.Add(this.numBegbal);
            this.panel1.Controls.Add(this.numBegdif);
            this.panel1.Controls.Add(this.lblDother);
            this.panel1.Controls.Add(this.lblAccbal);
            this.panel1.Controls.Add(this.lblDifqty);
            this.panel1.Controls.Add(this.lblTotalDif);
            this.panel1.Location = new System.Drawing.Point(291, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 264);
            this.panel1.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(114, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 89;
            this.label4.Text = "(ลิตร)";
            // 
            // numSalqty
            // 
            this.numSalqty._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSalqty._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.numSalqty._DecimalDigit = 2;
            this.numSalqty._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.numSalqty._MaxLength = 30;
            this.numSalqty._ReadOnly = true;
            this.numSalqty._SelectionLength = 0;
            this.numSalqty._SelectionStart = 4;
            this.numSalqty._Text = "0.00";
            this.numSalqty._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSalqty._UseThoundsandSeparate = true;
            this.numSalqty._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.numSalqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numSalqty.BackColor = System.Drawing.Color.White;
            this.numSalqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSalqty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numSalqty.Location = new System.Drawing.Point(3, 101);
            this.numSalqty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numSalqty.Name = "numSalqty";
            this.numSalqty.Size = new System.Drawing.Size(152, 23);
            this.numSalqty.TabIndex = 5;
            this.numSalqty._ValueChanged += new System.EventHandler(this.numSalqty__ValueChanged);
            this.numSalqty._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // numRcvqty
            // 
            this.numRcvqty._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRcvqty._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.numRcvqty._DecimalDigit = 2;
            this.numRcvqty._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.numRcvqty._MaxLength = 30;
            this.numRcvqty._ReadOnly = true;
            this.numRcvqty._SelectionLength = 0;
            this.numRcvqty._SelectionStart = 4;
            this.numRcvqty._Text = "0.00";
            this.numRcvqty._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRcvqty._UseThoundsandSeparate = true;
            this.numRcvqty._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.numRcvqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numRcvqty.BackColor = System.Drawing.Color.White;
            this.numRcvqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRcvqty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numRcvqty.Location = new System.Drawing.Point(28, 74);
            this.numRcvqty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numRcvqty.Name = "numRcvqty";
            this.numRcvqty.Size = new System.Drawing.Size(127, 23);
            this.numRcvqty.TabIndex = 4;
            this.numRcvqty._ValueChanged += new System.EventHandler(this.numRcvqty__ValueChanged);
            this.numRcvqty._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // numBegbal
            // 
            this.numBegbal._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numBegbal._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.numBegbal._DecimalDigit = 2;
            this.numBegbal._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.numBegbal._MaxLength = 30;
            this.numBegbal._ReadOnly = true;
            this.numBegbal._SelectionLength = 0;
            this.numBegbal._SelectionStart = 4;
            this.numBegbal._Text = "0.00";
            this.numBegbal._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBegbal._UseThoundsandSeparate = true;
            this.numBegbal._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.numBegbal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numBegbal.BackColor = System.Drawing.Color.White;
            this.numBegbal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numBegbal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numBegbal.Location = new System.Drawing.Point(3, 47);
            this.numBegbal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numBegbal.Name = "numBegbal";
            this.numBegbal.Size = new System.Drawing.Size(152, 23);
            this.numBegbal.TabIndex = 3;
            this.numBegbal._ValueChanged += new System.EventHandler(this.numBegbal__ValueChanged);
            this.numBegbal._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // numBegdif
            // 
            this.numBegdif._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numBegdif._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.numBegdif._DecimalDigit = 2;
            this.numBegdif._MaximumValue = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            262144});
            this.numBegdif._MaxLength = 30;
            this.numBegdif._ReadOnly = true;
            this.numBegdif._SelectionLength = 0;
            this.numBegdif._SelectionStart = 4;
            this.numBegdif._Text = "0.00";
            this.numBegdif._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBegdif._UseThoundsandSeparate = true;
            this.numBegdif._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.numBegdif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numBegdif.BackColor = System.Drawing.Color.White;
            this.numBegdif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numBegdif.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numBegdif.Location = new System.Drawing.Point(3, 208);
            this.numBegdif.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numBegdif.Name = "numBegdif";
            this.numBegdif.Size = new System.Drawing.Size(152, 23);
            this.numBegdif.TabIndex = 6;
            this.numBegdif._ValueChanged += new System.EventHandler(this.numBegdif__ValueChanged);
            this.numBegdif._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // lblDother
            // 
            this.lblDother.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDother.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDother.Location = new System.Drawing.Point(30, 132);
            this.lblDother.Name = "lblDother";
            this.lblDother.Size = new System.Drawing.Size(125, 16);
            this.lblDother.TabIndex = 0;
            this.lblDother.Text = "0.00";
            this.lblDother.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDother
            // 
            this.btnDother.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDother.Location = new System.Drawing.Point(62, 401);
            this.btnDother.Name = "btnDother";
            this.btnDother.Size = new System.Drawing.Size(66, 23);
            this.btnDother.TabIndex = 100;
            this.btnDother.TabStop = false;
            this.btnDother.Text = "อื่น ๆ  ...";
            this.btnDother.UseVisualStyleBackColor = true;
            this.btnDother.Click += new System.EventHandler(this.btnDother_Click);
            // 
            // btnSyncRcvqty
            // 
            this.btnSyncRcvqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncRcvqty.Image = global::XPump.Properties.Resources.sync_16;
            this.btnSyncRcvqty.Location = new System.Drawing.Point(2, 73);
            this.btnSyncRcvqty.Name = "btnSyncRcvqty";
            this.btnSyncRcvqty.Size = new System.Drawing.Size(25, 25);
            this.btnSyncRcvqty.TabIndex = 98;
            this.btnSyncRcvqty.TabStop = false;
            this.btnSyncRcvqty.UseVisualStyleBackColor = true;
            this.btnSyncRcvqty.Click += new System.EventHandler(this.btnSyncRcvqty_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Image = global::XPump.Properties.Resources.stop_16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(233, 545);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.btnCancel.Size = new System.Drawing.Size(168, 34);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "ยกเลิกการแก้ไข <Esc>";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Enabled = false;
            this.btnOK.Image = global::XPump.Properties.Resources.save_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(59, 545);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new System.Windows.Forms.Padding(5, 3, 12, 3);
            this.btnOK.Size = new System.Drawing.Size(168, 34);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "บันทึกข้อมูล <F9>";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.col_tank_name.Visible = false;
            this.col_tank_name.Width = 140;
            // 
            // col_section_name
            // 
            this.col_section_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_section_name.DataPropertyName = "section_name";
            this.col_section_name.HeaderText = "เลขที่ถัง";
            this.col_section_name.MinimumWidth = 140;
            this.col_section_name.Name = "col_section_name";
            this.col_section_name.ReadOnly = true;
            // 
            // col_rcvqty
            // 
            this.col_rcvqty.DataPropertyName = "rcvqty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_rcvqty.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_rcvqty.HeaderText = "Rcv Qty.";
            this.col_rcvqty.MinimumWidth = 120;
            this.col_rcvqty.Name = "col_rcvqty";
            this.col_rcvqty.ReadOnly = true;
            this.col_rcvqty.Visible = false;
            this.col_rcvqty.Width = 120;
            // 
            // col_accbal
            // 
            this.col_accbal.DataPropertyName = "accbal";
            this.col_accbal.HeaderText = "คงเหลือในบัญชี (ลิตร)";
            this.col_accbal.Name = "col_accbal";
            this.col_accbal.ReadOnly = true;
            // 
            // col_btn_rcvqty
            // 
            this.col_btn_rcvqty.HeaderText = "";
            this.col_btn_rcvqty.MinimumWidth = 23;
            this.col_btn_rcvqty.Name = "col_btn_rcvqty";
            this.col_btn_rcvqty.ReadOnly = true;
            this.col_btn_rcvqty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_btn_rcvqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_btn_rcvqty.Width = 23;
            // 
            // col_qty
            // 
            this.col_qty.DataPropertyName = "qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_qty.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_qty.HeaderText = "ปริมาณที่ตรวจวัดได้ (ลิตร)";
            this.col_qty.MinimumWidth = 160;
            this.col_qty.Name = "col_qty";
            this.col_qty.ReadOnly = true;
            this.col_qty.Width = 160;
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
            // col_working_express_db
            // 
            this.col_working_express_db.DataPropertyName = "working_express_db";
            this.col_working_express_db.HeaderText = "Working Express DB";
            this.col_working_express_db.Name = "col_working_express_db";
            this.col_working_express_db.ReadOnly = true;
            this.col_working_express_db.Visible = false;
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
            // col_salqty
            // 
            this.col_salqty.DataPropertyName = "salqty";
            this.col_salqty.HeaderText = "Sal Qty.";
            this.col_salqty.Name = "col_salqty";
            this.col_salqty.ReadOnly = true;
            this.col_salqty.Visible = false;
            // 
            // col_dother
            // 
            this.col_dother.DataPropertyName = "dother";
            this.col_dother.HeaderText = "Dother";
            this.col_dother.Name = "col_dother";
            this.col_dother.ReadOnly = true;
            this.col_dother.Visible = false;
            // 
            // DialogDayendEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 595);
            this.Controls.Add(this.btnDother);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label19);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnOK;
        private CC.XNumEdit inline_qty;
        private System.Windows.Forms.Label lblEndbal;
        private System.Windows.Forms.Label lblAccbal;
        private System.Windows.Forms.Label lblDifqty;
        private System.Windows.Forms.Label lblTotalDif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSaldat;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSyncRcvqty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private CC.XNumEdit numSalqty;
        private CC.XNumEdit numRcvqty;
        private CC.XNumEdit numBegbal;
        private CC.XNumEdit numBegdif;
        private System.Windows.Forms.Label lblDother;
        private System.Windows.Forms.Button btnDother;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcvqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_accbal;
        private System.Windows.Forms.DataGridViewButtonColumn col_btn_rcvqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dayend_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_section_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_daysttak;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_creby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cretime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgby;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_chgtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_salqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dother;
    }
}