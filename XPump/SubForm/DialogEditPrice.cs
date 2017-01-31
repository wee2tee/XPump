using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XPump.SubForm
{
    public partial class DialogEditPrice : Form
    {
        public decimal unitpr;

        public DialogEditPrice(decimal unitpr = 0m)
        {
            InitializeComponent();
            this.unitpr = unitpr;
        }

        private void DialogEditPrice_Load(object sender, EventArgs e)
        {
            this.num1._Value = this.unitpr;
        }
    }
}
