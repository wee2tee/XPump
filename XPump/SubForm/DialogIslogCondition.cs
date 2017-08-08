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

namespace XPump.SubForm
{
    public partial class DialogIslogCondition : Form
    {
        private MainForm main_form;

        public DialogIslogCondition(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }
    }
}
