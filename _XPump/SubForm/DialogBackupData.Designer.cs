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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogBackupData));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetFile = new CC.XTextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtTargetFolder = new CC.XTextEdit();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtTargetFile
            // 
            this.txtTargetFile._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFile._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTargetFile._MaxLength = 32767;
            this.txtTargetFile._ReadOnly = false;
            this.txtTargetFile._Text = "";
            this.txtTargetFile._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.txtTargetFile, "txtTargetFile");
            this.txtTargetFile.BackColor = System.Drawing.Color.White;
            this.txtTargetFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFile.Name = "txtTargetFile";
            this.txtTargetFile._TextChanged += new System.EventHandler(this.txtTargetFile__TextChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtTargetFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTargetFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFolder._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTargetFolder._MaxLength = 32767;
            this.txtTargetFolder._ReadOnly = true;
            this.txtTargetFolder._Text = "";
            this.txtTargetFolder._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.txtTargetFolder, "txtTargetFolder");
            this.txtTargetFolder.BackColor = System.Drawing.Color.White;
            this.txtTargetFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder._TextChanged += new System.EventHandler(this.txtTargetFolder__TextChanged);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DialogBackupData
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogBackupData";
            this.ShowIcon = false;
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