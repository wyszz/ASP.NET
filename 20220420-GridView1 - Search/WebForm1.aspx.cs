using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _20220420_GridView
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GridView1.DataSource = this.GetTeacherData(null);
                this.GridView1.DataBind();
            }
        }
            private DataTable GetTeacherData(string condition)
            {
                string connectstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
                SqlConnection sconn = new SqlConnection(connectstring);
                //string selectstring = "select * from teacher,title,role,authorized,office where teacher.titleid=title.titleid and teacher.roleid=role.roleid and teacher.officeid=office.officeid and teacher.authorizedid=authorized.authorizedid";
                string selectstring = "select * from view_teacher ";
                if (condition != null)
                {
                    selectstring += condition;
                }
                SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }

            protected void btn_Search_Click(object sender, EventArgs e)
            {
                //首先获得tbx的信息，要判断以下是否为空
                if (this.tbx_Search.Text.Trim() == "")
                {
                    Response.Write("<script>alert('搜索内容不能为空!')</script>");
                    return;
                }
                string tname = this.tbx_Search.Text.Trim();
                //然后确定单选框，究竟要选的是哪一项
                string condition = null;
                if (this.rbtnl_SearchMode.SelectedValue == "模糊")
                {
                    string like = string.Format("%{0}%", tname);
                    condition = string.Format(" where teachername like '{0}'", like);
                }
                else
                {
                    condition = string.Format(" where teachername='{0}'", tname);
                }
                this.GridView1.DataSource = this.GetTeacherData(condition);
                this.GridView1.DataBind();
            }
        }
    }