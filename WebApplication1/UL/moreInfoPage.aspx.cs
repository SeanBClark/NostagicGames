using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using cartPageBL.BL;

namespace WebApplication1.UL
{
    public partial class moreInfoPage : System.Web.UI.Page
    {
        int productID;
        DataTable productTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            productID = (int)Session["CurrentProduct"];

            if(productID == -1)
            {
                Response.Redirect("errorPage.aspx");
            }

            // Function to create hardcoded data table
            // Will be easy to replace with SQL data table eventually
            FillProductTable();
            // Datatable is used as datasource for the gridview
            // Gridview will eventually allow for sorting methods
            GVProducts.DataSource = productTable;
            // Applies data to gridview
            GVProducts.DataBind();
        }

        protected void FillProductTable()
        {
            //int cartCount = (int)Session["CartCount"];

            productTable = new DataTable();
            productTable.Columns.Add("ProductID", typeof(int));
            productTable.Columns.Add("Name", typeof(string));
            productTable.Columns.Add("Type", typeof(string));
            productTable.Columns.Add("Platform", typeof(string));
            productTable.Columns.Add("Price", typeof(decimal));
            productTable.Columns.Add("Description", typeof(string));
            //productTable.Columns.Add("Image", typeof(string));

            List<Models.ProductCart> ProductCartList = (List<Models.ProductCart>)Session["ProductCart"];

            BL.ProductsBL productsBLVariable = new BL.ProductsBL();
            var ProductRetrieved = productsBLVariable.getSingleProduct(productID);

            productTable.Rows.Add(productID, ProductRetrieved.Name, ProductRetrieved.Type, ProductRetrieved.Platform, ProductRetrieved.Price, ProductRetrieved.Description/*, ProductRetrieved.ImageFile*/);
        }

        protected void addToCart_Clicked(object sender, EventArgs e)
        {
            //int toCartID = Convert.ToInt32((sender as Button).CommandArgument);
            //System.Diagnostics.Debug.WriteLine("Product ID: " + toCartID);
            Response.Redirect("errorPage.aspx");
            //AddToCart(toCartID);
        }

        //Add products to cart
        protected void AddToCart(int id)
        {
            // Gets list of type ProductCart from session data
            List<Models.ProductCart> ProductCartList = (List<Models.ProductCart>)Session["ProductCart"];

            // If there exists a productcart item with matching id, increment quantity by 1
            Models.ProductCart CartItem = ProductCartList.Find(i => i.ID == id);
            if (CartItem != null)
            {
                System.Diagnostics.Debug.WriteLine("Incrementing ProductCart item quantity");
                CartItem.Quantity += 1;
            }
            // Else if null (no matching id), create productcart item with quantity 1 and add to list
            else if (CartItem == null)
            {
                System.Diagnostics.Debug.WriteLine("Creating new ProductCart item");
                CartItem = new Models.ProductCart(id, 1);
                ProductCartList.Add(CartItem);
            }

            // Stores list back into session data
            Session["ProductCart"] = ProductCartList;

            // Adds 1 to session cart count
            Session["CartCount"] = (int)Session["CartCount"] + 1;
            System.Diagnostics.Debug.WriteLine("Cart count: " + (int)Session["CartCount"]);
        }
    }
}