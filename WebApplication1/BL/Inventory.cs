using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication1.BL
{
    public class Inventory
    {
        public List<DAL.Category> GetCategories()
        {
            return DAL.CategoriesDB.GetCategories();
        }

        public List<DAL.Product> GetAllProducts()
        {
            return DAL.setProductMethods.GetAllProducts();
        }

        //Sends new product info to DAL
        public void BLAddProducts(string name, 
                                  int category, 
                                  string type, 
                                  string platform, 
                                  int amountAvailable, 
                                  int price, 
                                  string description, 
                                  string imageFile)
        {
            DAL.setProductMethods.addProductsDB(name, 
                                                category, 
                                                type, 
                                                platform, 
                                                amountAvailable, 
                                                price, 
                                                description, 
                                                imageFile);
        }

        //Tells DAL what to delete
        public void BLDeleteProduct(int index, int id)
        {
            DAL.setProductMethods.DeleteProducts(index, id);
        }

        //Tells DAL what to update
        public void BLUpdateProduct(int index, 
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
            DAL.setProductMethods.UpdateProducts(index, 
                                                 gv, 
                                                 name, 
                                                 category, 
                                                 type, 
                                                 platform, 
                                                 amountAvailable, 
                                                 price, 
                                                 description, 
                                                 imageFile
            );
        }
    }
}