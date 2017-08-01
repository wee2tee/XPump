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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogSettings));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtPeriodTo = new CC.XDatePicker();
            this.dtPeriodFrom = new CC.XDatePicker();
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
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOrgname = new CC.XTextEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnEditMysqlConnection = new System.Windows.Forms.Button();
            this.lblNotConnect = new System.Windows.Forms.Label();
            this.lblConnected = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.btnSave,
            this.btnStop});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::XPump.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::XPump.Properties.Resources.save;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::XPump.Properties.Resources.stop;
            this.btnStop.Name = "btnStop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtPeriodTo);
            this.panel1.Controls.Add(this.dtPeriodFrom);
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
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtOrgname);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Name = "panel1";
            // 
            // dtPeriodTo
            // 
            this.dtPeriodTo._ReadOnly = false;
            this.dtPeriodTo._SelectedDate = null;
            resources.ApplyResources(this.dtPeriodTo, "dtPeriodTo");
            this.dtPeriodTo.BackColor = System.Drawing.Color.White;
            this.dtPeriodTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtPeriodTo.Name = "dtPeriodTo";
            this.dtPeriodTo._SelectedDateChanged += new System.EventHandler(this.dtPeriodTo__SelectedDateChanged);
            this.dtPeriodTo._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // dtPeriodFrom
            // 
            this.dtPeriodFrom._ReadOnly = false;
            this.dtPeriodFrom._SelectedDate = null;
            resources.ApplyResources(this.dtPeriodFrom, "dtPeriodFrom");
            this.dtPeriodFrom.BackColor = System.Drawing.Color.White;
            this.dtPeriodFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtPeriodFrom.Name = "dtPeriodFrom";
            this.dtPeriodFrom._SelectedDateChanged += new System.EventHandler(this.dtPeriodFrom__SelectedDateChanged);
            this.dtPeriodFrom._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // numDayAuthLevel
            // 
            this.numDayAuthLevel._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDayAuthLevel._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.numDayAuthLevel._MaxLength = 1;
            this.numDayAuthLevel._ReadOnly = false;
            this.numDayAuthLevel._Text = "";
            this.numDayAuthLevel._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.numDayAuthLevel, "numDayAuthLevel");
            this.numDayAuthLevel.BackColor = System.Drawing.Color.White;
            this.numDayAuthLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDayAuthLevel.Name = "numDayAuthLevel";
            this.numDayAuthLevel._TextChanged += new System.EventHandler(this.numDayAuthLevel__TextChanged);
            this.numDayAuthLevel._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // numShiftAuthLevel
            // 
            this.numShiftAuthLevel._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numShiftAuthLevel._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.numShiftAuthLevel._MaxLength = 1;
            this.numShiftAuthLevel._ReadOnly = false;
            this.numShiftAuthLevel._Text = "";
            this.numShiftAuthLevel._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.numShiftAuthLevel, "numShiftAuthLevel");
            this.numShiftAuthLevel.BackColor = System.Drawing.Color.White;
            this.numShiftAuthLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numShiftAuthLevel.Name = "numShiftAuthLevel";
            this.numShiftAuthLevel._TextChanged += new System.EventHandler(this.numShiftAuthLevel__TextChanged);
            this.numShiftAuthLevel._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // drDayPrintMethod
            // 
            this.drDayPrintMethod._ReadOnly = false;
            this.drDayPrintMethod._SelectedItem = null;
            this.drDayPrintMethod._Text = "";
            resources.ApplyResources(this.drDayPrintMethod, "drDayPrintMethod");
            this.drDayPrintMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drDayPrintMethod.Name = "drDayPrintMethod";
            this.drDayPrintMethod._SelectedItemChanged += new System.EventHandler(this.drDayPrintMethod__SelectedItemChanged);
            this.drDayPrintMethod._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // drShiftPrintMethod
            // 
            this.drShiftPrintMethod._ReadOnly = false;
            this.drShiftPrintMethod._SelectedItem = null;
            this.drShiftPrintMethod._Text = "";
            resources.ApplyResources(this.drShiftPrintMethod, "drShiftPrintMethod");
            this.drShiftPrintMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drShiftPrintMethod.Name = "drShiftPrintMethod";
            this.drShiftPrintMethod._SelectedItemChanged += new System.EventHandler(this.drShiftPrintMethod__SelectedItemChanged);
            this.drShiftPrintMethod._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtOrgname
            // 
            this.txtOrgname._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgname._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOrgname._MaxLength = 32767;
            this.txtOrgname._ReadOnly = false;
            this.txtOrgname._Text = "";
            this.txtOrgname._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.txtOrgname, "txtOrgname");
            this.txtOrgname.BackColor = System.Drawing.Color.White;
            this.txtOrgname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgname.Name = "txtOrgname";
            this.txtOrgname._TextChanged += new System.EventHandler(this.txtOrgname__TextChanged);
            this.txtOrgname._DoubleClicked += new System.EventHandler(this.PerformEdit);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // btnEditMysqlConnection
            // 
            resources.ApplyResources(this.btnEditMysqlConnection, "btnEditMysqlConnection");
            this.btnEditMysqlConnection.Image = global::XPump.Properties.Resources.edit_16;
            this.btnEditMysqlConnection.Name = "btnEditMysqlConnection";
            this.btnEditMysqlConnection.UseVisualStyleBackColor = true;
            this.btnEditMysqlConnection.Click += new System.EventHandler(this.btnEditMysqlConnection_Click);
            // 
            // lblNotConnect
            // 
            resources.ApplyResources(this.lblNotConnect, "lblNotConnect");
            this.lblNotConnect.Image = global::XPump.Properties.Resources.exclaimation_16;
            this.lblNotConnect.Name = "lblNotConnect";
            // 
            // lblConnected
            // 
            resources.ApplyResources(this.lblConnected, "lblConnected");
            this.lblConnected.Image = global::XPump.Properties.Resources.ok_16;
            this.lblConnected.Name = "lblConnected";
            // 
            // DialogSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEditMysqlConnection);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblNotConnect);
            this.Controls.Add(this.lblConnected);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSettings";
            this.ShowIcon = false;
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
        private CC.XDatePicker dtPeriodTo;
        private CC.XDatePicker dtPeriodFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label21;
    }
}