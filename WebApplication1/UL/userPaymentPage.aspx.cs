using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using userPaymentBL.BL;
// access to the payment classes
using INFT3050.PaymentSystem;

namespace WebApplication1.UL
{
    public partial class userPaymentPage : System.Web.UI.Page
    {
        IPaymentSystem paymentSystem;
        PaymentRequest payment;

        protected void Page_Load(object sender, EventArgs e)
        {
            // SSL CODE. COMMENT OUT IF SSL DOESN'T WORK
            // SECURE PATH FOUND IN WEB.CONFIG FILE
            // SECURE PATH WILL DEPEND ON WHAT VS GIVES YOU WHEN ENABLING SSL = TRUE
            // Redirect for SSL if not already secured
            string securePath = (System.Configuration.ConfigurationManager.AppSettings["SecurePath"] + "UL/userPaymentPage.aspx");
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

            // other
            btnPayment.Click += new EventHandler(this.paymentFunc);
            btnOkay.Click += new EventHandler(this.okayFunc);
            paymentSystem = INFT3050PaymentFactory.Create();
        }

        // Quick button for testing and hard coding
        protected void paymentFunc(object sender, EventArgs e)
        {
            TryPayment("Arthur Anderson", "4444333322221111", 123, new DateTime(2020, 11, 1), 200, "test");
        }

        // Takes the data input from text boxes, converts them to correct type, and calls TryPayment
        protected void okayFunc(object sender, EventArgs e)
        {
            try
            {
                string inpCardName = txbCardName.Text;
                string inpCardNumber = txbCardNumber.Text;
                int inpCVC = Convert.ToInt32(txbCVC.Text);
                int inpExpiryDay = Convert.ToInt32(txbExpiryDay.Text);
                int inpExpiryMonth = Convert.ToInt32(txbExpiryMonth.Text);
                int inpExpiryYear = Convert.ToInt32(txbExpiryYear.Text);
                DateTime inpExpiry = new DateTime(inpExpiryYear, inpExpiryMonth, inpExpiryDay);
                decimal inpAmount = Convert.ToDecimal(txbAmount.Text);
                string inpDescription = txbDescription.Text;

                TryPayment(inpCardName, inpCardNumber, inpCVC, inpExpiry, inpAmount, inpDescription);
            }
            catch
            {
                lblPaymentResult.Text = Convert.ToString("Incorrect Input");
            }
        }

        private void TryPayment(string Name, string Number, int CVC, DateTime Expiry, decimal Amount, string Description)
        {
            payment = new PaymentRequest();
            payment.CardName = Name;
            payment.CardNumber = Number;
            payment.CVC = CVC;
            payment.Expiry = Expiry;
            payment.Amount = Amount;
            payment.Description = Description;

            var task = paymentSystem.MakePayment(payment);

            task.Wait();

            System.Diagnostics.Debug.WriteLine(task.IsCompleted);
            if (task.IsCompleted)
            {
                //showTransactionResult(task.Result);
                System.Diagnostics.Debug.WriteLine("------------RESULT:");
                System.Diagnostics.Debug.WriteLine(task.Result.TransactionResult);
                lblPaymentResult.Text = Convert.ToString(task.Result.TransactionResult);
            }
        }
    }
}