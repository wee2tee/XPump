namespace XPump.SubForm
{
    partial class DialogRcv
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabRcv = new System.Windows.Forms.TabControl();
            this.tabCreditCard = new System.Windows.Forms.TabPage();
            this.btnAddCreditCard = new System.Windows.Forms.Button();
            this.dgvRcv1 = new CC.XDatagrid();
            this.tabCoupon = new System.Windows.Forms.TabPage();
            this.btnAddCoupon = new System.Windows.Forms.Button();
            this.dgvRcv2 = new CC.XDatagrid();
            this.col_rcv1_chqnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv1_cardno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv1_bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv1_rcvamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv1_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv1_arrcpcq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv1_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_rcv2_chqnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv2_coupon_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv2_bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv2_working_express_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv2_arrcpcq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rcv2_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabRcv.SuspendLayout();
            this.tabCreditCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRcv1)).BeginInit();
            this.tabCoupon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRcv2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabRcv
            // 
            this.tabRcv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRcv.Controls.Add(this.tabCreditCard);
            this.tabRcv.Controls.Add(this.tabCoupon);
            this.tabRcv.Location = new System.Drawing.Point(3, 3);
            this.tabRcv.Name = "tabRcv";
            this.tabRcv.SelectedIndex = 0;
            this.tabRcv.Size = new System.Drawing.Size(793, 212);
            this.tabRcv.TabIndex = 10;
            // 
            // tabCreditCard
            // 
            this.tabCreditCard.Controls.Add(this.btnAddCreditCard);
            this.tabCreditCard.Controls.Add(this.dgvRcv1);
            this.tabCreditCard.Location = new System.Drawing.Point(4, 25);
            this.tabCreditCard.Name = "tabCreditCard";
            this.tabCreditCard.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreditCard.Size = new System.Drawing.Size(785, 183);
            this.tabCreditCard.TabIndex = 0;
            this.tabCreditCard.Text = "  บัตรเครดิต  ";
            this.tabCreditCard.UseVisualStyleBackColor = true;
            // 
            // btnAddCreditCard
            // 
            this.btnAddCreditCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCreditCard.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddCreditCard.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddCreditCard.ForeColor = System.Drawing.Color.Green;
            this.btnAddCreditCard.Image = global::XPump.Properties.Resources.plus_16;
            this.btnAddCreditCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCreditCard.Location = new System.Drawing.Point(729, 5);
            this.btnAddCreditCard.Name = "btnAddCreditCard";
            this.btnAddCreditCard.Size = new System.Drawing.Size(52, 25);
            this.btnAddCreditCard.TabIndex = 2;
            this.btnAddCreditCard.Text = "เพิ่ม";
            this.btnAddCreditCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCreditCard.UseVisualStyleBackColor = false;
            this.btnAddCreditCard.Click += new System.EventHandler(this.btnAddCreditCard_Click);
            // 
            // dgvRcv1
            // 
            this.dgvRcv1.AllowSortByColumnHeaderClicked = false;
            this.dgvRcv1.AllowUserToAddRows = false;
            this.dgvRcv1.AllowUserToDeleteRows = false;
            this.dgvRcv1.AllowUserToResizeColumns = false;
            this.dgvRcv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRcv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvRcv1.ColumnHeadersHeight = 28;
            this.dgvRcv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRcv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_rcv1_chqnum,
            this.col_rcv1_cardno,
            this.col_rcv1_bank,
            this.col_rcv1_rcvamt,
            this.col_rcv1_working_express_db,
            this.col_rcv1_arrcpcq,
            this.col_rcv1_delete});
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRcv1.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgvRcv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRcv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRcv1.EnableHeadersVisualStyles = false;
            this.dgvRcv1.FillEmptyRow = false;
            this.dgvRcv1.FocusedRowBorderRedLine = true;
            this.dgvRcv1.Location = new System.Drawing.Point(3, 3);
            this.dgvRcv1.MultiSelect = false;
            this.dgvRcv1.Name = "dgvRcv1";
            this.dgvRcv1.ReadOnly = true;
            this.dgvRcv1.RowHeadersVisible = false;
            this.dgvRcv1.RowTemplate.Height = 26;
            this.dgvRcv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRcv1.Size = new System.Drawing.Size(779, 177);
            this.dgvRcv1.StandardTab = true;
            this.dgvRcv1.TabIndex = 1;
            // 
            // tabCoupon
            // 
            this.tabCoupon.Controls.Add(this.btnAddCoupon);
            this.tabCoupon.Controls.Add(this.dgvRcv2);
            this.tabCoupon.Location = new System.Drawing.Point(4, 25);
            this.tabCoupon.Name = "tabCoupon";
            this.tabCoupon.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoupon.Size = new System.Drawing.Size(785, 183);
            this.tabCoupon.TabIndex = 1;
            this.tabCoupon.Text = "  คูปอง  ";
            this.tabCoupon.UseVisualStyleBackColor = true;
            // 
            // btnAddCoupon
            // 
            this.btnAddCoupon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCoupon.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddCoupon.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddCoupon.ForeColor = System.Drawing.Color.Green;
            this.btnAddCoupon.Image = global::XPump.Properties.Resources.plus_16;
            this.btnAddCoupon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCoupon.Location = new System.Drawing.Point(729, 5);
            this.btnAddCoupon.Name = "btnAddCoupon";
            this.btnAddCoupon.Size = new System.Drawing.Size(52, 25);
            this.btnAddCoupon.TabIndex = 3;
            this.btnAddCoupon.Text = "เพิ่ม";
            this.btnAddCoupon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCoupon.UseVisualStyleBackColor = false;
            this.btnAddCoupon.Click += new System.EventHandler(this.btnAddCoupon_Click);
            // 
            // dgvRcv2
            // 
            this.dgvRcv2.AllowSortByColumnHeaderClicked = false;
            this.dgvRcv2.AllowUserToAddRows = false;
            this.dgvRcv2.AllowUserToDeleteRows = false;
            this.dgvRcv2.AllowUserToResizeColumns = false;
            this.dgvRcv2.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRcv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvRcv2.ColumnHeadersHeight = 28;
            this.dgvRcv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRcv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_rcv2_chqnum,
            this.col_rcv2_coupon_num,
            this.dataGridViewTextBoxColumn4,
            this.col_rcv2_bank,
            this.col_rcv2_working_express_db,
            this.col_rcv2_arrcpcq,
            this.col_rcv2_delete});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRcv2.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgvRcv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRcv2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRcv2.EnableHeadersVisualStyles = false;
            this.dgvRcv2.FillEmptyRow = false;
            this.dgvRcv2.FocusedRowBorderRedLine = true;
            this.dgvRcv2.Location = new System.Drawing.Point(3, 3);
            this.dgvRcv2.MultiSelect = false;
            this.dgvRcv2.Name = "dgvRcv2";
            this.dgvRcv2.ReadOnly = true;
            this.dgvRcv2.RowHeadersVisible = false;
            this.dgvRcv2.RowTemplate.Height = 26;
            this.dgvRcv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRcv2.Size = new System.Drawing.Size(779, 177);
            this.dgvRcv2.StandardTab = true;
            this.dgvRcv2.TabIndex = 1;
            // 
            // col_rcv1_chqnum
            // 
            this.col_rcv1_chqnum.DataPropertyName = "chqnum";
            this.col_rcv1_chqnum.HeaderText = "รหัสรายการ";
            this.col_rcv1_chqnum.MinimumWidth = 120;
            this.col_rcv1_chqnum.Name = "col_rcv1_chqnum";
            this.col_rcv1_chqnum.ReadOnly = true;
            this.col_rcv1_chqnum.Width = 120;
            // 
            // col_rcv1_cardno
            // 
            this.col_rcv1_cardno.DataPropertyName = "cardnum";
            this.col_rcv1_cardno.HeaderText = "หมายเลขบัตร";
            this.col_rcv1_cardno.MinimumWidth = 160;
            this.col_rcv1_cardno.Name = "col_rcv1_cardno";
            this.col_rcv1_cardno.ReadOnly = true;
            this.col_rcv1_cardno.Width = 160;
            // 
            // col_rcv1_bank
            // 
            this.col_rcv1_bank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_rcv1_bank.DataPropertyName = "bank";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.Format = "N2";
            dataGridViewCellStyle26.NullValue = null;
            this.col_rcv1_bank.DefaultCellStyle = dataGridViewCellStyle26;
            this.col_rcv1_bank.HeaderText = "ธนาคาร";
            this.col_rcv1_bank.MinimumWidth = 80;
            this.col_rcv1_bank.Name = "col_rcv1_bank";
            this.col_rcv1_bank.ReadOnly = true;
            // 
            // col_rcv1_rcvamt
            // 
            this.col_rcv1_rcvamt.DataPropertyName = "rcvamt";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_rcv1_rcvamt.DefaultCellStyle = dataGridViewCellStyle27;
            this.col_rcv1_rcvamt.HeaderText = "จำนวนเงิน";
            this.col_rcv1_rcvamt.MinimumWidth = 120;
            this.col_rcv1_rcvamt.Name = "col_rcv1_rcvamt";
            this.col_rcv1_rcvamt.ReadOnly = true;
            this.col_rcv1_rcvamt.Width = 120;
            // 
            // col_rcv1_working_express_db
            // 
            this.col_rcv1_working_express_db.DataPropertyName = "working_express_db";
            this.col_rcv1_working_express_db.HeaderText = "Working Express DB";
            this.col_rcv1_working_express_db.Name = "col_rcv1_working_express_db";
            this.col_rcv1_working_express_db.ReadOnly = true;
            this.col_rcv1_working_express_db.Visible = false;
            // 
            // col_rcv1_arrcpcq
            // 
            this.col_rcv1_arrcpcq.DataPropertyName = "arrcpcq";
            this.col_rcv1_arrcpcq.HeaderText = "Arrcpcq";
            this.col_rcv1_arrcpcq.Name = "col_rcv1_arrcpcq";
            this.col_rcv1_arrcpcq.ReadOnly = true;
            this.col_rcv1_arrcpcq.Visible = false;
            // 
            // col_rcv1_delete
            // 
            this.col_rcv1_delete.HeaderText = "";
            this.col_rcv1_delete.MinimumWidth = 50;
            this.col_rcv1_delete.Name = "col_rcv1_delete";
            this.col_rcv1_delete.ReadOnly = true;
            this.col_rcv1_delete.Width = 50;
            // 
            // col_rcv2_chqnum
            // 
            this.col_rcv2_chqnum.HeaderText = "รหัสรายการ";
            this.col_rcv2_chqnum.MinimumWidth = 120;
            this.col_rcv2_chqnum.Name = "col_rcv2_chqnum";
            this.col_rcv2_chqnum.ReadOnly = true;
            this.col_rcv2_chqnum.Width = 120;
            // 
            // col_rcv2_coupon_num
            // 
            this.col_rcv2_coupon_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_rcv2_coupon_num.DataPropertyName = "cardnum";
            this.col_rcv2_coupon_num.HeaderText = "หมายเลขคูปอง";
            this.col_rcv2_coupon_num.MinimumWidth = 200;
            this.col_rcv2_coupon_num.Name = "col_rcv2_coupon_num";
            this.col_rcv2_coupon_num.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "rcvamt";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N2";
            dataGridViewCellStyle23.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn4.HeaderText = "จำนวนเงิน";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // col_rcv2_bank
            // 
            this.col_rcv2_bank.DataPropertyName = "bank";
            this.col_rcv2_bank.HeaderText = "Bank";
            this.col_rcv2_bank.Name = "col_rcv2_bank";
            this.col_rcv2_bank.ReadOnly = true;
            this.col_rcv2_bank.Visible = false;
            // 
            // col_rcv2_working_express_db
            // 
            this.col_rcv2_working_express_db.DataPropertyName = "working_express_db";
            this.col_rcv2_working_express_db.HeaderText = "Working Express DB";
            this.col_rcv2_working_express_db.Name = "col_rcv2_working_express_db";
            this.col_rcv2_working_express_db.ReadOnly = true;
            this.col_rcv2_working_express_db.Visible = false;
            // 
            // col_rcv2_arrcpcq
            // 
            this.col_rcv2_arrcpcq.DataPropertyName = "arrcpcq";
            this.col_rcv2_arrcpcq.HeaderText = "Arrcpcq";
            this.col_rcv2_arrcpcq.Name = "col_rcv2_arrcpcq";
            this.col_rcv2_arrcpcq.ReadOnly = true;
            this.col_rcv2_arrcpcq.Visible = false;
            // 
            // col_rcv2_delete
            // 
            this.col_rcv2_delete.HeaderText = "";
            this.col_rcv2_delete.MinimumWidth = 50;
            this.col_rcv2_delete.Name = "col_rcv2_delete";
            this.col_rcv2_delete.ReadOnly = true;
            this.col_rcv2_delete.Width = 50;
            // 
            // DialogRcv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 218);
            this.Controls.Add(this.tabRcv);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DialogRcv";
            this.ShowIcon = false;
            this.Text = "รับชำระค่าสินค้า/บริการ";
            this.Load += new System.EventHandler(this.DialogRcv_Load);
            this.tabRcv.ResumeLayout(false);
            this.tabCreditCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRcv1)).EndInit();
            this.tabCoupon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRcv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRcv;
        private System.Windows.Forms.TabPage tabCreditCard;
        private System.Windows.Forms.Button btnAddCreditCard;
        private CC.XDatagrid dgvRcv1;
        private System.Windows.Forms.TabPage tabCoupon;
        private System.Windows.Forms.Button btnAddCoupon;
        private CC.XDatagrid dgvRcv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv1_chqnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv1_cardno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv1_bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv1_rcvamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv1_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv1_arrcpcq;
        private System.Windows.Forms.DataGridViewButtonColumn col_rcv1_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv2_chqnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv2_coupon_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv2_bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv2_working_express_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rcv2_arrcpcq;
        private System.Windows.Forms.DataGridViewButtonColumn col_rcv2_delete;
    }
}