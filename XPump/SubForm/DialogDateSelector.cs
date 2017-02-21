﻿using System;
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

namespace XPump.SubForm
{
    public partial class DialogDateSelector : Form
    {
        public DateTime selected_date
        {
            get
            {
                return this.dtDate._SelectedDate.Value;
            }
        }
        private DateTime? initial_date;
        private string lbl_date_title;

        public DialogDateSelector(string lbl_date_title, DateTime? initial_date)
        {
            InitializeComponent();
            this.lbl_date_title = lbl_date_title;
            this.initial_date = initial_date;
        }

        private void DialogDateSelector_Load(object sender, EventArgs e)
        {
            this.lblDateTitle.Text = this.lbl_date_title;
            this.dtDate.SetDate(this.initial_date);
        }

        private void dtDate__SelectedDateChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = ((XDatePicker)sender)._SelectedDate.HasValue ? true : false;
        }
    }
}
