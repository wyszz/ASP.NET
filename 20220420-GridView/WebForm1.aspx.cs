using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace _20220420_GridView
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.DataSource = this.GetTeacherData();
            this.GridView1.DataBind();

        }
        private DataTable GetTeacherData()
        {
            string connectstring = @"Data Source=DESKTOP-VDERB5N;Initial Catalog=ScoreDB;Persist Security Info=True;User ID=sa;Password=123";
            SqlConnection sconn = new SqlConnection(connectstring);
            string selectstring = "select * from teacher";
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}