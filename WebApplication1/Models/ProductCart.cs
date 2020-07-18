using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductCart
    {
        public ProductCart(int initID, int initQuantity)
        {
            ID = initID;
            Quantity = initQuantity;
        }
        public int ID { get; set; }
        public int Quantity { get; set; }

    }
}