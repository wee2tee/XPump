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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripDailyTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuShiftTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripStock = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStmas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.อนๆToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripDailyTransaction,
            this.ToolStripStock,
            this.อนๆToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1012, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripDailyTransaction
            // 
            this.ToolStripDailyTransaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuShiftTransaction});
            this.ToolStripDailyTransaction.Name = "ToolStripDailyTransaction";
            this.ToolStripDailyTransaction.Size = new System.Drawing.Size(107, 20);
            this.ToolStripDailyTransaction.Text = "รายการประจำวัน";
            // 
            // MnuShiftTransaction
            // 
            this.MnuShiftTransaction.Name = "MnuShiftTransaction";
            this.MnuShiftTransaction.Size = new System.Drawing.Size(228, 22);
            this.MnuShiftTransaction.Text = "บันทึกรายการขายประจำผลัด";
            this.MnuShiftTransaction.Click += new System.EventHandler(this.MnuShiftTransaction_Click);
            // 
            // ToolStripStock
            // 
            this.ToolStripStock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuStmas,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1});
            this.ToolStripStock.Name = "ToolStripStock";
            this.ToolStripStock.Size = new System.Drawing.Size(107, 20);
            this.ToolStripStock.Text = "ฐานข้อมูลเริ่มต้น";
            // 
            // MnuStmas
            // 
            this.MnuStmas.Name = "MnuStmas";
            this.MnuStmas.Size = new System.Drawing.Size(195, 22);
            this.MnuStmas.Text = "รายละเอียดสินค้า";
            this.MnuStmas.Click += new System.EventHandler(this.MnuStmas_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem2.Text = "กำหนดแท๊งค์เก็บน้ำมัน";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.MnuTank_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem1.Text = "กำหนดผลัดพนักงาน";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.MnuShift_Click);
            // 
            // อนๆToolStripMenuItem
            // 
            this.อนๆToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings});
            this.อนๆToolStripMenuItem.Name = "อนๆToolStripMenuItem";
            this.อนๆToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.อนๆToolStripMenuItem.Text = "อื่น ๆ";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(152, 22);
            this.mnuSettings.Text = "ตั้งค่าระบบ";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 645);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1012, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 667);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripDailyTransaction;
        private System.Windows.Forms.ToolStripMenuItem MnuShiftTransaction;
        private System.Windows.Forms.ToolStripMenuItem ToolStripStock;
        private System.Windows.Forms.ToolStripMenuItem MnuStmas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem อนๆToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
    }
}

