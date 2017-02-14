using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XPump.SubForm
{
    public partial class FormPrintPreview : Form
    {
        private int total_page;

        public FormPrintPreview(PrintDocument document)
        {
            InitializeComponent();
            this.printDialog1.Document = document;
            this.printPreviewControl1.Document = document;
            this.total_page = GetTotalPageCount(document);
        }

        private void FormPrintPreview_Load(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 1;
            this.printPreviewControl1.Document.EndPrint += delegate
            {
                this.txtPageNum.Text = (this.printPreviewControl1.StartPage + 1).ToString();
            };
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (this.txtPageNum.Focused)
                {
                    this.printPreviewControl1.StartPage = Int32.Parse(this.txtPageNum.Text);
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                this.btnClose.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //PrintDialog pd = new PrintDialog();
            //pd.Document = this.printPreviewControl1.Document;
            //pd.UseEXDialog = true;

            //if(pd.ShowDialog() == DialogResult.OK)
            //{
            //    pd.Document.Print();
            //}
            if(this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.printDialog1.Document.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom += 0.1;
            this.btnZoomOut.Enabled = this.printPreviewControl1.Zoom > 0.5 ? true : false;
            this.btnZoomIn.Enabled = this.printPreviewControl1.Zoom >= 2 ? false : true;
            this.lblZoomPerc.Text = (this.printPreviewControl1.Zoom * 100).ToString() + "%";
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom -= 0.1;
            this.btnZoomIn.Enabled = this.printPreviewControl1.Zoom < 2 ? true : false;
            this.btnZoomOut.Enabled = this.printPreviewControl1.Zoom <= 0.6 ? false : true;
            this.lblZoomPerc.Text = (this.printPreviewControl1.Zoom * 100).ToString() + "%";
        }

        private void btnZoomFit_Click(object sender, EventArgs e)
        {
            //this.printPreviewControl1.AutoZoom = true;
            //this.btnZoomIn.Enabled = this.printPreviewControl1.Zoom < 2 ? true : false;
            //this.btnZoomOut.Enabled = this.printPreviewControl1.Zoom > 1 ? true : false;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.txtPageNum.Text = "1";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(this.txtPageNum.Text) > 1)
            {
                this.txtPageNum.Text = (Int32.Parse(this.txtPageNum.Text) - 1).ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(this.txtPageNum.Text) < this.total_page)
            {
                this.txtPageNum.Text = (Int32.Parse(this.txtPageNum.Text) + 1).ToString();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.txtPageNum.Text = this.total_page.ToString();
        }

        private void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            this.printPreviewControl1.StartPage = Int32.Parse(((ToolStripTextBox)sender).Text) - 1;
        }

        public static int GetTotalPageCount(PrintDocument printDocument)
        {
            int count = 0;
            printDocument.PrintController = new PreviewPrintController();
            printDocument.PrintPage += (sender, e) => count++;
            printDocument.Print();
            return count;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
