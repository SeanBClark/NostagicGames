using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.BL
{
    public class OrderBL
    {
        public void insertOrderDetails(int productID, int quantity, int orderTotal)
        {
            DAL.OrderMethods.insertOrderDetails(productID, quantity, orderTotal);
        }

        public void insertOrder(int UserID, int total)
        {
            DAL.OrderMethods.insertOrder(UserID, total);
        }

        public void getOrderHistory(int id)
        {
            DAL.OrderMethods.getOrderHistory(id);
        }
    }
}