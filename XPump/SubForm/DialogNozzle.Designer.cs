namespace XPump.SubForm
{
    partial class DialogNozzle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv = new CC.XDatagrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col__isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_isactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nozzle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTank = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnStopItem = new System.Windows.Forms.Button();
            this.btnSaveItem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Location = new System.Drawing.Point(5, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 218);
            this.panel1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowSortByColumnHeaderClicked = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeight = 28;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_name,
            this.col_desc,
            this.col__isactive,
            this.col_remark,
            this.col_isactive,
            this.col_nozzle,
            this.col_working_express_db});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F);
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
            this.dgv.Size = new System.Drawing.Size(655, 218);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
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
            // col_name
            // 
            this.col_name.DataPropertyName = "name";
            this.col_name.HeaderText = "เลขที่หัวจ่าย";
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
            // col__isactive
            // 
            this.col__isactive.DataPropertyName = "_isactive";
            this.col__isactive.HeaderText = "สถานะ";
            this.col__isactive.MinimumWidth = 100;
            this.col__isactive.Name = "col__isactive";
            this.col__isactive.ReadOnly = true;
            // 
            // col_remark
            // 
            this.col_remark.DataPropertyName = "remark";
            this.col_remark.HeaderText = "Remark";
            this.col_remark.Name = "col_remark";
            this.col_remark.ReadOnly = true;
            this.col_remark.Visible = false;
            // 
            // col_isactive
            // 
            this.col_isactive.DataPropertyName = "isactive";
            this.col_isactive.HeaderText = "Isactive";
            this.col_isactive.Name = "col_isactive";
            this.col_isactive.ReadOnly = true;
            this.col_isactive.Visible = false;
            // 
            // col_nozzle
            // 
            this.col_nozzle.DataPropertyName = "nozzle";
            this.col_nozzle.HeaderText = "Nozzle";
            this.col_nozzle.Name = "col_nozzle";
            this.col_nozzle.ReadOnly = true;
            this.col_nozzle.Visible = false;
            // 
            // col_working_express_db
            // 
            this.col_working_express_db.DataPropertyName = "working_express_db";
            this.col_working_express_db.HeaderText = "Working Express DB";
            this.col_working_express_db.Name = "col_working_express_db";
            this.col_working_express_db.ReadOnly = true;
            this.col_working_express_db.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "แท๊งค์ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "รหัสช่องเก็บน้ำมัน :";
            // 
            // lblTank
            // 
            this.lblTank.AutoSize = true;
            this.lblTank.Location = new System.Drawing.Point(143, 11);
            this.lblTank.Name = "lblTank";
            this.lblTank.Size = new System.Drawing.Size(26, 16);
            this.lblTank.TabIndex = 1;
            this.lblTank.Text = "xxx";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(143, 32);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(26, 16);
            this.lblSection.TabIndex = 1;
            this.lblSection.Text = "xxx";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(7, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "หัวจ่ายน้ำมัน";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddItem.Image = global::XPump.Properties.Resources.add_16;
            this.btnAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItem.Location = new System.Drawing.Point(305, 52);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(50, 24);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "เพิ่ม";
            this.btnAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDeleteItem.Image = global::XPump.Properties.Resources.delete_16;
            this.btnDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteItem.Location = new System.Drawing.Point(414, 52);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(45, 24);
            this.btnDeleteItem.TabIndex = 5;
            this.btnDeleteItem.Text = "ลบ";
            this.btnDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEditItem.Image = global::XPump.Properties.Resources.edit_16;
            this.btnEditItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditItem.Location = new System.Drawing.Point(356, 52);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(57, 24);
            this.btnEditItem.TabIndex = 4;
            this.btnEditItem.Text = "แก้ไข";
            this.btnEditItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnStopItem
            // 
            this.btnStopItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnStopItem.Image = global::XPump.Properties.Resources.stop_16;
            this.btnStopItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopItem.Location = new System.Drawing.Point(531, 52);
            this.btnStopItem.Name = "btnStopItem";
            this.btnStopItem.Size = new System.Drawing.Size(129, 24);
            this.btnStopItem.TabIndex = 7;
            this.btnStopItem.Text = "ยกเลิกการเพิ่ม/แก้ไข";
            this.btnStopItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopItem.UseVisualStyleBackColor = true;
            this.btnStopItem.Click += new System.EventHandler(this.btnStopItem_Click);
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSaveItem.Image = global::XPump.Properties.Resources.save_16;
            this.btnSaveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveItem.Location = new System.Drawing.Point(470, 52);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(60, 24);
            this.btnSaveItem.TabIndex = 6;
            this.btnSaveItem.Text = "บันทึก";
            this.btnSaveItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveItem.UseVisualStyleBackColor = true;
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_Click);
            // 
            // DialogNozzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 301);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnStopItem);
            this.Controls.Add(this.btnSaveItem);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTank);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 200);
            this.Name = "DialogNozzle";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "หัวจ่ายน้ำมัน";
            this.Load += new System.EventHandler(this.DialogNozzle_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CC.XDatagrid dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTank;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnStopItem;
        private System.Windows.Forms.Button btnSaveItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col__isactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_isactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nozzle;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_working_express_db;
    }
}