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
using XPump.Misc;
using System.IO;
using System.Data.OleDb;

namespace XPump.CustomControls
{
    public partial class BrowseBoxSlm : XBrowseBox
    {
        public string _DataPath { get; set; }
        private List<OeslmDbfList> oeslm_list;
        public string selected_slmnam = string.Empty;

        public event EventHandler _SelectedSlmcodChanged;

        public BrowseBoxSlm()
        {
            InitializeComponent();
        }

        private void BrowseBoxSlm__ButtonClick(object sender, EventArgs e)
        {
            this.oeslm_list = GetSlmList(this._DataPath);

            DataGridViewTextBoxColumn col_slmcod = new DataGridViewTextBoxColumn
            {
                Name = "col_slmcod",
                HeaderText = "รหัส",
                DataPropertyName = "slmcod",
                Width = 120,
                MinimumWidth = 120,
            };
            DataGridViewTextBoxColumn col_slmnam = new DataGridViewTextBoxColumn
            {
                Name = "col_slmnam",
                HeaderText = "ชื่อพนักงานขาย",
                DataPropertyName = "slmnam",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_slmcod,
                col_slmnam
            };

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(cols, this.oeslm_list, col_slmcod.Name, this._textBox.Text.TrimEnd());
            br.SetBounds(this.PointToScreen(Point.Empty).X - 5, this.PointToScreen(Point.Empty).Y + this.Height, br.Width, br.Height);
            if(br.ShowDialog() == DialogResult.OK)
            {
                this._Text = br.selected_row.Cells[col_slmcod.Name].Value.ToString().TrimEnd();
                this.selected_slmnam = br.selected_row.Cells[col_slmnam.Name].Value.ToString().TrimEnd();
                if(this._SelectedSlmcodChanged != null)
                {
                    this._SelectedSlmcodChanged(this, e);
                }
            }
        }

        public static List<OeslmDbfList> GetSlmList(string data_path)
        {
            var oeslm_list = new List<OeslmDbfList>();
            if (data_path == null || data_path.Trim().Length == 0 || !Directory.Exists(data_path))
            {
                XMessageBox.Show("Data path not found!", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return oeslm_list;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select slmcod, slmnam From oeslm Order By slmcod ASC";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        conn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            oeslm_list.Add(new OeslmDbfList
                            {
                                slmcod = !dt.Rows[i].IsNull("slmcod") ? dt.Rows[i]["slmcod"].ToString().TrimEnd() : string.Empty,
                                slmnam = !dt.Rows[i].IsNull("slmnam") ? dt.Rows[i]["slmnam"].ToString().TrimEnd() : string.Empty
                            });
                        }

                        return oeslm_list;
                    }
                }
            }
        }

        private void BrowseBoxSlm__Leave(object sender, EventArgs e)
        {
            if (_DataPath.Trim().Length == 0 || !Directory.Exists(_DataPath))
            {
                XMessageBox.Show("Data path not found!", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return;
            }

            if(this._textBox.Text.Trim().Length == 0)
            {
                this.selected_slmnam = string.Empty;
                return;
            }

            var slm_list = GetSlmList(this._DataPath);
            var selected_slm = slm_list.Where(s => s.slmcod.TrimEnd() == this._textBox.Text.TrimEnd()).FirstOrDefault();
            if (selected_slm != null)
            {
                this.selected_slmnam = selected_slm.slmnam;
            }
            else
            {
                this.selected_slmnam = string.Empty;
                this.Focus();
                this._btnBrowse.PerformClick();
            }
        }
    }
}
