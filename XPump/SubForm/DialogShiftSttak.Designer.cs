namespace XPump.SubForm
{
    partial class DialogShiftSttak
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
            this.inline_qty = new CC.XNumEdit();
            this.dgv = new CC.XDatagrid();
            this.col_sttak_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_takdat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_section_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_tank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_section_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_sttak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sttak_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.inline_qty);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 190);
            this.panel1.TabIndex = 0;
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
            this.inline_qty._SelectionStart = 5;
            this.inline_qty._Text = "-1.00";
            this.inline_qty._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inline_qty._UseThoundsandSeparate = true;
            this.inline_qty._Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147352576});
            this.inline_qty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inline_qty.BackColor = System.Drawing.Color.White;
            this.inline_qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_qty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_qty.Location = new System.Drawing.Point(554, 35);
            this.inline_qty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_qty.Name = "inline_qty";
            this.inline_qty.Size = new System.Drawing.Size(140, 23);
            this.inline_qty.TabIndex = 2;
            this.inline_qty._ValueChanged += new System.EventHandler(this.inline_qty__ValueChanged);
            this.inline_qty._GotFocus += new System.EventHandler(this.inline_qty__GotFocus);
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 28;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_sttak_id,
            this.col_sttak_takdat,
            this.col_sttak_section_id,
            this.col_sttak_tank_name,
            this.col_sttak_section_name,
            this.col_sttak_stkcod,
            this.col_sttak_stkdes,
            this.col_sttak_qty,
            this.col_sttak_sttak,
            this.col_sttak_working_express_db});
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
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 26;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(697, 190);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 1;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
            // 
            // col_sttak_id
            // 
            this.col_sttak_id.DataPropertyName = "id";
            this.col_sttak_id.HeaderText = "ID";
            this.col_sttak_id.Name = "col_sttak_id";
            this.col_sttak_id.ReadOnly = true;
            this.col_sttak_id.Visible = false;
            // 
            // col_sttak_takdat
            // 
            this.col_sttak_takdat.DataPropertyName = "takdat";
            this.col_sttak_takdat.HeaderText = "วันที่";
            this.col_sttak_takdat.MinimumWidth = 80;
            this.col_sttak_takdat.Name = "col_sttak_takdat";
            this.col_sttak_takdat.ReadOnly = true;
            this.col_sttak_takdat.Visible = false;
            this.col_sttak_takdat.Width = 80;
            // 
            // col_sttak_section_id
            // 
            this.col_sttak_section_id.DataPropertyName = "section_id";
            this.col_sttak_section_id.HeaderText = "Section ID";
            this.col_sttak_section_id.Name = "col_sttak_section_id";
            this.col_sttak_section_id.ReadOnly = true;
            this.col_sttak_section_id.Visible = false;
            // 
            // col_sttak_tank_name
            // 
            this.col_sttak_tank_name.DataPropertyName = "tank_name";
            this.col_sttak_tank_name.HeaderText = "รหัสแท๊งค์";
            this.col_sttak_tank_name.MinimumWidth = 140;
            this.col_sttak_tank_name.Name = "col_sttak_tank_name";
            this.col_sttak_tank_name.ReadOnly = true;
            this.col_sttak_tank_name.Width = 140;
            // 
            // col_sttak_section_name
            // 
            this.col_sttak_section_name.DataPropertyName = "section_name";
            this.col_sttak_section_name.HeaderText = "เลขที่ถัง";
            this.col_sttak_section_name.MinimumWidth = 140;
            this.col_sttak_section_name.Name = "col_sttak_section_name";
            this.col_sttak_section_name.ReadOnly = true;
            this.col_sttak_section_name.Width = 140;
            // 
            // col_sttak_stkcod
            // 
            this.col_sttak_stkcod.DataPropertyName = "stkcod";
            this.col_sttak_stkcod.HeaderText = "รหัสสินค้า";
            this.col_sttak_stkcod.MinimumWidth = 140;
            this.col_sttak_stkcod.Name = "col_sttak_stkcod";
            this.col_sttak_stkcod.ReadOnly = true;
            this.col_sttak_stkcod.Width = 140;
            // 
            // col_sttak_stkdes
            // 
            this.col_sttak_stkdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_sttak_stkdes.DataPropertyName = "stkdes";
            this.col_sttak_stkdes.HeaderText = "รายละเอียด";
            this.col_sttak_stkdes.Name = "col_sttak_stkdes";
            this.col_sttak_stkdes.ReadOnly = true;
            // 
            // col_sttak_qty
            // 
            this.col_sttak_qty.DataPropertyName = "qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_sttak_qty.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_sttak_qty.HeaderText = "ปริมาณที่วัดได้ (ลิตร)";
            this.col_sttak_qty.MinimumWidth = 140;
            this.col_sttak_qty.Name = "col_sttak_qty";
            this.col_sttak_qty.ReadOnly = true;
            this.col_sttak_qty.Width = 140;
            // 
            // col_sttak_sttak
            // 
            this.col_sttak_sttak.DataPropertyName = "shiftsttak";
            this.col_sttak_sttak.HeaderText = "Shift Sttak";
            this.col_sttak_sttak.Name = "col_sttak_sttak";
            this.col_sttak_sttak.ReadOnly = true;
            this.col_sttak_sttak.Visible = false;
            // 
            // col_sttak_working_express_db
            // 
            this.col_sttak_working_express_db.DataPropertyName = "working_express_db";
            this.col_sttak_working_express_db.HeaderText = "Working Express DB";
            this.col_sttak_working_express_db.Name = "col_sttak_working_express_db";
            this.col_sttak_working_express_db.ReadOnly = true;
            this.col_sttak_working_express_db.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::XPump.Properties.Resources.save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(236, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnSave.Size = new System.Drawing.Size(112, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "บันทึก <F9>";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::XPump.Properties.Resources.stop_16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(354, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(112, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(77, 163);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(46, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // DialogShiftSttak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 248);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEdit);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogShiftSttak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "บันทึกปริมาณน้ำมันที่ตรวจนับได้";
            this.Load += new System.EventHandler(this.DialogShiftSttak_Load);
            this.Shown += new System.EventHandler(this.DialogShiftSttak_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_takdat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_section_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_tank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_section_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_sttak;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sttak_working_express_db;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private CC.XNumEdit inline_qty;
        private System.Windows.Forms.Button btnEdit;
    }
}