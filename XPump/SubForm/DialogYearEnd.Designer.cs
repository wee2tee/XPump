namespace XPump.SubForm
{
    partial class DialogYearEnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogYearEnd));
            this.lblWarning = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOldYearFrom = new System.Windows.Forms.Label();
            this.lblOldYearTo = new System.Windows.Forms.Label();
            this.lblNewYearFrom = new System.Windows.Forms.Label();
            this.lblNewYearTo = new System.Windows.Forms.Label();
            this.txtYes = new CC.XTextEdit();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWarning
            // 
            resources.ApplyResources(this.lblWarning, "lblWarning");
            this.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWarning.Name = "lblWarning";
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // lblOldYearFrom
            // 
            resources.ApplyResources(this.lblOldYearFrom, "lblOldYearFrom");
            this.lblOldYearFrom.BackColor = System.Drawing.Color.White;
            this.lblOldYearFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOldYearFrom.Name = "lblOldYearFrom";
            // 
            // lblOldYearTo
            // 
            resources.ApplyResources(this.lblOldYearTo, "lblOldYearTo");
            this.lblOldYearTo.BackColor = System.Drawing.Color.White;
            this.lblOldYearTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOldYearTo.Name = "lblOldYearTo";
            // 
            // lblNewYearFrom
            // 
            resources.ApplyResources(this.lblNewYearFrom, "lblNewYearFrom");
            this.lblNewYearFrom.BackColor = System.Drawing.Color.White;
            this.lblNewYearFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewYearFrom.Name = "lblNewYearFrom";
            // 
            // lblNewYearTo
            // 
            resources.ApplyResources(this.lblNewYearTo, "lblNewYearTo");
            this.lblNewYearTo.BackColor = System.Drawing.Color.White;
            this.lblNewYearTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewYearTo.Name = "lblNewYearTo";
            // 
            // txtYes
            // 
            this.txtYes._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYes._CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtYes._MaxLength = 3;
            this.txtYes._ReadOnly = false;
            this.txtYes._Text = "";
            this.txtYes._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            resources.ApplyResources(this.txtYes, "txtYes");
            this.txtYes.BackColor = System.Drawing.Color.White;
            this.txtYes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYes.Name = "txtYes";
            this.txtYes._TextChanged += new System.EventHandler(this.txtYes__TextChanged);
            this.txtYes._Leave += new System.EventHandler(this.txtYes__Leave);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::XPump.Properties.Resources.stop_16;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Image = global::XPump.Properties.Resources.ok_16;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // DialogYearEnd
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtYes);
            this.Controls.Add(this.lblNewYearTo);
            this.Controls.Add(this.lblOldYearTo);
            this.Controls.Add(this.lblNewYearFrom);
            this.Controls.Add(this.lblOldYearFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblWarning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogYearEnd";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.DialogYearEnd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label label2;
        private CC.XTextEdit txtYes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOldYearFrom;
        private System.Windows.Forms.Label lblOldYearTo;
        private System.Windows.Forms.Label lblNewYearFrom;
        private System.Windows.Forms.Label lblNewYearTo;
    }
}