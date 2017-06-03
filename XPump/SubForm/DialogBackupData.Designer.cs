namespace XPump.SubForm
{
    partial class DialogBackupData
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetFile = new CC.XTextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTargetFolder = new CC.XTextEdit();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "สำรองข้อมูลไปไว้ที่";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "ชื่อแฟ้มข้อมูลสำรอง";
            // 
            // txtTargetFile
            // 
            this.txtTargetFile._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFile._MaxLength = 32767;
            this.txtTargetFile._ReadOnly = false;
            this.txtTargetFile._Text = "";
            this.txtTargetFile._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTargetFile.BackColor = System.Drawing.Color.White;
            this.txtTargetFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTargetFile.Location = new System.Drawing.Point(131, 53);
            this.txtTargetFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTargetFile.Name = "txtTargetFile";
            this.txtTargetFile.Size = new System.Drawing.Size(293, 23);
            this.txtTargetFile.TabIndex = 2;
            this.txtTargetFile._TextChanged += new System.EventHandler(this.txtTargetFile__TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtTargetFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTargetFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 97);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFolder._MaxLength = 32767;
            this.txtTargetFolder._ReadOnly = true;
            this.txtTargetFolder._Text = "";
            this.txtTargetFolder._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTargetFolder.BackColor = System.Drawing.Color.White;
            this.txtTargetFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFolder.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTargetFolder.Location = new System.Drawing.Point(131, 26);
            this.txtTargetFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(265, 23);
            this.txtTargetFolder.TabIndex = 0;
            this.txtTargetFolder.TabStop = false;
            this.txtTargetFolder._TextChanged += new System.EventHandler(this.txtTargetFolder__TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(396, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 25);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(117, 122);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 33);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "เริ่มสำรอง <F9>";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(235, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 33);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DialogBackupData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 173);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogBackupData";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "สำรองข้อมูล";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CC.XTextEdit txtTargetFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private CC.XTextEdit txtTargetFolder;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}