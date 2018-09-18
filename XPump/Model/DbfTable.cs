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
using CC;

namespace XPump.Model
{
    public class DbfTable
    {
        //public static string GetExpressDataPath(SccompDbf working_express_db)
        //{
        //    settings settings = DialogSettings.GetSettings();

        //    string data_path = string.Empty;
        //    if (settings != null && (settings.express_data_path.Contains(@":\") || settings.express_data_path.Contains(@"\\")))
        //    {
        //        data_path = settings.express_data_path + @"\";
        //    }
        //    else
        //    {
        //        data_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\" + settings.express_data_path + @"\";
        //    }

        //    return data_path;
        //}

        public enum RECORD_FLAG
        {
            FIRST,
            LAST,
            NEXT,
            PREVIOUS
        }

        public static bool IsSecureFileExist(string file_name)
        {
            string secure_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\secure\";
            if(File.Exists(secure_path + file_name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsDataFileExist(string file_name, SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path; //GetExpressDataPath();

            if(File.Exists(data_path + file_name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static OleDbConnection GetDbConnection(SccompDbf working_express_db)
        //{
        //    string data_path = working_express_db.abs_path;

        //    try
        //    {
        //        OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path);
        //        return conn;
        //    }
        //    catch (Exception ex)
        //    {
        //        XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        public static DataTable Isprd(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path;

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "isprd.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Isprd.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from Isprd";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Stmas(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path; //GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "stmas.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Stmas.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

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

        public static DataTable StmasByStkcod(SccompDbf working_express_db, string stkcod)
        {
            string data_path = working_express_db.abs_path; //GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "stmas.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Stmas.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from Stmas Where TRIM(stkcod) = '" + stkcod + "'";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable GetDataBySql(SccompDbf working_express_db, string sql, string tableName)
        {
            string data_path = working_express_db.abs_path; //GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + tableName + ".dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม " + tableName + ".dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = sql;

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Scuser()
        {
            string secure_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\secure\";

            if (!(Directory.Exists(secure_path) && File.Exists(secure_path + "scuser.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Scuser.dbf ไม่พบ, อาจเป็นเพราะท่านติดตั้งโปรแกรมไว้ไม่ถูกที่ โปรแกรมนี้จะต้องถูกติดตั้งภายใต้โฟลเดอร์ของโปรแกรมเอ็กซ์เพรสเท่านั้น", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }


            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + secure_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from Scuser";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Scacclv()
        {
            string secure_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\secure\";

            if (!(Directory.Exists(secure_path) && File.Exists(secure_path + "scacclv.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Scacclv.dbf ไม่พบ, อาจเป็นเพราะท่านติดตั้งโปรแกรมไว้ไม่ถูกที่ โปรแกรมนี้จะต้องถูกติดตั้งภายใต้โฟลเดอร์ของโปรแกรมเอ็กซ์เพรสเท่านั้น", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }


            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + secure_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from Scacclv";

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
                XMessageBox.Show("ค้นหาแฟ้ม Sccomp.dbf ไม่พบ, อาจเป็นเพราะท่านติดตั้งโปรแกรมไว้ไม่ถูกที่ โปรแกรมนี้จะต้องถูกติดตั้งภายใต้โฟลเดอร์ของโปรแกรมเอ็กซ์เพรสเท่านั้น", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
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

        public static DataTable Isrun(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path; //GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "isrun.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Isrun.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
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

        public static DataTable Istab(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path;

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "istab.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Istab.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from Istab";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Isinfo(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path; // GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "isinfo.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Isinfo.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from Isinfo";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Stloc(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path; // GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "stloc.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Stloc.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from stloc";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Stcrd(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path; // GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "stcrd.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Stcrd.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from stcrd";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Apmas(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path; // GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "apmas.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Apmas.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from apmas";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Aptrn(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path; // GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "aptrn.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Aptrn.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from aptrn";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static DataTable Artrn(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path; // GetExpressDataPath();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "artrn.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Artrn.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return new DataTable();
            }

            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + data_path);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                string mySQL = "select * from artrn";

                OleDbCommand cmd = new OleDbCommand(mySQL, conn);
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                DA.Fill(dt);

                conn.Close();
            }

            return dt;
        }

        public static ArmasDbf Armas(SccompDbf working_express_db, string cuscod)
        {
            string data_path = working_express_db.abs_path;

            if(!(Directory.Exists(data_path) && File.Exists(data_path + "armas.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Armas.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return null;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                DataTable dt = new DataTable();

                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Select ar.*, acc.accnam as accnam, custyp.typdes as custypdesc, area.typdes as areadesc, dlv.typdes as dlvbydesc, slm.slmnam as slmnam From armas ar ";
                    cmd.CommandText += @"Left Join glacc acc On ar.accnum = acc.accnum ";
                    cmd.CommandText += @"Left Join istab custyp On ar.custyp = custyp.typcod and custyp.tabtyp = '45' ";
                    cmd.CommandText += @"Left Join istab area On ar.areacod = area.typcod and area.tabtyp = '40' ";
                    cmd.CommandText += @"Left Join istab dlv On ar.dlvby = dlv.typcod and dlv.tabtyp = '41' ";
                    cmd.CommandText += @"Left Join oeslm slm On ar.slmcod = slm.slmcod ";
                    cmd.CommandText += @"Where TRIM(ar.cuscod) = ?";
                    cmd.Parameters.AddWithValue("@Cuscod", cuscod.Trim());
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        conn.Close();

                        return new DbfTable().ConvertDatatableToArmas(dt);
                    }
                }
            }
        }

        public static ArmasDbf Armas(SccompDbf working_express_db, RECORD_FLAG rec_flag = RECORD_FLAG.FIRST)
        {
            string data_path = working_express_db.abs_path;

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "armas.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Armas.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return null;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                DataTable dt = new DataTable();

                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    if(rec_flag == RECORD_FLAG.FIRST)
                    {
                        cmd.CommandText = @"Select ar.*, acc.accnam as accnam, custyp.typdes as custypdesc, area.typdes as areadesc, dlv.typdes as dlvbydesc, slm.slmnam as slmnam From armas ar ";
                        cmd.CommandText += @"Left Join glacc acc On ar.accnum = acc.accnum ";
                        cmd.CommandText += @"Left Join istab custyp On ar.custyp = custyp.typcod and custyp.tabtyp = '45' ";
                        cmd.CommandText += @"Left Join istab area On ar.areacod = area.typcod and area.tabtyp = '40' ";
                        cmd.CommandText += @"Left Join istab dlv On ar.dlvby = dlv.typcod and dlv.tabtyp = '41' ";
                        cmd.CommandText += @"Left Join oeslm slm On ar.slmcod = slm.slmcod ";
                        cmd.CommandText += @"Order By cuscod ASC Top 1";
                    }
                    else if(rec_flag == RECORD_FLAG.LAST)
                    {
                        cmd.CommandText = @"Select ar.*, acc.accnam as accnam, custyp.typdes as custypdesc, area.typdes as areadesc, dlv.typdes as dlvbydesc, slm.slmnam as slmnam From armas ar ";
                        cmd.CommandText += @"Left Join glacc acc On ar.accnum = acc.accnum ";
                        cmd.CommandText += @"Left Join istab custyp On ar.custyp = custyp.typcod and custyp.tabtyp = '45' ";
                        cmd.CommandText += @"Left Join istab area On ar.areacod = area.typcod and area.tabtyp = '40' ";
                        cmd.CommandText += @"Left Join istab dlv On ar.dlvby = dlv.typcod and dlv.tabtyp = '41' ";
                        cmd.CommandText += @"Left Join oeslm slm On ar.slmcod = slm.slmcod ";
                        cmd.CommandText += @"Order By cuscod DESC Top 1";
                    }
                    else
                    {
                        cmd.CommandText = @"Select ar.*, acc.accnam as accnam, custyp.typdes as custypdesc, area.typdes as areadesc, dlv.typdes as dlvbydesc, slm.slmnam as slmnam From armas ar ";
                        cmd.CommandText += @"Left Join glacc acc On ar.accnum = acc.accnum ";
                        cmd.CommandText += @"Left Join istab custyp On ar.custyp = custyp.typcod and custyp.tabtyp = '45' ";
                        cmd.CommandText += @"Left Join istab area On ar.areacod = area.typcod and area.tabtyp = '40' ";
                        cmd.CommandText += @"Left Join istab dlv On ar.dlvby = dlv.typcod and dlv.tabtyp = '41' ";
                        cmd.CommandText += @"Left Join oeslm slm On ar.slmcod = slm.slmcod ";
                        cmd.CommandText += @"Order By cuscod ASC Top 1";
                    }

                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        conn.Close();

                        return new DbfTable().ConvertDatatableToArmas(dt);
                    }
                }
            }
        }

        //public static ArmasDbf Armas(SccompDbf working_express_db, RECORD_FLAG rec_flag, string curr_cuscod)
        //{
        //    string data_path = working_express_db.abs_path;

        //    if (!(Directory.Exists(data_path) && File.Exists(data_path + "armas.dbf")))
        //    {
        //        XMessageBox.Show("ค้นหาแฟ้ม Armas.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
        //        return null;
        //    }

        //    using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
        //    {
        //        DataTable dt = new DataTable();

        //        conn.Open();
        //        using (OleDbCommand cmd = conn.CreateCommand())
        //        {
        //            if (rec_flag == RECORD_FLAG.NEXT)
        //            {
        //                cmd.CommandText = "Select * From armas Order By cuscod ASC Top 1";
        //            }
        //            else if (rec_flag == RECORD_FLAG.PREVIOUS)
        //            {
        //                cmd.CommandText = "Select * From armas Order By cuscod DESC Top 1";
        //            }
        //            else
        //            {
        //                cmd.CommandText = "Select * From armas Order By cuscod ASC Top 1";
        //            }

        //            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
        //            {
        //                da.Fill(dt);
        //                conn.Close();

        //                return new DbfTable().ConvertDatatableToArmas(dt);
        //            }
        //        }
        //    }
        //}

        private ArmasDbf ConvertDatatableToArmas(DataTable dt)
        {
            ArmasDbf armas = null;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int dummy_int;
                var org = !dt.Rows[i].IsNull("orgnum") ? Int32.TryParse(dt.Rows[i]["orgnum"].ToString(), out dummy_int) ? dummy_int : 0 : 0;

                armas = new ArmasDbf
                {
                    accnum = !dt.Rows[i].IsNull("accnum") ? dt.Rows[i]["accnum"].ToString().TrimEnd() : string.Empty,
                    addr01 = !dt.Rows[i].IsNull("addr01") ? dt.Rows[i]["addr01"].ToString().TrimEnd() : string.Empty,
                    addr02 = !dt.Rows[i].IsNull("addr02") ? dt.Rows[i]["addr02"].ToString().TrimEnd() : string.Empty,
                    addr03 = !dt.Rows[i].IsNull("addr03") ? dt.Rows[i]["addr03"].ToString().TrimEnd() : string.Empty,
                    areacod = !dt.Rows[i].IsNull("areacod") ? dt.Rows[i]["areacod"].ToString().TrimEnd() : string.Empty,
                    balance = !dt.Rows[i].IsNull("balance") ? Convert.ToDouble(dt.Rows[i]["balance"]) : 0,
                    chgdat = !dt.Rows[i].IsNull("chgdat") ? (DateTime?)dt.Rows[i]["chgdat"] : null,
                    chqrcv = !dt.Rows[i].IsNull("chqrcv") ? Convert.ToDouble(dt.Rows[i]["chqrcv"]) : 0,
                    contact = !dt.Rows[i].IsNull("contact") ? dt.Rows[i]["contact"].ToString().TrimEnd() : string.Empty,
                    creby = !dt.Rows[i].IsNull("creby") ? dt.Rows[i]["creby"].ToString().TrimEnd() : string.Empty,
                    credat = !dt.Rows[i].IsNull("credat") ? (DateTime?)dt.Rows[i]["credat"] : null,
                    crline = !dt.Rows[i].IsNull("crline") ? Convert.ToDouble(dt.Rows[i]["crline"]) : 0,
                    cuscod = !dt.Rows[i].IsNull("cuscod") ? dt.Rows[i]["cuscod"].ToString().TrimEnd() : string.Empty,
                    cusnam = !dt.Rows[i].IsNull("cusnam") ? dt.Rows[i]["cusnam"].ToString().TrimEnd() : string.Empty,
                    cusnam2 = !dt.Rows[i].IsNull("cusnam2") ? dt.Rows[i]["cusnam2"].ToString().TrimEnd() : string.Empty,
                    custyp = !dt.Rows[i].IsNull("custyp") ? dt.Rows[i]["custyp"].ToString().TrimEnd() : string.Empty,
                    disc = !dt.Rows[i].IsNull("disc") ? (dt.Rows[i]["disc"].ToString().Trim().Length > 0 ? dt.Rows[i]["disc"].ToString() : string.Empty) : string.Empty,
                    dlvby = !dt.Rows[i].IsNull("dlvby") ? dt.Rows[i]["dlvby"].ToString().TrimEnd() : string.Empty,
                    inactdat = !dt.Rows[i].IsNull("inactdat") ? (DateTime?)dt.Rows[i]["inactdat"] : null,
                    lasivc = !dt.Rows[i].IsNull("lasivc") ? (DateTime?)dt.Rows[i]["lasivc"] : null,
                    orgnum = org,
                    paycond = !dt.Rows[i].IsNull("paycond") ? dt.Rows[i]["paycond"].ToString().TrimEnd() : string.Empty,
                    payer = !dt.Rows[i].IsNull("payer") ? dt.Rows[i]["payer"].ToString().TrimEnd() : string.Empty,
                    paytrm = !dt.Rows[i].IsNull("paytrm") ? Convert.ToInt32(dt.Rows[i]["paytrm"]) : 0,
                    prenam = !dt.Rows[i].IsNull("prenam") ? dt.Rows[i]["prenam"].ToString().TrimEnd() : string.Empty,
                    remark = !dt.Rows[i].IsNull("remark") ? dt.Rows[i]["remark"].ToString().TrimEnd() : string.Empty,
                    shipto = !dt.Rows[i].IsNull("shipto") ? dt.Rows[i]["shipto"].ToString().TrimEnd() : string.Empty,
                    slmcod = !dt.Rows[i].IsNull("slmcod") ? dt.Rows[i]["slmcod"].ToString().TrimEnd() : string.Empty,
                    status = !dt.Rows[i].IsNull("status") ? dt.Rows[i]["status"].ToString() : string.Empty,
                    tabpr = !dt.Rows[i].IsNull("tabpr") ? dt.Rows[i]["tabpr"].ToString() : string.Empty,
                    taxcond = !dt.Rows[i].IsNull("taxcond") ? dt.Rows[i]["taxcond"].ToString() : string.Empty,
                    taxgrp = !dt.Rows[i].IsNull("taxgrp") ? dt.Rows[i]["taxgrp"].ToString() : string.Empty,
                    taxid = !dt.Rows[i].IsNull("taxid") ? dt.Rows[i]["taxid"].ToString().TrimEnd() : string.Empty,
                    taxrat = !dt.Rows[i].IsNull("taxrat") ? Convert.ToDecimal(dt.Rows[i]["taxrat"]) : 0,
                    taxtyp = !dt.Rows[i].IsNull("taxtyp") ? dt.Rows[i]["taxtyp"].ToString() : string.Empty,
                    telnum = !dt.Rows[i].IsNull("telnum") ? dt.Rows[i]["telnum"].ToString().TrimEnd() : string.Empty,
                    tracksal = !dt.Rows[i].IsNull("tracksal") ? dt.Rows[i]["tracksal"].ToString() : string.Empty,
                    userid = !dt.Rows[i].IsNull("userid") ? dt.Rows[i]["userid"].ToString() : string.Empty,
                    zipcod = !dt.Rows[i].IsNull("zipcod") ? dt.Rows[i]["zipcod"].ToString() : string.Empty,
                    _accnam = !dt.Rows[i].IsNull("accnam") ? dt.Rows[i]["accnam"].ToString() : string.Empty,
                    _custypdesc = !dt.Rows[i].IsNull("custypdesc") ? dt.Rows[i]["custypdesc"].ToString().TrimEnd() : string.Empty,
                    _areadesc = !dt.Rows[i].IsNull("areadesc") ? dt.Rows[i]["areadesc"].ToString().TrimEnd() : string.Empty,
                    _dlvbydesc = !dt.Rows[i].IsNull("dlvbydesc") ? dt.Rows[i]["dlvbydesc"].ToString().TrimEnd() : string.Empty,
                    _slmnam = !dt.Rows[i].IsNull("slmnam") ? dt.Rows[i]["slmnam"].ToString().TrimEnd() : string.Empty
                };
            }
            return armas;
        }

        public static List<string> ArmasCuscodList(SccompDbf working_express_db, bool is_decending = false)
        {
            string data_path = working_express_db.abs_path;
            List<string> armas = new List<string>();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "armas.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Armas.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return armas;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                DataTable dt = new DataTable();

                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    if (is_decending)
                    {
                        cmd.CommandText = "Select cuscod From armas Order By cuscod DESC";
                    }
                    else
                    {
                        cmd.CommandText = "Select cuscod From armas Order By cuscod ASC";
                    }
                    
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        conn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var cuscod = !dt.Rows[i].IsNull("cuscod") ? dt.Rows[i]["cuscod"].ToString().TrimEnd() : string.Empty;
                            armas.Add(cuscod);
                        }

                        return armas;
                    }
                }
            }
        }

        public static List<ArmasDbfList> ArmasList(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path;
            List<ArmasDbfList> armas = new List<ArmasDbfList>();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "armas.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Armas.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return armas;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                DataTable dt = new DataTable();

                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * From armas Order By cuscod";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        conn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int dummy_int;
                            var org = !dt.Rows[i].IsNull("orgnum") ? Int32.TryParse(dt.Rows[i]["orgnum"].ToString(), out dummy_int) ? dummy_int : 0 : 0;

                            armas.Add(new ArmasDbfList
                            {
                                accnum = !dt.Rows[i].IsNull("accnum") ? dt.Rows[i]["accnum"].ToString().TrimEnd() : string.Empty,
                                areacod = !dt.Rows[i].IsNull("areacod") ? dt.Rows[i]["areacod"].ToString().TrimEnd() : string.Empty,
                                contact = !dt.Rows[i].IsNull("contact") ? dt.Rows[i]["contact"].ToString().TrimEnd() : string.Empty,
                                crline = !dt.Rows[i].IsNull("crline") ? Convert.ToDouble(dt.Rows[i]["crline"]) : 0,
                                cuscod = !dt.Rows[i].IsNull("cuscod") ? dt.Rows[i]["cuscod"].ToString().TrimEnd() : string.Empty,
                                cusnam = !dt.Rows[i].IsNull("cusnam") ? dt.Rows[i]["cusnam"].ToString().TrimEnd() : string.Empty,
                                disc = !dt.Rows[i].IsNull("disc") ? dt.Rows[i]["disc"].ToString() : string.Empty,
                                dlvby = !dt.Rows[i].IsNull("dlvby") ? dt.Rows[i]["dlvby"].ToString().TrimEnd() : string.Empty,
                                paycond = !dt.Rows[i].IsNull("paycond") ? dt.Rows[i]["paycond"].ToString().TrimEnd() : string.Empty,
                                paytrm = !dt.Rows[i].IsNull("paytrm") ? Convert.ToInt32(dt.Rows[i]["paytrm"]) : 0,
                                prenam = !dt.Rows[i].IsNull("prenam") ? dt.Rows[i]["prenam"].ToString().TrimEnd() : string.Empty,
                                slmcod = !dt.Rows[i].IsNull("slmcod") ? dt.Rows[i]["slmcod"].ToString().TrimEnd() : string.Empty,
                                tabpr = !dt.Rows[i].IsNull("tabpr") ? dt.Rows[i]["tabpr"].ToString().TrimEnd() : string.Empty,
                            });
                        }

                        return armas;
                    }
                }
            }
        }

        public static List<OeslmDbfList> OeslmList(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path;
            List<OeslmDbfList> oeslm = new List<OeslmDbfList>();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "oeslm.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Oeslm.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return oeslm;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select slmcod, slmnam From oeslm Order By slmcod ASC";

                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            oeslm.Add(new OeslmDbfList
                            {
                                slmcod = !dt.Rows[i].IsNull("slmcod") ? dt.Rows[i]["slmcod"].ToString().TrimEnd() : string.Empty,
                                slmnam = !dt.Rows[i].IsNull("slmnam") ? dt.Rows[i]["slmnam"].ToString().TrimEnd() : string.Empty
                            });
                        }

                        conn.Close();
                        return oeslm;
                    }
                }
            }
        }

        public static List<IstabDbf> IstabList(SccompDbf working_express_db, TABTYP tabtyp)
        {
            string data_path = working_express_db.abs_path;
            List<IstabDbf> istab = new List<IstabDbf>();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "istab.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Istab.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return istab;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    switch (tabtyp)
                    {
                        case TABTYP.PRENAM:
                            cmd.CommandText = "Select * From istab Where TRIM(tabtyp)='51' and TRIM(typcod)='06' Order By typcod ASC";
                            break;
                        case TABTYP.REMARK_AR:
                            cmd.CommandText = "Select * From istab Where TRIM(tabtyp)='51' and TRIM(typcod)='18' Order By typcod ASC";
                            break;
                        case TABTYP.CUSTYP:
                            cmd.CommandText = "Select * From istab Where TRIM(tabtyp)='45' Order By typcod ASC";
                            break;
                        case TABTYP.AREA:
                            cmd.CommandText = "Select * From istab Where TRIM(tabtyp)='40' Order By typcod ASC";
                            break;
                        case TABTYP.DLVBY:
                            cmd.CommandText = "Select * From istab Where TRIM(tabtyp)='41' Order By typcod ASC";
                            break;
                        case TABTYP.PAYCOND:
                            cmd.CommandText = "Select * From istab Where TRIM(tabtyp)='51' and TRIM(typcod)='17' Order By typdes ASC";
                            break;
                        default:
                            cmd.CommandText = "Select * From istab Where TRIM(tabtyp)=''";
                            break;
                    }

                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            istab.Add(new IstabDbf
                            {
                                depcod = !dt.Rows[i].IsNull("depcod") ? dt.Rows[i]["depcod"].ToString().TrimEnd() : string.Empty,
                                fld01 = !dt.Rows[i].IsNull("fld01") ? dt.Rows[i]["fld01"].ToString().TrimEnd() : string.Empty,
                                fld02 = !dt.Rows[i].IsNull("fld02") ? Convert.ToDouble(dt.Rows[i]["fld02"]) : 0,
                                shortnam = !dt.Rows[i].IsNull("shortnam") ? dt.Rows[i]["shortnam"].ToString().TrimEnd() : string.Empty,
                                shortnam2 = !dt.Rows[i].IsNull("shortnam2") ? dt.Rows[i]["shortnam2"].ToString().TrimEnd() : string.Empty,
                                status = !dt.Rows[i].IsNull("status") ? dt.Rows[i]["status"].ToString().TrimEnd() : string.Empty,
                                tabtyp = !dt.Rows[i].IsNull("tabtyp") ? dt.Rows[i]["tabtyp"].ToString().TrimEnd() : string.Empty,
                                typcod = !dt.Rows[i].IsNull("typcod") ? dt.Rows[i]["typcod"].ToString().TrimEnd() : string.Empty,
                                typdes = !dt.Rows[i].IsNull("typdes") ? dt.Rows[i]["typdes"].ToString().TrimEnd() : string.Empty,
                                typdes2 = !dt.Rows[i].IsNull("typdes2") ? dt.Rows[i]["typdes2"].ToString().TrimEnd() : string.Empty
                            });
                        }

                        conn.Close();
                        return istab;
                    }
                }
            }
        }

        public static List<GlaccDbfList> GlaccDbfList(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path;
            List<GlaccDbfList> glacc = new List<GlaccDbfList>();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "glacc.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Glacc.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return glacc;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    //cmd.CommandText = "Select accnum,accnam,?,level,acctyp,parent From  glacc Where acctyp=?";
                    //cmd.Parameters.AddWithValue("@Group", "group");
                    //cmd.Parameters.AddWithValue("@Acctyp", "0");
                    cmd.CommandText = "Select * From  glacc Where acctyp='0'";

                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        conn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string group = string.Empty;
                            if (!dt.Rows[i].IsNull("group"))
                            {
                                switch (dt.Rows[i]["group"].ToString().Trim())
                                {
                                    case "1":
                                        group = "สินทรัพย์";
                                        break;
                                    case "2":
                                        group = "หนี้สิน";
                                        break;
                                    case "3":
                                        group = "ทุน";
                                        break;
                                    case "4":
                                        group = "รายได้";
                                        break;
                                    case "5":
                                        group = "ค่าใช้จ่าย";
                                        break;
                                    default:
                                        break;
                                }
                            }

                            glacc.Add(new Model.GlaccDbfList
                            {
                                accnam = !dt.Rows[i].IsNull("accnam") ? dt.Rows[i]["accnam"].ToString().TrimEnd() : string.Empty,
                                accnum = !dt.Rows[i].IsNull("accnum") ? dt.Rows[i]["accnum"].ToString().TrimEnd() : string.Empty,
                                acctyp = !dt.Rows[i].IsNull("acctyp") ? (dt.Rows[i]["acctyp"].ToString().Trim() == "0" ? "POS" : "SUM") : string.Empty,
                                group = group,
                                level = !dt.Rows[i].IsNull("level") ? Convert.ToInt32(dt.Rows[i]["level"]) : 0,
                                parent = !dt.Rows[i].IsNull("parent") ? dt.Rows[i]["parent"].ToString().TrimEnd() : string.Empty
                            });
                        }

                        return glacc;
                    }
                }
            }
        }

        public static List<StkgrpBillMethodList> StkgrpBillMethodList(SccompDbf working_express_db)
        {
            string data_path = working_express_db.abs_path;
            List<StkgrpBillMethodList> istab = new List<StkgrpBillMethodList>();

            if (!(Directory.Exists(data_path) && File.Exists(data_path + "istab.dbf")))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Istab.dbf ในที่เก็บข้อมูล \"" + data_path + "\" ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return istab;
            }

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + data_path))
            {
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    DataTable dt = new DataTable();

                    cmd.CommandText = "Sele * From istab Where tabtyp=? Order By typcod ASC";
                    cmd.Parameters.AddWithValue("@tabtyp", "22");
                    conn.Open();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        conn.Close();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            istab.Add(new StkgrpBillMethodList
                            {
                                typcod = !dt.Rows[i].IsNull("typcod") ? dt.Rows[i]["typcod"].ToString().TrimEnd() : string.Empty,
                                shortnam = !dt.Rows[i].IsNull("shortnam") ? dt.Rows[i]["shortnam"].ToString().TrimEnd() : string.Empty,
                                typdes = !dt.Rows[i].IsNull("typdes") ? dt.Rows[i]["typdes"].ToString().TrimEnd() : string.Empty,
                                stktyp = !dt.Rows[i].IsNull("shortnam2") ? (dt.Rows[i]["shortnam2"].ToString().Contains(STKGRP.FUEL.ToString()) ? STKGRP.FUEL.ToStringDescription() : (dt.Rows[i]["shortnam2"].ToString().Contains(STKGRP.OTHER.ToString()) ? STKGRP.OTHER.ToStringDescription() : STKGRP.NA_O.ToStringDescription())) : STKGRP.NA_O.ToStringDescription(),
                                bill_method = !dt.Rows[i].IsNull("shortnam2") ? (dt.Rows[i]["shortnam2"].ToString().Contains(BILL_METHOD.VAL.ToString()) ? BILL_METHOD.VAL.ToStringDescription() : (dt.Rows[i]["shortnam2"].ToString().Contains(BILL_METHOD.QTY.ToString()) ? BILL_METHOD.QTY.ToStringDescription() : BILL_METHOD.NA_Q.ToStringDescription())) : BILL_METHOD.NA_Q.ToStringDescription()
                            });
                        }

                        return istab;
                    }
                }
            }

        }
    }
    
    

    public enum TABTYP
    {
        PRENAM,
        REMARK_AR,
        CUSTYP,
        AREA,
        DLVBY,
        PAYCOND
    }

    public enum STKGRP
    {
        FUEL,
        OTHER,
        NA_O
    }

    public enum BILL_METHOD
    {
        QTY,
        VAL,
        NA_Q
    }

    public class IsprdDbf
    {
        public DateTime? beg1 { get; set; }
        public DateTime? end1 { get; set; }
        public string lock1 { get; set; }
        public DateTime? beg2 { get; set; }
        public DateTime? end2 { get; set; }
        public string lock2 { get; set; }
        public DateTime? beg3 { get; set; }
        public DateTime? end3 { get; set; }
        public string lock3 { get; set; }
        public DateTime? beg4 { get; set; }
        public DateTime? end4 { get; set; }
        public string lock4 { get; set; }
        public DateTime? beg5 { get; set; }
        public DateTime? end5 { get; set; }
        public string lock5 { get; set; }
        public DateTime? beg6 { get; set; }
        public DateTime? end6 { get; set; }
        public string lock6 { get; set; }
        public DateTime? beg7 { get; set; }
        public DateTime? end7 { get; set; }
        public string lock7 { get; set; }
        public DateTime? beg8 { get; set; }
        public DateTime? end8 { get; set; }
        public string lock8 { get; set; }
        public DateTime? beg9 { get; set; }
        public DateTime? end9 { get; set; }
        public string lock9 { get; set; }
        public DateTime? beg10 { get; set; }
        public DateTime? end10 { get; set; }
        public string lock10 { get; set; }
        public DateTime? beg11 { get; set; }
        public DateTime? end11 { get; set; }
        public string lock11 { get; set; }
        public DateTime? beg12 { get; set; }
        public DateTime? end12 { get; set; }
        public string lock12 { get; set; }

        public DateTime? beg1ny { get; set; }
        public DateTime? end1ny { get; set; }
        public string lock1ny { get; set; }
        public DateTime? beg2ny { get; set; }
        public DateTime? end2ny { get; set; }
        public string lock2ny { get; set; }
        public DateTime? beg3ny { get; set; }
        public DateTime? end3ny { get; set; }
        public string lock3ny { get; set; }
        public DateTime? beg4ny { get; set; }
        public DateTime? end4ny { get; set; }
        public string lock4ny { get; set; }
        public DateTime? beg5ny { get; set; }
        public DateTime? end5ny { get; set; }
        public string lock5ny { get; set; }
        public DateTime? beg6ny { get; set; }
        public DateTime? end6ny { get; set; }
        public string lock6ny { get; set; }
        public DateTime? beg7ny { get; set; }
        public DateTime? end7ny { get; set; }
        public string lock7ny { get; set; }
        public DateTime? beg8ny { get; set; }
        public DateTime? end8ny { get; set; }
        public string lock8ny { get; set; }
        public DateTime? beg9ny { get; set; }
        public DateTime? end9ny { get; set; }
        public string lock9ny { get; set; }
        public DateTime? beg10ny { get; set; }
        public DateTime? end10ny { get; set; }
        public string lock10ny { get; set; }
        public DateTime? beg11ny { get; set; }
        public DateTime? end11ny { get; set; }
        public string lock11ny { get; set; }
        public DateTime? beg12ny { get; set; }
        public DateTime? end12ny { get; set; }
        public string lock12ny { get; set; }
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

    public class StlocDbf
    {
        public string stkcod { get; set; }
        public string loccod { get; set; }
        public string area { get; set; }
        public string stkclass { get; set; }
        public double locbal { get; set; }
        public double unitpr { get; set; }
        public double locval { get; set; }
        public double locreo { get; set; }
        public double locres { get; set; }
        public DateTime? lpurdat { get; set; }
        public DateTime? lseldat { get; set; }
        public DateTime? lmovdat { get; set; }
        public DateTime? takdat { get; set; }
        public string mlotnum { get; set; }
        public double mrembal { get; set; }
        public double mremval { get; set; }
        public double begbal { get; set; }
        public double begval { get; set; }
        public double qty1 { get; set; }
        public double qty2 { get; set; }
        public double qty3 { get; set; }
        public double qty4 { get; set; }
        public double qty5 { get; set; }
        public double qty6 { get; set; }
        public double qty7 { get; set; }
        public double qty8 { get; set; }
        public double qty9 { get; set; }
        public double qty10 { get; set; }
        public double qty11 { get; set; }
        public double qty12 { get; set; }
        public double qty1ny { get; set; }
        public double qty2ny { get; set; }
        public double qty3ny { get; set; }
        public double qty4ny { get; set; }
        public double qty5ny { get; set; }
        public double qty6ny { get; set; }
        public double qty7ny { get; set; }
        public double qty8ny { get; set; }
        public double qty9ny { get; set; }
        public double qty10ny { get; set; }
        public double qty11ny { get; set; }
        public double qty12ny { get; set; }
        public double val1 { get; set; }
        public double val2 { get; set; }
        public double val3 { get; set; }
        public double val4 { get; set; }
        public double val5 { get; set; }
        public double val6 { get; set; }
        public double val7 { get; set; }
        public double val8 { get; set; }
        public double val9 { get; set; }
        public double val10 { get; set; }
        public double val11 { get; set; }
        public double val12 { get; set; }
        public double val1ny { get; set; }
        public double val2ny { get; set; }
        public double val3ny { get; set; }
        public double val4ny { get; set; }
        public double val5ny { get; set; }
        public double val6ny { get; set; }
        public double val7ny { get; set; }
        public double val8ny { get; set; }
        public double val9ny { get; set; }
        public double val10ny { get; set; }
        public double val11ny { get; set; }
        public double val12ny { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }
    }

    public class StcrdDbf
    {
        public string stkcod { get; set; }
        public string loccod { get; set; }
        public string docnum { get; set; }
        public string seqnum { get; set; }
        public DateTime? docdat { get; set; }
        public string rdocnum { get; set; }
        public string refnum { get; set; }
        public string depcod { get; set; }
        public string posopr { get; set; }
        public string free { get; set; }
        public string vatcod { get; set; }
        public string people { get; set; }
        public string slmcod { get; set; }
        public string flag { get; set; }
        public double trnqty { get; set; }
        public string tqucod { get; set; }
        public double tfactor { get; set; }
        public double unitpr { get; set; }
        public string disc { get; set; }
        public double discamt { get; set; }
        public double trnval { get; set; }
        public double phybal { get; set; }
        public string retstk { get; set; }
        public double xtrnqty { get; set; }
        public double xunitpr { get; set; }
        public double xtrnval { get; set; }
        public double xsalval { get; set; }
        public double netval { get; set; }
        public string mlotnum { get; set; }
        public double mrembal { get; set; }
        public double mremval { get; set; }
        public double balchg { get; set; }
        public double valchg { get; set; }
        public double lotbal { get; set; }
        public double lotval { get; set; }
        public double lunitpr { get; set; }
        public string pstkcod { get; set; }
        public string accnumdr { get; set; }
        public string accnumcr { get; set; }
        public string stkdes { get; set; }
        public string packing { get; set; }
        public string jobcod { get; set; }
        public string phase { get; set; }
        public string coscod { get; set; }
        public string reimburse { get; set; }
    }

    public class ApmasDbf
    {
        public string supcod { get; set; }
        public string suptyp { get; set; }
        public string onhold { get; set; }
        public string prenam { get; set; }
        public string supnam { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
        public string zipcod { get; set; }
        public string telnum { get; set; }
        public string contact { get; set; }
        public string supnam2 { get; set; }
        public decimal paytrm { get; set; }
        public string paycond { get; set; }
        public string dlvby { get; set; }
        public decimal vatrat { get; set; }
        public string flgvat { get; set; }
        public string disc { get; set; }
        public double balance { get; set; }
        public double chqpay { get; set; }
        public double crline { get; set; }
        public DateTime? lasrcv { get; set; }
        public string accnum { get; set; }
        public string remark { get; set; }
        public string taxid { get; set; }
        public decimal orgnum { get; set; }
        public string taxdes { get; set; }
        public decimal taxrat { get; set; }
        public string taxtyp { get; set; }
        public string taxcond { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }
    }

    public class AptrnDbf
    {
        public string rectyp { get; set; }
        public string docnum { get; set; }
        public DateTime? docdat { get; set; }
        public string refnum { get; set; }
        public DateTime? vatprd { get; set; }
        public string vatlate { get; set; }
        public string vattyp { get; set; }
        public string postgl { get; set; }
        public string ponum { get; set; }
        public string dntyp { get; set; }
        public string depcod { get; set; }
        public string flgvat { get; set; }
        public string supcod { get; set; }
        public string shipto { get; set; }
        public string youref { get; set; }
        public decimal paytrm { get; set; }
        public DateTime? duedat { get; set; }
        public string bilnum { get; set; }
        public string dlvby { get; set; }
        public string nxtseq { get; set; }
        public double amount { get; set; }
        public string disc { get; set; }
        public double discamt { get; set; }
        public double aftdisc { get; set; }
        public string advnum { get; set; }
        public double advamt { get; set; }
        public double total { get; set; }
        public double amtrat0 { get; set; }
        public decimal vatrat { get; set; }
        public double vatamt { get; set; }
        public double netamt { get; set; }
        public double netval { get; set; }
        public double payamt { get; set; }
        public double remamt { get; set; }
        public string cmplapp { get; set; }
        public DateTime? cmpldat { get; set; }
        public string docstat { get; set; }
        public double cshpay { get; set; }
        public double chqpay { get; set; }
        public double intpay { get; set; }
        public double tax { get; set; }
        public double rcvamt { get; set; }
        public double chqpas { get; set; }
        public DateTime? vatdat { get; set; }
        public string srv_vattyp { get; set; }
        public string pvatprorat { get; set; }
        public decimal pvat_rf { get; set; }
        public decimal pvat_nrf { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string userprn { get; set; }
        public DateTime? prndat { get; set; }
        public decimal prncnt { get; set; }
        public string prntim { get; set; }
        public string authid { get; set; }
        public DateTime? approve { get; set; }
        public string billbe { get; set; }
        public decimal orgnum { get; set; }
        public string c_type { get; set; }
        public DateTime? c_date { get; set; }
        public string c_ref { get; set; }
        public double c_rate { get; set; }
        public string c_fixrate { get; set; }
        public double c_ratio { get; set; }
        public double c_amount { get; set; }
        public string c_disc { get; set; }
        public double c_discamt { get; set; }
        public double c_aftdisc { get; set; }
        public double c_advamt { get; set; }
        public double c_total { get; set; }
        public double c_netamt { get; set; }
        public double c_netval { get; set; }
        public double c_rcvamt { get; set; }
        public double c_difamt { get; set; }
        public double c_payamt { get; set; }
        public double c_remamt { get; set; }
        public string link1 { get; set; }
        public DateTime? dat1 { get; set; }
        public DateTime? dat2 { get; set; }
        public double num1 { get; set; }
        public double num2 { get; set; }
        public string str1 { get; set; }
        public string str2 { get; set; }
    }

    public class ArtrnDbf
    {
        public string rectyp { get; set; }
        public string docnum { get; set; }
        public DateTime? docdat { get; set; }
        public string postgl { get; set; }
        public string sonum { get; set; }
        public string cntyp { get; set; }
        public string depcod { get; set; }
        public string flgvat { get; set; }
        public string slmcod { get; set; }
        public string cuscod { get; set; }
        public string shipto { get; set; }
        public string youref { get; set; }
        public string areacod { get; set; }
        public decimal paytrm { get; set; }
        public DateTime? duedat { get; set; }
        public string bilnum { get; set; }
        public string nxtseq { get; set; }
        public double amount { get; set; }
        public string disc { get; set; }
        public double discamt { get; set; }
        public double aftdisc { get; set; }
        public string advnum { get; set; }
        public double advamt { get; set; }
        public double total { get; set; }
        public double amtrat0 { get; set; }
        public decimal vatrat { get; set; }
        public double vatamt { get; set; }
        public double netamt { get; set; }
        public double netval { get; set; }
        public double rcvamt { get; set; }
        public double remamt { get; set; }
        public double comamt { get; set; }
        public string cmplapp { get; set; }
        public DateTime? cmpldat { get; set; }
        public string docstat { get; set; }
        public double cshrcv { get; set; }
        public double chqrcv { get; set; }
        public double intrcv { get; set; }
        public double beftax { get; set; }
        public decimal taxrat { get; set; }
        public string taxcond { get; set; }
        public double tax { get; set; }
        public double ivcamt { get; set; }
        public double chqpas { get; set; }
        public DateTime? vatdat { get; set; }
        public DateTime? vatprd { get; set; }
        public string vatlate { get; set; }
        public string srv_vattyp { get; set; }
        public string dlvby { get; set; }
        public DateTime? reserve { get; set; }

        /* V.2 + creby,credat */
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        /**********************/

        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string userprn { get; set; }
        public DateTime? prndat { get; set; }
        public decimal prncnt { get; set; }
        
        /* only in v.1 */
        public string prntim { get; set; }
        /***************/

        public string authid { get; set; }
        public DateTime? approve { get; set; }
        public string billto { get; set; }
        public decimal orgnum { get; set; }

        /* V.2 + ponum */
        public string ponum { get; set; }
        /***************/

        /* V.2 */
        public string c_type { get; set; }
        public DateTime? c_date { get; set; }
        public string c_ref { get; set; }
        public double c_rate { get; set; }
        public string c_fixrate { get; set; }
        public double c_ratio { get; set; }
        public double c_amount { get; set; }
        public string c_disc { get; set; }
        public double c_discamt { get; set; }
        public double c_aftdisc { get; set; }
        public double c_advamt { get; set; }
        public double c_total { get; set; }
        public double c_netamt { get; set; }
        public double c_netval { get; set; }
        public double c_ivcamt { get; set; }
        public double c_difamt { get; set; }
        public double c_rcvamt { get; set; }
        public double c_remamt { get; set; }
        public string link1 { get; set; }
        public DateTime? dat1 { get; set; }
        public DateTime? dat2 { get; set; }
        public double num1 { get; set; }
        public double num2 { get; set; }
        public string str1 { get; set; }
        public string str2 { get; set; }
    }

    public class ScuserDbf
    {
        public string rectyp { get; set; }
        public string reccod { get; set; }
        public string connectgrp { get; set; }
        public string recdes { get; set; }
        public DateTime? revokedat { get; set; }
        public DateTime? resumedat { get; set; }
        public string language { get; set; }
        public decimal userattr { get; set; }
        public DateTime? laswrk { get; set; }
        public DateTime? laspwd { get; set; }
        public DateTime? lasusedat { get; set; }
        public string lasusetim { get; set; }
        public string secure { get; set; }
        public decimal authlev { get; set; }
        public string userpwd { get; set; }
        public string status { get; set; }
        public string prnnum { get; set; }
        public string rwttxt { get; set; }

    }

    public class ScacclvDbf
    {
        public string compcod { get; set; }
        public string filename { get; set; }
        public string accessid { get; set; }
        public string submodule { get; set; }
        public string isread { get; set; }
        public string isadd { get; set; }
        public string isedit { get; set; }
        public string isdelete { get; set; }
        public string isprint { get; set; }
        public string iscancel { get; set; }
        public string isapprove { get; set; }

    }

    public class SccompDbf
    {
        public DbConnectionConfig db_conn_config;
        public string compnam { get; set; }
        public string compcod { get; set; }
        public string path { get; set; }
        public DateTime? gendat { get; set; }
        public string candel { get; set; }

        public string abs_path
        {
            get
            {
                string path_txt = string.Empty;

                string p = this.path;
                if (this.path.Contains("("))
                    p = this.path.Substring(0, this.path.IndexOf("("));

                if(p.Contains(@":\") || p.StartsWith(@"\\"))
                {
                    path_txt = p.Trim();
                }
                else
                {
                    DirectoryInfo dir_info = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                    string absolute_path = dir_info.Parent.FullName + @"\" + p.Trim();
                    path_txt = absolute_path;
                }

                return path_txt.TrimEnd('\\') + @"\";
            }
        }
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

    public class IstabDbf
    {
        public string tabtyp { get; set; }
        public string typcod { get; set; }
        public string shortnam { get; set; }
        public string shortnam2 { get; set; }
        public string typdes { get; set; }
        public string typdes2 { get; set; }
        public string fld01 { get; set; }
        public double? fld02 { get; set; }
        public string depcod { get; set; }
        public string status { get; set; }

    }

    public class IstabDbfList
    {
        public string typcod { get; set; }
        public string shortnam { get; set; }
        public string typdes { get; set; }
    }

    public class IsinfoDbf
    {
        public string thinam { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string telnum { get; set; }
        public string engnam { get; set; }
        public string addr01eng { get; set; }
        public string addr02eng { get; set; }
        public string trdreg { get; set; }
        public string taxid { get; set; }
        public string linkgl { get; set; }
        public double vatrat { get; set; }
        public string flgvat { get; set; }
        public string seditqu { get; set; }
        public string chgsalpr { get; set; }
        public string losesal { get; set; }
        public string st_lt_reop { get; set; }
        public string insertit { get; set; }
        public string cost_enc { get; set; }
        public string pvatprorat { get; set; }
        public double pvat_rf { get; set; }
        public double pvat_nrf { get; set; }
        public string arprefer { get; set; }
        public string apprefer { get; set; }
        public string stprefer { get; set; }
        public string glprefer { get; set; }
        public string cshpurjnl { get; set; }
        public string crepurjnl { get; set; }
        public string purretjnl { get; set; }
        public string othexpjnl { get; set; }
        public string aprcpjnl { get; set; }
        public string paspcqjnl { get; set; }
        public string cshsaljnl { get; set; }
        public string cresaljnl { get; set; }
        public string salretjnl { get; set; }
        public string othincjnl { get; set; }
        public string arrcpjnl { get; set; }
        public string pasrcqjnl { get; set; }
        public string intissjnl { get; set; }
        public string takadjjnl { get; set; }
        public string cosadjjnl { get; set; }
        public string baddbtjnl { get; set; }
        public string bnkmovjnl { get; set; }
        public string incchqjnl { get; set; }
        public string expchqjnl { get; set; }
        public string aradvjnl { get; set; }
        public string apadvjnl { get; set; }
        public string fadprjnl { get; set; }
        public string ardnjnl { get; set; }
        public string apcnjnl { get; set; }
        public string cosmtd { get; set; }
        public string bnkdep { get; set; }
        public string bnkpaid { get; set; }
        public string paspcqauto { get; set; }
        public string accnum00 { get; set; }
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
        public string accnum13 { get; set; }
        public string accnum14 { get; set; }
        public string accnum15 { get; set; }
        public string accnum16 { get; set; }
        public string accnum17 { get; set; }
        public string accnum18 { get; set; }
        public string accnum19 { get; set; }
        public string accnum20 { get; set; }
        public string accnum21 { get; set; }
        public string accnum22 { get; set; }
        public string accnum23 { get; set; }
        public string accnum24 { get; set; }
        public string accnum25 { get; set; }
        public string accnum26 { get; set; }
        public string accnum27 { get; set; }
        public string accnum28 { get; set; }
        public string accnum29 { get; set; }
        public string accnum30 { get; set; }
        public string accnum31 { get; set; }
        public string accnum32 { get; set; }
        public string accnum33 { get; set; }
        public string accnum34 { get; set; }
        public string accnum35 { get; set; }
        public string accnum36 { get; set; }
        public string accnum37 { get; set; }
        public string accnum38 { get; set; }
        public string accnum39 { get; set; }
        public string accnum40 { get; set; }
        public string accnum41 { get; set; }
        public string accnum42 { get; set; }
        public string accnum43 { get; set; }
        public string accnum44 { get; set; }
        public string accnum45 { get; set; }
        public string pt_str1 { get; set; }
        public string pt_str1eng { get; set; }
        public string petty1 { get; set; }
        public string pt_str2 { get; set; }
        public string pt_str2eng { get; set; }
        public string petty2 { get; set; }
        public string pt_str3 { get; set; }
        public string pt_str3eng { get; set; }
        public string petty3 { get; set; }
        public string pt_str4 { get; set; }
        public string pt_str4eng { get; set; }
        public string petty4 { get; set; }
        public string pt_str5 { get; set; }
        public string pt_str5end { get; set; }
        public string petty5 { get; set; }
        public string glpict { get; set; }
        public string stpict { get; set; }
        public string fapict { get; set; }
        public string mainloc { get; set; }
        public string negallow { get; set; }
        public string isperpetua { get; set; }
        public string yearthai { get; set; }
        public string peditqu { get; set; }
        public string peditfac { get; set; }
        public string teditqu { get; set; }
        public string teditfac { get; set; }
        public string e_lpursal { get; set; }
        public int ardue1 { get; set; }
        public int ardue2 { get; set; }
        public int arovr1 { get; set; }
        public int arovr2 { get; set; }
        public int arovr3 { get; set; }
        public int apdue1 { get; set; }
        public int apdue2 { get; set; }
        public int apovr1 { get; set; }
        public int apovr2 { get; set; }
        public int apovr3 { get; set; }
        public int qrdue1 { get; set; }
        public int qrdue2 { get; set; }
        public int qrovr1 { get; set; }
        public int qrovr2 { get; set; }
        public int qrovr3 { get; set; }
        public int qpdue1 { get; set; }
        public int qpdue2 { get; set; }
        public int qpovr1 { get; set; }
        public int qpovr2 { get; set; }
        public int qpovr3 { get; set; }
        public int stage1 { get; set; }
        public int stage2 { get; set; }
        public int stage3 { get; set; }
        public string glrunning { get; set; }
        public string usedep { get; set; }
        public string cndeduct { get; set; }
        public string dndeduct { get; set; }
        public int savscrtime { get; set; }
        public string ed_sstkdes { get; set; }
        public string ed_pstkdes { get; set; }
        public string fadprauto { get; set; }
        public string fadprmonly { get; set; }
        public string dprmethod { get; set; }
        public string online { get; set; }
        public string reserve1 { get; set; }
        public string reserve2 { get; set; }
        public int reserve3 { get; set; }
        public string reserve4 { get; set; }
        public string usepacking { get; set; }
        public string reprnauth { get; set; }
        public string abnormexit { get; set; }
        public string ovrcrauth { get; set; }
        public string chkneglev { get; set; }
        public string negauth { get; set; }
        public string whoami { get; set; }
        public double mintaxamt { get; set; }
        public double mintaxrat { get; set; }
        public string socialid { get; set; }
        public string povdntid { get; set; }
        public int dsimlpri { get; set; }
        public int dsimlqty { get; set; }
        public int dsimlfac { get; set; }
        public string anyloc { get; set; }
        public string loc_cost { get; set; }
        public string loc_dep { get; set; }
        public string use_cqu { get; set; }
        public string st_dat1 { get; set; }
        public string st_dat1eng { get; set; }
        public string st_dat1use { get; set; }
        public string st_dat2 { get; set; }
        public string st_dat2eng { get; set; }
        public string st_dat2use { get; set; }
        public string st_num1 { get; set; }
        public string st_num1eng { get; set; }
        public string st_num1use { get; set; }
        public string st_str1 { get; set; }
        public string st_str1eng { get; set; }
        public string st_str1use { get; set; }
        public string st_str2 { get; set; }
        public string st_str2eng { get; set; }
        public string st_str2use { get; set; }
        public string st_str3 { get; set; }
        public string st_str3eng { get; set; }
        public string st_str3use { get; set; }
        public string st_str4 { get; set; }
        public string st_str4eng { get; set; }
        public string st_str4use { get; set; }
        public string usebarcod { get; set; }
        public string so_cr_lock { get; set; }
        public string so_logloc { get; set; }
        public double crline_a { get; set; }
        public double crline_b { get; set; }
        public double crline_c { get; set; }
        public double crline_d { get; set; }
        public double crline_e { get; set; }
        public string crline_a_l { get; set; }
        public string crline_b_l { get; set; }
        public string crline_c_l { get; set; }
        public string crline_d_l { get; set; }
        public string crline_e_l { get; set; }
        public string ovrcrallow { get; set; }
        public string usejob { get; set; }
        public string jb_str1 { get; set; }
        public string jb_str1eng { get; set; }
        public string jb_str1use { get; set; }
        public string jb_str2 { get; set; }
        public string jb_str2eng { get; set; }
        public string jb_str2use { get; set; }
        public string jb_str3 { get; set; }
        public string jb_str3eng { get; set; }
        public string jb_str3use { get; set; }
        public string jb_str4 { get; set; }
        public string jb_str4eng { get; set; }
        public string jb_str4use { get; set; }
        public string jb_str5 { get; set; }
        public string jb_str5eng { get; set; }
        public string jb_str5use { get; set; }
        public int postacc { get; set; }
        public string sharefile { get; set; }
        public string srv_vattyp { get; set; }
        public string reprn_lev { get; set; }
        public string cancel_lev { get; set; }
        public string delete_lev { get; set; }
        public string approv_met { get; set; }
        public string approv_lev { get; set; }
        public string ovrlin_lev { get; set; }
        public string vat_initem { get; set; }
        public string jbpict { get; set; }
        public string vatreplev { get; set; }
        public DateTime vatrepbeg { get; set; }
        public int orgnum { get; set; }
        public string orgstr { get; set; }
    }

    public class ArmasDbf : ICloneable
    {
        public string cuscod { get; set; }
        public string custyp { get; set; }
        public string prenam { get; set; }
        public string cusnam { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
        public string zipcod { get; set; }
        public string telnum { get; set; }
        public string contact { get; set; }
        public string cusnam2 { get; set; }
        public string taxid { get; set; }
        public int orgnum { get; set; }
        public string taxtyp { get; set; }
        public decimal taxrat { get; set; }
        public string taxgrp { get; set; }
        public string taxcond { get; set; }
        public string shipto { get; set; }
        public string slmcod { get; set; }
        public string areacod { get; set; }
        public int paytrm { get; set; }
        public string paycond { get; set; }
        public string payer { get; set; }
        public string tabpr { get; set; }
        public string disc { get; set; }
        public double balance { get; set; }
        public double chqrcv { get; set; }
        public double crline { get; set; }
        public DateTime? lasivc { get; set; }
        public string accnum { get; set; }
        public string remark { get; set; }
        public string dlvby { get; set; }
        public string tracksal { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }

        /* Some field in join table */
        public string _accnam { get; set; }
        public string _custypdesc { get; set; }
        public string _slmnam { get; set; }
        public string _areadesc { get; set; }
        public string _dlvbydesc { get; set; }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class ArmasDbfList
    {
        public string cuscod { get; set; }
        public string cusnam { get; set; }
        public string prenam { get; set; }
        public string contact { get; set; }
        public int paytrm { get; set; }
        public string paycond { get; set; }
        public string tabpr { get; set; }
        public string disc { get; set; }
        public double crline { get; set; }
        public string slmcod { get; set; }
        public string areacod { get; set; }
        public string dlvby { get; set; }
        public string accnum { get; set; }
    }

    public class OeslmDbf
    {
        public string slmcod { get; set; }
        public string slmnam { get; set; }
        public string slmtyp { get; set; }
        public decimal comrate { get; set; }
        public string areacod { get; set; }
        public string taxid { get; set; }
        public string positn { get; set; }
        public string socialid { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
        public string zipcod { get; set; }
        public string telnum { get; set; }
        public double tar1 { get; set; }
        public double tar2 { get; set; }
        public double tar3 { get; set; }
        public double tar4 { get; set; }
        public double tar5 { get; set; }
        public double tar6 { get; set; }
        public double tar7 { get; set; }
        public double tar8 { get; set; }
        public double tar9 { get; set; }
        public double tar10 { get; set; }
        public double tar11 { get; set; }
        public double tar12 { get; set; }
        public double tar1ny { get; set; }
        public double tar2ny { get; set; }
        public double tar3ny { get; set; }
        public double tar4ny { get; set; }
        public double tar5ny { get; set; }
        public double tar6ny { get; set; }
        public double tar7ny { get; set; }
        public double tar8ny { get; set; }
        public double tar9ny { get; set; }
        public double tar10ny { get; set; }
        public double tar11ny { get; set; }
        public double tar12ny { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public DateTime? create { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }
    }

    public class OeslmDbfList
    {
        public string slmcod { get; set; }
        public string slmnam { get; set; }
    }

    public class GlaccDbf
    {
        public string accnum { get; set; }
        public string accnam { get; set; }
        public string accnam2 { get; set; }
        public int level { get; set; }
        public string parent { get; set; }
        public string group { get; set; }
        public string acctyp { get; set; }
        public string usedep { get; set; }
        public string usejob { get; set; }
        public string nature { get; set; }
        public string consol { get; set; }
        public string status { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
    }

    public class GlaccDbfList
    {
        public string accnum { get; set; }
        public string accnam { get; set; }
        public string group { get; set; }
        public int level { get; set; }
        public string acctyp { get; set; }
        public string parent { get; set; }
    }

    public class StkgrpBillMethodList
    {
        public string typcod { get; set; }
        public string shortnam { get; set; }
        public string typdes { get; set; }
        public string stktyp { get; set; }
        public string bill_method { get; set; }
    }
}