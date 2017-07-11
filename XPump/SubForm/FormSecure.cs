using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Misc;
using XPump.Model;
using CC;

namespace XPump.SubForm
{
    public partial class FormSecure : Form
    {
        private MainForm main_form;
        private List<ScuserDbf> scusers;
        private ScuserDbf curr_user;

        public FormSecure(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FormSecure_Load(object sender, EventArgs e)
        {
            this.BackColor = MiscResource.WIND_BG;
            this.btnFirst.PerformClick();
        }

        private void FillForm()
        {
            if(this.curr_user != null)
            {
                this.txtUserId.Text = this.curr_user.reccod.Trim();
                this.txtUserName.Text = this.curr_user.recdes.Trim();
                this.txtGroup.Text = this.scusers.Where(s => s.rectyp.Trim() == "G" && s.reccod.Trim() == this.curr_user.connectgrp.Trim()).FirstOrDefault() != null ? this.scusers.Where(s => s.rectyp.Trim() == "G" && s.reccod.Trim() == this.curr_user.connectgrp.Trim()).First().reccod.Trim() : string.Empty;
                this.lblUserGroup.Text = this.scusers.Where(s => s.rectyp.Trim() == "G" && s.reccod.Trim() == this.curr_user.connectgrp.Trim()).FirstOrDefault() != null ? this.scusers.Where(s => s.rectyp.Trim() == "G" && s.reccod.Trim() == this.curr_user.connectgrp.Trim()).First().recdes.Trim() : string.Empty;
                this.txtLevel.Text = this.curr_user.authlev.ToString();
                this.txtSecure.Text = this.curr_user.secure == "1" ? "ตรวจสอบสิทธิก่อนใช้งาน" : "ไม่ตรวจสอบสิทธิ";
                this.txtLanguage.Text = this.curr_user.language == "E" ? "English" : "ไทย";
                switch (this.curr_user.status.Trim())
                {
                    case "":
                        this.txtStatus.Text = "ปกติ";
                        break;
                    case "S":
                        this.txtStatus.Text = "ตรวจสอบเข้มงวด";
                        break;
                    case "X":
                        this.txtStatus.Text = "ห้ามใช้";
                        break;
                    default:
                        this.txtStatus.Text = "";
                        break;
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.scusers = DbfTable.Scuser().ToScuserList();
            var sc = this.scusers.Where(s => s.rectyp == "U").OrderBy(s => s.reccod.Trim()).ToList();
            if (sc.Count > 0)
            {
                this.curr_user = sc.First();
            }
            else
            {
                this.curr_user = null;
            }

            this.FillForm();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.curr_user == null)
                return;

            this.scusers = DbfTable.Scuser().ToScuserList();
            var sc = this.scusers.Where(s => s.rectyp == "U" && s.reccod.Trim().CompareTo(this.curr_user.reccod.Trim()) < 0).OrderByDescending(s => s.reccod.Trim()).ToList();
            if (sc.Count > 0)
            {
                this.curr_user = sc.First();
            }
            else
            {
                return;
            }

            this.FillForm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.curr_user == null)
                return;

            this.scusers = DbfTable.Scuser().ToScuserList();
            var sc = this.scusers.Where(s => s.rectyp == "U" && s.reccod.Trim().CompareTo(this.curr_user.reccod.Trim()) > 0).OrderBy(s => s.reccod.Trim()).ToList();
            if (sc.Count > 0)
            {
                this.curr_user = sc.First();
            }
            else
            {
                return;
            }

            this.FillForm();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.scusers = DbfTable.Scuser().ToScuserList();
            var sc = this.scusers.Where(s => s.rectyp == "U").OrderBy(s => s.reccod.Trim()).ToList();
            if (sc.Count > 0)
            {
                this.curr_user = sc.Last();
            }
            else
            {
                this.curr_user = null;
            }

            this.FillForm();
        }
    }
}
