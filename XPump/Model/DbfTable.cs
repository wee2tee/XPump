using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.SubForm;
using XPump.Misc;

namespace XPump.Model
{
    public class DbfTable
    {
        

        public static DataTable Stmas()
        {
            settings settings = DialogSettings.GetSettings();

            string data_path = string.Empty;
            if (settings != null && (settings.express_data_path.Contains(@":\") || settings.express_data_path.Contains(@"\\")))
            {
                data_path = settings.express_data_path;
            }
            else
            {
                data_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\" + settings.express_data_path + @"\";
            }

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "stmas.dbf")))
            {
                MessageBox.Show("ค้นหาแฟ้ม Stmas.dbf ในที่เก็บข้อมูล \"" + settings.express_data_path + "\" ไม่พบ, กรุณาตรวจสอบที่เก็บข้อมูลของโปรแกรม Express ในเมนูตั้งค่าระบบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }
            //var x = DBFHelper.DBFParse.ReadDBF(data_path + "stmas.dbf");
            //MessageBox.Show(x.Rows.Count.ToString() + " loaded, Started at : " + xtime.ToString() + ", Completed at : " + DateTime.Now.ToString());
            //return x;


            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from Stmas";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Sccomp()
        {
            string secure_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\secure\";

            if (!(Directory.Exists(secure_path) && File.Exists(secure_path + "sccomp.dbf")))
            {
                MessageBox.Show("ค้นหาแฟ้ม Sccomp.dbf ไม่พบ, อาจเป็นเพราะท่านติดตั้งโปรแกรมไว้ไม่ถูกที่ โปรแกรมนี้จะต้องถูกติดตั้งภายใต้โฟลเดอร์ของโปรแกรมเอ็กซ์เพรสเท่านั้น", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }


            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + secure_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from Sccomp";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Isrun()
        {
            settings settings = DialogSettings.GetSettings();

            string data_path = string.Empty;
            if (settings != null && (settings.express_data_path.Contains(@":\") || settings.express_data_path.Contains(@"\\")))
            {
                data_path = settings.express_data_path;
            }
            else
            {
                data_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\" + settings.express_data_path + @"\";
            }

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "isrun.dbf")))
            {
                MessageBox.Show("ค้นหาแฟ้ม Isrun.dbf ในที่เก็บข้อมูล \"" + settings.express_data_path + "\" ไม่พบ, กรุณาตรวจสอบที่เก็บข้อมูลของโปรแกรม Express ในเมนูตั้งค่าระบบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from Isrun";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }
    }


    public class StmasDbf
    {
        public string stkcod { get; set; }
        public string stkdes { get; set; }
        public string stkdes2 { get; set; }
        public string stktyp { get; set; }
        public string stklev { get; set; }
        public string stkgrp { get; set; }
        public string barcod { get; set; }
        public string stkcods { get; set; }
        public string acccod { get; set; }
        public string isinv { get; set; }
        public string stkclass { get; set; }
        public string negallow { get; set; }
        public string qucod { get; set; }
        public string cqucod { get; set; }
        public double cfactor { get; set; }
        public double stnpr { get; set; }
        public string ispur { get; set; }
        public string pqucod { get; set; }
        public double pfactor { get; set; }
        public string lpurqu { get; set; }
        public double lpurfac { get; set; }
        public double lpurpr { get; set; }
        public string lpdisc { get; set; }
        public DateTime? lpurdat { get; set; }
        public string supcod { get; set; }
        public string issal { get; set; }
        public string squcod { get; set; }
        public double sfactor { get; set; }
        public double sellpr1 { get; set; }
        public double sellpr2 { get; set; }
        public double sellpr3 { get; set; }
        public double sellpr4 { get; set; }
        public double sellpr5 { get; set; }
        public string tracksal { get; set; }
        public string vatcod { get; set; }
        public string iscom { get; set; }
        public string comrat { get; set; }
        public string lsellqu { get; set; }
        public double lsellfac { get; set; }
        public double lsellpr { get; set; }
        public string lsdisc { get; set; }
        public DateTime? lseldat { get; set; }
        public decimal? numelem { get; set; }
        public double totbal { get; set; }
        public double totval { get; set; }
        public double totreo { get; set; }
        public double totres { get; set; }
        public double opnbal { get; set; }
        public double unitpr { get; set; }
        public double opnval { get; set; }
        public DateTime? lasupd { get; set; }
        public string packing { get; set; }
        public string mlotnum { get; set; }
        public double mrembal { get; set; }
        public double mremval { get; set; }
        public string remark { get; set; }
        public DateTime? dat1 { get; set; }
        public DateTime? dat2 { get; set; }
        public double num1 { get; set; }
        public string str1 { get; set; }
        public string str2 { get; set; }
        public string str3 { get; set; }
        public string str4 { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }

    }

    public class SccompDbf
    {
        public string compnam { get; set; }
        public string compcod { get; set; }
        public string path { get; set; }
        public DateTime? gendat { get; set; }
        public string candel { get; set; }

    }

    public class IsrunDbf
    {
        public string doctyp { get; set; }
        public string doccod { get; set; }
        public string shortnam { get; set; }
        public string posdes { get; set; }
        public string posdes2 { get; set; }
        public string prefix { get; set; }
        public string docnum { get; set; }
        public bool ismodify { get; set; }
        public string depcod { get; set; }
        public string jnltyp { get; set; }
        public string jnlexp { get; set; }
        public string accnum01 { get; set; }
        public string accnum02 { get; set; }
        public string accnum03 { get; set; }
        public string accnum04 { get; set; }
        public string accnum05 { get; set; }
        public string accnum06 { get; set; }
        public string accnum07 { get; set; }
        public string accnum08 { get; set; }
        public string accnum09 { get; set; }
        public string accnum10 { get; set; }
        public string accnum11 { get; set; }
        public string accnum12 { get; set; }
        public string flgvat { get; set; }
        public decimal vatrat { get; set; }
        public string srv_vattyp { get; set; }
        public string autoprn { get; set; }
        public string whichform { get; set; }
        public string reprn_lev { get; set; }
        public string cancel_lev { get; set; }
        public string delete_lev { get; set; }
        public string approv_met { get; set; }
        public string approv_lev { get; set; }
        public string ovrlin_lev { get; set; }
        public string vat_initem { get; set; }
        public string loccod { get; set; }
        public string usebarcod { get; set; }
        public string pvatprorat { get; set; }
        public string reserve1 { get; set; }
        public string reserve2 { get; set; }
        public double reserve3 { get; set; }

    }
}
