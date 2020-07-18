using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// For DataTable
using System.Data;
using userHistoyBL.BL;

namespace WebApplication1
{
    public partial class userHistorypage : System.Web.UI.Page
    {
        DataTable historyTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillHistoryTable();
            //gvHistory.DataSource = historyTable;
            //gvHistory.DataBind();
        }

        protected void FillHistoryTable()
        {
            historyTable = new DataTable();
            historyTable.Columns.Add("ID", typeof(int));
            historyTable.Columns.Add("Name", typeof(string));
            historyTable.Columns.Add("Date", typeof(DateTime));

            for (int i = 0; i < 2; i++)
            {
                DateTime dt = DateTime.Now;
                historyTable.Rows.Add(i + 1, "Item " + (i + 1).ToString(), dt);
            }
        }
    }
}