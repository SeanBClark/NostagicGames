using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using manageProductsBL.BL;
using System.IO;
using WebApplication1.DAL;

namespace WebApplication1.UL
{
    public partial class landingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                {
                    populateGV();
                }
                populateDDL();
            }
        }

        protected void moreInfo_Clicked(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32((sender as Button).CommandArgument);
            System.Diagnostics.Debug.WriteLine("Product ID: " + productID);

            Session["CurrentProduct"] = productID;

            Response.Redirect("moreInfoPage.aspx");
        }

        protected void addToCart_Clicked(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32((sender as Button).CommandArgument);
            System.Diagnostics.Debug.WriteLine("Product ID: " + productID);

            AddToCart(productID);
        }

        //Populates drop down list on page
        public void populateDDL()
        {

            BL.Inventory inventory = new BL.Inventory();
            var ddl = GVProducts.FooterRow.FindControl("ddlCategoryFooter") as DropDownList;

            if (ddl != null)
            {
                ddl.Items.Clear();
                foreach (var category in inventory.GetCategories())
                {
                    ddl.Items.Add(new ListItem(category.Name, category.Id.ToString()));
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Can't find dropdown list");
            }

        }


        //Populates Grid View on Page
        public void populateGV()
        {
            BL.Inventory inventory = new BL.Inventory();
            if (inventory.GetAllProducts().Count > 0)
            {
                var productList = inventory.GetAllProducts();
                GVProducts.DataSource = productList;
                GVProducts.DataBind();
            }
            else
            {
                var productList = inventory.GetAllProducts();
                GVProducts.DataSource = productList;
                productList.Add(new Product() { ProductID = 0, CategoryID = 0, Name = "N/A", Type = "N/A", Platform = "N/A", AmountAvailable = 0, Price = 0, Description = "N/A", ImageFile = "N/A" });
                GVProducts.DataBind();
                productList.RemoveAt(0);
                GVProducts.Rows[0].Cells.Clear();
                GVProducts.Rows[0].Cells.Add(new TableCell());
                GVProducts.Rows[0].Cells[0].ColumnSpan = GVProducts.Columns.Count;
                GVProducts.Rows[0].Cells[0].Text = "No Products Available!";
                GVProducts.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        //Adds data to grid view
        public void addData()
        {
            try
            {
                if ((GVProducts.FooterRow.FindControl("txtNameFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtTypeFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtPlatformFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtAmountAvailableFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtPriceFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtDescriptionFooter") as TextBox).Text == "")
                {
                    populateGV();
                    populateDDL();
                }
                else
                {
                    BL.Inventory inventory = new BL.Inventory();
                    var ctrl = GVProducts.FooterRow.FindControl("fileImgSaveFooter");
                    var fileUpload = (FileUpload)ctrl;
                    var img = fileUpload.PostedFile.FileName;
                    string image = img;
                    string imgFile = Path.GetFileName(image);
                    string folderPath = Server.MapPath("~/Images/");
                    fileUpload.SaveAs(folderPath + Path.GetFileName(fileUpload.FileName));
                    string name = (GVProducts.FooterRow.FindControl("txtNameFooter") as TextBox).Text.Trim();
                    var selectedCategoryStr = (GVProducts.FooterRow.FindControl("ddlCategoryFooter") as DropDownList).SelectedValue;
                    int selectedCategory = int.Parse(selectedCategoryStr);
                    var AmntAvStr = (GVProducts.FooterRow.FindControl("txtAmountAvailableFooter") as TextBox).Text.Trim();
                    int AmountAvailable = int.Parse(AmntAvStr);
                    var priceString = (GVProducts.FooterRow.FindControl("txtPriceFooter") as TextBox).Text.Trim();
                    int price = int.Parse(priceString);
                    string type = (GVProducts.FooterRow.FindControl("txtTypeFooter") as TextBox).Text.Trim();
                    string platform = (GVProducts.FooterRow.FindControl("txtPlatformFooter") as TextBox).Text.Trim();
                    string desc = (GVProducts.FooterRow.FindControl("txtDescriptionFooter") as TextBox).Text.Trim();
                    inventory.BLAddProducts(name, selectedCategory, type, platform, AmountAvailable, price, desc, image);
                    
                    populateGV();
                    populateDDL();
                }
            }
            catch
            {
                populateGV();
                populateDDL();
            }
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

