namespace XPump.CustomControls
{
    partial class BrowseBoxCuscod
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
            this.SuspendLayout();
            // 
            // _btnBrowse
            // 
            this._btnBrowse.Size = new System.Drawing.Size(26, 26);
            // 
            // _textBox
            // 
            this._textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // BrowseBoxCuscod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "BrowseBoxCuscod";
            this.Size = new System.Drawing.Size(116, 26);
            this._ButtonClick += new System.EventHandler(this.BrowseBoxCuscod__ButtonClick);
            this._Leave += new System.EventHandler(this.BrowseBoxCuscod__Leave);
            this.Load += new System.EventHandler(this.BrowseBoxCuscod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
