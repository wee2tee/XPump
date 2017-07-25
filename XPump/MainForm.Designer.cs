namespace XPump
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShiftTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDailyClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTankSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShift = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIstab = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDotherMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataManage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSecure = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYearEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblExpressDataPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMysqlDbName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDaily,
            this.mnuSetup,
            this.mnuOther});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDaily
            // 
            this.mnuDaily.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShiftTransaction,
            this.mnuDailyClose});
            this.mnuDaily.Name = "mnuDaily";
            this.mnuDaily.Size = new System.Drawing.Size(107, 20);
            this.mnuDaily.Tag = "1";
            this.mnuDaily.Text = "รายการประจำวัน";
            // 
            // mnuShiftTransaction
            // 
            this.mnuShiftTransaction.Name = "mnuShiftTransaction";
            this.mnuShiftTransaction.Size = new System.Drawing.Size(206, 22);
            this.mnuShiftTransaction.Tag = "11";
            this.mnuShiftTransaction.Text = "บันทึกรายการประจำผลัด";
            this.mnuShiftTransaction.Click += new System.EventHandler(this.MnuShiftTransaction_Click);
            // 
            // mnuDailyClose
            // 
            this.mnuDailyClose.Name = "mnuDailyClose";
            this.mnuDailyClose.Size = new System.Drawing.Size(206, 22);
            this.mnuDailyClose.Tag = "12";
            this.mnuDailyClose.Text = "ปิดยอดขายประจำวัน";
            this.mnuDailyClose.Click += new System.EventHandler(this.mnuDailyClose_Click);
            // 
            // mnuSetup
            // 
            this.mnuSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuTankSetup,
            this.mnuShift,
            this.mnuIstab});
            this.mnuSetup.Name = "mnuSetup";
            this.mnuSetup.Size = new System.Drawing.Size(66, 20);
            this.mnuSetup.Tag = "2";
            this.mnuSetup.Text = "เริ่มระบบ";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(195, 22);
            this.mnuSettings.Tag = "21";
            this.mnuSettings.Text = "ตั้งค่าระบบ";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuTankSetup
            // 
            this.mnuTankSetup.Name = "mnuTankSetup";
            this.mnuTankSetup.Size = new System.Drawing.Size(195, 22);
            this.mnuTankSetup.Tag = "22";
            this.mnuTankSetup.Text = "กำหนดแท๊งค์เก็บน้ำมัน";
            this.mnuTankSetup.Click += new System.EventHandler(this.MnuTankSetup_Click);
            // 
            // mnuShift
            // 
            this.mnuShift.Name = "mnuShift";
            this.mnuShift.Size = new System.Drawing.Size(195, 22);
            this.mnuShift.Tag = "23";
            this.mnuShift.Text = "กำหนดผลัดพนักงาน";
            this.mnuShift.Click += new System.EventHandler(this.MnuShift_Click);
            // 
            // mnuIstab
            // 
            this.mnuIstab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDotherMessage});
            this.mnuIstab.Name = "mnuIstab";
            this.mnuIstab.Size = new System.Drawing.Size(195, 22);
            this.mnuIstab.Tag = "24";
            this.mnuIstab.Text = "ตารางข้อมูล";
            // 
            // mnuDotherMessage
            // 
            this.mnuDotherMessage.Name = "mnuDotherMessage";
            this.mnuDotherMessage.Size = new System.Drawing.Size(218, 22);
            this.mnuDotherMessage.Text = "รายการหักยอดขาย (อื่น ๆ)";
            this.mnuDotherMessage.Click += new System.EventHandler(this.mnuDotherMessage_Click);
            // 
            // mnuOther
            // 
            this.mnuOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDataManage,
            this.mnuSecure,
            this.mnuYearEnd,
            this.mnuChangeCompany});
            this.mnuOther.Name = "mnuOther";
            this.mnuOther.Size = new System.Drawing.Size(46, 20);
            this.mnuOther.Tag = "3";
            this.mnuOther.Text = "อื่น ๆ";
            // 
            // mnuDataManage
            // 
            this.mnuDataManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBackup,
            this.mnuRestore});
            this.mnuDataManage.Name = "mnuDataManage";
            this.mnuDataManage.Size = new System.Drawing.Size(178, 22);
            this.mnuDataManage.Tag = "31";
            this.mnuDataManage.Text = "จัดการฐานข้อมูล";
            // 
            // mnuBackup
            // 
            this.mnuBackup.Name = "mnuBackup";
            this.mnuBackup.Size = new System.Drawing.Size(184, 22);
            this.mnuBackup.Tag = "311";
            this.mnuBackup.Text = "สำรองข้อมูล";
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // mnuRestore
            // 
            this.mnuRestore.Name = "mnuRestore";
            this.mnuRestore.Size = new System.Drawing.Size(184, 22);
            this.mnuRestore.Tag = "312";
            this.mnuRestore.Text = "นำข้อมูลสำรองมาใช้";
            this.mnuRestore.Click += new System.EventHandler(this.mnuRestore_Click);
            // 
            // mnuSecure
            // 
            this.mnuSecure.Name = "mnuSecure";
            this.mnuSecure.Size = new System.Drawing.Size(178, 22);
            this.mnuSecure.Tag = "32";
            this.mnuSecure.Text = "แฟ้มผู้ใช้งานระบบ";
            this.mnuSecure.Click += new System.EventHandler(this.mnuSecure_Click);
            // 
            // mnuYearEnd
            // 
            this.mnuYearEnd.Name = "mnuYearEnd";
            this.mnuYearEnd.Size = new System.Drawing.Size(178, 22);
            this.mnuYearEnd.Tag = "33";
            this.mnuYearEnd.Text = "การประมวลผลสิ้นปี";
            this.mnuYearEnd.Click += new System.EventHandler(this.mnuYearEnd_Click);
            // 
            // mnuChangeCompany
            // 
            this.mnuChangeCompany.Name = "mnuChangeCompany";
            this.mnuChangeCompany.Size = new System.Drawing.Size(178, 22);
            this.mnuChangeCompany.Tag = "34";
            this.mnuChangeCompany.Text = "เปลี่ยนบริษัท";
            this.mnuChangeCompany.Click += new System.EventHandler(this.mnuChangeCompany_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.lblUserID,
            this.toolStripStatusLabel1,
            this.lblExpressDataPath,
            this.toolStripStatusLabel2,
            this.lblMysqlDbName,
            this.lblVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(848, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(51, 19);
            this.toolStripStatusLabel3.Text = "รหัสผูใช้ : ";
            // 
            // lblUserID
            // 
            this.lblUserID.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(22, 19);
            this.lblUserID.Text = " - ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(117, 19);
            this.toolStripStatusLabel1.Text = ", ที่เก็บข้อมูลเอ็กซ์เพรส : ";
            // 
            // lblExpressDataPath
            // 
            this.lblExpressDataPath.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblExpressDataPath.Name = "lblExpressDataPath";
            this.lblExpressDataPath.Size = new System.Drawing.Size(22, 19);
            this.lblExpressDataPath.Text = " - ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(107, 19);
            this.toolStripStatusLabel2.Text = ", ฐานข้อมูล MySQL : ";
            // 
            // lblMysqlDbName
            // 
            this.lblMysqlDbName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblMysqlDbName.Name = "lblMysqlDbName";
            this.lblMysqlDbName.Size = new System.Drawing.Size(22, 19);
            this.lblMysqlDbName.Text = " - ";
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(492, 19);
            this.lblVersion.Spring = true;
            this.lblVersion.Text = "version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 563);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XPump";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDaily;
        private System.Windows.Forms.ToolStripMenuItem mnuShiftTransaction;
        private System.Windows.Forms.ToolStripMenuItem mnuSetup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuShift;
        private System.Windows.Forms.ToolStripMenuItem mnuTankSetup;
        private System.Windows.Forms.ToolStripMenuItem mnuOther;
        private System.Windows.Forms.ToolStripMenuItem mnuDailyClose;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblExpressDataPath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblMysqlDbName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblUserID;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeCompany;
        private System.Windows.Forms.ToolStripMenuItem mnuIstab;
        private System.Windows.Forms.ToolStripMenuItem mnuDotherMessage;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuDataManage;
        private System.Windows.Forms.ToolStripMenuItem mnuBackup;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuYearEnd;
        private System.Windows.Forms.ToolStripMenuItem mnuSecure;
    }
}

