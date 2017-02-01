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
    public partial class DialogNumEdit : Form
    {
        public DialogNumEdit()
        {
            InitializeComponent();
        }

        private void DialogNumEdit_Shown(object sender, EventArgs e)
        {
            this.Width = 60;
        }
    }
}
