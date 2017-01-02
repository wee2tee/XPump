﻿namespace CC
{
    partial class XDatePicker
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
            this.btnShowCalendar = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnShowCalendar
            // 
            this.btnShowCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowCalendar.Image = global::CC.Properties.Resources.calendar_16;
            this.btnShowCalendar.Location = new System.Drawing.Point(78, -1);
            this.btnShowCalendar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowCalendar.Name = "btnShowCalendar";
            this.btnShowCalendar.Size = new System.Drawing.Size(24, 23);
            this.btnShowCalendar.TabIndex = 2;
            this.btnShowCalendar.UseVisualStyleBackColor = true;
            this.btnShowCalendar.Click += new System.EventHandler(this.btnShowCalendar_Click);
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Location = new System.Drawing.Point(3, 3);
            this.txtDate.Mask = "00/00/0000";
            this.txtDate.Name = "txtDate";
            this.txtDate.PromptChar = ' ';
            this.txtDate.Size = new System.Drawing.Size(76, 16);
            this.txtDate.TabIndex = 3;
            this.txtDate.ValidatingType = typeof(System.DateTime);
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // XDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnShowCalendar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XDatePicker";
            this.Size = new System.Drawing.Size(103, 23);
            this.Load += new System.EventHandler(this.XDatePicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnShowCalendar;
        private System.Windows.Forms.MaskedTextBox txtDate;
    }
}