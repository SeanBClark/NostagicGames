using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1;

namespace WebApplication1.DAL
{
    public class ProductReturn
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Platform { get; set; }
        public int AmountAvailable { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }

    public class getProductMethods
    {
        //get a product from the DB
        public static void getProductProperties(int id)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string query = "SELECT Name, type, platform, price, Description, ImageFile FROM Products WHERE ProductID = @ID";
            SqlCommand getProduct = new SqlCommand(query, connection);
            getProduct.Parameters.AddWithValue("@ID", id);
            getProduct.ExecuteNonQuery();
            connection.Close();
        }

        public static DAL.ProductReturn getProductReturn(int id)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string query = "SELECT * FROM Products WHERE ProductID = '"+id+"'";
            SqlCommand DataRead = new SqlCommand(query, connection);
            SqlDataReader read = DataRead.ExecuteReader();
            ProductReturn ProductToReturn = new ProductReturn();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    ProductToReturn.ProductID = (int)read["ProductID"];
                    ProductToReturn.CategoryID = (int)read["CategoryID"];
                    ProductToReturn.Name = read["Name"].ToString();
                    ProductToReturn.Type = read["Type"].ToString();
                    ProductToReturn.Platform = read["Platform"].ToString();
                    ProductToReturn.AmountAvailable = (int)read["AmountAvailable"];
                    ProductToReturn.Price = (decimal)read["Price"];
                    ProductToReturn.Description = read["Description"].ToString();
                    ProductToReturn.ImageFile = read["ImageFile"].ToString();
                }
            }
            return ProductToReturn;
        }
    }
}