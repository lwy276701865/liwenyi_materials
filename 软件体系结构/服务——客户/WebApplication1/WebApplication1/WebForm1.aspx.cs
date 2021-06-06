using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            localhost1.WebService1 web = new localhost1.WebService1();
            foreach(string i in web.Shift())
            {
                ListBox1.Items.Add(i);
            }
        }
    }
}