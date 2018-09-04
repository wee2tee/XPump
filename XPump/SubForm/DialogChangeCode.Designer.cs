namespace XPump.SubForm
{
    partial class DialogChangeCode
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
            this.lblOldCode = new System.Windows.Forms.Label();
            this.lblNewCode = new System.Windows.Forms.Label();
            this.txtOldCode = new System.Windows.Forms.TextBox();
            this.txtNewCode = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOldCode
            // 
            this.lblOldCode.AutoSize = true;
            this.lblOldCode.Location = new System.Drawing.Point(74, 27);
            this.lblOldCode.Name = "lblOldCode";
            this.lblOldCode.Size = new System.Drawing.Size(44, 16);
            this.lblOldCode.TabIndex = 0;
            this.lblOldCode.Text = "ชื่อเดิม";
            // 
            // lblNewCode
            // 
            this.lblNewCode.AutoSize = true;
            this.lblNewCode.Location = new System.Drawing.Point(74, 59);
            this.lblNewCode.Name = "lblNewCode";
            this.lblNewCode.Size = new System.Drawing.Size(46, 16);
            this.lblNewCode.TabIndex = 0;
            this.lblNewCode.Text = "ชื่อใหม่";
            // 
            // txtOldCode
            // 
            this.txtOldCode.Enabled = false;
            this.txtOldCode.Location = new System.Drawing.Point(134, 24);
            this.txtOldCode.Name = "txtOldCode";
            this.txtOldCode.Size = new System.Drawing.Size(125, 23);
            this.txtOldCode.TabIndex = 0;
            this.txtOldCode.TextChanged += new System.EventHandler(this.txtOldCode_TextChanged);
            // 
            // txtNewCode
            // 
            this.txtNewCode.Location = new System.Drawing.Point(134, 56);
            this.txtNewCode.MaxLength = 20;
            this.txtNewCode.Name = "txtNewCode";
            this.txtNewCode.Size = new System.Drawing.Size(125, 23);
            this.txtNewCode.TabIndex = 1;
            this.txtNewCode.TextChanged += new System.EventHandler(this.txtNewCode_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(73, 105);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 29);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "ตกลง <F9>";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(174, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DialogChangeCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 158);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtNewCode);
            this.Controls.Add(this.txtOldCode);
            this.Controls.Add(this.lblNewCode);
            this.Controls.Add(this.lblOldCode);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogChangeCode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "เปลี่ยนชื่อผลัด";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblOldCode;
        public System.Windows.Forms.Label lblNewCode;
        public System.Windows.Forms.TextBox txtOldCode;
        public System.Windows.Forms.TextBox txtNewCode;
    }
}