using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CC
{
    public partial class XTimePicker : DateTimePicker
    {
        public XTimePicker()
        {
            InitializeComponent();
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "HH:mm:ss";
            this.ShowUpDown = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Console.WriteLine(" .. painted");
        }
    }
}
