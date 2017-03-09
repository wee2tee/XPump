namespace XPump.SubForm
{
    partial class DialogShiftSelector
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
            this.dgv = new CC.XDatagrid();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_paeprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_phpprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_prrprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_saiprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shsprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sivprefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_end_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.col_seq,
            this.col_paeprefix,
            this.col_phpprefix,
            this.col_prrprefix,
            this.col_saiprefix,
            this.col_shsprefix,
            this.col_sivprefix,
            this.col_name,
            this.col_desc,
            this.col_start_time,
            this.col_end_time,
            this.col_remark,
            this.col_shift});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.FillEmptyRow = false;
            this.dgv.FocusedRowBorderRedLine = true;
            this.dgv.Location = new System.Drawing.Point(2, 2);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 26;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(439, 164);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(7, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(83, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            this.col_seq.HeaderText = "Seq";
            this.col_seq.Name = "col_seq";
            this.col_seq.ReadOnly = true;
            this.col_seq.Visible = false;
            // 
            // col_paeprefix
            // 
            this.col_paeprefix.DataPropertyName = "paeprefix";
            this.col_paeprefix.HeaderText = "paeprefix";
            this.col_paeprefix.Name = "col_paeprefix";
            this.col_paeprefix.ReadOnly = true;
            this.col_paeprefix.Visible = false;
            // 
            // col_phpprefix
            // 
            this.col_phpprefix.DataPropertyName = "phpprefix";
            this.col_phpprefix.HeaderText = "phpprefix";
            this.col_phpprefix.Name = "col_phpprefix";
            this.col_phpprefix.ReadOnly = true;
            this.col_phpprefix.Visible = false;
            // 
            // col_prrprefix
            // 
            this.col_prrprefix.DataPropertyName = "prrprefix";
            this.col_prrprefix.HeaderText = "prrprefix";
            this.col_prrprefix.Name = "col_prrprefix";
            this.col_prrprefix.ReadOnly = true;
            this.col_prrprefix.Visible = false;
            // 
            // col_saiprefix
            // 
            this.col_saiprefix.DataPropertyName = "saiprefix";
            this.col_saiprefix.HeaderText = "saiprefix";
            this.col_saiprefix.Name = "col_saiprefix";
            this.col_saiprefix.ReadOnly = true;
            this.col_saiprefix.Visible = false;
            // 
            // col_shsprefix
            // 
            this.col_shsprefix.DataPropertyName = "shsprefix";
            this.col_shsprefix.HeaderText = "shsprefix";
            this.col_shsprefix.Name = "col_shsprefix";
            this.col_shsprefix.ReadOnly = true;
            this.col_shsprefix.Visible = false;
            // 
            // col_sivprefix
            // 
            this.col_sivprefix.DataPropertyName = "sivprefix";
            this.col_sivprefix.HeaderText = "sivprefix";
            this.col_sivprefix.Name = "col_sivprefix";
            this.col_sivprefix.ReadOnly = true;
            this.col_sivprefix.Visible = false;
            // 
            // col_name
            // 
            this.col_name.DataPropertyName = "name";
            this.col_name.HeaderText = "รหัส";
            this.col_name.MinimumWidth = 120;
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Width = 120;
            // 
            // col_desc
            // 
            this.col_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_desc.DataPropertyName = "description";
            this.col_desc.HeaderText = "รายละเอียด";
            this.col_desc.Name = "col_desc";
            this.col_desc.ReadOnly = true;
            // 
            // col_start_time
            // 
            this.col_start_time.DataPropertyName = "starttime";
            this.col_start_time.HeaderText = "เวลาเริ่มต้น";
            this.col_start_time.MinimumWidth = 100;
            this.col_start_time.Name = "col_start_time";
            this.col_start_time.ReadOnly = true;
            // 
            // col_end_time
            // 
            this.col_end_time.DataPropertyName = "endtime";
            this.col_end_time.HeaderText = "เวลาสิ้นสุด";
            this.col_end_time.MinimumWidth = 100;
            this.col_end_time.Name = "col_end_time";
            this.col_end_time.ReadOnly = true;
            // 
            // col_remark
            // 
            this.col_remark.DataPropertyName = "remark";
            this.col_remark.HeaderText = "Remark";
            this.col_remark.Name = "col_remark";
            this.col_remark.ReadOnly = true;
            this.col_remark.Visible = false;
            // 
            // col_shift
            // 
            this.col_shift.DataPropertyName = "shift";
            this.col_shift.HeaderText = "Shift";
            this.col_shift.Name = "col_shift";
            this.col_shift.ReadOnly = true;
            this.col_shift.Visible = false;
            // 
            // DialogShiftSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 213);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgv);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogShiftSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.DialogShiftSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CC.XDatagrid dgv;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_paeprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_phpprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_prrprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_saiprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shsprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sivprefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_end_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shift;
    }
}