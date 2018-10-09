using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;
using XPump.Model;
using XPump.SubForm;
using System.Data.OleDb;

namespace XPump.CustomControls
{
    public partial class BrowseBoxCuscod : XBrowseBox
    {
        public string _DataPath { get; set; }
        private List<CuscodInquiryList> cuscod_list;
        //public string selected_cusnam = string.Empty;
        public ArmasDbf selected_cust = null;

        public event EventHandler _SelectedCuscodChanged;

        public BrowseBoxCuscod()
        {
            InitializeComponent();
        }

        private void BrowseBoxCuscod_Load(object sender, EventArgs e)
        {

        }

        public static List<CuscodInquiryList> GetCuscodList(string data_path)
        {
            List<CuscodInquiryList> cuscod_list = new List<CuscodInquiryList>();

            if(data_path == null || data_path.Trim().Length == 0)
            {
                XMessageBox.Show("Data path not found!", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return cuscod_list;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select ar.cuscod as cuscod, ar.cusnam as cusnam, ar.orgnum as orgnum, ar.custyp as custyp, ist.typdes as _custypdesc, ist.tabtyp as tabtyp, ar.addr01 as addr01, ar.addr02 as addr02, ar.addr03 as addr03, ar.zipcod as zipcod, ar.status as status From armas ar ";
                    cmd.CommandText += "Left Join istab ist On ar.custyp = ist.typcod and ist.tabtyp = '45' ";
                    cmd.CommandText += "Order By cuscod ASC";

                    DataTable dt = new DataTable();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cuscod_list.Add(new CuscodInquiryList
                            {
                                addr01 = !dt.Rows[i].IsNull("addr01") ? dt.Rows[i]["addr01"].ToString().TrimEnd() : string.Empty,
                                addr02 = !dt.Rows[i].IsNull("addr02") ? dt.Rows[i]["addr02"].ToString().TrimEnd() : string.Empty,
                                addr03 = !dt.Rows[i].IsNull("addr03") ? dt.Rows[i]["addr03"].ToString().TrimEnd() : string.Empty,
                                cuscod = !dt.Rows[i].IsNull("cuscod") ? dt.Rows[i]["cuscod"].ToString().TrimEnd() : string.Empty,
                                cusnam = !dt.Rows[i].IsNull("cusnam") ? dt.Rows[i]["cusnam"].ToString().TrimEnd() : string.Empty,
                                custyp = !dt.Rows[i].IsNull("custyp") ? dt.Rows[i]["custyp"].ToString().TrimEnd() : string.Empty,
                                orgnum = !dt.Rows[i].IsNull("orgnum") ? Convert.ToInt32(dt.Rows[i]["orgnum"]) : -1,
                                status = !dt.Rows[i].IsNull("status") ? dt.Rows[i]["status"].ToString().TrimEnd() : string.Empty,
                                zipcod = !dt.Rows[i].IsNull("zipcod") ? dt.Rows[i]["zipcod"].ToString().TrimEnd() : string.Empty,
                                _custypdesc = !dt.Rows[i].IsNull("_custypdesc") ? dt.Rows[i]["_custypdesc"].ToString().TrimEnd() : string.Empty,
                            });
                        }

                        return cuscod_list;
                    }
                }
            }
        }

        private void BrowseBoxCuscod__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_cuscod = new DataGridViewTextBoxColumn
            {
                Name = "col_cuscod",
                DataPropertyName = "cuscod",
                HeaderText = "รหัส",
                Width = 100,
                MinimumWidth = 100,
            };
            DataGridViewTextBoxColumn col_cusnam = new DataGridViewTextBoxColumn
            {
                Name = "col_cusnam",
                DataPropertyName = "cusnam",
                HeaderText = "ชื่อลูกค้า",
                Width = 260,
                MinimumWidth = 260,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn col_orgnum = new DataGridViewTextBoxColumn
            {
                Name = "col_orgnum",
                DataPropertyName = "orgnum",
                HeaderText = "สาขา#",
                Width = 50,
                MinimumWidth = 50,
            };
            DataGridViewTextBoxColumn col_custyp = new DataGridViewTextBoxColumn
            {
                Name = "col_custyp",
                DataPropertyName = "custyp",
                HeaderText = "",
                Width = 40,
                MinimumWidth = 40
            };
            DataGridViewTextBoxColumn col_custypdesc = new DataGridViewTextBoxColumn
            {
                Name = "col_custypdesc",
                DataPropertyName = "_custypdesc",
                HeaderText = "ประเภทลูกค้า",
                Width = 100,
                MinimumWidth = 100
            };
            DataGridViewTextBoxColumn col_addr01 = new DataGridViewTextBoxColumn
            {
                Name = "col_addr01",
                DataPropertyName = "addr01",
                HeaderText = "ที่อยู่บรรทัดที่1",
                Width = 240,
                MinimumWidth = 100
            };
            DataGridViewTextBoxColumn col_addr02 = new DataGridViewTextBoxColumn
            {
                Name = "col_addr02",
                DataPropertyName = "addr02",
                HeaderText = "ที่อยู่บรรทัดที่2",
                Width = 240,
                MinimumWidth = 100
            };
            DataGridViewTextBoxColumn col_addr03 = new DataGridViewTextBoxColumn
            {
                Name = "col_addr03",
                DataPropertyName = "addr03",
                HeaderText = "ที่อยู่บรรทัดที่3",
                Width = 160,
                MinimumWidth = 100
            };
            DataGridViewTextBoxColumn col_zipcod = new DataGridViewTextBoxColumn
            {
                Name = "col_zipcod",
                DataPropertyName = "zipcod",
                HeaderText = "รหัสไปรษณีย์",
                Width = 100,
                MinimumWidth = 100
            };
            DataGridViewTextBoxColumn col_status = new DataGridViewTextBoxColumn
            {
                Name = "col_status",
                DataPropertyName = "status",
                HeaderText = "สถานะ",
                Width = 60,
                MinimumWidth = 60
            };
            col_orgnum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewColumn[] cols = new DataGridViewColumn[] { col_cuscod, col_cusnam, col_orgnum, col_custyp, col_custypdesc, col_addr01, col_addr02, col_addr03, col_zipcod, col_status };

            this.cuscod_list = GetCuscodList(this._DataPath);
            string curr_txt = string.Empty;
            if(this._Text.Trim().Length > 0)
            {
                var cus = this.cuscod_list.Where(c => c.cuscod.CompareTo(this._Text.TrimEnd()) >= 0).FirstOrDefault();
                curr_txt = cus != null ? cus.cuscod : curr_txt;
            }

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(cols, this.cuscod_list, col_cuscod.Name, curr_txt);
            br.SetBounds(this.PointToScreen(Point.Empty).X, this.PointToScreen(Point.Empty).Y + this.Height, br.Width, br.Height);
            br.dgv.AllowUserToResizeColumns = true;

            if(br.ShowDialog() == DialogResult.OK)
            {
                this.selected_cust = DbfTable.Armas(this._DataPath, br.selected_row.Cells[col_cuscod.Name].Value.ToString().TrimEnd());
                this._Text = br.selected_row.Cells[col_cuscod.Name].Value.ToString().TrimEnd();
                //this.selected_cusnam = br.selected_row.Cells[col_cusnam.Name].Value.ToString().TrimEnd();
                if(this._SelectedCuscodChanged != null)
                {
                    this._SelectedCuscodChanged(this, e);
                }
            }
        }

        private void BrowseBoxCuscod__Leave(object sender, EventArgs e)
        {
            if(this._Text.Trim().Length == 0)
            {
                this._Text = string.Empty;
                this.selected_cust = null;
                //this.selected_cusnam = string.Empty;
                if(this._SelectedCuscodChanged != null)
                {
                    this._SelectedCuscodChanged(this, e);
                }
            }
            else
            {
                var selected_cust = GetCuscodList(this._DataPath).Where(c => c.cuscod.TrimEnd() == this._Text.TrimEnd()).FirstOrDefault();
                if (selected_cust != null)
                {
                    this._Text = selected_cust.cuscod;
                    this.selected_cust = DbfTable.Armas(this._DataPath, selected_cust.cuscod.TrimEnd());
                    //this.selected_cusnam = selected_cust.cusnam.TrimEnd();
                    if(this._SelectedCuscodChanged != null)
                    {
                        this._SelectedCuscodChanged(this, e);
                    }
                }
                else
                {
                    this.Focus();
                    this.PerformButtonClick();
                }
            }
        }
    }

    public class CuscodInquiryList
    {
        public string cuscod { get; set; }
        public string cusnam { get; set; }
        public int orgnum { get; set; }
        public string custyp { get; set; }
        public string _custypdesc { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
        public string zipcod { get; set; }
        public string status { get; set; }
    }
}
