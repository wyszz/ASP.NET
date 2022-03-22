using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1 QueryString 字符串不区分大小写
            if (this.Request.QueryString["aaa"] != null)
            {
                this.Label1.Text += this.Request.QueryString["aaa"];
            }
            //2
            if (this.Request.QueryString["k2"] != null && this.Request.QueryString["k3"] != null)
            {
                this.Label2.Text += this.Request.QueryString["k1"] + " " + this.Request.QueryString["k2"] + " " + this.Request.QueryString["k3"];

            }
        }
    }
}