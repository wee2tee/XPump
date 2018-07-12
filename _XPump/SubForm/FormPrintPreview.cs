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
        //public event EventHandler _OutputToPrinter;

        public FormPrintPreview(PrintDocument document, int total_page)
        {
            InitializeComponent();
            this.printDialog1.Document = document;
            this.printPreviewControl1.Document = document;
            this.total_page = total_page;
            //this.total_page = GetTotalPageCount(document);
        }

        private void FormPrintPreview_Load(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 1;
            this.printPreviewControl1.Document.EndPrint += delegate
            {
                this.txtPageNum.Text = (this.printPreviewControl1.StartPage + 1).ToString();
            };
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if(this._OutputToPrinter != null)
            //{
            //    this._OutputToPrinter(this, e);
            //}
            this.printPreviewControl1.Document.Print();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom += 0.2;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (this.printPreviewControl1.Zoom <= 0.4)
                return;
                
            this.printPreviewControl1.Zoom -= 0.2;
        }

        private void btnZoomFit_Click(object sender, EventArgs e)
        {
            this.printPreviewControl1.AutoZoom = true;
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

        private void btnSplitNone_Click(object sender, EventArgs e)
        {
            this.printPreviewControl1.Columns = 1;
            this.printPreviewControl1.Rows = 1;
            this.printPreviewControl1.AutoZoom = true;
        }

        private void btnSplit2_Click(object sender, EventArgs e)
        {
            this.printPreviewControl1.Columns = 2;
            this.printPreviewControl1.Rows = 1;
            this.printPreviewControl1.AutoZoom = true;

        }

        private void btnSplit4_Click(object sender, EventArgs e)
        {
            this.printPreviewControl1.Columns = 2;
            this.printPreviewControl1.Rows = 2;
            this.printPreviewControl1.AutoZoom = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if (keyData == Keys.Enter)
            //{
            //    if (this.txtPageNum.Focused)
            //    {
            //        this.printPreviewControl1.StartPage = Int32.Parse(this.txtPageNum.Text);
            //        return true;
            //    }
            //}

            if (keyData == Keys.PageUp)
            {
                this.btnPrevious.PerformClick();
                return true;
            }

            if (keyData == Keys.PageDown)
            {
                this.btnNext.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Home))
            {
                this.btnFirst.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.End))
            {
                this.btnLast.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.OemMinus))
            {
                this.btnZoomOut.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Oemplus))
            {
                this.btnZoomIn.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.D0))
            {
                this.btnZoomFit.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                this.btnPrint.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.NumPad1))
            {
                this.btnSplitNone.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.NumPad2))
            {
                this.btnSplit2.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.NumPad4))
            {
                this.btnSplit4.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.btnClose.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
