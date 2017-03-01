namespace XPump.SubForm
{
    partial class DialogPrintSetupB
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
            this.rdFile = new System.Windows.Forms.RadioButton();
            this.rdPrinter = new System.Windows.Forms.RadioButton();
            this.rdScreen = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtDate = new CC.XDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdFile);
            this.groupBox1.Controls.Add(this.rdPrinter);
            this.groupBox1.Controls.Add(this.rdScreen);
            this.groupBox1.Location = new System.Drawing.Point(12, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(120, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "แสดงผลทาง";
            // 
            // rdFile
            // 
            this.rdFile.AutoSize = true;
            this.rdFile.Enabled = false;
            this.rdFile.Location = new System.Drawing.Point(18, 71);
            this.rdFile.Name = "rdFile";
            this.rdFile.Size = new System.Drawing.Size(83, 20);
            this.rdFile.TabIndex = 1;
            this.rdFile.Text = "แฟ้มข้อมูล";
            this.rdFile.UseVisualStyleBackColor = true;
            this.rdFile.CheckedChanged += new System.EventHandler(this.rdFile_CheckedChanged);
            // 
            // rdPrinter
            // 
            this.rdPrinter.AutoSize = true;
            this.rdPrinter.Location = new System.Drawing.Point(18, 45);
            this.rdPrinter.Name = "rdPrinter";
            this.rdPrinter.Size = new System.Drawing.Size(84, 20);
            this.rdPrinter.TabIndex = 2;
            this.rdPrinter.Text = "เครื่องพิมพ์";
            this.rdPrinter.UseVisualStyleBackColor = true;
            this.rdPrinter.CheckedChanged += new System.EventHandler(this.rdPrinter_CheckedChanged);
            // 
            // rdScreen
            // 
            this.rdScreen.AutoSize = true;
            this.rdScreen.Location = new System.Drawing.Point(18, 20);
            this.rdScreen.Name = "rdScreen";
            this.rdScreen.Size = new System.Drawing.Size(64, 20);
            this.rdScreen.TabIndex = 3;
            this.rdScreen.Text = "จอภาพ";
            this.rdScreen.UseVisualStyleBackColor = true;
            this.rdScreen.CheckedChanged += new System.EventHandler(this.rdScreen_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(212, 74);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "กำหนดขอบเขตรายงาน";
            // 
            // dtDate
            // 
            this.dtDate._ReadOnly = false;
            this.dtDate._SelectedDate = null;
            this.dtDate.BackColor = System.Drawing.Color.White;
            this.dtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtDate.Location = new System.Drawing.Point(72, 29);
            this.dtDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(103, 23);
            this.dtDate.TabIndex = 1;
            this.dtDate._SelectedDateChanged += new System.EventHandler(this.dtDate__SelectedDateChanged);
            this.dtDate._Leave += new System.EventHandler(this.dtDate__Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "วันที่";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(157, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(67, 27);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(157, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 27);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DialogPrintSetupB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 219);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogPrintSetupB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DialogPrintSetupB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdFile;
        private System.Windows.Forms.RadioButton rdPrinter;
        private System.Windows.Forms.RadioButton rdScreen;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private CC.XDatePicker dtDate;
    }
}