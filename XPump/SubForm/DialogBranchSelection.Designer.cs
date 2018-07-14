namespace XPump.SubForm
{
    partial class DialogBranchSelection
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv = new CC.XDatagrid();
            this.col_branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_depcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_servername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dbname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_db_connection_config = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(23, 22);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
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
            this.col_branch,
            this.col_depcod,
            this.col_servername,
            this.col_dbname,
            this.col_working_express_db,
            this.col_db_connection_config});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
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
            this.dgv.Size = new System.Drawing.Size(23, 22);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // col_branch
            // 
            this.col_branch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_branch.DataPropertyName = "branch";
            this.col_branch.HeaderText = "ชื่อสถานีบริการฯ (สาขา)";
            this.col_branch.Name = "col_branch";
            this.col_branch.ReadOnly = true;
            // 
            // col_depcod
            // 
            this.col_depcod.DataPropertyName = "depcod";
            this.col_depcod.HeaderText = "รหัสแผนก";
            this.col_depcod.MinimumWidth = 70;
            this.col_depcod.Name = "col_depcod";
            this.col_depcod.ReadOnly = true;
            this.col_depcod.Width = 70;
            // 
            // col_servername
            // 
            this.col_servername.DataPropertyName = "servername";
            this.col_servername.HeaderText = "ชื่อเซิร์ฟเวอร์";
            this.col_servername.Name = "col_servername";
            this.col_servername.ReadOnly = true;
            // 
            // col_dbname
            // 
            this.col_dbname.DataPropertyName = "dbname";
            this.col_dbname.HeaderText = "ชื่อฐานข้อมูล";
            this.col_dbname.MinimumWidth = 80;
            this.col_dbname.Name = "col_dbname";
            this.col_dbname.ReadOnly = true;
            this.col_dbname.Width = 120;
            // 
            // col_working_express_db
            // 
            this.col_working_express_db.DataPropertyName = "working_express_db";
            this.col_working_express_db.HeaderText = "WorkingExpressDb";
            this.col_working_express_db.Name = "col_working_express_db";
            this.col_working_express_db.ReadOnly = true;
            this.col_working_express_db.Visible = false;
            // 
            // col_db_connection_config
            // 
            this.col_db_connection_config.DataPropertyName = "db_connection_config";
            this.col_db_connection_config.HeaderText = "DbConnectionConfig";
            this.col_db_connection_config.Name = "col_db_connection_config";
            this.col_db_connection_config.ReadOnly = true;
            this.col_db_connection_config.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(111, 92);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(192, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "เลือกสาขา";
            // 
            // cbBranch
            // 
            this.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Location = new System.Drawing.Point(114, 39);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(208, 24);
            this.cbBranch.TabIndex = 0;
            this.cbBranch.SelectedIndexChanged += new System.EventHandler(this.cbBranch_SelectedIndexChanged);
            // 
            // DialogBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 145);
            this.Controls.Add(this.cbBranch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DialogBranch";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "เลือกสาขา (แผนก)";
            this.Load += new System.EventHandler(this.DialogBranch_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_depcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_servername;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dbname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_db_connection_config;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBranch;
    }
}