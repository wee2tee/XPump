namespace XPump.SubForm
{
    partial class DialogImportStmasConfirmReplace
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnSkipOne = new System.Windows.Forms.Button();
            this.btnSkipAll = new System.Windows.Forms.Button();
            this.btnReplaceOne = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(12, 19);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(472, 50);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message";
            // 
            // btnSkipOne
            // 
            this.btnSkipOne.Location = new System.Drawing.Point(12, 88);
            this.btnSkipOne.Name = "btnSkipOne";
            this.btnSkipOne.Size = new System.Drawing.Size(100, 64);
            this.btnSkipOne.TabIndex = 1;
            this.btnSkipOne.Text = "ข้าม\r\nเฉพาะรายการนี้";
            this.btnSkipOne.UseVisualStyleBackColor = true;
            this.btnSkipOne.Click += new System.EventHandler(this.btnSkipOne_Click);
            // 
            // btnSkipAll
            // 
            this.btnSkipAll.Location = new System.Drawing.Point(118, 88);
            this.btnSkipAll.Name = "btnSkipAll";
            this.btnSkipAll.Size = new System.Drawing.Size(96, 64);
            this.btnSkipAll.TabIndex = 1;
            this.btnSkipAll.Text = "ข้าม\r\nทั้งหมดที่ซ้ำ";
            this.btnSkipAll.UseVisualStyleBackColor = true;
            this.btnSkipAll.Click += new System.EventHandler(this.btnSkipAll_Click);
            // 
            // btnReplaceOne
            // 
            this.btnReplaceOne.Location = new System.Drawing.Point(242, 88);
            this.btnReplaceOne.Name = "btnReplaceOne";
            this.btnReplaceOne.Size = new System.Drawing.Size(118, 64);
            this.btnReplaceOne.TabIndex = 1;
            this.btnReplaceOne.Text = "บันทึกแทนที่\r\nข้อมูลเดิม\r\nเฉพาะรายการนี้";
            this.btnReplaceOne.UseVisualStyleBackColor = true;
            this.btnReplaceOne.Click += new System.EventHandler(this.btnReplaceOne_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(366, 88);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(118, 64);
            this.btnReplaceAll.TabIndex = 1;
            this.btnReplaceAll.Text = "บันทึกแทนที่\r\nข้อมูลเดิม\r\nทั้งหมดที่ซ้ำ";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // DialogImportStmasConfirmReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 164);
            this.ControlBox = false;
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnReplaceOne);
            this.Controls.Add(this.btnSkipAll);
            this.Controls.Add(this.btnSkipOne);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogImportStmasConfirmReplace";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DialogImportStmasConfirmReplace_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSkipOne;
        private System.Windows.Forms.Button btnSkipAll;
        private System.Windows.Forms.Button btnReplaceOne;
        private System.Windows.Forms.Button btnReplaceAll;
    }
}