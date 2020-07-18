using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// For DataTable
using System.Data;
using System.Data.Sql;
using cartPageBL.BL;

namespace WebApplication1.UL
{
    public partial class cartPage : System.Web.UI.Page
    {
        DataTable cartTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            // SSL CODE. COMMENT OUT IF SSL DOESN'T WORK
            // SECURE PATH FOUND IN WEB.CONFIG FILE
            // SECURE PATH WILL DEPEND ON WHAT VS GIVES YOU WHEN ENABLING SSL = TRUE
            // Redirect for SSL if not already secured
            string securePath = (System.Configuration.ConfigurationManager.AppSettings["SecurePath"] + "UL/cartPage.aspx");
            System.Diagnostics.Debug.WriteLine(securePath);
            System.Diagnostics.Debug.WriteLine(HttpContext.Current.Request.Url.AbsoluteUri);
            if (securePath != HttpContext.Current.Request.Url.AbsoluteUri)
            {
                Response.Redirect(securePath);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Already secured");
            }

            labelCartCount.Text = "Cart: " + ((int)Session["CartCount"]).ToString();
            if ((int)Session["CartCount"] <= 0)
            {
                NoItemsInCart.Visible = true;
            }
            else
            {
                NoItemsInCart.Visible = false;
            }
            clearButton.Click += new EventHandler(this.ClearCart);
            checkoutButton.Click += new EventHandler(this.proBuy);
            // Function to create hardcoded data table
            // Will be easy to replace with SQL data table eventually
            FillCartTable();
            // Datatable is used as datasource for the gridview
            // Gridview will eventually allow for sorting methods
            gvCart.DataSource = cartTable;
            // Applies data to gridview
            gvCart.DataBind();
        }

        // Clear completely renews the cart session data
        protected void ClearCart(object sender, EventArgs e)
        {
            Session["CartCount"] = (int)0;
            Session["ProductCart"] = new List<Models.ProductCart>();
            Response.Redirect(Request.RawUrl);
        }

        // Simply redirects for now
        protected void proBuy(object sender, EventArgs e)
        {
            //if ((int)Session["CartCount"] < 1)
            //{
            //    NoItemsInCart.Visible = true;
            //}
            //else
            //{
            //    NoItemsInCart.Visible = false;
                Response.Redirect("userPaymentPage.aspx");
            //}
        }

        // References for own use
        // https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable?view=netframework-4.7.2
        // https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.gridview.databind?view=netframework-4.7.2
        // https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.templatefield?view=netframework-4.7.2
        // https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.linkbutton?view=netframework-4.7.2

        // Function to create data table for cart
        protected void FillCartTable()
        {
            //int cartCount = (int)Session["CartCount"];

            cartTable = new DataTable();
            cartTable.Columns.Add("ProductID", typeof(int));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Name", typeof(string));
            cartTable.Columns.Add("Type", typeof(string));
            cartTable.Columns.Add("Platform", typeof(string));
            cartTable.Columns.Add("Price", typeof(decimal));

            List<Models.ProductCart> ProductCartList = (List<Models.ProductCart>)Session["ProductCart"];

            for (int i = 0; i < ProductCartList.Count; i++)
            {
                //System.Diagnostics.Debug.WriteLine("Creating row: " + (i+1) + " for ID:" + ProductCartList[i].ID);

                BL.ProductsBL productsBLVariable = new BL.ProductsBL();
                var ProductRetrieved = productsBLVariable.getSingleProduct(ProductCartList[i].ID);
                
                cartTable.Rows.Add(ProductCartList[i].ID, ProductCartList[i].Quantity, ProductRetrieved.Name, ProductRetrieved.Type, ProductRetrieved.Platform, ProductRetrieved.Price);
            }
        }
        // Possibly useless code
        //Button btn = new Button();
        //btn.ID = "RemoveButton" + i.ToString();
        //btn.Text = "Remove";
        //btn.Click += RemoveBtnClicked;


        // UNFINISHED --------------
        // Will eventually be used to send to specific item page
        protected void lnkView_Clicked(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);

            Session["CurrentProduct"] = id;

            Response.Redirect("moreInfoPage.aspx");
        }


        // Fully removes item from the session data cart, if there are any items in there to begin with
        protected void lnkRemove_Clicked(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            RemoveFromCart(id);
            // Refresh page
            Response.Redirect(Request.RawUrl);
        }

        // Finds the item that corresponds with id and decrements quantity, or removes if quantity == 1;
        protected void RemoveFromCart(int id)
        {
            // Gets list of type ProductCart from session data
            List<Models.ProductCart> ProductCartList = (List<Models.ProductCart>)Session["ProductCart"];

            // If there is a productcart item with matching id
            Models.ProductCart CartItem = ProductCartList.Find(i => i.ID == id);
            if(CartItem != null)
            {
                // If quantity > 1, decrement quantity by 1
                if(CartItem.Quantity > 1)
                {
                    System.Diagnostics.Debug.WriteLine("Decrementing ProductCart item quantity");
                    CartItem.Quantity -= 1;
                }
                // Else if quantity == 1, remove productcart item from list
                else if (CartItem.Quantity == 1)
                {
                    System.Diagnostics.Debug.WriteLine("Removing ProductCart item");
                    ProductCartList.Remove(CartItem);
                }
            }
            // Else weird error, console log
            else if (CartItem == null)
            {
                System.Diagnostics.Debug.WriteLine("Error: Could not find item to remove with id: " + id);
            }

            // Stores list back into session data
            Session["ProductCart"] = ProductCartList;

            // Removes 1 from session cart count
            Session["CartCount"] = (int)Session["CartCount"] - 1;
            System.Diagnostics.Debug.WriteLine("Cart count: " + (int)Session["CartCount"]);
        }
    }
}