using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication1.BL
{
    public class ProductsBL
    {
        public void getProductID(int id)
        {
            DAL.getProductMethods.getProductProperties(id);
        }

        public DAL.ProductReturn getSingleProduct(int id)
        {
            return DAL.getProductMethods.getProductReturn(id);
        }
    }
}