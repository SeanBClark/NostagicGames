using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UL
{
    public partial class adminLandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // SSL CODE. COMMENT OUT IF SSL DOESN'T WORK
            // SECURE PATH FOUND IN WEB.CONFIG FILE
            // SECURE PATH WILL DEPEND ON WHAT VS GIVES YOU WHEN ENABLING SSL = TRUE
            // Redirect for SSL if not already secured
            string securePath = (System.Configuration.ConfigurationManager.AppSettings["SecurePath"] + "UL/adminLandingPage.aspx");
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
        }
    }
}