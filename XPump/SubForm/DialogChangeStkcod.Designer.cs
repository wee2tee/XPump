namespace XPump.SubForm
{
    partial class DialogChangeStkcod
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOldStkcod = new System.Windows.Forms.Label();
            this.txtNewStkcod = new CC.XTextEdit();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสสินค้าเดิม";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "เปลี่ยนเป็น";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(114, 93);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 29);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "ตกลง <F9>";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(214, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblOldStkcod
            // 
            this.lblOldStkcod.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOldStkcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOldStkcod.Location = new System.Drawing.Point(126, 22);
            this.lblOldStkcod.Name = "lblOldStkcod";
            this.lblOldStkcod.Size = new System.Drawing.Size(222, 23);
            this.lblOldStkcod.TabIndex = 2;
            this.lblOldStkcod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewStkcod
            // 
            this.txtNewStkcod._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewStkcod._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNewStkcod._MaxLength = 32767;
            this.txtNewStkcod._ReadOnly = false;
            this.txtNewStkcod._Text = "";
            this.txtNewStkcod._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewStkcod.BackColor = System.Drawing.Color.White;
            this.txtNewStkcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewStkcod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNewStkcod.Location = new System.Drawing.Point(126, 48);
            this.txtNewStkcod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewStkcod.Name = "txtNewStkcod";
            this.txtNewStkcod.Size = new System.Drawing.Size(222, 23);
            this.txtNewStkcod.TabIndex = 1;
            this.txtNewStkcod._TextChanged += new System.EventHandler(this.txtNewStkcod__TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(350, 48);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 24);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.toolTip1.SetToolTip(this.btnBrowse, "เลือกจากข้อมูลสินค้าใน Express");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // DialogChangeStkcod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 140);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtNewStkcod);
            this.Controls.Add(this.lblOldStkcod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogChangeStkcod";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "เปลี่ยนรหัสสินค้า";
            this.Load += new System.EventHandler(this.DialogChangeStkcod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblOldStkcod;
        private CC.XTextEdit txtNewStkcod;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}