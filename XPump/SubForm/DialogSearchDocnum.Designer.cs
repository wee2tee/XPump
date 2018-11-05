namespace XPump.SubForm
{
    partial class DialogSearchDocnum
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
            this.lblSearchLabel = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.MaskedTextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSearchLabel
            // 
            this.lblSearchLabel.AutoSize = true;
            this.lblSearchLabel.Location = new System.Drawing.Point(47, 33);
            this.lblSearchLabel.Name = "lblSearchLabel";
            this.lblSearchLabel.Size = new System.Drawing.Size(77, 16);
            this.lblSearchLabel.TabIndex = 0;
            this.lblSearchLabel.Text = "เลขที่เอกสาร";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtKeyword.Location = new System.Drawing.Point(130, 30);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.PromptChar = ' ';
            this.txtKeyword.Size = new System.Drawing.Size(135, 23);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGo.Location = new System.Drawing.Point(142, 79);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(51, 25);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "ไป";
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // DialogSearchDocnum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 124);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.lblSearchLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DialogSearchDocnum";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ป้อนข้อมูลที่ต้องการค้นหา";
            this.Load += new System.EventHandler(this.DialogSearchDocnum_Load);
            this.Shown += new System.EventHandler(this.DialogSearchDocnum_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchLabel;
        private System.Windows.Forms.MaskedTextBox txtKeyword;
        private System.Windows.Forms.Button btnGo;
    }
}