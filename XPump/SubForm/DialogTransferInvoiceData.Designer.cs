namespace XPump.SubForm
{
    partial class DialogTransferInvoiceData
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
            this.cDocPrefix = new CC.XDropdownList();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cDateFrom = new CC.XDatePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cDateTo = new CC.XDatePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cGroupBill = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            this.lblProgressDocnum = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cDocPrefix
            // 
            this.cDocPrefix._ReadOnly = false;
            this.cDocPrefix._SelectedItem = null;
            this.cDocPrefix._Text = "";
            this.cDocPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cDocPrefix.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cDocPrefix.Location = new System.Drawing.Point(132, 103);
            this.cDocPrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cDocPrefix.Name = "cDocPrefix";
            this.cDocPrefix.Size = new System.Drawing.Size(238, 23);
            this.cDocPrefix.TabIndex = 0;
            this.cDocPrefix._SelectedItemChanged += new System.EventHandler(this.cDocPrefix__SelectedItemChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "บิลขายจากเมนู";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "รายการของวันที่";
            // 
            // cDateFrom
            // 
            this.cDateFrom._ReadOnly = false;
            this.cDateFrom._SelectedDate = null;
            this.cDateFrom.BackColor = System.Drawing.Color.White;
            this.cDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cDateFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cDateFrom.Location = new System.Drawing.Point(132, 135);
            this.cDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cDateFrom.Name = "cDateFrom";
            this.cDateFrom.Size = new System.Drawing.Size(103, 23);
            this.cDateFrom.TabIndex = 1;
            this.cDateFrom._SelectedDateChanged += new System.EventHandler(this.cDateFrom__SelectedDateChanged);
            this.cDateFrom._Leave += new System.EventHandler(this.cDateFrom__Leave);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 66);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(20, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "หมายเหตุ : โปรแกรมจะทำการโอนข้อมูลเฉพาะรายการ\r\nที่ยังไม่เคยโอนเข้าเอ็กซ์เพรสเท่าน" +
    "ั้น";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(101, 276);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "ตกลง <F9>";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(212, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cDateTo
            // 
            this.cDateTo._ReadOnly = false;
            this.cDateTo._SelectedDate = null;
            this.cDateTo.BackColor = System.Drawing.Color.White;
            this.cDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cDateTo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cDateTo.Location = new System.Drawing.Point(267, 135);
            this.cDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cDateTo.Name = "cDateTo";
            this.cDateTo.Size = new System.Drawing.Size(103, 23);
            this.cDateTo.TabIndex = 2;
            this.cDateTo._SelectedDateChanged += new System.EventHandler(this.cDateTo__SelectedDateChanged);
            this.cDateTo._Leave += new System.EventHandler(this.cDateTo__Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "ถึง";
            // 
            // cGroupBill
            // 
            this.cGroupBill.AutoSize = true;
            this.cGroupBill.Location = new System.Drawing.Point(132, 175);
            this.cGroupBill.Name = "cGroupBill";
            this.cGroupBill.Size = new System.Drawing.Size(176, 20);
            this.cGroupBill.TabIndex = 3;
            this.cGroupBill.Text = "รวมรายการเป็น 1 วัน : 1 บิล";
            this.cGroupBill.UseVisualStyleBackColor = true;
            this.cGroupBill.CheckedChanged += new System.EventHandler(this.cGroupBill_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(36, 237);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(344, 14);
            this.progressBar1.TabIndex = 6;
            // 
            // lblProgressPercent
            // 
            this.lblProgressPercent.Location = new System.Drawing.Point(325, 218);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(56, 16);
            this.lblProgressPercent.TabIndex = 7;
            this.lblProgressPercent.Text = "0%";
            this.lblProgressPercent.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblProgressDocnum
            // 
            this.lblProgressDocnum.Location = new System.Drawing.Point(139, 218);
            this.lblProgressDocnum.Name = "lblProgressDocnum";
            this.lblProgressDocnum.Size = new System.Drawing.Size(140, 16);
            this.lblProgressDocnum.TabIndex = 7;
            this.lblProgressDocnum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DialogTransferInvoiceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 331);
            this.Controls.Add(this.lblProgressDocnum);
            this.Controls.Add(this.lblProgressPercent);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cGroupBill);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cDateTo);
            this.Controls.Add(this.cDateFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cDocPrefix);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogTransferInvoiceData";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "โอนข้อมูลบิลขาย";
            this.Load += new System.EventHandler(this.DialogTransferInvoiceData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CC.XDropdownList cDocPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CC.XDatePicker cDateFrom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private CC.XDatePicker cDateTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cGroupBill;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgressPercent;
        private System.Windows.Forms.Label lblProgressDocnum;
    }
}