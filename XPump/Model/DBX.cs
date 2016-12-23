using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using XPump.Model;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace XPump.Model
{
    public class DBX
    {
        public const string member_server = "localhost";
        public const string member_db_name = "xmember";
        public const string member_db_uid = "root";
        public const string member_db_pwd = "12345";
        public const int member_db_port = 3306;

        private string server_name;
        public string ServerName { get { return this.server_name; } }
        private string db_name;
        public string DbName { get { return this.db_name; } }
        private string db_userid;
        public string DbUserId { get { return this.db_userid; } }
        private string db_password;
        public string DbPassword { get { return this.db_password; } }
        public int port_no;
        public int PortNo { get { return this.port_no; } }

        public DBX(string server_name, string db_userid, string db_password, string db_name, int port_no = 3306)
        {
            //string cloud_server = "localhost";
            //string cloud_db_name = "sn";
            //string cloud_db_uid = "root";
            //string cloud_db_pwd = "12345";

            ///** Not use this because not supported for charset keyword **/
            //string originalConnectionString = ConfigurationManager.ConnectionStrings["xpumpEntities"].ConnectionString;
            //EntityConnectionStringBuilder ecsBuilder = new EntityConnectionStringBuilder(originalConnectionString);
            //SqlConnectionStringBuilder scsBuilder = new SqlConnectionStringBuilder(ecsBuilder.ProviderConnectionString)
            //{
            //    DataSource = cloud_server,
            //    UserID = cloud_db_uid,
            //    Password = cloud_db_pwd,
            //    InitialCatalog = cloud_db_name,

            //};
            //string providerConnectionString = scsBuilder.ToString();
            //ecsBuilder.ProviderConnectionString = providerConnectionString;

            //string contextConnectionString = ecsBuilder.ToString();

            //return new xpumpEntities(contextConnectionString);

            this.server_name = server_name;
            this.db_name = db_name;
            this.db_userid = db_userid;
            this.db_password = db_password;
            this.port_no = port_no;
        }

        public xpumpEntities GetDBEntities()
        {
            return new xpumpEntities("metadata=res://*/Model.XPumpModel.csdl|res://*/Model.XPumpModel.ssdl|res://*/Model.XPumpModel.msl;provider=MySql.Data.MySqlClient;provider connection string=\"Data Source=" + this.server_name + ";Initial Catalog=" + this.db_name + ";Persist Security Info=True;User ID=" + this.db_userid + ";Password=" + this.db_password + ";charset=utf8\"");
        }

        public static xpumpEntities DataSet()
        {
            DBX db_context = new DBX("localhost", "root", "12345", "xpump");
            return db_context.GetDBEntities();
        }
    }
}
