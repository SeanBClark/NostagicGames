using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WebApplication1.UL
{
    public partial class adminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // SSL CODE. COMMENT OUT IF SSL DOESN'T WORK
            // SECURE PATH FOUND IN WEB.CONFIG FILE
            // SECURE PATH WILL DEPEND ON WHAT VS GIVES YOU WHEN ENABLING SSL = TRUE
            // Redirect for SSL if not already secured
            string securePath = (System.Configuration.ConfigurationManager.AppSettings["SecurePath"] + "UL/adminLogin.aspx");
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

            lblOutput.Visible = false;
            LbUsernamVal.Visible = false;
            btnLoginAct.Click += new EventHandler(this.validationOnLoginBtn);
            btnClear.Click += new EventHandler(this.clearLoginForm);
        }

        protected void clearLoginForm(object sender, EventArgs e)
        {
            txbUsername.Text = string.Empty;
            txbPassword.Text = string.Empty;
        }

        protected void validationOnLoginBtn(object sender, EventArgs e)
        {
            LbUsernamVal.Visible = false;
            BL.userAccountManagementAdminBL adminLogin = new BL.userAccountManagementAdminBL();
            
            if (adminLogin.loginAdmin(txbUsername.Text, txbPassword.Text))
            {
                lblOutput.Text = "Successfully Logged In!";
                lblOutput.Visible = true;
            }
            else
            {
                lblOutput.Text = "Error Logging In! Incorrect Username Or Password!";
                lblOutput.Visible = true;
            }
            

        }

        ////Taken from https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        //public static bool IsValidEmail(string email)
        //{
        //    if (string.IsNullOrWhiteSpace(email))
        //        return false;

        //    try
        //    {
        //        // Normalize the domain
        //        email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
        //                              RegexOptions.None, TimeSpan.FromMilliseconds(200));

        //        // Examines the domain part of the email and normalizes it.
        //        string DomainMapper(Match match)
        //        {
        //            // Use IdnMapping class to convert Unicode domain names.
        //            var idn = new IdnMapping();

        //            // Pull out and process domain name (throws ArgumentException on invalid)
        //            var domainName = idn.GetAscii(match.Groups[2].Value);

        //            return match.Groups[1].Value + domainName;
        //        }
        //    }
        //    catch (RegexMatchTimeoutException e)
        //    {
        //        return false;
        //    }
        //    catch (ArgumentException e)
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        return Regex.IsMatch(email,
        //            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        //            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        //            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {
        //        return false;
        //    }
        //}
    }
}