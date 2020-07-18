using System;
using System.Collections.Generic;
//using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using additionalMethodsDAL.DAL;
//using setProductMethodsDAL.DAL;
using WebApplication1;

//UNUSED
//UNUSED
//UNUSED
//UNUSED
//UNUSED
//UNUSED

namespace manageProductsBL.BL
{ 
    public class managerProductsAdmin
    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                populateGV();
//                populateDDL();
//            }
//        }

//        public void populateDDL()
//        {
//            DataTable dataTable = new DataTable();
//            DataAccess dataConString = new DataAccess();
//            var connection = dataConString.GetConnectionString();
//            connection.Open();
//            SqlCommand cmd = new SqlCommand("SELECT CategoryName,CategoryID FROM Category", connection);
//            SqlDataReader read = cmd.ExecuteReader();

//            var ddl = GVProducts.FooterRow.FindControl("ddlCategoryFooter") as DropDownList;

//            if (ddl != null)
//            {
//                ddl.Items.Clear();
//                if (read.HasRows)
//                {
//                    while (read.Read())
//                    {
//                        ddl.Items.Add(new ListItem(read["CategoryName"].ToString(), read["CategoryID"].ToString()));
//                    }
//                }
//            }
//            else
//            {
//                System.Diagnostics.Debug.WriteLine("Can't find dropdown list");
//            }
//        }

//        public void populateGV()
//        {
//            DataTable dataTable = new DataTable();
//            DataAccess dataConString = new DataAccess();
//            var connection = dataConString.GetConnectionString();
//            connection.Open();
//            SqlDataAdapter DataAdapter = new SqlDataAdapter("SELECT * FROM Products", connection);
//            DataAdapter.Fill(dataTable);
//            connection.Close();
//            if (dataTable.Rows.Count > 0)
//            {
//                GVProducts.DataSource = dataTable;
//                GVProducts.DataBind();
//            }
//            else
//            {
//                dataTable.Rows.Add(dataTable.NewRow());
//                GVProducts.DataSource = dataTable;
//                GVProducts.DataBind();
//                GVProducts.Rows[0].Cells.Clear();
//                GVProducts.Rows[0].Cells.Add(new TableCell());
//                GVProducts.Rows[0].Cells[0].ColumnSpan = dataTable.Columns.Count;
//                GVProducts.Rows[0].Cells[0].Text = "No Data Could Be Found!";
//                GVProducts.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
//            }
//            connection.Close();

//        }
//        public void addData()
//        {
//            try
//            {
//                if ((GVProducts.FooterRow.FindControl("txtNameFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtTypeFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtPlatformFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtAmountAvailableFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtPriceFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtDescriptionFooter") as TextBox).Text == "" || (GVProducts.FooterRow.FindControl("txtImageFileFooter") as TextBox).Text == "")
//                {
//                    populateGV();
//                    populateDDL();
//                    //lblSuccess.Visible = true;
//                    //lblSuccess.Text = "One Or More Text Fields Empty! Please Fill In All Data!";
//                }
//                else
//                {
//                    DataAccess dataConString = new DataAccess();
//                    var connection = dataConString.GetConnectionString();
//                    connection.Open();
//                    string query = "INSERT INTO Products (Name, CategoryID, Type, Platform, AmountAvailable, Price, Description, ImageFile) VALUES (@Name, @Category, @Type, @Platform, @AmountAvailable, @Price, @Description, @ImageFile)";
//                    SqlCommand InsertNewCommand = new SqlCommand(query, connection);

//                    var selectedCategoryStr = (GVProducts.FooterRow.FindControl("ddlCategoryFooter") as DropDownList).SelectedValue;
//                    int selectedCategory = int.Parse(selectedCategoryStr);
//                    InsertNewCommand.Parameters.AddWithValue("@Name", (GVProducts.FooterRow.FindControl("txtNameFooter") as TextBox).Text.Trim());
//                    InsertNewCommand.Parameters.AddWithValue("@Category", selectedCategory);
//                    InsertNewCommand.Parameters.AddWithValue("@Type", (GVProducts.FooterRow.FindControl("txtTypeFooter") as TextBox).Text.Trim());
//                    InsertNewCommand.Parameters.AddWithValue("@Platform", (GVProducts.FooterRow.FindControl("txtPlatformFooter") as TextBox).Text.Trim());
//                    InsertNewCommand.Parameters.AddWithValue("@AmountAvailable", (GVProducts.FooterRow.FindControl("txtAmountAvailableFooter") as TextBox).Text.Trim());
//                    InsertNewCommand.Parameters.AddWithValue("@Price", (GVProducts.FooterRow.FindControl("txtPriceFooter") as TextBox).Text.Trim());
//                    InsertNewCommand.Parameters.AddWithValue("@Description", (GVProducts.FooterRow.FindControl("txtDescriptionFooter") as TextBox).Text.Trim());
//                    InsertNewCommand.Parameters.AddWithValue("@ImageFile", (GVProducts.FooterRow.FindControl("txtImageFileFooter") as TextBox).Text.Trim());
//                    InsertNewCommand.ExecuteNonQuery();
//                    connection.Close();
//                    populateGV();
//                    populateDDL();
//                    //lblSuccess.Visible = true;
//                    //lblSuccess.Text = "Successfully Added!";
//                }
//            }
//            catch
//            {
//                populateGV();
//                populateDDL();
//                //lblSuccess.Visible = true;
//                //lblSuccess.Text = "Error Adding Data! Check you have the right data types, for example, amount available, price and categoryID require an integer type!";
//            }
//        }
//        public void SaveUpdate(int index)
//        {
//            DataAccess dataConString = new DataAccess();
//            var connection = dataConString.GetConnectionString();
//            connection.Open();
//            var ctrl = GVProducts.Rows[index].FindControl("fileImgSave");
//            var fileUpload = (FileUpload)ctrl;
//            var img = fileUpload.PostedFile.FileName;
//            string image = img;
//            string imgFile = Path.GetFileName(image);
//            string folderPath = Server.MapPath("~/Images/");
//            fileUpload.SaveAs(folderPath + Path.GetFileName(fileUpload.FileName));
//            string query = "UPDATE Products SET Name=@Name, CategoryID=@Category, Type=@Type, Platform=@Platform, AmountAvailable=@AmountAvailable, Price=@Price, Description=@Description, ImageFile=@ImageFile WHERE ProductID = @id";
//            SqlCommand InsertNewCommand = new SqlCommand(query, connection);
//            InsertNewCommand.Parameters.AddWithValue("@Name", (GVProducts.Rows[index].FindControl("txtName") as TextBox).Text.Trim());
//            InsertNewCommand.Parameters.AddWithValue("@Category", (GVProducts.Rows[index].FindControl("txtCategory") as TextBox).Text.Trim());
//            InsertNewCommand.Parameters.AddWithValue("@Type", (GVProducts.Rows[index].FindControl("txtType") as TextBox).Text.Trim());
//            InsertNewCommand.Parameters.AddWithValue("@Platform", (GVProducts.Rows[index].FindControl("txtPlatform") as TextBox).Text.Trim());
//            InsertNewCommand.Parameters.AddWithValue("@AmountAvailable", (GVProducts.Rows[index].FindControl("txtAmountAvailable") as TextBox).Text.Trim());
//            InsertNewCommand.Parameters.AddWithValue("@Price", (GVProducts.Rows[index].FindControl("txtPrice") as TextBox).Text.Trim());
//            InsertNewCommand.Parameters.AddWithValue("@Description", (GVProducts.Rows[index].FindControl("txtDescription") as TextBox).Text.Trim());
//            InsertNewCommand.Parameters.AddWithValue("@ImageFile", imgFile);
//            InsertNewCommand.Parameters.AddWithValue("@id", Convert.ToInt32(GVProducts.DataKeys[index].Value.ToString()));
//            InsertNewCommand.ExecuteNonQuery();
//            GVProducts.EditIndex = -1;
//            populateGV();
//            populateDDL();
//            connection.Close();
//        }
//        public void DeleteRow(int index, int id)
//        {

//            populateGV();
//            populateDDL();
//        }
//        protected void GVProducts_RowCommand(object sender, GridViewCommandEventArgs e)
//        {
//            if (e.CommandName.Equals("AddNew"))
//            {
//                addData();
//            }
//        }

//        protected void GVProducts_RowEditing(object sender, GridViewEditEventArgs e)
//        {
//            GVProducts.EditIndex = e.NewEditIndex;
//            populateGV();
//            populateDDL();
//        }

//        protected void GVProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
//        {
//            GVProducts.EditIndex = -1;
//            populateGV();
//            populateDDL();
//        }

//        protected void GVProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
//        {
//            int a = e.RowIndex;
//            SaveUpdate(a);
//        }

//        protected void GVProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            int a = e.RowIndex;
//            DeleteRow(a, Convert.ToInt32(GVProducts.DataKeys[a].Value.ToString()));
//        }
//        //protected void Page_Load(object sender, EventArgs e)
//        //{
//        //    if (!IsPostBack)
//        //    {
//        //        populateGV();
//        //        populateDDL();
//        //    }
//        //}
//        //public void DeleteRow(int index, int id)
//        //{
//        //    setProductMethods deleteProducts = new setProductMethods();
//        //    deleteProducts.deleteRow(index, id);
//        //}
    }
}