using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;
using XPump.Model;

namespace XPump.SubForm
{
    public partial class DialogSellValue : Form
    {
        private MainForm main_form;
        public stcrd stcrd;
        public string nozzle = null;

        public DialogSellValue(MainForm main_form, stcrd stcrd)
        {
            this.main_form = main_form;
            this.stcrd = stcrd;
            InitializeComponent();
        }

        private void DialogSellValue_Load(object sender, EventArgs e)
        {

        }

        public static List<nozzle> GetNozzleList(SccompDbf working_express_db)
        {
            using (xpumpEntities db = DBX.DataSet(working_express_db))
            {
                var nozzles = db.nozzle.Where(n => n.isactive && n.)
            }
        }
    }
}
