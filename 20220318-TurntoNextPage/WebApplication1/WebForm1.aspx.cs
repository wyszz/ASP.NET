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

        protected void btn_TurntoNextPage_Click(object sender, EventArgs e)
        {
            //列表项为空时 SelectedIndex 值为 -1
            if (this.RadioButtonList1.SelectedIndex >= 0)
            {
                switch(this.RadioButtonList1.SelectedIndex)
                {
                    case 0:
                        {
                            // "webform2.aspx?var=" 内大小写不区分，默认在当前网页的路径下去找，
                            string surl = "webform2.aspx?var=" + this.RadioButtonList1.SelectedItem.Text;
                            Page.Response.Redirect(surl);
                            break;
                        }
                    case 1:
                        {
                            string surl = "webform2.aspx?k1=" + this.RadioButtonList1.SelectedItem.Text+"&k2=123&k3=abc";
                            Page.Response.Redirect(surl);
                            break;
                        }
                    default:
                        {
                            Response.Write("<script>alert('请选择其中一个方法！')</script>");
                            break;
                        }
                }
            }
        }
    }
}