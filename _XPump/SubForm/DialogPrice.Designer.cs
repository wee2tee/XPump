namespace XPump.SubForm
{
    partial class DialogPrice
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inline_date = new CC.XDatePicker();
            this.inline_unitpr = new CC.XNumEdit();
            this.dgv = new CC.XDatagrid();
            this.col_stkcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stkdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_unitpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stmas_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit_16;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(354, 287);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(3);
            this.btnEdit.Size = new System.Drawing.Size(161, 35);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "ปรับราคาใหม่ <Alt+E>";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Image = global::XPump.Properties.Resources.ok_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(201, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new System.Windows.Forms.Padding(3);
            this.btnOK.Size = new System.Drawing.Size(147, 35);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ใช้ราคาตามนี้ <F5>";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.inline_date);
            this.panel1.Controls.Add(this.inline_unitpr);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 264);
            this.panel1.TabIndex = 4;
            // 
            // inline_date
            // 
            this.inline_date._ReadOnly = false;
            this.inline_date._SelectedDate = null;
            this.inline_date.BackColor = System.Drawing.Color.White;
            this.inline_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_date.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_date.Location = new System.Drawing.Point(36, 37);
            this.inline_date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_date.Name = "inline_date";
            this.inline_date.Size = new System.Drawing.Size(103, 23);
            this.inline_date.TabIndex = 5;
            this.inline_date._SelectedDateChanged += new System.EventHandler(this.inline_date__SelectedDateChanged);
            // 
            // inline_unitpr
            // 
            this.inline_unitpr._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_unitpr._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inline_unitpr._DecimalDigit = 2;
            this.inline_unitpr._ForeColorReadOnlyState = System.Drawing.SystemColors.ControlText;
            this.inline_unitpr._MaximumValue = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.inline_unitpr._MaxLength = 30;
            this.inline_unitpr._ReadOnly = false;
            this.inline_unitpr._SelectionLength = 0;
            this.inline_unitpr._SelectionStart = 4;
            this.inline_unitpr._Text = "0.00";
            this.inline_unitpr._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inline_unitpr._UseThoundsandSeparate = true;
            this.inline_unitpr._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.inline_unitpr.BackColor = System.Drawing.Color.White;
            this.inline_unitpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inline_unitpr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.inline_unitpr.Location = new System.Drawing.Point(36, 64);
            this.inline_unitpr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inline_unitpr.Name = "inline_unitpr";
            this.inline_unitpr.Size = new System.Drawing.Size(90, 23);
            this.inline_unitpr.TabIndex = 6;
            this.inline_unitpr._ValueChanged += new System.EventHandler(this.inline_unitpr__ValueChanged);
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
            this.dgv.ColumnHeadersHeight = 28;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_stkcod,
            this.col_stkdes,
            this.col_date,
            this.col_unitpr,
            this.col_stmas_id,
            this.col_price_id,
            this.col_working_express_db});
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
            this.dgv.Size = new System.Drawing.Size(699, 264);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgv.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgv_Scroll);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // col_stkcod
            // 
            this.col_stkcod.DataPropertyName = "stkcod";
            this.col_stkcod.HeaderText = "รหัสสินค้า";
            this.col_stkcod.MinimumWidth = 170;
            this.col_stkcod.Name = "col_stkcod";
            this.col_stkcod.ReadOnly = true;
            this.col_stkcod.Width = 170;
            // 
            // col_stkdes
            // 
            this.col_stkdes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_stkdes.DataPropertyName = "stkdes";
            this.col_stkdes.HeaderText = "รายละเอียด";
            this.col_stkdes.Name = "col_stkdes";
            this.col_stkdes.ReadOnly = true;
            // 
            // col_date
            // 
            this.col_date.DataPropertyName = "price_date";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.col_date.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_date.HeaderText = "วันที่กำหนดราคา";
            this.col_date.MinimumWidth = 110;
            this.col_date.Name = "col_date";
            this.col_date.ReadOnly = true;
            this.col_date.Width = 110;
            // 
            // col_unitpr
            // 
            this.col_unitpr.DataPropertyName = "unitpr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_unitpr.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_unitpr.HeaderText = "ราคาต่อหน่วย(ลิตร)";
            this.col_unitpr.MinimumWidth = 130;
            this.col_unitpr.Name = "col_unitpr";
            this.col_unitpr.ReadOnly = true;
            this.col_unitpr.Width = 130;
            // 
            // col_stmas_id
            // 
            this.col_stmas_id.DataPropertyName = "stmas_id";
            this.col_stmas_id.HeaderText = "Stmas Id";
            this.col_stmas_id.Name = "col_stmas_id";
            this.col_stmas_id.ReadOnly = true;
            this.col_stmas_id.Visible = false;
            // 
            // col_price_id
            // 
            this.col_price_id.DataPropertyName = "price_id";
            this.col_price_id.HeaderText = "Price Id";
            this.col_price_id.Name = "col_price_id";
            this.col_price_id.ReadOnly = true;
            this.col_price_id.Visible = false;
            // 
            // col_working_express_db
            // 
            this.col_working_express_db.DataPropertyName = "working_express_db";
            this.col_working_express_db.HeaderText = "Working Express DB";
            this.col_working_express_db.Name = "col_working_express_db";
            this.col_working_express_db.ReadOnly = true;
            this.col_working_express_db.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Image = global::XPump.Properties.Resources.save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(144, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(3);
            this.btnSave.Size = new System.Drawing.Size(241, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "บันทึกข้อมูล และ ใช้ราคาตามนี้ <F9>";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Image = global::XPump.Properties.Resources.stop_16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(391, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(186, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ยกเลิกการปรับราคา <Esc>";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DialogPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 339);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogPrice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "กำหนดราคาน้ำมันวันนี้";
            this.Load += new System.EventHandler(this.DialogPrice_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnEdit;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private CC.XNumEdit inline_unitpr;
        private CC.XDatePicker inline_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stkdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unitpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stmas_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_working_express_db;
    }
}