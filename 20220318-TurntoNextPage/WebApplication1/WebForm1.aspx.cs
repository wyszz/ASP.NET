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
                switch (this.RadioButtonList1.SelectedIndex)
                {
                    case 0:
                        {
                            // "webform2.aspx?var=" 内大小写不区分，默认在当前网页的路径下去找，
                            string surl = "webform2.aspx?aaa=" + this.RadioButtonList1.SelectedItem.Text;
                            Page.Response.Redirect(surl);
                            break;
                        }
                    case 1:
                        {
                            string surl = "webform2.aspx?k1=" + this.RadioButtonList1.SelectedItem.Text + "&k2=123&k3=abc";
                            Page.Response.Redirect(surl);
                            break;
                        }
                    //cookie和QueryString只能传字符串
                    case 2:
                        {
                            HttpCookie cookie_name = new HttpCookie("name");
                            cookie_name.Value = HttpUtility.UrlEncode(this.RadioButtonList1.SelectedItem.Text);
                            Response.AppendCookie(cookie_name);
                            Response.Redirect("~/webform2.aspx");
                            break;
                        }
                    // Session 可以传对象，区分大小写，session 是会话变量，只要同一个浏览器没有被关闭，session 对象就会存在，Session 私有的
                    case 3:
                        {
                            Session["sa"] = this.RadioButtonList1.SelectedItem.Text;
                            Response.Redirect("webform2.aspx");
                            break;
                        }
                    // 生命周期最长，在服务器启动时自动创建，在服务器停止时销毁。没有 Session 安全，Application 公有的，最大的风险是所有用户共有信息
                    case 4:
                        {
                            Application["ab"] = this.RadioButtonList1.SelectedItem.Text;
                            Response.Redirect("webform2.aspx");
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