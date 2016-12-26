namespace CC
{
    partial class XBrowseBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnBrowse = new System.Windows.Forms.Button();
            this._textBox = new CC.XTextBox();
            this.SuspendLayout();
            // 
            // _btnBrowse
            // 
            this._btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnBrowse.Image = global::CC.Properties.Resources.zoom_16;
            this._btnBrowse.Location = new System.Drawing.Point(90, -1);
            this._btnBrowse.Margin = new System.Windows.Forms.Padding(0);
            this._btnBrowse.Name = "_btnBrowse";
            this._btnBrowse.Size = new System.Drawing.Size(29, 27);
            this._btnBrowse.TabIndex = 55;
            this._btnBrowse.TabStop = false;
            this._btnBrowse.UseVisualStyleBackColor = true;
            this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
            this._btnBrowse.Enter += new System.EventHandler(this._btnBrowse_Enter);
            // 
            // _textBox
            // 
            this._textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._textBox.Location = new System.Drawing.Point(2, 2);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(88, 16);
            this._textBox.TabIndex = 56;
            this._textBox.ReadOnlyChanged += new System.EventHandler(this._textBox_ReadOnlyChanged);
            this._textBox.TextChanged += new System.EventHandler(this._textBox_TextChanged);
            // 
            // XBrowseBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._textBox);
            this.Controls.Add(this._btnBrowse);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XBrowseBox";
            this.Size = new System.Drawing.Size(118, 23);
            this.Load += new System.EventHandler(this.CustomBrowseField_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private XTextBox _textBox;
        public System.Windows.Forms.Button _btnBrowse;
    }
}
