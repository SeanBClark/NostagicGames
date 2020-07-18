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

namespace WebApplication1
{
    public partial class managerProductsAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // SSL CODE. COMMENT OUT IF SSL DOESN'T WORK
            // SECURE PATH FOUND IN WEB.CONFIG FILE
            // SECURE PATH WILL DEPEND ON WHAT VS GIVES YOU WHEN ENABLING SSL = TRUE
            // Redirect for SSL if not already secured
            string securePath = (System.Configuration.ConfigurationManager.AppSettings["SecurePath"] + "UL/managerProductsAdmin.aspx");
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

            if (!IsPostBack)
            {
                populateGV();
                populateDDL();
            }
        }

        //Populates Drop down list for page
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

        //Populates grid view for page
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
                productList.Add(new Product() { ProductID = 0, CategoryID = 0, Name = "N/A", Type = "N/A", Platform = "N/A", AmountAvailable = 0, Price = 0, Description="N/A", ImageFile = "N/A" });
                GVProducts.DataBind();
                productList.RemoveAt(0);
                GVProducts.Rows[0].Cells.Clear();
                GVProducts.Rows[0].Cells.Add(new TableCell());
                GVProducts.Rows[0].Cells[0].ColumnSpan = GVProducts.Columns.Count;
                GVProducts.Rows[0].Cells[0].Text = "No Data!";
                GVProducts.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        //Add new product function
        public void addData()
        {
            try
            {
                if ((GVProducts.FooterRow.FindControl("txtNameFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtTypeFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtPlatformFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtAmountAvailableFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtPriceFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtDescriptionFooter") as TextBox).Text == "")
                {
                    lblSuccess.Visible = true;
                    lblSuccess.Text = "Data Missing!";
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
                    if (lblSuccess.Visible)
                    {
                        lblSuccess.Visible = false;
                    }
                    populateGV();
                    populateDDL();
                }
            }
            catch
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Error Adding Data! Ensure Data Is In Correct Format And All Data Is Filled Out!";
                populateGV();
                populateDDL();
            }
        }


        //update product info function
        public void SaveUpdate(int index)
        {
            try
            {
                BL.Inventory inventory = new BL.Inventory();
                var ctrl = GVProducts.Rows[index].FindControl("fileImgSave");
                var fileUpload = (FileUpload)ctrl;
                var img = fileUpload.PostedFile.FileName;
                string image = img;
                string imgFile = Path.GetFileName(image);
                string folderPath = Server.MapPath("~/Images/");
                fileUpload.SaveAs(folderPath + Path.GetFileName(fileUpload.FileName));
                string name = (GVProducts.Rows[index].FindControl("txtName") as TextBox).Text.Trim();
                var selectedCategoryStr = (GVProducts.Rows[index].FindControl("txtCategory") as TextBox).Text.Trim();
                int selectedCategory = int.Parse(selectedCategoryStr);
                var AmntAvStr = (GVProducts.Rows[index].FindControl("txtAmountAvailable") as TextBox).Text.Trim();
                int AmountAvailable = int.Parse(AmntAvStr);
                var priceString = (GVProducts.Rows[index].FindControl("txtPrice") as TextBox).Text.Trim();
                int price = int.Parse(priceString);
                string type = (GVProducts.Rows[index].FindControl("txtType") as TextBox).Text.Trim();
                string platform = (GVProducts.Rows[index].FindControl("txtPlatform") as TextBox).Text.Trim();
                string desc = (GVProducts.Rows[index].FindControl("txtDescription") as TextBox).Text.Trim();
                inventory.BLUpdateProduct(index, GVProducts, name, selectedCategory, type, platform, AmountAvailable, price, desc, image);
                GVProducts.EditIndex = -1;
                if (lblSuccess.Visible)
                {
                    lblSuccess.Visible = false;
                }
                populateGV();
                populateDDL();
            }
            catch
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Error With Updating! Ensure Data Is In Correct Format And All Data Is Filled Out!";
            }
            
        }

        //Delete product from DB
        public void DeleteRow(int index, int id)
            {
                if(lblSuccess.Visible)
                {
                    lblSuccess.Visible = false;
                }
                BL.Inventory inventory = new BL.Inventory();
                inventory.BLDeleteProduct(index, id);
                populateGV();
                populateDDL();
            }

        //
        protected void GVProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
               addData();
            }
        }

        protected void GVProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVProducts.EditIndex = e.NewEditIndex;
            populateGV();
            populateDDL();
        }

        protected void GVProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVProducts.EditIndex = -1;
            populateGV();
            populateDDL();
        }

        protected void GVProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int a = e.RowIndex;
            SaveUpdate(a);
        }

        protected void GVProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            DeleteRow(a, Convert.ToInt32(GVProducts.DataKeys[a].Value.ToString()));
        }
    }
}