using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UL
{
    public partial class resetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnClear.Click += new EventHandler(this.clearLoginForm);
            btnLoginAct.Click += new EventHandler(this.sendEmail);
        }

        protected void clearLoginForm(object sender, EventArgs e)
        {
            txbUsername.Text = string.Empty;
        }

        //function to send email to user to reset password
        //Currently crashes
        //
        //
        //
        //
        protected void sendEmail(object sender, EventArgs e)
        {
            string emailName = txbUsername.Text;

            SmtpClient smtpClient = new SmtpClient("mail.NostalgicGames.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("", "");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("info@MyWebsiteDomainName", "MyWeb Site");
            mail.To.Add(new MailAddress(emailName));
            mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

            smtpClient.Send(mail);
        }
    }
}