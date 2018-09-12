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
using System.Data.OleDb;
using XPump.SubForm;
using System.IO;

namespace XPump.CustomControls
{
    public partial class BrowseBoxIstabFixed : XBrowseBox
    {
        public string _DataPath { get; set; }
        private string _tabtyp = "";
        public string _TabTyp
        {
            get
            {
                return this._tabtyp;
            }
            set
            {
                this._tabtyp = value;
            }
        }
        private List<IstabDbfList> istab_list;
        public string selected_typdes = string.Empty;

        public event EventHandler _SelectedIstabChanged;

        public BrowseBoxIstabFixed()
        {
            InitializeComponent();
        }

        private void BrowseBoxIstabFixed__ButtonClick(object sender, EventArgs e)
        {
            this.istab_list = GetIstabList(this._DataPath, this._tabtyp);

            DataGridViewTextBoxColumn col_typcod = new DataGridViewTextBoxColumn
            {
                Name = "col_typcod",
                HeaderText = "รหัส",
                DataPropertyName = "typcod",
                Width = 80,
                MinimumWidth = 80,
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "คำย่อ",
                DataPropertyName = "shortnam",
                Width = 120,
                MinimumWidth = 120,
            };
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "รายละเอียด",
                DataPropertyName = "typdes",
                Width = 120,
                MinimumWidth = 120,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typcod,
                col_shortnam,
                col_typdes
            };

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(cols, this.istab_list, col_typcod.Name, this._textBox.Text.TrimEnd());
            br.SetBounds(this.PointToScreen(Point.Empty).X - 5, this.PointToScreen(Point.Empty).Y + this.Height, br.Width, br.Height);
            if (br.ShowDialog() == DialogResult.OK)
            {
                this._Text = br.selected_row.Cells[col_typcod.Name].Value.ToString().TrimEnd();
                this.selected_typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString().TrimEnd();
                if (this._SelectedIstabChanged != null)
                {
                    this._SelectedIstabChanged(this, e);
                }
            }
        }

        public static List<IstabDbfList> GetIstabList(string data_path, string tabtyp)
        {
            var istab_list = new List<IstabDbfList>();
            if (data_path == null || data_path.Trim().Length == 0 || !Directory.Exists(data_path))
            {
                XMessageBox.Show("Data path not found!", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return istab_list;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select typcod, shortnam, typdes From istab Where Trim(tabtyp)=? Order By typcod ASC";
                    cmd.Parameters.AddWithValue("@Tabtyp", tabtyp.Trim());
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        conn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            istab_list.Add(new IstabDbfList
                            {
                                typcod = !dt.Rows[i].IsNull("typcod") ? dt.Rows[i]["typcod"].ToString().TrimEnd() : string.Empty,
                                shortnam = !dt.Rows[i].IsNull("shortnam") ? dt.Rows[i]["shortnam"].ToString().TrimEnd() : string.Empty,
                                typdes = !dt.Rows[i].IsNull("typdes") ? dt.Rows[i]["typdes"].ToString().TrimEnd() : string.Empty
                            });
                        }

                        return istab_list;
                    }
                }
            }
        }

        private void BrowseBoxIstabFixed__Leave(object sender, EventArgs e)
        {
            if (_DataPath.Trim().Length == 0 || !Directory.Exists(_DataPath))
            {
                XMessageBox.Show("Data path not found!", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return;
            }

            if (this._textBox.Text.Trim().Length == 0)
            {
                this.selected_typdes = string.Empty;
                return;
            }

            var slm_list = GetIstabList(this._DataPath, this._tabtyp);
            var selected_slm = slm_list.Where(s => s.typcod.TrimEnd() == this._textBox.Text.TrimEnd()).FirstOrDefault();
            if (selected_slm != null)
            {
                this.selected_typdes = selected_slm.typdes;
            }
            else
            {
                this.selected_typdes = string.Empty;
                this.Focus();
                this._btnBrowse.PerformClick();
            }
        }
    }
}
