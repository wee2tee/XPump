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

        public static xpumpEntities DataSet(string server_name, string user_name, string password, string database_name, int port = 3306)
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


            return new xpumpEntities("metadata=res://*/Model.XPumpModels.csdl|res://*/Model.XPumpModels.ssdl|res://*/Model.XPumpModels.msl;provider=MySql.Data.MySqlClient;provider connection string=\"Data Source=" + server_name + ";Initial Catalog=" + database_name + ";Persist Security Info=True;User ID=" + user_name + ";Password=" + password + ";charset=utf8\"");
        }
    }
}
