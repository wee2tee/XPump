namespace XPump.SubForm
{
    partial class DialogSttak
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.xDatagrid1 = new CC.XDatagrid();
            ((System.ComponentModel.ISupportInitialize)(this.xDatagrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // xDatagrid1
            // 
            this.xDatagrid1.AllowSortByColumnHeaderClicked = false;
            this.xDatagrid1.AllowUserToAddRows = false;
            this.xDatagrid1.AllowUserToDeleteRows = false;
            this.xDatagrid1.AllowUserToResizeColumns = false;
            this.xDatagrid1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.xDatagrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.xDatagrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xDatagrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.xDatagrid1.EnableHeadersVisualStyles = false;
            this.xDatagrid1.FillEmptyRow = false;
            this.xDatagrid1.FocusedRowBorderRedLine = false;
            this.xDatagrid1.Location = new System.Drawing.Point(12, 154);
            this.xDatagrid1.MultiSelect = false;
            this.xDatagrid1.Name = "xDatagrid1";
            this.xDatagrid1.ReadOnly = true;
            this.xDatagrid1.RowHeadersVisible = false;
            this.xDatagrid1.RowTemplate.Height = 26;
            this.xDatagrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.xDatagrid1.Size = new System.Drawing.Size(594, 218);
            this.xDatagrid1.StandardTab = true;
            this.xDatagrid1.TabIndex = 0;
            // 
            // DialogSttak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 430);
            this.Controls.Add(this.xDatagrid1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSttak";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "บันทึกปริมาณน้ำมันที่ตรวจนับได้จริง";
            ((System.ComponentModel.ISupportInitialize)(this.xDatagrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CC.XDatagrid xDatagrid1;
    }
}