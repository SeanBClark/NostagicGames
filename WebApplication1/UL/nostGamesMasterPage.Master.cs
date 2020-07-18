using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;
using masterPageBL.BL;

namespace WebApplication1.UL
{
    public partial class nostGamesMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnManageAccount.Click += new EventHandler(this.manageButtonFunc);
            btnRegister.Click += new EventHandler(this.registerNormButtonFunc);
            btnLoginAct.Click += new EventHandler(this.validationOnLoginBtn);
            btnClear.Click += new EventHandler(this.clearLoginForm);
            btnResetPassword.Click += new EventHandler(this.btnResetPasswordRediect);
            //btnHistory.Click += new EventHandler(this.btnHistoryRedirect);
            LbUsernamVal.Visible = false;

        }

        protected void clearLoginForm(object sender, EventArgs e)
        {
            txbUsername.Text = string.Empty;
            txbPassword.Text = string.Empty;
        }

        protected void btnHistoryRedirect(object sender, EventArgs e)
        {
            Response.Redirect("userHistoryPage.aspx");
        }

        protected void btnResetPasswordRediect(object sender, EventArgs e)
        {
            Response.Redirect("resetPassword.aspx");
        }

        protected void validationOnLoginBtn(object sender, EventArgs e)
        {   
            if (IsValidEmail(txbUsername.Text) == false)
            {
                LbUsernamVal.Visible = true;
            }
            else
            {
                LbUsernamVal.Visible = false;
                BL.userAccountManagementAdminBL Uam = new BL.userAccountManagementAdminBL();
                if (Uam.loginUser(txbUsername.Text, txbPassword.Text))
                {
                    btnLogin.Text = "logout";
                }
                else
                {
                    btnLogin.Text = "error";
                }
            }
        }

        // Returns a string showing how many items are in the session cart, or an empty string if none
        public string StringCartCount()
        {
            int iCount = (int)Session["CartCount"];
            string strCount;
            if (iCount < 1)
            {
                strCount = "";
            }
            else
            {
                strCount = " (" + iCount.ToString() + ")";
            }
            return strCount;
        }

        protected void manageButtonFunc(object sender, EventArgs e)
        {
            Response.Redirect("adminLandingPage.aspx");
        }

        protected void registerNormButtonFunc(object sender, EventArgs e)
        {
            Response.Redirect("userRegistration.aspx");
        }

        protected void registerAdminButtonFunc(object sender, EventArgs e)
        {
            Response.Redirect("AdminRegistrationPage.aspx");
        }

        //protected void loginDiv(object sender, EventArgs e)
        //{
        //    if (IsValidEmail(txbUsername.Text) == false)
        //    {
        //        LbUsernamVal.Visible = true;
        //    }
        //    else
        //    {
        //        LbUsernamVal.Visible = false;
        //    }
        //}

        //Taken from https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}