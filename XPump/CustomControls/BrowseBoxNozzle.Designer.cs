namespace XPump.CustomControls
{
    partial class BrowseBoxNozzle
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
            // _textBox
            // 
            this._textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // BrowseBoxNozzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "BrowseBoxNozzle";
            this.Load += new System.EventHandler(this.BrowseBoxNozzle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
