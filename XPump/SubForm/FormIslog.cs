using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.Misc;
using System.Threading;
using CC;
using System.Globalization;
using System.Drawing.Printing;

namespace XPump.SubForm
{
    public partial class FormIslog : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private BindingList<islogVM> islogs;
        private int? focused_id;
        private DateTime? condLogDateFrom = null;
        private DateTime? condLogDateTo = null;
        private string condLogCode = string.Empty;
        private string condLogData = string.Empty;
        private string condLogModule = string.Empty;
        private string condLogUser = string.Empty;
        private SORT sort;
        private enum SORT
        {
            ASC,
            DESC
        }

        public FormIslog(MainForm main_form)
        {
            this.main_form = main_form;
            Thread.CurrentThread.CurrentUICulture = this.main_form.c_info;
            InitializeComponent();
        }

        private void FormIslog_Load(object sender, EventArgs e)
        {
            this.ResetControlState(FORM_MODE.READ_ITEM);
            this.sort = SORT.DESC;
            
            this.btnRefresh.PerformClick();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        private void ResetControlState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnPrint.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
        }

        private List<islog> GetPreviousLog(int? start_id = null, int take_item = 20)
        {
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                if (!start_id.HasValue)
                {
                    var logs = sec.islog.OrderByDescending(i => i.id).Take(take_item).ToList();
                    return logs.OrderBy(i => i.id).ToList();
                }
                else
                {
                    var logs = sec.islog.OrderByDescending(i => i.id).Where(i => i.id < start_id.Value).Take(take_item).ToList();
                    return logs.OrderBy(i => i.id).ToList();
                }
            }
        }

        private List<islog> GetNextLog(int? start_id = null, int take_item = 20)
        {
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                if (!start_id.HasValue)
                {
                    var logs = sec.islog.OrderBy(i => i.id).Take(take_item).ToList();
                    return logs;
                }
                else
                {
                    var logs = sec.islog.OrderBy(i => i.id).Where(i => i.id > start_id.Value).Take(take_item).ToList();
                    return logs;
                }
            }
        }

        private List<islogVM> GetLogByCondition(DateTime? logDateFrom = null, DateTime? logDateTo = null, string logCode = "", string logData = "", string logModule = "", string logUser = "")
        {
            List<islogVM> logs = new List<islogVM>();
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                string condition = string.Empty;
                condition += logCode.Trim().Length > 0 ? " logcode=\"" + logCode.Trim() + "\" " : "";
                condition += condition.Trim().Length > 0 && logData.Trim().Length > 0 ? " AND " : "";
                condition += logData.Trim().Length > 0 ? " expressdata=\"" + logData.Trim() + "\" " : "";
                condition += condition.Trim().Length > 0 && logModule.Trim().Length > 0 ? " AND " : "";
                condition += logModule.Trim().Length > 0 ? " modcod=\"" + logModule.Trim() + "\" " : "";
                condition += condition.Trim().Length > 0 && logUser.Trim().Length > 0 ? " AND " : "";
                condition += logUser.Trim().Length > 0 ? " username=\"" + logUser.Trim() + "\" " : "";

                if (logDateFrom.HasValue && logDateTo.HasValue)
                {
                    var from_date = logDateFrom.Value;
                    var to_date = logDateTo.Value.AddDays(1); // adding 1 day to support time suffix

                    if (condition.Trim().Length > 0)
                    {
                        logs = sec.islog.Where(i => i.cretime.CompareTo(from_date) >= 0 && i.cretime.CompareTo(to_date) < 0).Where(condition).ToViewModel();
                    }
                    else
                    {
                        logs = sec.islog.Where(i => i.cretime.CompareTo(from_date) >= 0 && i.cretime.CompareTo(to_date) < 0).ToViewModel();
                    }
                }
                else
                {
                    logs = condition.Trim().Length > 0 ? sec.islog.Where(condition).ToViewModel() : sec.islog.ToViewModel();
                }
            }
            return logs;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DateTime two_years_ago = DateTime.Now.Date.AddYears(-2);

            if(XMessageBox.Show(string.Format(this.main_form.GetMessage("0026"), two_years_ago.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH"))), "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question, this.main_form.c_info) == DialogResult.OK)
            {
                using (xpumpsecureEntities sec = DBX.DataSecureSet())
                {
                    try
                    {
                        var islog_to_delete = sec.islog.Where(s => s.cretime.CompareTo(two_years_ago) < 0);

                        sec.affdata.RemoveRange(sec.affdata.Where(s => islog_to_delete.Select(i => i.id).Contains(s.islog_id)));
                        sec.islog.RemoveRange(islog_to_delete);
                        sec.SaveChanges();
                        this.btnRefresh.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error, this.main_form.c_info);
                    }
                }
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {
            this.btnSearchByDate.PerformClick();
        }

        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            DialogDateSelector d = new DialogDateSelector("ดูเหตุการณ์วันที่", DateTime.Now);
            if(d.ShowDialog() == DialogResult.OK)
            {
                List<dynamic> logs;
                var date = d.selected_date.Date;
                logs = this.GetLogByCondition(date, date, "", "", "", "").ToList<dynamic>();

                List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
                foreach (DataGridViewColumn col in this.dgv.Columns.Cast<DataGridViewColumn>())
                {
                    var c = (DataGridViewColumn)col.Clone();
                    c.DisplayIndex = ((DataGridViewColumn)col).DisplayIndex;
                    cols.Add(c);
                }

                cols.Where(c => c.Name == this.col_description.Name).First().MinimumWidth = 300;

                DialogInquiry inq = new DialogInquiry(logs, cols, cols.Where(c => c.Name == this.col_cretime.Name).First(), null, false, this.main_form.c_info, false);
                inq.ShowDialog();
            }
        }

        private void btnSearchByCondition_Click(object sender, EventArgs e)
        {
            DialogIslogCondition cond = new DialogIslogCondition(this.main_form, this.condLogDateFrom, this.condLogDateTo, this.condLogCode, this.condLogData, this.condLogModule, this.condLogUser);
            if(cond.ShowDialog() == DialogResult.OK)
            {
                this.condLogDateFrom = cond.logDateFrom;
                this.condLogDateTo = cond.logDateTo;
                this.condLogCode = cond.logCode;
                this.condLogData = cond.logData;
                this.condLogModule = cond.logModule;
                this.condLogUser = cond.logUserName;

                List<dynamic> logs = this.GetLogByCondition(this.condLogDateFrom, this.condLogDateTo, this.condLogCode, this.condLogData, this.condLogModule, this.condLogUser).ToList<dynamic>();
                logs = this.sort == SORT.DESC ? logs.OrderBy(l => l.id).ToList<dynamic>() : logs.OrderByDescending(l => l.id).ToList<dynamic>();

                List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
                foreach (DataGridViewColumn col in this.dgv.Columns.Cast<DataGridViewColumn>())
                {
                    var c = (DataGridViewColumn)col.Clone();
                    c.DisplayIndex = ((DataGridViewColumn)col).DisplayIndex;
                    cols.Add(c);
                }

                cols.Where(c => c.Name == this.col_description.Name).First().MinimumWidth = 300;

                DialogInquiry inq = new DialogInquiry(logs, cols, cols.Where(c => c.Name == this.col_cretime.Name).First(), null, false, this.main_form.c_info, false);
                inq.ShowDialog();
            }
        }

        private void btnPrint_ButtonClick(object sender, EventArgs e)
        {
            this.btnPrintAll.PerformClick();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            //DialogDateRangeSelector d = new DialogDateRangeSelector(this.main_form, false, false, DateTime.Now, DateTime.Now);
            DialogIslogCondition cond = new DialogIslogCondition(this.main_form, this.condLogDateFrom, this.condLogDateTo, "", "", "", "", true, false);

            if(cond.ShowDialog() == DialogResult.OK)
            {
                List<islogVM> logs = this.GetLogByCondition(cond.logDateFrom, cond.logDateTo, "", "", "", "");

                /* Perform print */
                this.PerformPrint(logs, cond);
            }
        }

        private void btnPrintCondition_Click(object sender, EventArgs e)
        {
            DialogIslogCondition cond = new DialogIslogCondition(this.main_form, this.condLogDateFrom, this.condLogDateTo, this.condLogCode, this.condLogData, this.condLogModule, this.condLogUser, true);
            if (cond.ShowDialog() == DialogResult.OK)
            {
                this.condLogDateFrom = cond.logDateFrom;
                this.condLogDateTo = cond.logDateTo;
                this.condLogCode = cond.logCode;
                this.condLogData = cond.logData;
                this.condLogModule = cond.logModule;
                this.condLogUser = cond.logUserName;

                List<islogVM> logs = this.GetLogByCondition(this.condLogDateFrom, this.condLogDateTo, this.condLogCode, this.condLogData, this.condLogModule, this.condLogUser);
                //logs = this.sort == SORT.DESC ? logs.OrderBy(l => l.id).ToList<dynamic>() : logs.OrderByDescending(l => l.id).ToList<dynamic>();

                /* Perform print */
                this.PerformPrint(logs, cond);
            }
        }

        private void PerformPrint(List<islogVM> logs, DialogIslogCondition cond)
        {
            LoadingForm loading = new LoadingForm();
            loading.ShowCenterParent(this);

            XPrintPreview xp = null;
            PrintDialog pd = null;
            string err_msg = string.Empty;

            BackgroundWorker work = new BackgroundWorker();
            work.DoWork += delegate
            {
                try
                {
                    int total_page = XPrintPreview.GetTotalPageCount(this.PreparePrintDoc(logs, cond));

                    if (cond.printOutput == PRINT_OUTPUT.SCREEN)
                    {
                        xp = new XPrintPreview(this.PreparePrintDoc(logs, cond, total_page), total_page);
                        return;
                    }

                    if (cond.printOutput == PRINT_OUTPUT.PRINTER)
                    {
                        pd = new PrintDialog();
                        pd.Document = this.PreparePrintDoc(logs, cond, total_page);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    err_msg = ex.Message;
                }
            };
            work.RunWorkerCompleted += delegate
            {
                loading.Close();
                if(cond.printOutput == PRINT_OUTPUT.SCREEN && xp != null)
                {
                    xp.MdiParent = this.main_form;
                    xp.Show();
                    return;
                }

                if(cond.printOutput == PRINT_OUTPUT.PRINTER && pd != null)
                {
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        pd.Document.Print();
                    }
                    return;
                }

                XMessageBox.Show(err_msg, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error, this.main_form.c_info);
            };

            work.RunWorkerAsync();
        }

        private PrintDocument PreparePrintDoc(List<islogVM> logs, DialogIslogCondition cond, int total_page = 0)
        {
            Font fnt_title_bold = new Font("angsana new", 12f, FontStyle.Bold);
            Font fnt_header_bold = new Font("angsana new", 11f, FontStyle.Bold); // tahoma 8f bold
            Font fnt_header = new Font("angsana new", 11f, FontStyle.Regular); // tahoma 8f
            Font fnt_bold = new Font("angsana new", 10f, FontStyle.Bold); // tahoma 7f bold
            Font fnt = new Font("angsana new", 10f, FontStyle.Regular); // tahoma 7f
            Pen p = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush bg_gray = new SolidBrush(Color.Silver);
            SolidBrush bg_lightgray = new SolidBrush(Color.Gainsboro);
            StringFormat format_left = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_right = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

            int page = 0;
            int item_count = 0;

            PrintDocument docs = new PrintDocument();
            //PaperSize ps = new PaperSize();
            //ps.RawKind = (int)PaperKind.A4;
            //docs.DefaultPageSettings.PaperSize = ps;
            docs.DefaultPageSettings.Margins = new Margins(50, 40, 50, 50);
            //docs.DefaultPageSettings.Landscape = true;
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

                /* report header */
                Rectangle rect = new Rectangle(x, y, e.MarginBounds.Right - x, line_height);
                string str = "Event Log Report";
                e.Graphics.DrawString(str, fnt_title_bold, brush, rect, format_center);

                str = "Page " + page.ToString() + " / " + total_page.ToString();
                var str_measure = TextRenderer.MeasureText(e.Graphics, str, fnt_header);
                rect = str.GetDisplayRect(fnt_header, e.MarginBounds.Right - str_measure.Width, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_right);

                y += line_height;
                str = "Log Date/Time : " + (cond.logDateFrom.HasValue && cond.logDateTo.HasValue ? cond.logDateFrom.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + " - " + cond.logDateTo.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) : "*All");
                rect = str.GetDisplayRect(fnt_header, x, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                y += line_height;
                str = "Log Code : " + (cond.logCode.Trim().Length > 0 ? cond.logCode.Trim() : "*All");
                rect = str.GetDisplayRect(fnt_header, x, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "Express Data : " + (cond.logData.Trim().Length > 0 ? cond.logData.Trim() : "*All");
                rect = str.GetDisplayRect(fnt_header, rect.X + rect.Width + 5, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "Module : " + (cond.logModule.Trim().Length > 0 ? cond.logModule.Trim() : "*All");
                rect = str.GetDisplayRect(fnt_header, rect.X + rect.Width + 5, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "User Name : " + (cond.logUserName.Trim().Length > 0 ? cond.logUserName.Trim() : "*All");
                rect = str.GetDisplayRect(fnt_header, rect.X + rect.Width + 5, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                y += line_height;
                e.Graphics.DrawLine(p, new Point(e.MarginBounds.X, y), new Point(e.MarginBounds.Right, y));

                //y += line_height / 2;
                Rectangle rect_date = ("00/00/0000 00:00:00").GetDisplayRect(fnt_header_bold, x, y);
                e.Graphics.DrawString("Date/TIme", fnt_header_bold, brush, rect_date, format_center);

                Rectangle rect_desc = ("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx").GetDisplayRect(fnt_header_bold, rect_date.X + rect_date.Width + 5, y);
                e.Graphics.DrawString("Description", fnt_header_bold, brush, rect_desc, format_center);

                Rectangle rect_data = ("xxxxxxxxxxxxxxxxx").GetDisplayRect(fnt_header_bold, rect_desc.X + rect_desc.Width + 5, y);
                e.Graphics.DrawString("Express Data Path", fnt_header_bold, brush, rect_data, format_center);

                Rectangle rect_modul = ("xxxxxxx").GetDisplayRect(fnt_header_bold, rect_data.X + rect_data.Width + 5, y);
                e.Graphics.DrawString("Module", fnt_header_bold, brush, rect_modul, format_center);

                Rectangle rect_code = ("xxxxxxxx").GetDisplayRect(fnt_header_bold, rect_modul.X + rect_modul.Width + 5, y);
                e.Graphics.DrawString("Log Code", fnt_header_bold, brush, rect_code, format_center);

                Rectangle rect_user = ("xxxxxxxxxx").GetDisplayRect(fnt_header_bold, rect_code.X + rect_code.Width + 5, y);
                e.Graphics.DrawString("User Name", fnt_header_bold, brush, rect_user, format_center);

                y += line_height;
                e.Graphics.DrawLine(p, new Point(e.MarginBounds.X, y), new Point(e.MarginBounds.Right, y));

                y += line_height / 2;
                /* report item data */
                for (int i = item_count; i < logs.Count; i++)
                {
                    rect_date.Y = y;
                    e.Graphics.DrawString(logs[i].cretime.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture), fnt, brush, rect_date, format_left);

                    rect_desc.Y = y;
                    e.Graphics.DrawString(logs[i].description, fnt, brush, rect_desc, format_left);

                    rect_data.Y = y;
                    e.Graphics.DrawString(logs[i].expressdata, fnt, brush, rect_data, format_center);

                    rect_modul.Y = y;
                    e.Graphics.DrawString(logs[i].modcod, fnt, brush, rect_modul, format_center);

                    rect_code.Y = y;
                    e.Graphics.DrawString(logs[i].logcode, fnt, brush, rect_code, format_center);

                    rect_user.Y = y;
                    e.Graphics.DrawString(logs[i].username, fnt, brush, rect_user, format_center);

                    y += line_height;
                    item_count++;

                    if(y >= e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
            };

            return docs;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.focused_id = null;
            if(this.sort == SORT.DESC)
            {
                this.islogs = new BindingList<islogVM>(this.GetPreviousLog(null, 1).ToViewModel());
            }
            else
            {
                this.islogs = new BindingList<islogVM>(this.GetNextLog(null, 1).ToViewModel());
            }
            this.dgv.DataSource = this.islogs;
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (this.islogs.Count > 0 && this.focused_id == null)
            //    this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_logcode.Name].Selected = true;
            
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            var d = this.islogs;

            this.focused_id = (int?)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_id.Name].Value;

            if (((XDatagrid)sender).CurrentCell.RowIndex == 0)
            {
                int curr_id = (int)((XDatagrid)sender).Rows[0].Cells[this.col_id.Name].Value;

                if (this.sort == SORT.DESC) // DESC
                {
                    foreach (var item in this.GetPreviousLog(curr_id, 20).ToViewModel().OrderByDescending(i => i.id))
                    {
                        this.islogs.Insert(0, item);
                    }
                }
                else if(this.sort == SORT.ASC) // ASC
                {
                    foreach (var item in this.GetNextLog(curr_id, 20).ToViewModel().OrderBy(i => i.id))
                    {
                        this.islogs.Insert(0, item);
                    }
                }
                
                ((XDatagrid)sender).FirstDisplayedScrollingRowIndex = ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == curr_id).First().Index;
            }
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 1 && e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_cretime.Name).First().Index)
                {
                    this.sort = this.sort == SORT.DESC ? SORT.ASC : SORT.DESC;
                    this.btnRefresh.PerformClick();
                }
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1 && e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_cretime.Name).First().Index)
            {
                e.CellStyle.BackColor = Color.Tan;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                if(this.sort == SORT.DESC)
                {
                    using (SolidBrush brush = new SolidBrush(Color.SaddleBrown))
                    {
                        PointF p1 = new PointF(e.CellBounds.X + e.CellBounds.Width - 18, e.CellBounds.Y + 18);
                        PointF p2 = new PointF(p1.X + 10, p1.Y);
                        PointF p3 = new PointF(e.CellBounds.X + e.CellBounds.Width - 13, e.CellBounds.Y + 10);
                        e.Graphics.FillPolygon(brush, new PointF[] { p1, p2, p3 });
                        e.Graphics.DrawPolygon(new Pen(Color.WhiteSmoke), new PointF[] { p1, p2, p3 });
                    }
                }
                else if(this.sort == SORT.ASC)
                {
                    using (SolidBrush brush = new SolidBrush(Color.SaddleBrown))
                    {
                        PointF p1 = new PointF(e.CellBounds.X + e.CellBounds.Width - 18, e.CellBounds.Y + 10);
                        PointF p2 = new PointF(p1.X + 10, p1.Y);
                        PointF p3 = new PointF(e.CellBounds.X + e.CellBounds.Width - 13, e.CellBounds.Y + 18);
                        e.Graphics.FillPolygon(brush, new PointF[] { p1, p2, p3 });
                        e.Graphics.DrawPolygon(new Pen(Color.WhiteSmoke), new PointF[] { p1, p2, p3 });
                    }
                }

                e.Handled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.D))
            {
                this.btnDelete.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.S))
            {
                this.btnSearchByDate.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.K))
            {
                this.btnSearchByCondition.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.P))
            {
                this.btnPrintAll.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.P))
            {
                this.btnPrintCondition.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            if(keyData == Keys.Tab)
            {
                using (xpumpsecureEntities sec = DBX.DataSecureSet())
                {
                    int total_record = sec.islog.AsEnumerable().Count();
                    int curr_record_id = this.dgv.CurrentCell != null ? (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_id.Name].Value : -1;

                    DialogDataInfo info = new DialogDataInfo("Islog", curr_record_id, total_record, "", null, "", null);
                    info.ShowDialog();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
