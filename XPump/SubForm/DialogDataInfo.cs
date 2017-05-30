using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XPump.SubForm
{
    public partial class DialogDataInfo : Form
    {
        private string table_name;
        private int current_id;
        private int total_record;
        private string creby;
        private DateTime? cretime;
        private string chgby;
        private DateTime? chgtime;
        private string apprby;
        private DateTime? apprtime;
        private string prnby;
        private DateTime? prntime;
        private int? prncnt;

        public DialogDataInfo(string table_name, int current_id, int total_record, string creby, DateTime? cretime, string chgby, DateTime? chgtime)
        {
            InitializeComponent();
            this.table_name = table_name;
            this.current_id = current_id;
            this.total_record = total_record;
            this.creby = creby;
            this.cretime = cretime;
            this.chgby = chgby;
            this.chgtime = chgtime;
        }

        public DialogDataInfo(string table_name, int current_id, int total_record, string creby, DateTime? cretime, string chgby, DateTime? chgtime, string apprby, DateTime? apprtime)
            : this(table_name, current_id, total_record, creby, cretime, chgby, chgtime)
        {
            this.apprby = apprby;
            this.apprtime = apprtime;
        }

        public DialogDataInfo(string table_name, int current_id, int total_record, string creby, DateTime? cretime, string chgby, DateTime? chgtime, string apprby, DateTime? apprtime, string prnby, DateTime? prntime, int prncnt)
            : this(table_name, current_id, total_record, creby, cretime, chgby, chgtime, apprby, apprtime)
        {
            this.prnby = prnby;
            this.prntime = prntime;
            this.prncnt = prncnt;
        }

        private void DialogDataInfo_Load(object sender, EventArgs e)
        {
            this.Text = this.table_name;

            this.txtCreBy._Text = this.creby != null ? this.creby : string.Empty;
            this.txtCreTime._Text = this.cretime.HasValue ? this.cretime.Value.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("th-TH")) : string.Empty;

            this.txtChgBy._Text = this.chgby != null ? this.chgby : string.Empty;
            this.txtChgTime._Text = this.chgtime.HasValue ? this.chgtime.Value.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("th-TH")) : string.Empty;

            this.txtApprBy._Text = this.apprby != null ? this.apprby : string.Empty;
            this.txtApprTime._Text = this.apprtime.HasValue ? this.apprtime.Value.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("th-TH")) : string.Empty;

            this.txtPrnBy._Text = this.prnby != null ? this.prnby : string.Empty;
            this.txtPrnTime._Text = this.prntime.HasValue ? this.prntime.Value.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("th-TH")) : string.Empty;
            this.txtPrnCnt._Text = this.prncnt.HasValue ? this.prncnt.Value.ToString() : "0";

            this.txtId._Text = this.current_id.ToString();
            this.txtTotal._Text = this.total_record.ToString();

            this.ActiveControl = this.btnClose;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnClose.PerformClick();
                return true;
            }

            if(keyData == Keys.Tab)
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    //public class DataInfo
    //{
    //    public int id { get; set; }
    //    public int total_record { get; set; }

    //}
}
