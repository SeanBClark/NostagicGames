using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebApplication1.DAL
{
    public class setUserMethods
    {
        //insert new user into DB
        public static void insertUser (string email, string password)
        {
            DataAccess dataCon = new DataAccess();
            var connection = dataCon.GetConnectionString();
            connection.Open();
            string query = "INSERT INTO Customer (Email, Password) VALUES(@Email, @Password)";
            SqlCommand insertCommand = new SqlCommand(query, connection);
            insertCommand.Parameters.AddWithValue("@Email", email);
            insertCommand.Parameters.AddWithValue("@Password", password);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        //insert new admin users
        //requires additinal admin code to grant admin access
        public static void insertAdmin(string adminNo, string password, string email)
        {
            DataAccess dataCon = new DataAccess();
            var connection = dataCon.GetConnectionString();
            connection.Open();
            string query = "INSERT INTO Admin (AdminNo, Password, Email) VALUES(@AdminNo, @Password, @Email)";
            SqlCommand insertCommand = new SqlCommand(query, connection);
            insertCommand.Parameters.AddWithValue("@AdminNo", adminNo);
            insertCommand.Parameters.AddWithValue("@Password", password);
            insertCommand.Parameters.AddWithValue("@Email", email);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        //Update users current status. eg. Banned/Unbanned
        public static void updateUserStatus(int index, GridView gv, string status)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string query = "UPDATE Customer SET Status = @Status WHERE UserID = @UserID";
            SqlCommand updateCommand = new SqlCommand(query, connection);
            updateCommand.Parameters.AddWithValue("@Status", status);
            updateCommand.Parameters.AddWithValue("@UserID", Convert.ToInt32(gv.DataKeys[index].Value.ToString()));
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}