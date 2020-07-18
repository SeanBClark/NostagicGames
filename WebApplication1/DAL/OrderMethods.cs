using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class OrderMethods
    {
        public static void insertOrder(int UserID, int total)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string query = "INSERT INTO Orders(UserID, Total) VALUES(@ID, @Total)";
            SqlCommand orderCommand = new SqlCommand(query, connection);
            orderCommand.Parameters.AddWithValue("@ID", UserID);
            orderCommand.Parameters.AddWithValue("@Total", total);
            orderCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void insertOrderDetails(int productID, int quantity, int orderTotal)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string query = "INSERT INTO OrderDetails(ProductID, Quantity, OrderTotal) VALUES(@ID, @Quantity, @OrderTotal)";
            SqlCommand orderCommand = new SqlCommand(query, connection);
            orderCommand.Parameters.AddWithValue("@ID", productID);
            orderCommand.Parameters.AddWithValue("@Quantity", quantity);
            orderCommand.Parameters.AddWithValue("@OrderTotal", orderTotal);
            orderCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void getOrderHistory(int userID)
        {
            DataAccess dataConString = new DataAccess();
            var connection = dataConString.GetConnectionString();
            connection.Open();
            string query = "SELECT OrderID, ProductID, Quantity, OrderTotal FROM OrderDetails WHERE ProductID = '" + userID + "'";
            SqlCommand getHistory = new SqlCommand(query, connection);
            getHistory.ExecuteNonQuery();
            connection.Close();
        }
    }
}