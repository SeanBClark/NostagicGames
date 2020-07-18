using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1.DAL
{
    //Gather all Category Names and ID
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoriesDB
    {
        // 
        // get all categories from the database
        public static List<Category> GetCategories()
        {
            DataTable dataTable = new DataTable();
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT CategoryName,CategoryID FROM Category", connection);
            SqlDataReader read = cmd.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (read.Read())
            {
                categories.Add(new Category() { Name = read["CategoryName"].ToString(), Id = (int)read["CategoryID"] });
            }

            return categories;
        }
    }
}