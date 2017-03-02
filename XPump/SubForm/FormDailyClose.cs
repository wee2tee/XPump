using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.Misc;
using CC;
using System.Globalization;
using System.Drawing.Printing;

namespace XPump.SubForm
{
    public partial class FormDailyClose : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private BindingSource bs;
        private List<dayend> dayend_list;
        private DateTime? curr_date;
        private dayend curr_dayend;

        public FormDailyClose(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
            {
                if (MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

        private void DialogDailySummary_Load(object sender, EventArgs e)
        {
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;

            this.form_mode = FORM_MODE.READ;
            this.btnLast.PerformClick();
            this.ActiveControl = this.dgv;
        }

        private List<dayend> GetDayEnd(DateTime date)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.dayend.Include("daysttak").Where(d => d.saldat == date).ToList();
            }
        }

        private void FillForm()
        {
            this.lblDate.Text = this.curr_date.HasValue && this.dayend_list.Count > 0 ? this.curr_date.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) : string.Empty;

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.dayend_list.ToViewModel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogDateSelector dlg = new DialogDateSelector("วันที่ปิดยอดขาย", DateTime.Now);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    if(db.dayend.Where(d => d.saldat == dlg.selected_date).Count() > 0)
                    {
                        MessageBox.Show("วันที่ \"" + dlg.selected_date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + "\" ปิดยอดขายไปแล้ว, ไม่สามารถปิดซ้ำได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    try
                    {
                        var stmas_ids = db.salessummary.Where(s => s.saldat == dlg.selected_date)
                                        .GroupBy(s => s.stmas_id)
                                        .Select(s => s.Key).ToArray();

                        if(stmas_ids.Count() == 0)
                        {
                            MessageBox.Show("ไม่พบการบันทึกรายการประจำผลัดของวันที่ \"" + dlg.selected_date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + "\", กรุณาบันทึกรายการประจำผลัดก่อนทำการปิดขอดขายประจำวัน", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        foreach (int stmas_id in stmas_ids)
                        {
                            dayendVM d = new dayend()
                            {
                                id = -1,
                                stmas_id = stmas_id,
                                dothertxt = string.Empty,
                                saldat = dlg.selected_date,

                            }.ToViewModel();
                            db.dayend.Add(d.dayend);
                            db.SaveChanges();

                            var sections = db.section.Where(s => s.stmas_id == stmas_id).ToList();

                            foreach (var sect in sections)
                            {
                                shiftsttak sttak = db.shiftsttak.Where(s => s.takdat == dlg.selected_date)
                                            .Where(s => s.section_id == sect.id)
                                            .Where(s => s.qty > -1).FirstOrDefault();


                                db.daysttak.Add(new daysttak
                                {
                                    dayend_id = d.dayend.id,
                                    qty = sttak != null ? sttak.qty : -1,
                                    section_id = sect.id
                                });
                                db.SaveChanges();

                                foreach (shiftsales sales in db.shiftsales.Where(s => s.saldat == dlg.selected_date).ToList())
                                {
                                    sales.closed = true;
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.curr_date = dlg.selected_date;
                this.btnRefresh.PerformClick();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curr_dayend == null)
                return;

            DialogDayendEdit dlg = new DialogDayendEdit(this.main_form, this.curr_dayend);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.dayend_list = this.GetDayEnd(this.curr_date.Value);
                this.FillForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!this.curr_date.HasValue)
                return;

            if(MessageBox.Show("ลบข้อมูลการปิดยอดขายของวันที่ \"" + this.curr_date.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + "\" ทิ้งทั้งหมด, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        var dayends = db.dayend.Where(d => d.saldat == this.curr_date.Value).ToList();

                        foreach (var de in dayends)
                        {
                            foreach (var sttak in db.daysttak.Where(d => d.dayend_id == de.id).ToList())
                            {
                                db.daysttak.Remove(db.daysttak.Find(sttak.id));
                            }
                            db.dayend.Remove(db.dayend.Find(de.id));
                        }

                        var shiftsales = db.shiftsales.Where(s => s.saldat == this.curr_date.Value);
                        foreach (var sales in shiftsales)
                        {
                            sales.closed = false;
                        }

                        db.SaveChanges();
                        this.btnNext.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                var tmp = db.dayend.OrderBy(d => d.saldat).FirstOrDefault();

                if (tmp != null)
                {
                    this.curr_date = tmp.saldat;
                    this.dayend_list = this.GetDayEnd(tmp.saldat);
                }
                else
                {
                    this.curr_date = null;
                    this.dayend_list = new List<dayend>();
                }

                this.FillForm();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                if (this.curr_date.HasValue)
                {
                    var tmp = db.dayend.OrderByDescending(d => d.saldat).Where(d => d.saldat.CompareTo(this.curr_date.Value) < 0).FirstOrDefault();

                    if(tmp != null)
                    {
                        this.curr_date = tmp.saldat;
                        this.dayend_list = this.GetDayEnd(tmp.saldat);
                    }
                    else
                    {
                        return;
                        //this.curr_date = null;
                        //this.dayend_list = new List<dayend>();
                    }

                    this.FillForm();
                }
                else
                {
                    this.btnFirst.PerformClick();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                if (this.curr_date.HasValue)
                {
                    var tmp = db.dayend.OrderBy(d => d.saldat).Where(d => d.saldat.CompareTo(this.curr_date.Value) > 0).FirstOrDefault();

                    if (tmp != null)
                    {
                        this.curr_date = tmp.saldat;
                        this.dayend_list = this.GetDayEnd(tmp.saldat);
                    }
                    else
                    {
                        return;
                        //this.curr_date = null;
                        //this.dayend_list = new List<dayend>();
                    }

                    this.FillForm();
                }
                else
                {
                    this.btnLast.PerformClick();
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                var tmp = db.dayend.OrderByDescending(d => d.saldat).FirstOrDefault();

                if (tmp != null)
                {
                    this.curr_date = tmp.saldat;
                    this.dayend_list = this.GetDayEnd(tmp.saldat);
                }
                else
                {
                    this.curr_date = null;
                    this.dayend_list = new List<dayend>();
                }

                this.FillForm();
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {

        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintB_Click(object sender, EventArgs e)
        {
            DialogPrintSetupB print = new DialogPrintSetupB(this.curr_date);
            if (print.ShowDialog() == DialogResult.OK)
            {
                var report_data = this.GetReportBData(print.selected_date.Value);
                int total_page = XPrintPreview.GetTotalPageCount(this.PreparePrintDoc_B(report_data));
                if(print.output == PRINT_OUTPUT.SCREEN)
                {
                    XPrintPreview xp = new XPrintPreview(this.PreparePrintDoc_B(report_data, total_page), total_page);
                    xp.MdiParent = this.main_form;
                    xp.Show();
                }

                if(print.output == PRINT_OUTPUT.PRINTER)
                {
                    PrintDialog pd = new PrintDialog();
                    pd.Document = this.PreparePrintDoc_B(report_data, total_page);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        pd.Document.Print();
                    }
                }
            }
        }

        private void btnPrintC_Click(object sender, EventArgs e)
        {
            DialogPrintSetupC print = new DialogPrintSetupC(this.curr_date);
            if (print.ShowDialog() == DialogResult.OK)
            {
                var report_data = this.GetReportCData(print.first_date_of_month.Value, print.last_date_of_month.Value);
                int total_page = XPrintPreview.GetTotalPageCount(this.PreparePrintDoc_C(report_data));
                if (print.output == PRINT_OUTPUT.SCREEN)
                {
                    XPrintPreview xp = new XPrintPreview(this.PreparePrintDoc_C(report_data, total_page), total_page);
                    xp.MdiParent = this.main_form;
                    xp.Show();
                }

                if (print.output == PRINT_OUTPUT.PRINTER)
                {
                    PrintDialog pd = new PrintDialog();
                    pd.Document = this.PreparePrintDoc_C(report_data, total_page);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        pd.Document.Print();
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.curr_date.HasValue)
            {
                this.dayend_list = this.GetDayEnd(this.curr_date.Value);
                this.FillForm();
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            dayend tmp = (dayend)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_dayend.Name].Value;

            if (this.curr_dayend == null)
            {
                this.curr_dayend = tmp;
            }
            else
            {
                if(this.curr_dayend.id != tmp.id)
                {
                    this.curr_dayend = tmp;
                }
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                this.btnEdit.PerformClick();
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index == -1)
                    return;

                ((XDatagrid)sender).Rows[row_index].Cells[this.col_stkcod.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt+E>");
                mnu_edit.Click += delegate
                {
                    this.btnEdit.PerformClick();
                };
                cm.MenuItems.Add(mnu_edit);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.A))
            {
                this.btnAdd.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                this.btnDelete.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Home))
            {
                this.btnFirst.PerformClick();
                return true;
            }

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

            if (keyData == (Keys.Control | Keys.End))
            {
                this.btnLast.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.S))
            {
                this.btnSearch.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.L))
            {
                this.btnInquiryRest.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.L))
            {
                this.btnInquiryAll.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.P))
            {
                this.btnPrintB.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                this.btnPrintC.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private ReportBModel GetReportBData(DateTime date)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                ReportBModel report_data = new ReportBModel();
                report_data.isinfoDbfVM = DbfTable.Isinfo().ToList<IsinfoDbf>().First().ToViewModel();
                report_data.reportDate = date;

                List<string> doc_hp = new List<string>();
                List<string> doc_rr = new List<string>();
                foreach (shift s in db.shift.ToList())
                {
                    doc_hp.Add(s.phpprefix);
                    doc_rr.Add(s.prrprefix);
                }
                var apmas = DbfTable.Apmas().ToApmasList();
                var aptrn = DbfTable.Aptrn().ToAptrnList()
                            .Where(a => a.docdat.HasValue)
                            .Where(a => a.docdat.Value == report_data.reportDate)
                            .Where(a => doc_hp.Contains(a.docnum.Substring(0, 2)) || doc_rr.Contains(a.docnum.Substring(0, 2)))
                            .OrderBy(a => a.docnum).ToList();
                var stcrd = DbfTable.Stcrd().ToStcrdList()
                            .Where(s => s.docdat.HasValue)
                            .Where(s => s.docdat.Value == report_data.reportDate)
                            .Where(s => aptrn.Select(a => a.docnum).Contains(s.docnum))
                            .OrderBy(s => s.docnum).ToList();

                report_data.purvattransVM = stcrd.Where(s => doc_hp.Contains(s.docnum.Substring(0, 2)) || doc_rr.Contains(s.docnum.Substring(0, 2)))
                            .GroupBy(s => s.docnum.Trim())
                            .Select(s => new VatTransDbfVM
                            {
                                docnum = stcrd.Where(st => st.docnum.Trim() == s.Key).First().docnum.Trim(),
                                docdat = stcrd.Where(st => st.docnum.Trim() == s.Key).First().docdat.Value,
                                people = apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).FirstOrDefault() != null ? apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).First().prenam.Trim() + " " + apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).First().supnam.Trim() : string.Empty,
                                stkcod = stcrd.Where(st => st.docnum.Trim() == s.Key).First().stkcod.Trim(),
                                netval = stcrd.Where(st => st.docnum.Trim() == s.Key).First().netval,
                                vatamt = Convert.ToDouble(string.Format("{0:0.00}", (stcrd.Where(st => st.docnum.Trim() == s.Key).First().netval * 7) / 100))
                            }).OrderBy(s => s.docdat).ThenBy(s => s.docnum).ToList();

                report_data.dayend = db.dayend.Include("daysttak").Include("stmas").Where(d => d.saldat == date).ToList();

                return report_data;
            }
        }

        private PrintDocument PreparePrintDoc_B(ReportBModel report_data, int total_page = 0)
        {
            Font fnt_title_bold = new Font("angsana new", 12f, FontStyle.Bold);
            Font fnt_header_bold = new Font("angsana new", 11f, FontStyle.Bold); // tahoma 8f bold
            Font fnt_header = new Font("angsana new", 11f, FontStyle.Regular); // tahoma 8f
            Font fnt_bold = new Font("angsana new", 10f, FontStyle.Bold); // tahoma 7f bold
            Font fnt = new Font("angsana new", 10f, FontStyle.Regular); // tahoma 7f
            Pen p = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush bg_gray = new SolidBrush(Color.Gainsboro);
            StringFormat format_left = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_right = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

            int page = 0;
            int item_count = 0;
            int item_per_page = 4;
            int section_per_product = 5;

            PrintDocument docs = new PrintDocument();
            //PaperSize ps = new PaperSize();
            //ps.RawKind = (int)PaperKind.A4;
            //docs.DefaultPageSettings.PaperSize = ps;
            docs.DefaultPageSettings.Margins = new Margins(20, 20, 30, 30);
            docs.DefaultPageSettings.Landscape = true;
            docs.BeginPrint += delegate (object sender, PrintEventArgs e)
            {
                page = 0;
                item_count = 0;
            };
            docs.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int line_height = fnt_header.Height;

                page++;

                // draw margin bound
                //e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(x, y, e.MarginBounds.Right - x, e.MarginBounds.Bottom - y));

                /* report header */
                Rectangle rect = new Rectangle(x, y, e.MarginBounds.Right - x, line_height);
                string str = "รายงานแสดงรายละเอียดการขายน้ำมันเชื้อเพลิง";
                e.Graphics.DrawString(str, fnt_header_bold, brush, rect, format_center);

                y += line_height; // new line
                str = "วันที่ " + report_data.reportDate.ToString("d MMMM", CultureInfo.CurrentCulture) + " พ.ศ. " + report_data.reportDate.ToString("yyyy", CultureInfo.CurrentCulture);
                rect = str.GetDisplayRect(fnt_header, (int)Math.Round((double)(e.MarginBounds.Width / 2) + x - (str.Width(fnt_header) / 2)), y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_center);

                y += line_height; // new line
                str = "ชื่อผู้ประกอบการ: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                rect = report_data.isinfoDbfVM.compnam.GetDisplayRect(fnt_header, x + rect.Width, y);
                e.Graphics.DrawString(report_data.isinfoDbfVM.compnam, fnt_header, brush, rect, format_left);

                str = "[ส่วน ข]";
                rect = str.GetDisplayRect(fnt_header, x + e.MarginBounds.Width - str.Width(fnt_header), y);
                rect.X -= 10;
                e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro), rect.X - 5, rect.Y - 3, rect.Width + 10, rect.Height + 6);
                e.Graphics.DrawRectangle(Pens.Black, rect.X - 5, rect.Y - 3, rect.Width + 10, rect.Height + 6);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_center);

                y += line_height; // new line
                str = "ชื่อสถานีบริการน้ำมัน: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                str = report_data.isinfoDbfVM.orgnam;
                rect = str.GetDisplayRect(fnt_header, x + rect.Width, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "เลขประจำตัวผู้เสียภาษี :   ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.X = e.MarginBounds.Right - rect.Width - 150;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_right);

                str = report_data.isinfoDbfVM.taxid;
                rect = str.GetDisplayRect(fnt_header, rect.X + rect.Width, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                y += line_height; // new line
                str = "ที่อยู่: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                str = report_data.isinfoDbfVM.addr;
                rect = str.GetDisplayRect(fnt_header, x + rect.Width, y);
                rect.Width += 30;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "หน้า " + page.ToString() + "/" + total_page;
                rect = str.GetDisplayRect(fnt_header, e.MarginBounds.Right - str.Width(fnt_header), y);
                rect.X -= 10;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_right);

                y += line_height; // new line
                str = report_data.isinfoDbfVM.telnum.Contains("โทร") || report_data.isinfoDbfVM.telnum.ToLower().Contains("tel") ? report_data.isinfoDbfVM.telnum : "โทร. " + report_data.isinfoDbfVM.telnum;
                rect = str.GetDisplayRect(fnt_header, x + 110, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                /* item (loop) */
                y += line_height; // new line
                int start_body_y = y;
                int page_item = 0;
                //List<VatTransDbfVM> sal_vattrans = new List<VatTransDbfVM>();
                //List<VatTransDbfVM> pur_vattrans = new List<VatTransDbfVM>();
                //decimal tot_salvat = 0m;
                //decimal tot_purvat = 0m;

                Rectangle rect_str_container = new Rectangle(x, y, 200, line_height * 2);
                e.Graphics.FillRectangle(bg_gray, rect_str_container);
                e.Graphics.DrawRectangle(p, rect_str_container);
                e.Graphics.DrawString("รายการ", fnt_bold, brush, rect_str_container, new StringFormat { Alignment = StringAlignment.Center });

                rect_str_container.Y += rect_str_container.Height;
                rect_str_container.Height = line_height * section_per_product;
                e.Graphics.DrawRectangle(p, rect_str_container);
                e.Graphics.DrawString("1. น้ำมันสะสมในถังวัดได้จริงสิ้นงวด", fnt, brush, rect_str_container, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });

                rect_str_container.Y += rect_str_container.Height;
                rect_str_container.Height = line_height;
                e.Graphics.DrawRectangle(p, rect_str_container);
                e.Graphics.DrawString("2. รวมยอดน้ำมันวัดได้จริงสิ้นงวด", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                rect_str_container.Height = line_height * 8;
                e.Graphics.DrawRectangle(p, rect_str_container);

                rect_str_container.Height = line_height;
                e.Graphics.DrawString("3. น้ำมันที่วัดได้จริงต้นงวด", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("4. บวก ยอดรับน้ำมัน", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("5. หัก น้ำมันที่ขายผ่านมิเตอร์ระหว่างวัน", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("   หัก อื่น ๆ ระบุ______________________", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("6. น้ำมันคงเหลือในบัญชี (3+4-5)", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("7. ผลต่างน้ำมันปัจจุบัน (2-6)", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("8. บวก ผลต่างสะสมยกมา", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("9. ผลต่างสะสมปัจจุบันยกไป (7+8)", fnt, brush, rect_str_container, format_left);

                Rectangle rect_section = new Rectangle(x, y, 60, line_height);
                int sub_col_width = Convert.ToInt32(Math.Floor((double)((e.MarginBounds.Right - e.MarginBounds.Left) - rect_str_container.Width) / item_per_page));
                Rectangle rect_stk = new Rectangle(x, y, sub_col_width - rect_section.Width, line_height);

                x += rect_str_container.Width;
                for (int i = item_count; i < report_data.dayend.Count; i++)
                {
                    page_item++;
                    item_count++;

                    x = e.MarginBounds.Left + rect_str_container.Width + (sub_col_width * (page_item - 1));

                    rect_section.X = x;
                    rect_section.Y = start_body_y;
                    rect_section.Height = line_height * 2;
                    e.Graphics.FillRectangle(bg_gray, rect_section);
                    e.Graphics.DrawRectangle(p, rect_section);
                    e.Graphics.DrawString("เลขที่" + Environment.NewLine + "ถัง", fnt_bold, brush, rect_section, format_center);
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height, rect_section.Width, line_height * section_per_product));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height + (line_height * section_per_product), rect_section.Width, line_height));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height + (line_height * section_per_product) + line_height, rect_section.Width, line_height * 8));

                    rect_stk.X = rect_section.X + rect_section.Width;
                    rect_stk.Y = start_body_y;
                    rect_stk.Height = line_height * 2;
                    e.Graphics.FillRectangle(bg_gray, rect_stk);
                    e.Graphics.DrawRectangle(p, rect_stk);
                    e.Graphics.DrawString(report_data.dayend[i].ToViewModel().stkcod, fnt_bold, brush, rect_stk, format_center);
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height, rect_stk.Width, line_height * section_per_product));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height + (line_height * section_per_product), rect_stk.Width, line_height));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height + (line_height * section_per_product) + line_height, rect_stk.Width, line_height * 8));

                    for(int j = 0; j < section_per_product; j++)
                    {
                        rect_section.Y += rect_section.Height;
                        rect_section.Height = line_height;
                        string sect = report_data.dayend[i].daysttak.Count > j ? report_data.dayend[i].daysttak.ToList()[j].ToViewModel().section_name : "-";
                        e.Graphics.DrawString(sect, fnt, brush, rect_section, format_center);

                        rect_stk.Y += rect_stk.Height;
                        rect_stk.Height = line_height;
                        string qty = report_data.dayend[i].daysttak.Count > j ? string.Format("{0:#,#0.00}", report_data.dayend[i].daysttak.ToList()[j].ToViewModel().qty) : string.Empty;
                        e.Graphics.DrawString(qty, fnt, brush, rect_stk, format_right);
                    }

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().endbal), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().begbal), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().rcvqty), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().salqty), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().dother), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().accbal), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().difqty), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().begdif), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().begdif + report_data.dayend[i].ToViewModel().difqty), fnt, brush, rect_stk, format_right);

                    Rectangle rect_vat = new Rectangle(e.MarginBounds.Left, rect_stk.Y + line_height, e.MarginBounds.Right - e.MarginBounds.Left, line_height);
                    if (page_item == 1)
                    {
                        rect_vat.Y += line_height;
                        foreach (VatTransDbfVM doc in report_data.purvattransVM)
                        {
                            string vat = "ใบจ่ายน้ำมันหรือใบกำกับภาษีขนส่งน้ำมันเลขที่ " + doc.docnum.Trim() + " ลงวันที่ " + doc.docdat.ToString("dd", CultureInfo.CurrentCulture) + " เดือน " + doc.docdat.ToString("MMMM", CultureInfo.CurrentCulture) + " พ.ศ. " + doc.docdat.ToString("yyyy", CultureInfo.CurrentCulture) + " ของผู้ค้าน้ำมันราย " + doc.people;
                            e.Graphics.DrawString(vat, fnt, brush, rect_vat, format_left);
                        }
                    }

                    if (item_count == item_per_page && item_count < report_data.dayend.Count)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }
            };

            return docs;
        }


        private ReportCModel GetReportCData(DateTime first_date, DateTime last_date)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                ReportCModel report_data = new ReportCModel();
                report_data.isinfoDbfVM = DbfTable.Isinfo().ToList<IsinfoDbf>().First().ToViewModel();
                report_data.reportDate = last_date;

                List<string> doc_hp = new List<string>();
                List<string> doc_rr = new List<string>();
                foreach (shift s in db.shift.ToList())
                {
                    doc_hp.Add(s.phpprefix);
                    doc_rr.Add(s.prrprefix);
                }
                var apmas = DbfTable.Apmas().ToApmasList();
                var aptrn = DbfTable.Aptrn().ToAptrnList()
                            .Where(a => a.docdat.HasValue)
                            .Where(a => a.docdat.Value.CompareTo(first_date) >= 0 && a.docdat.Value.CompareTo(last_date) <= 0)
                            .Where(a => doc_hp.Contains(a.docnum.Substring(0, 2)) || doc_rr.Contains(a.docnum.Substring(0, 2)))
                            .OrderBy(a => a.docnum).ToList();
                var stcrd = DbfTable.Stcrd().ToStcrdList()
                            .Where(s => s.docdat.HasValue)
                            .Where(s => s.docdat.Value.CompareTo(first_date) >= 0 && s.docdat.Value.CompareTo(last_date) <= 0)
                            .Where(s => aptrn.Select(a => a.docnum).Contains(s.docnum))
                            .OrderBy(s => s.docnum).ToList();

                report_data.purvattransVM = stcrd.Where(s => doc_hp.Contains(s.docnum.Substring(0, 2)) || doc_rr.Contains(s.docnum.Substring(0, 2)))
                            .GroupBy(s => s.docnum.Trim())
                            .Select(s => new VatTransDbfVM
                            {
                                docnum = stcrd.Where(st => st.docnum.Trim() == s.Key).First().docnum.Trim(),
                                docdat = stcrd.Where(st => st.docnum.Trim() == s.Key).First().docdat.Value,
                                people = apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).FirstOrDefault() != null ? apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).First().prenam.Trim() + " " + apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).First().supnam.Trim() : string.Empty,
                                stkcod = stcrd.Where(st => st.docnum.Trim() == s.Key).First().stkcod.Trim(),
                                netval = stcrd.Where(st => st.docnum.Trim() == s.Key).First().netval,
                                vatamt = Convert.ToDouble(string.Format("{0:0.00}", (stcrd.Where(st => st.docnum.Trim() == s.Key).First().netval * 7) / 100))
                            }).OrderBy(s => s.docdat).ThenBy(s => s.docnum).ToList();

                report_data.dayend = db.dayend.Include("daysttak").Include("stmas").Where(d => d.saldat.CompareTo(first_date) >= 0 && d.saldat.CompareTo(last_date) <= 0).ToList();

                report_data.monthend = new List<monthendVM>();
                foreach (var item in report_data.dayend)
                {
                    var me = db.stmas.Find(item.stmas_id).GetMonthEndVM(first_date, last_date);
                    report_data.monthend.Add(me);
                }

                return report_data;
            }
        }

        private PrintDocument PreparePrintDoc_C(ReportCModel report_data, int total_page = 0)
        {
            Font fnt_title_bold = new Font("angsana new", 12f, FontStyle.Bold);
            Font fnt_header_bold = new Font("angsana new", 11f, FontStyle.Bold); // tahoma 8f bold
            Font fnt_header = new Font("angsana new", 11f, FontStyle.Regular); // tahoma 8f
            Font fnt_bold = new Font("angsana new", 10f, FontStyle.Bold); // tahoma 7f bold
            Font fnt = new Font("angsana new", 10f, FontStyle.Regular); // tahoma 7f
            Pen p = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush bg_gray = new SolidBrush(Color.Gainsboro);
            StringFormat format_left = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_right = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

            int page = 0;
            int item_count = 0;
            int item_per_page = 4;
            int section_per_product = 5;

            PrintDocument docs = new PrintDocument();
            //PaperSize ps = new PaperSize();
            //ps.RawKind = (int)PaperKind.A4;
            //docs.DefaultPageSettings.PaperSize = ps;
            docs.DefaultPageSettings.Margins = new Margins(20, 20, 30, 30);
            docs.DefaultPageSettings.Landscape = true;
            docs.BeginPrint += delegate (object sender, PrintEventArgs e)
            {
                page = 0;
                item_count = 0;
            };
            docs.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int line_height = fnt_header.Height;

                page++;

                // draw margin bound
                //e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(x, y, e.MarginBounds.Right - x, e.MarginBounds.Bottom - y));

                /* report header */
                Rectangle rect = new Rectangle(x, y, e.MarginBounds.Right - x, line_height);
                string str = "รายงานแสดงรายละเอียดการขายน้ำมันเชื้อเพลิง";
                e.Graphics.DrawString(str, fnt_header_bold, brush, rect, format_center);

                y += line_height; // new line
                str = "ณ เดือน " + report_data.reportDate.ToString("MMMM", CultureInfo.CurrentCulture) + " พ.ศ. " + report_data.reportDate.ToString("yyyy", CultureInfo.CurrentCulture);
                rect = str.GetDisplayRect(fnt_header, (int)Math.Round((double)(e.MarginBounds.Width / 2) + x - (str.Width(fnt_header) / 2)), y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_center);

                y += line_height; // new line
                str = "ชื่อผู้ประกอบการ: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                rect = report_data.isinfoDbfVM.compnam.GetDisplayRect(fnt_header, x + rect.Width, y);
                e.Graphics.DrawString(report_data.isinfoDbfVM.compnam, fnt_header, brush, rect, format_left);

                str = "[ส่วน ค]";
                rect = str.GetDisplayRect(fnt_header, x + e.MarginBounds.Width - str.Width(fnt_header), y);
                rect.X -= 10;
                e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro), rect.X - 5, rect.Y - 3, rect.Width + 10, rect.Height + 6);
                e.Graphics.DrawRectangle(Pens.Black, rect.X - 5, rect.Y - 3, rect.Width + 10, rect.Height + 6);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_center);

                y += line_height; // new line
                str = "ชื่อสถานีบริการน้ำมัน: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                str = report_data.isinfoDbfVM.orgnam;
                rect = str.GetDisplayRect(fnt_header, x + rect.Width, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "เลขประจำตัวผู้เสียภาษี :   ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.X = e.MarginBounds.Right - rect.Width - 150;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_right);

                str = report_data.isinfoDbfVM.taxid;
                rect = str.GetDisplayRect(fnt_header, rect.X + rect.Width, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                y += line_height; // new line
                str = "ที่อยู่: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                str = report_data.isinfoDbfVM.addr;
                rect = str.GetDisplayRect(fnt_header, x + rect.Width, y);
                rect.Width += 30;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "หน้า " + page.ToString() + "/" + total_page;
                rect = str.GetDisplayRect(fnt_header, e.MarginBounds.Right - str.Width(fnt_header), y);
                rect.X -= 10;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_right);

                y += line_height; // new line
                str = report_data.isinfoDbfVM.telnum.Contains("โทร") || report_data.isinfoDbfVM.telnum.ToLower().Contains("tel") ? report_data.isinfoDbfVM.telnum : "โทร. " + report_data.isinfoDbfVM.telnum;
                rect = str.GetDisplayRect(fnt_header, x + 110, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                /* item (loop) */
                y += line_height; // new line
                int start_body_y = y;
                int page_item = 0;
                //List<VatTransDbfVM> sal_vattrans = new List<VatTransDbfVM>();
                //List<VatTransDbfVM> pur_vattrans = new List<VatTransDbfVM>();
                //decimal tot_salvat = 0m;
                //decimal tot_purvat = 0m;

                Rectangle rect_str_container = new Rectangle(x, y, 200, line_height * 2);
                e.Graphics.FillRectangle(bg_gray, rect_str_container);
                e.Graphics.DrawRectangle(p, rect_str_container);
                e.Graphics.DrawString("รายการ", fnt_bold, brush, rect_str_container, new StringFormat { Alignment = StringAlignment.Center });

                rect_str_container.Y += rect_str_container.Height;
                rect_str_container.Height = line_height * section_per_product;
                e.Graphics.DrawRectangle(p, rect_str_container);
                e.Graphics.DrawString("1. น้ำมันสะสมในถังวัดได้จริงสิ้นงวด", fnt, brush, rect_str_container, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });

                rect_str_container.Y += rect_str_container.Height;
                rect_str_container.Height = line_height;
                e.Graphics.DrawRectangle(p, rect_str_container);
                e.Graphics.DrawString("2. รวมยอดน้ำมันวัดได้จริงสิ้นงวด", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                rect_str_container.Height = line_height * 8;
                e.Graphics.DrawRectangle(p, rect_str_container);

                rect_str_container.Height = line_height;
                e.Graphics.DrawString("3. น้ำมันที่วัดได้จริงต้นงวด", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("4. บวก ยอดรับน้ำมัน", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("5. หัก น้ำมันที่ขายผ่านมิเตอร์ระหว่างวัน", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("   หัก อื่น ๆ ระบุ______________________", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("6. น้ำมันคงเหลือในบัญชี (3+4-5)", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("7. ผลต่างน้ำมันปัจจุบัน (2-6)", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("8. บวก ผลต่างสะสมยกมา", fnt, brush, rect_str_container, format_left);

                rect_str_container.Y += rect_str_container.Height;
                e.Graphics.DrawString("9. ผลต่างสะสมปัจจุบันยกไป (7+8)", fnt, brush, rect_str_container, format_left);

                Rectangle rect_section = new Rectangle(x, y, 60, line_height);
                int sub_col_width = Convert.ToInt32(Math.Floor((double)((e.MarginBounds.Right - e.MarginBounds.Left) - rect_str_container.Width) / item_per_page));
                Rectangle rect_stk = new Rectangle(x, y, sub_col_width - rect_section.Width, line_height);

                x += rect_str_container.Width;
                for (int i = item_count; i < report_data.dayend.Count; i++)
                {
                    page_item++;
                    item_count++;

                    x = e.MarginBounds.Left + rect_str_container.Width + (sub_col_width * (page_item - 1));

                    rect_section.X = x;
                    rect_section.Y = start_body_y;
                    rect_section.Height = line_height * 2;
                    e.Graphics.FillRectangle(bg_gray, rect_section);
                    e.Graphics.DrawRectangle(p, rect_section);
                    e.Graphics.DrawString("เลขที่" + Environment.NewLine + "ถัง", fnt_bold, brush, rect_section, format_center);
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height, rect_section.Width, line_height * section_per_product));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height + (line_height * section_per_product), rect_section.Width, line_height));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height + (line_height * section_per_product) + line_height, rect_section.Width, line_height * 8));

                    rect_stk.X = rect_section.X + rect_section.Width;
                    rect_stk.Y = start_body_y;
                    rect_stk.Height = line_height * 2;
                    e.Graphics.FillRectangle(bg_gray, rect_stk);
                    e.Graphics.DrawRectangle(p, rect_stk);
                    e.Graphics.DrawString(report_data.dayend[i].ToViewModel().stkcod, fnt_bold, brush, rect_stk, format_center);
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height, rect_stk.Width, line_height * section_per_product));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height + (line_height * section_per_product), rect_stk.Width, line_height));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height + (line_height * section_per_product) + line_height, rect_stk.Width, line_height * 8));

                    for (int j = 0; j < section_per_product; j++)
                    {
                        rect_section.Y += rect_section.Height;
                        rect_section.Height = line_height;
                        string sect = report_data.dayend[i].daysttak.Count > j ? report_data.dayend[i].daysttak.ToList()[j].ToViewModel().section_name : "-";
                        e.Graphics.DrawString(sect, fnt, brush, rect_section, format_center);

                        rect_stk.Y += rect_stk.Height;
                        rect_stk.Height = line_height;
                        string qty = report_data.dayend[i].daysttak.Count > j ? string.Format("{0:#,#0.00}", report_data.dayend[i].daysttak.ToList()[j].ToViewModel().qty) : string.Empty;
                        e.Graphics.DrawString(qty, fnt, brush, rect_stk, format_right);
                    }

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().endbal), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().begbal), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().rcvqty), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().salqty), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().dother), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().accbal), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().difqty), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().begdif), fnt, brush, rect_stk, format_right);

                    rect_stk.Y += rect_stk.Height;
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel().begdif + report_data.dayend[i].ToViewModel().difqty), fnt, brush, rect_stk, format_right);

                    Rectangle rect_vat = new Rectangle(e.MarginBounds.Left, rect_stk.Y + line_height, e.MarginBounds.Right - e.MarginBounds.Left, line_height);
                    if (page_item == 1)
                    {
                        foreach (VatTransDbfVM doc in report_data.purvattransVM)
                        {
                            rect_vat.Y += line_height;
                            string vat = "ใบจ่ายน้ำมันหรือใบกำกับภาษีขนส่งน้ำมันเลขที่ " + doc.docnum.Trim() + "     ลงวันที่ " + doc.docdat.ToString("dd", CultureInfo.CurrentCulture) + " เดือน " + doc.docdat.ToString("MMMM", CultureInfo.CurrentCulture) + " พ.ศ. " + doc.docdat.ToString("yyyy", CultureInfo.CurrentCulture) + "     ของผู้ค้าน้ำมันราย " + doc.people;
                            e.Graphics.DrawString(vat, fnt, brush, rect_vat, format_left);
                        }
                    }

                    if (item_count == item_per_page && item_count < report_data.dayend.Count)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }
            };

            return docs;
        }
    }
}
