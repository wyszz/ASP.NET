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
        private DataTable GetTeacherData(string tname)
        {
            string connectstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connectstring);
            string selectstring = "select * from view_teacher ";
            if (this.rbtnl_SearchMode.SelectedValue == "模糊")
            {
                selectstring += " where teachername like @teachername";
                tname = "%" + tname + "%";
            }
            else
            {
                selectstring += " where teachername = @teachername";
            }
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            sda.SelectCommand.Parameters.AddWithValue("teachername", tname);
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
            this.GridView1.DataSource = this.GetTeacherData(tname);
            this.GridView1.DataBind();
        }
    }
}