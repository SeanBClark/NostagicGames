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
    public partial class userRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //bxAdminCode.Visible = false;
            matchError.Visible = false;
            LbUsernamVal.Visible = false;
            //lbCodeVal.Visible = false;
            lbPassVal.Visible = false;
            btnContinue.Click += new EventHandler(this.continueButtonFunc);
            btnClear.Click += new EventHandler(this.clearForms);
            //btnRegAdmin.Click += new EventHandler(this.adminRegRedirect);
        }

        //redirect function
        protected void continueButtonFunc(object sender, EventArgs e)
        {
            //if (txbPassword.Text != txbRePassword.Text)
            if (compareStringFunc(txbPassword.Text, txbRePassword.Text) == false)
            {
                matchError.Visible = true;
            }
            else
            {
                matchError.Visible = false;
            }

            if (checkPassword(txbPassword.Text) == false)
            {
                lbPassVal.Visible = true;
            }
            else
            {
                lbPassVal.Visible = false;
            }

            if (IsValidEmail(txbUsername.Text) == false)
            {
                LbUsernamVal.Visible = true;
            }
            else
            {
                LbUsernamVal.Visible = false;
            }
            if (compareStringFunc(txbPassword.Text, txbRePassword.Text) &&
                checkPassword(txbPassword.Text) &&
                IsValidEmail(txbUsername.Text))
            {
                BL.userRegistrationBL userReg = new BL.userRegistrationBL();
                userReg.insertUser(txbUsername.Text, txbPassword.Text);
                Response.Redirect("regThankYou.aspx");
            }

            //Currently does not work due to page reloading, unsure how to fix. 
            //Validation does work, display text will display then page reloads and text is gone
            //if (bxAdminCode.Visible)
            //{
            //    if (isValCodeInts(txbAdminCode.Text) == false)
            //    {
            //        bxAdminCode.Visible = true;
            //        lbCodeVal.Visible = true;
            //    }
            //    else
            //    {
            //        lbCodeVal.Visible = false;
            //    }
            //}

        }

        //Function to clear forms
        protected void clearForms(object sender, EventArgs e)
        {
            txbUsername.Text = string.Empty;
            txbPassword.Text = string.Empty;
            txbRePassword.Text = string.Empty;
            //txbAdminCode.Text = string.Empty;
        }

        //protected void adminRegRedirect(object sender, EventArgs e)
        //{
        //    bxAdminCode.Visible = true;
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
            catch (System.ArgumentException e)
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

        public static bool isValCodeInts(string code)
        {
            if (String.IsNullOrEmpty(code))
            {
                return false;
            }
            try
            {
                code.All(char.IsDigit);
                return true;
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
        }

        public static bool compareStringFunc(string textOne, string textTwo)
        {
            if (String.IsNullOrEmpty(textOne))
            {
                return false;
            }
            if (String.IsNullOrEmpty(textTwo))
            {
                return false;
            }
            try
            {
                if (textOne == textTwo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentException e)
            {
                return false;
            }
        }

        public static bool checkPassword(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(password,
                    @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{4,8}$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
        }
    }
}