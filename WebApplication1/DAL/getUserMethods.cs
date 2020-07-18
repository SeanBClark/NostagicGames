using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1;

namespace WebApplication1.DAL
{
    //Class to store all user data into vars
    public class Users
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetNo { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string DateJoined { get; set; }
    }

    //Get all customers from database
    public class getUserMethods
    {
        public static List<Users> getUsers()
        {
            DataTable dataTable = new DataTable();
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", connection);
            SqlDataReader read = cmd.ExecuteReader();

            List<Users> users = new List<Users>();

            while (read.Read())
            {
                users.Add(new Users() {UserID = (int)read["UserID"], FirstName= read["FirstName"].ToString(), LastName= read["LastName"].ToString(),
                        StreetNo = read["StreetNo"].ToString(), Street = read["Street"].ToString(), Suburb = read["Suburb"].ToString(),
                        Postcode = read["Postcode"].ToString(), State = read["State"].ToString(), Status = read["Status"].ToString(),
                        Country= read["Country"].ToString(), Email= read["Email"].ToString(), Phone= read["Phone"].ToString(),
                        Password = read["Password"].ToString(), DateJoined = read["DateJoined"].ToString() });
            }

            return users;
        }

        //Check if user has account, if they do log in, if not display error
        public static bool userLogin(string email, string password)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string checkUser = "SELECT count(*) FROM Customer WHERE Email='" + email + "'";
            SqlCommand command = new SqlCommand(checkUser, connection);
            int emailExist = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            if(emailExist == 1)
            {
                connection.Open();
                string checkPassword = "SELECT Password FROM Customer WHERE Email='" + email + "'";
                SqlCommand passwordCmd = new SqlCommand(checkPassword, connection);
                string pass = passwordCmd.ExecuteScalar().ToString().Replace(" ", "");
                if(pass == password)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        //administator login, works same way as user login however, takes the extra step of getting admin code
        public static bool adminLogin(string adminNo, string password)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string checkAdmin = "SELECT count(*) FROM Admin WHERE AdminNo ='" + adminNo + "'";
            SqlCommand command = new SqlCommand(checkAdmin, connection);
            int adminNoExists = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            if(adminNoExists == 1)
            {
                connection.Open();
                string checkPassword = "SELECT Password FROM Admin WHERE AdminNo ='" + adminNo + "'";
                SqlCommand passwordCmd = new SqlCommand(checkPassword, connection);
                string pass = passwordCmd.ExecuteScalar().ToString().Replace(" ", "");
                if(pass == password)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
            else
            {
                connection.Close();
                return false;
            }
        }
    }
}