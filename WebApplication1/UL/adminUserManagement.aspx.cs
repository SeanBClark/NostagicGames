using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UL
{
    public partial class adminUserManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // SSL CODE. COMMENT OUT IF SSL DOESN'T WORK
            // SECURE PATH FOUND IN WEB.CONFIG FILE
            // SECURE PATH WILL DEPEND ON WHAT VS GIVES YOU WHEN ENABLING SSL = TRUE
            // Redirect for SSL if not already secured
            string securePath = (System.Configuration.ConfigurationManager.AppSettings["SecurePath"] + "UL/adminUserManagement.aspx");
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
            }
        }

        //Grabs info from BL and populates the grid view on the page
        public void populateGV()
        {
            BL.userAccountManagementAdminBL AccClass = new BL.userAccountManagementAdminBL();
            if(AccClass.getUsers().Count > 0)
            {
                var userList = AccClass.getUsers();
                GVUsers.DataSource = userList;
                GVUsers.DataBind();
            }
            else
            {
                var userList = AccClass.getUsers();
                GVUsers.DataSource = userList;
                userList.Add(new DAL.Users() { UserID = 0, FirstName = "N/A", LastName = "N/A", StreetNo = "N/A", Street = "N/A", Suburb = "N/A", Postcode = "N/A", State = "N/A", Country = "N/A", Phone = "N/A", Password = "N/A", DateJoined = "N/A" });              
                GVUsers.DataBind();
                userList.RemoveAt(0);
                GVUsers.Rows[0].Cells.Add(new TableCell());
                GVUsers.Rows[0].Cells[0].ColumnSpan = GVUsers.Columns.Count;
                GVUsers.Rows[0].Cells[0].Text = "No Data!";
                GVUsers.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        public void saveUpdate(int index)
        {
            BL.userAccountManagementAdminBL updateClass = new BL.userAccountManagementAdminBL();
            string status = (GVUsers.Rows[index].FindControl("ddlStatus") as DropDownList).Text.Trim();
            updateClass.updateUserStatus(index, GVUsers, status);
            GVUsers.EditIndex = -1;
            populateGV();
        }

        protected void GVUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVUsers.EditIndex = e.NewEditIndex;
            populateGV();
        }

        protected void GVUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVUsers.EditIndex = -1;
            populateGV();
        }

        protected void GVUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int a = e.RowIndex;
            saveUpdate(a);
        }
    }
}