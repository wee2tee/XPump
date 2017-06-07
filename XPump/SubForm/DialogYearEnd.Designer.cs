namespace XPump.SubForm
{
    partial class DialogYearEnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogYearEnd));
            this.lblWarning = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOldYearFrom = new System.Windows.Forms.Label();
            this.lblOldYearTo = new System.Windows.Forms.Label();
            this.lblNewYearFrom = new System.Windows.Forms.Label();
            this.lblNewYearTo = new System.Windows.Forms.Label();
            this.txtYes = new CC.XTextEdit();
            this.SuspendLayout();
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWarning.Location = new System.Drawing.Point(12, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Padding = new System.Windows.Forms.Padding(10);
            this.lblWarning.Size = new System.Drawing.Size(490, 153);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Text = resources.GetString("lblWarning.Text");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ถ้าท่านได้สำรองข้อมูลไว้แล้ว ให้ป้อน YES เพื่อยืนยันให้ประมวลผลสิ้นปี";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Enabled = false;
            this.btnOK.Image = global::XPump.Properties.Resources.ok_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(172, 294);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new System.Windows.Forms.Padding(5, 0, 8, 0);
            this.btnOK.Size = new System.Drawing.Size(82, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "ตกลง";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::XPump.Properties.Resources.stop_16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(260, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCancel.Size = new System.Drawing.Size(82, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "รอบปีที่จะทำการประมวลผล(ล้างข้อมูลออก)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "รอบปีใหม่(หลังการประมวลผล)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(382, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(382, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "-";
            // 
            // lblOldYearFrom
            // 
            this.lblOldYearFrom.BackColor = System.Drawing.Color.White;
            this.lblOldYearFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOldYearFrom.Location = new System.Drawing.Point(288, 182);
            this.lblOldYearFrom.Name = "lblOldYearFrom";
            this.lblOldYearFrom.Size = new System.Drawing.Size(90, 21);
            this.lblOldYearFrom.TabIndex = 1;
            // 
            // lblOldYearTo
            // 
            this.lblOldYearTo.BackColor = System.Drawing.Color.White;
            this.lblOldYearTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOldYearTo.Location = new System.Drawing.Point(396, 182);
            this.lblOldYearTo.Name = "lblOldYearTo";
            this.lblOldYearTo.Size = new System.Drawing.Size(90, 21);
            this.lblOldYearTo.TabIndex = 1;
            // 
            // lblNewYearFrom
            // 
            this.lblNewYearFrom.BackColor = System.Drawing.Color.White;
            this.lblNewYearFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewYearFrom.Location = new System.Drawing.Point(288, 208);
            this.lblNewYearFrom.Name = "lblNewYearFrom";
            this.lblNewYearFrom.Size = new System.Drawing.Size(90, 21);
            this.lblNewYearFrom.TabIndex = 1;
            // 
            // lblNewYearTo
            // 
            this.lblNewYearTo.BackColor = System.Drawing.Color.White;
            this.lblNewYearTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewYearTo.Location = new System.Drawing.Point(396, 208);
            this.lblNewYearTo.Name = "lblNewYearTo";
            this.lblNewYearTo.Size = new System.Drawing.Size(90, 21);
            this.lblNewYearTo.TabIndex = 1;
            // 
            // txtYes
            // 
            this.txtYes._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYes._CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtYes._MaxLength = 3;
            this.txtYes._ReadOnly = false;
            this.txtYes._Text = "";
            this.txtYes._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYes.BackColor = System.Drawing.Color.White;
            this.txtYes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtYes.Location = new System.Drawing.Point(424, 252);
            this.txtYes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYes.Name = "txtYes";
            this.txtYes.Size = new System.Drawing.Size(42, 23);
            this.txtYes.TabIndex = 1;
            this.txtYes._TextChanged += new System.EventHandler(this.txtYes__TextChanged);
            this.txtYes._Leave += new System.EventHandler(this.txtYes__Leave);
            // 
            // DialogYearEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 343);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtYes);
            this.Controls.Add(this.lblNewYearTo);
            this.Controls.Add(this.lblOldYearTo);
            this.Controls.Add(this.lblNewYearFrom);
            this.Controls.Add(this.lblOldYearFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblWarning);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogYearEnd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ประมวลผลสิ้นปี";
            this.Load += new System.EventHandler(this.DialogYearEnd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label label2;
        private CC.XTextEdit txtYes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOldYearFrom;
        private System.Windows.Forms.Label lblOldYearTo;
        private System.Windows.Forms.Label lblNewYearFrom;
        private System.Windows.Forms.Label lblNewYearTo;
    }
}