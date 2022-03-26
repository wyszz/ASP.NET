using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageCode
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ibtn_imgcheckingcode.ImageUrl = "WebForm2.aspx";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string checkingcode = tbx_imgcheckingcode.Text;
            HttpCookie cookie_checkingcode = Request.Cookies["ImageV"];
            string scode = cookie_checkingcode.Value.ToUpper().ToString();
            if (checkingcode.ToUpper()!= scode)
            {
                Response.Write("<script>alert('验证码输入不正确！')</script>");
            }
            else
            {
                this.tbx_imgcheckingcode.Text = "";
                Response.Write("<script>alert('验证码输入正确')</script>");
            }
        }
    }
}