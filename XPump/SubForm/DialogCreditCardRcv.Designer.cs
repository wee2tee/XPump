namespace XPump.SubForm
{
    partial class DialogCreditCardRcv
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.bnkCod = new System.Windows.Forms.ComboBox();
            this.creditCardNum = new System.Windows.Forms.MaskedTextBox();
            this.rcvAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcvAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.bnkCod);
            this.groupBox1.Controls.Add(this.creditCardNum);
            this.groupBox1.Controls.Add(this.rcvAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(422, 58);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 16);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "เพิ่ม";
            // 
            // bnkCod
            // 
            this.bnkCod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bnkCod.FormattingEnabled = true;
            this.bnkCod.Location = new System.Drawing.Point(145, 55);
            this.bnkCod.Name = "bnkCod";
            this.bnkCod.Size = new System.Drawing.Size(262, 24);
            this.bnkCod.TabIndex = 1;
            this.bnkCod.SelectedIndexChanged += new System.EventHandler(this.bnkCod_SelectedIndexChanged);
            // 
            // creditCardNum
            // 
            this.creditCardNum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.creditCardNum.Location = new System.Drawing.Point(145, 29);
            this.creditCardNum.Mask = "0000-0000-0000-0000";
            this.creditCardNum.Name = "creditCardNum";
            this.creditCardNum.PromptChar = ' ';
            this.creditCardNum.Size = new System.Drawing.Size(205, 23);
            this.creditCardNum.TabIndex = 0;
            this.creditCardNum.TextChanged += new System.EventHandler(this.creditCardNum_TextChanged);
            // 
            // rcvAmount
            // 
            this.rcvAmount.DecimalPlaces = 2;
            this.rcvAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rcvAmount.Location = new System.Drawing.Point(145, 82);
            this.rcvAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.rcvAmount.Name = "rcvAmount";
            this.rcvAmount.Size = new System.Drawing.Size(117, 23);
            this.rcvAmount.TabIndex = 2;
            this.rcvAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rcvAmount.ThousandsSeparator = true;
            this.rcvAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rcvAmount_KeyUp);
            this.rcvAmount.Leave += new System.EventHandler(this.rcvAmount_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(34, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "ธนาคารผู้ออกบัตร";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(76, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "จำนวนเงิน";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "หมายเลขบัตรเครดิต";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(138, 159);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 33);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "ตกลง <F9>";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(254, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 33);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DialogCreditCardRcv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 212);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DialogCreditCardRcv";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "รับชำระด้วยบัตรเครดิต";
            this.Load += new System.EventHandler(this.DialogCreditCardRcv_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcvAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox creditCardNum;
        private System.Windows.Forms.NumericUpDown rcvAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox bnkCod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}