﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XPump.SubForm
{
    public partial class DialogViewDb : Form
    {
        private List<string> db_name_list;

        public DialogViewDb(List<string> db_name_list)
        {
            this.db_name_list = db_name_list;
            InitializeComponent();
        }

        private void DialogViewDb_Load(object sender, EventArgs e)
        {
            this.dgv.DataSource = this.db_name_list;
        }
    }
}
