namespace XPump.SubForm
{
    partial class DialogStmasChangeCode
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNew = new CC.XTextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(95, 94);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(178, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "เปลี่ยนเป็น";
            // 
            // txtNew
            // 
            this.txtNew._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNew._MaxLength = 32767;
            this.txtNew._ReadOnly = false;
            this.txtNew._Text = "";
            this.txtNew._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNew.BackColor = System.Drawing.Color.White;
            this.txtNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNew.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNew.Location = new System.Drawing.Point(129, 51);
            this.txtNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(162, 23);
            this.txtNew.TabIndex = 0;
            this.txtNew._TextChanged += new System.EventHandler(this.txtNew__TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "รหัสเดิม";
            // 
            // txtOld
            // 
            this.txtOld.Enabled = false;
            this.txtOld.Location = new System.Drawing.Point(129, 24);
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(162, 23);
            this.txtOld.TabIndex = 3;
            // 
            // DialogStmasChangeCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 136);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogStmasChangeCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "StockFile";
            this.Text = "เปลี่ยนรหัสสินค้า";
            this.Load += new System.EventHandler(this.DialogStmasChangeCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private CC.XTextEdit txtNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOld;
    }
}