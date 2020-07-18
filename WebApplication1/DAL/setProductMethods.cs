using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1;

namespace WebApplication1.DAL
{

    //class to store products vars
    public class Product
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

    //Add new products to DB
    public class setProductMethods
    {
        public static List<DAL.Product> GetAllProducts()
        {
            DataTable dataTable = new DataTable();
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            SqlCommand DataRead = new SqlCommand("SELECT * FROM Products", connection);
            SqlDataReader read = DataRead.ExecuteReader();
            List<Product> products = new List<Product>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    products.Add(new Product() {
                        ProductID = (int)read["ProductID"],
                        CategoryID = (int)read["CategoryID"],
                        Name = read["Name"].ToString(),
                        Type = read["Type"].ToString(),
                        Platform = read["Platform"].ToString(),
                        AmountAvailable = (int)read["AmountAvailable"],
                        Price = (decimal)read["Price"],
                        Description = read["Description"].ToString(),
                        ImageFile = read["ImageFile"].ToString()
                    });
                }
            }
            return products;
        }

        public static void addProductsDB(string name, 
                                         int category, 
                                         string type, 
                                         string platform, 
                                         int amountAvailable, 
                                         int price, 
                                         string description, 
                                         string imageFile)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string query = "INSERT INTO Products (Name, CategoryID, Type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES (@Name, @Category, @Type, @Platform, @AmountAvailable, @Price, @Description, @ImageFile)";
            SqlCommand InsertNewCommand = new SqlCommand(query, connection);
            InsertNewCommand.Parameters.AddWithValue("@Name", name);
            InsertNewCommand.Parameters.AddWithValue("@Category", category);
            InsertNewCommand.Parameters.AddWithValue("@Type", type);
            InsertNewCommand.Parameters.AddWithValue("@Platform", platform);
            InsertNewCommand.Parameters.AddWithValue("@AmountAvailable", amountAvailable);
            InsertNewCommand.Parameters.AddWithValue("@Price", price);
            InsertNewCommand.Parameters.AddWithValue("@Description", description);
            InsertNewCommand.Parameters.AddWithValue("@ImageFile", imageFile);
            InsertNewCommand.ExecuteNonQuery();
            connection.Close();
        }

        //delete product from the DBw
        public static void DeleteProducts(int index, int prodID)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string query = "DELETE FROM Products WHERE ProductID = @id";
            SqlCommand InsertNewCommand = new SqlCommand(query, connection);
            InsertNewCommand.Parameters.AddWithValue("@id", prodID);
            InsertNewCommand.ExecuteNonQuery();
            connection.Close();
        }

        //update products in DB
        //
        //Issues: Currently requires image to be reuploaded each time. As this is outside the scope of the project we have left it as is. 
        //
        public static void UpdateProducts(int index, 
                                          GridView gv, 
                                          string name, 
                                          int category, 
                                          string type, 
                                          string platform, 
                                          int amountAvailable, 
                                          int price, 
                                          string description, 
                                          string imageFile)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string query = "UPDATE Products SET Name=@Name, CategoryID=@Category, Type=@Type, Platform=@Platform, AmountAvailable=@AmountAvailable, Price=@Price, Description=@Description, ImageFile=@ImageFile WHERE ProductID = @id";
            SqlCommand InsertNewCommand = new SqlCommand(query, connection);
            InsertNewCommand.Parameters.AddWithValue("@Name", name);
            InsertNewCommand.Parameters.AddWithValue("@Category", category);
            InsertNewCommand.Parameters.AddWithValue("@Type", type);
            InsertNewCommand.Parameters.AddWithValue("@Platform", platform);
            InsertNewCommand.Parameters.AddWithValue("@AmountAvailable", Convert.ToInt32(amountAvailable));
            InsertNewCommand.Parameters.AddWithValue("@Price", price);
            InsertNewCommand.Parameters.AddWithValue("@Description", description);
            InsertNewCommand.Parameters.AddWithValue("@ImageFile", imageFile);
            InsertNewCommand.Parameters.AddWithValue("@id", Convert.ToInt32(gv.DataKeys[index].Value.ToString()));
            InsertNewCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}