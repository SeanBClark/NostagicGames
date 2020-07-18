using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.UI.WebControls;
using System.Configuration;
//DataAccess dataConString = new DataAccess();
//var connectionVariable = dataConString.GetConnectionString();
namespace WebApplication1
{
    public class DataAccess
    {
        //Connection string to connect to database
        public SqlConnection GetConnectionString()
        {
            string conString = ConfigurationManager.ConnectionStrings["NostalgicGamesDBConnectionStringLachy"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            return connection;
        }
    }
}
