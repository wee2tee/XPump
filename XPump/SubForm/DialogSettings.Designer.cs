namespace XPump.SubForm
{
    partial class DialogSettings
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEditMysqlConnection = new System.Windows.Forms.Button();
            this.lblNotConnect = new System.Windows.Forms.Label();
            this.lblConnected = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numDayAuthLevel = new CC.XNumTextEdit();
            this.numShiftAuthLevel = new CC.XNumTextEdit();
            this.drDayPrintMethod = new CC.XDropdownList();
            this.drShiftPrintMethod = new CC.XDropdownList();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOrgname = new CC.XTextEdit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.btnSave,
            this.btnStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(554, 43);
            this.toolStrip1.TabIndex = 6;
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit;
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(36, 40);
            this.btnEdit.Text = "แก้ไขข้อมูล <Alt+E>";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 40);
            this.btnSave.Text = "บันทึกข้อมูล <F9>";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Enabled = false;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            this.btnStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 40);
            this.btnStop.Text = "ยกเลิกการแก้ไขข้อมูล <Esc>";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "1. ชื่อสถานีบริการน้ำมัน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "กำหนดการเชื่อมต่อฐานข้อมูล MySql";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = ":";
            // 
            // btnEditMysqlConnection
            // 
            this.btnEditMysqlConnection.Image = global::XPump.Properties.Resources.edit_16;
            this.btnEditMysqlConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditMysqlConnection.Location = new System.Drawing.Point(341, 64);
            this.btnEditMysqlConnection.Name = "btnEditMysqlConnection";
            this.btnEditMysqlConnection.Padding = new System.Windows.Forms.Padding(3);
            this.btnEditMysqlConnection.Size = new System.Drawing.Size(178, 30);
            this.btnEditMysqlConnection.TabIndex = 8;
            this.btnEditMysqlConnection.Text = "แก้ไขการเชื่อมต่อ MySQL";
            this.btnEditMysqlConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditMysqlConnection.UseVisualStyleBackColor = true;
            this.btnEditMysqlConnection.Click += new System.EventHandler(this.btnEditMysqlConnection_Click);
            // 
            // lblNotConnect
            // 
            this.lblNotConnect.Image = global::XPump.Properties.Resources.exclaimation_16;
            this.lblNotConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotConnect.Location = new System.Drawing.Point(230, 71);
            this.lblNotConnect.Name = "lblNotConnect";
            this.lblNotConnect.Size = new System.Drawing.Size(110, 16);
            this.lblNotConnect.TabIndex = 7;
            this.lblNotConnect.Text = "ไม่มีการเชื่อมต่อ";
            this.lblNotConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConnected
            // 
            this.lblConnected.Image = global::XPump.Properties.Resources.ok_16;
            this.lblConnected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblConnected.Location = new System.Drawing.Point(230, 71);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(94, 16);
            this.lblConnected.TabIndex = 7;
            this.lblConnected.Text = "เชื่อมต่อแล้ว";
            this.lblConnected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblConnected.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numDayAuthLevel);
            this.panel1.Controls.Add(this.numShiftAuthLevel);
            this.panel1.Controls.Add(this.drDayPrintMethod);
            this.panel1.Controls.Add(this.drShiftPrintMethod);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtOrgname);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(17, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 253);
            this.panel1.TabIndex = 9;
            // 
            // numDayAuthLevel
            // 
            this.numDayAuthLevel._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDayAuthLevel._MaxLength = 1;
            this.numDayAuthLevel._ReadOnly = false;
            this.numDayAuthLevel._Text = "";
            this.numDayAuthLevel._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numDayAuthLevel.BackColor = System.Drawing.Color.White;
            this.numDayAuthLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDayAuthLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numDayAuthLevel.Location = new System.Drawing.Point(316, 157);
            this.numDayAuthLevel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numDayAuthLevel.Name = "numDayAuthLevel";
            this.numDayAuthLevel.Size = new System.Drawing.Size(20, 23);
            this.numDayAuthLevel.TabIndex = 6;
            this.numDayAuthLevel._TextChanged += new System.EventHandler(this.numDayAuthLevel__TextChanged);
            this.numDayAuthLevel._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // numShiftAuthLevel
            // 
            this.numShiftAuthLevel._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numShiftAuthLevel._MaxLength = 1;
            this.numShiftAuthLevel._ReadOnly = false;
            this.numShiftAuthLevel._Text = "";
            this.numShiftAuthLevel._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numShiftAuthLevel.BackColor = System.Drawing.Color.White;
            this.numShiftAuthLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numShiftAuthLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numShiftAuthLevel.Location = new System.Drawing.Point(316, 61);
            this.numShiftAuthLevel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numShiftAuthLevel.Name = "numShiftAuthLevel";
            this.numShiftAuthLevel.Size = new System.Drawing.Size(20, 23);
            this.numShiftAuthLevel.TabIndex = 4;
            this.numShiftAuthLevel._TextChanged += new System.EventHandler(this.numShiftAuthLevel__TextChanged);
            this.numShiftAuthLevel._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // drDayPrintMethod
            // 
            this.drDayPrintMethod._ReadOnly = false;
            this.drDayPrintMethod._SelectedItem = null;
            this.drDayPrintMethod._Text = "";
            this.drDayPrintMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drDayPrintMethod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.drDayPrintMethod.Location = new System.Drawing.Point(316, 199);
            this.drDayPrintMethod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drDayPrintMethod.Name = "drDayPrintMethod";
            this.drDayPrintMethod.Size = new System.Drawing.Size(167, 23);
            this.drDayPrintMethod.TabIndex = 7;
            this.drDayPrintMethod._SelectedItemChanged += new System.EventHandler(this.drDayPrintMethod__SelectedItemChanged);
            this.drDayPrintMethod._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // drShiftPrintMethod
            // 
            this.drShiftPrintMethod._ReadOnly = false;
            this.drShiftPrintMethod._SelectedItem = null;
            this.drShiftPrintMethod._Text = "";
            this.drShiftPrintMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drShiftPrintMethod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.drShiftPrintMethod.Location = new System.Drawing.Point(316, 102);
            this.drShiftPrintMethod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drShiftPrintMethod.Name = "drShiftPrintMethod";
            this.drShiftPrintMethod.Size = new System.Drawing.Size(167, 23);
            this.drShiftPrintMethod.TabIndex = 5;
            this.drShiftPrintMethod._SelectedItemChanged += new System.EventHandler(this.drShiftPrintMethod__SelectedItemChanged);
            this.drShiftPrintMethod._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "0 = ไม่ต้องรับรอง,\r\n1 - 9 = ระดับอนุมัติที่ให้รับรอง";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(341, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 32);
            this.label7.TabIndex = 7;
            this.label7.Text = "0 = ไม่ต้องรับรอง,\r\n1 - 9 = ระดับอนุมัติที่ให้รับรอง";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(35, 161);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(184, 16);
            this.label17.TabIndex = 7;
            this.label17.Text = "รับรองรายการ ต้องขออนุมัติระดับ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "รับรองรายการ ต้องขออนุมัติระดับ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(35, 202);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(278, 16);
            this.label16.TabIndex = 7;
            this.label16.Text = "การรับรองรายการเพื่อพิมพ์รายงานส่วน ข. และ ค. :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "การรับรองรายการเพื่อพิมพ์รายงานส่วน ก. :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(261, 16);
            this.label15.TabIndex = 7;
            this.label15.Text = "3. การรับรอง/พิมพ์ รายการปิดยอดขายประจำวัน";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "2. การรับรอง/พิมพ์ รายการประจำผลัด";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(233, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(233, 202);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(233, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = ":";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = ":";
            // 
            // txtOrgname
            // 
            this.txtOrgname._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgname._MaxLength = 32767;
            this.txtOrgname._ReadOnly = false;
            this.txtOrgname._Text = "";
            this.txtOrgname._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOrgname.BackColor = System.Drawing.Color.White;
            this.txtOrgname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgname.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOrgname.Location = new System.Drawing.Point(204, 9);
            this.txtOrgname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrgname.Name = "txtOrgname";
            this.txtOrgname.Size = new System.Drawing.Size(287, 23);
            this.txtOrgname.TabIndex = 1;
            this.txtOrgname._TextChanged += new System.EventHandler(this.txtOrgname__TextChanged);
            this.txtOrgname._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // DialogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 378);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEditMysqlConnection);
            this.Controls.Add(this.lblNotConnect);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ตั้งค่าระบบ";
            this.Load += new System.EventHandler(this.DialogSettings_Load);
            this.Shown += new System.EventHandler(this.DialogSettings_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Label label2;
        private CC.XTextEdit txtOrgname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditMysqlConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Label lblNotConnect;
        private System.Windows.Forms.Panel panel1;
        private CC.XDropdownList drShiftPrintMethod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private CC.XNumTextEdit numShiftAuthLevel;
        private System.Windows.Forms.Label label7;
        private CC.XNumTextEdit numDayAuthLevel;
        private CC.XDropdownList drDayPrintMethod;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
    }
}