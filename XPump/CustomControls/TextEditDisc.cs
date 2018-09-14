using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;
using System.Text.RegularExpressions;

namespace XPump.CustomControls
{
    public partial class TextEditDisc : XTextEdit
    {
        public TextEditDisc()
        {
            InitializeComponent();
            this._TextAlign = HorizontalAlignment.Right;
            this._MaxLength = 10;
        }

        private void TextEditDisc__Leave(object sender, EventArgs e)
        {
            bool is_percent = this._Text.Contains("+") || this._Text.Contains("%") ? true : false;
            string txt = this._Text;
            if (txt.Contains(".."))
            {
                int ndx = txt.IndexOf("..");
                txt = txt.Substring(0, ndx);
            }

            string rewrite_str = string.Empty;
            decimal out_dec;

            if (is_percent)
            {
                if (txt.Contains("+"))
                {
                    txt = txt.Replace("%", "");

                    string[] s = txt.Split('+');

                    for (int i = 0; i < s.Count(); i++)
                    {
                        if(s[i].Split('.').Count() > 1) // more than 1 decimal point
                        {
                            if(decimal.TryParse(s[i].Split('.')[0] + "." + s[i].Split('.')[1], out out_dec))
                            {
                                if(out_dec > 0)
                                {
                                    rewrite_str += rewrite_str.Length > 0 ? "+" : "";
                                    rewrite_str += out_dec.ToString("0.##");
                                }
                            }
                        }
                        else // 0 or 1 decimal point
                        {
                            if (decimal.TryParse(s[i], out out_dec))
                            {
                                if (out_dec > 0)
                                {
                                    rewrite_str += rewrite_str.Length > 0 ? "+" : "";
                                    rewrite_str += out_dec.ToString("0.##");
                                }
                            }
                        }
                    }

                    if (rewrite_str.Length == 10)
                    {
                        rewrite_str = rewrite_str.Substring(0, 9) + "%";
                    }
                    else if (rewrite_str.Length > 0)
                    {
                        rewrite_str += "%";
                    }
                    else
                    {
                        rewrite_str += "";
                    }
                }
                else
                {
                    txt = txt.Replace("%", "");

                    if (decimal.TryParse(txt, out out_dec))
                    {
                        if (out_dec > 0)
                        {
                            rewrite_str += out_dec.ToString("0.##") + "%";
                        }
                    }
                }
            }
            else
            {
                if (txt.Contains('.') && txt.Split('.').Count() > 1)
                {
                    if (decimal.TryParse(txt.Split('.')[0] + "." + txt.Split('.')[1], out out_dec))
                    {
                        if(out_dec > 0)
                        {
                            rewrite_str += out_dec.ToString("0.##");
                        }
                    }
                }
                else
                {
                    if (decimal.TryParse(txt, out out_dec))
                    {
                        if(out_dec > 0)
                        {
                            rewrite_str += out_dec.ToString("0.##");
                        }
                    }
                }
            }

            this._Text = rewrite_str;

        }

        private void TextEditDisc__KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift || e.KeyCode == Keys.Home || e.KeyCode == Keys.Back || e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Add || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == (Keys.Shift | Keys.D5))
            {
                return;
            }
            else
            {
                string key_str = e.KeyData.ToString();

                Regex rx = new Regex(@"[\+0-9.]", RegexOptions.IgnoreCase);
                if (!rx.IsMatch(key_str.Trim()))
                {
                    e.SuppressKeyPress = true;
                    return;
                }
            }
        }
    }
}
