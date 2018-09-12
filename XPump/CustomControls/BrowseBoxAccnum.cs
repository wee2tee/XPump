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
using System.IO;
using System.Data.OleDb;
using XPump.SubForm;

namespace XPump.CustomControls
{
    public partial class BrowseBoxAccnum : XBrowseBox
    {
        public string _DataPath { get; set; }
        public bool _OnlyPostAccount { get; set; }
        private List<GlaccDbfList> glacc_list;
        public string selected_accnam = string.Empty;

        public event EventHandler _SelectedAccnumChanged;

        public BrowseBoxAccnum()
        {
            InitializeComponent();
        }

        private void BrowseBoxAccnum__ButtonClick(object sender, EventArgs e)
        {
            this.glacc_list = GetAccList(this._DataPath, this._OnlyPostAccount);

            DataGridViewTextBoxColumn col_accnum = new DataGridViewTextBoxColumn
            {
                Name = "col_accnum",
                HeaderText = "เลขที่บัญชี",
                DataPropertyName = "accnum",
                Width = 120,
                MinimumWidth = 120,
            };
            DataGridViewTextBoxColumn col_accnam = new DataGridViewTextBoxColumn
            {
                Name = "col_accnam",
                HeaderText = "ชื่อบัญชี",
                DataPropertyName = "accnam",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn col_group = new DataGridViewTextBoxColumn
            {
                Name = "col_group",
                HeaderText = "หมวด",
                DataPropertyName = "group",
                Width = 80,
                MinimumWidth = 80,
            };
            DataGridViewTextBoxColumn col_level = new DataGridViewTextBoxColumn
            {
                Name = "col_level",
                HeaderText = "ระดับ",
                DataPropertyName = "level",
                Width = 60,
                MinimumWidth = 60,
            };
            DataGridViewTextBoxColumn col_acctyp = new DataGridViewTextBoxColumn
            {
                Name = "col_acctyp",
                HeaderText = "ประเภท",
                DataPropertyName = "acctyp",
                Width = 80,
                MinimumWidth = 80,
            };
            DataGridViewTextBoxColumn col_parent = new DataGridViewTextBoxColumn
            {
                Name = "col_parent",
                HeaderText = "บัญชีคุม",
                DataPropertyName = "parent",
                Width = 120,
                MinimumWidth = 120,
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_accnum,
                col_accnam,
                col_group,
                col_level,
                col_acctyp,
                col_parent
            };

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(cols, this.glacc_list, col_accnum.Name, this._textBox.Text.TrimEnd());
            br.SetBounds(this.PointToScreen(Point.Empty).X - 5, this.PointToScreen(Point.Empty).Y + this.Height, br.Width, br.Height);
            if (br.ShowDialog() == DialogResult.OK)
            {
                this._Text = br.selected_row.Cells[col_accnum.Name].Value.ToString().TrimEnd();
                this.selected_accnam = br.selected_row.Cells[col_accnam.Name].Value.ToString().TrimEnd();
                if (this._SelectedAccnumChanged != null)
                {
                    this._SelectedAccnumChanged(this, e);
                }
            }
        }

        public static List<GlaccDbfList> GetAccList(string data_path, bool only_post_account)
        {
            var acc_list = new List<GlaccDbfList>();
            if (data_path == null || data_path.Trim().Length == 0 || !Directory.Exists(data_path))
            {
                XMessageBox.Show("Data path not found!", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return acc_list;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    if (only_post_account)
                    {
                        cmd.CommandText = "Select * From glacc Where acctyp='0' Order By accnum ASC";
                    }
                    else
                    {
                        cmd.CommandText = "Select * From glacc Order By accnum ASC";
                    }
                    
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        conn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string group = string.Empty;
                            if (!dt.Rows[i].IsNull("group"))
                            {
                                switch (dt.Rows[i]["group"].ToString().Trim())
                                {
                                    case "1":
                                        group = "สินทรัพย์";
                                        break;
                                    case "2":
                                        group = "หนี้สิน";
                                        break;
                                    case "3":
                                        group = "ทุน";
                                        break;
                                    case "4":
                                        group = "รายได้";
                                        break;
                                    case "5":
                                        group = "ค่าใช้จ่าย";
                                        break;
                                    default:
                                        break;
                                }
                            }

                            acc_list.Add(new GlaccDbfList
                            {
                                accnam = !dt.Rows[i].IsNull("accnam") ? dt.Rows[i]["accnam"].ToString().TrimEnd() : string.Empty,
                                accnum = !dt.Rows[i].IsNull("accnum") ? dt.Rows[i]["accnum"].ToString().TrimEnd() : string.Empty,
                                acctyp = !dt.Rows[i].IsNull("acctyp") ? (dt.Rows[i]["acctyp"].ToString().Trim() == "0" ? "POS" : "SUM") : string.Empty,
                                group = group,
                                level = !dt.Rows[i].IsNull("level") ? Convert.ToInt32(dt.Rows[i]["level"]) : 0,
                                parent = !dt.Rows[i].IsNull("parent") ? dt.Rows[i]["parent"].ToString().TrimEnd() : string.Empty
                            });
                        }

                        return acc_list;
                    }
                }
            }
        }

        private void BrowseBoxAccnum__Leave(object sender, EventArgs e)
        {
            if (_DataPath.Trim().Length == 0 || !Directory.Exists(_DataPath))
            {
                XMessageBox.Show("Data path not found!", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return;
            }

            if (this._textBox.Text.Trim().Length == 0)
            {
                this.selected_accnam = string.Empty;
                return;
            }

            var acc_list = GetAccList(this._DataPath, this._OnlyPostAccount);
            var selected_acc = acc_list.Where(s => s.accnum.TrimEnd() == this._textBox.Text.TrimEnd()).FirstOrDefault();
            if (selected_acc != null)
            {
                this.selected_accnam = selected_acc.accnam;
            }
            else
            {
                this.selected_accnam = string.Empty;
                this.Focus();
                this._btnBrowse.PerformClick();
            }
        }
    }
}
