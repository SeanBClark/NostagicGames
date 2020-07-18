using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UL
{
    public partial class adminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnMngtUsers.Click += new EventHandler(this.btnMngtUserRedirect);
            btnMngtProducts.Click += new EventHandler(this.btnMngtProductsRedirect);
            btnAdminLog.Click += new EventHandler(this.btnAdminRegRedirect);
            btnLoginToAdmin.Click += new EventHandler(this.btnAdminLogRedirect);
        }

        protected void btnMngtUserRedirect(object sender, EventArgs e)
        {
            Response.Redirect("adminUserManagement.aspx");
        }

        protected void btnMngtProductsRedirect(object sender, EventArgs e)
        {
            Response.Redirect("managerProductsAdmin.aspx");
        }

        protected void btnAdminRegRedirect(object sender, EventArgs e)
        {
            Response.Redirect("adminRegistration.aspx");
        }

        protected void btnAdminLogRedirect(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        
    }
}