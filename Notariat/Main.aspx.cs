using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Notariat.ContractDatabase;

namespace Notariat
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            GridView1.DataSource = ContractDatabase.Contracts;
            GridView1.DataBind();

            int index = 0;
            foreach (Contract contract in ContractDatabase.Contracts)
            {
                TableCell cell = GridView1.Rows[index].Cells[0];
                switch (contract.Status)
                {
                    case 0:
                        cell.BackColor = Color.DarkBlue;
                        cell.ForeColor = Color.White;
                        break;
                    case 3:
                        cell.BackColor = Color.Gray;
                        cell.ForeColor = Color.White;
                        break;
                    case 4:
                        cell.BackColor = Color.Red;
                        cell.ForeColor = Color.White;
                        break;
                }
            }
            index++;
        }
    }
}