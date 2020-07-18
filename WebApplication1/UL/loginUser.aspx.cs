using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using loginUserBL.BL;

namespace WebApplication1.UL
{
    public partial class loginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelError.Visible = false;
            btnForgotPassword.Click += new EventHandler(this.sendToForgotPassword);
            btnRegister.Click += new EventHandler(this.sendToRegister);
            btnLogin.Click += new EventHandler(this.setToTYPage);
        }

        protected void sendToForgotPassword(object sender, EventArgs e)
        {
            // Does nothing for now
        }

        protected void sendToRegister(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationPage.aspx");
        }

        //only redirects if form data is valid, and form data matches the hardcoded values in this page
        protected void setToTYPage(object sender, EventArgs e)
        {
            BL.userAccountManagementAdminBL Uam = new BL.userAccountManagementAdminBL();
            if(Uam.loginUser(textBoxEmail.Text, textBoxPassword.Text))
            {
                labelError.Visible = true;
                labelError.Text = "login success!";
            }
            else
            {
                //this was a test
                Response.Redirect("RegistrationPage.aspx");
            }
            // If the page is valid and the data matches, go to success page
            //if ((Page.IsValid) && IsMatching())
            //{
            //    Response.Redirect("sucessLogin.aspx");
            //}
        }

        // compares users inputs with hard coded example data, returns true if they match, false if not
        //protected bool IsMatching()
        //{
        //    if ((textBoxEmail.Text == exampleEmail) && (textBoxPassword.Text == examplePassword))
        //    {
        //        return (true);
        //    }
        //    else
        //    {
        //        labelError.Text = "Email or password is incorrect";
        //        return (false);
        //    }
        //}
    }
}