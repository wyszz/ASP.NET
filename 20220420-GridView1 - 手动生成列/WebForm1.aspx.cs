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
            this.LoadGridView();
        }
        //
        private void LoadGridView()
        {
            if (this.GridView1.Columns.Count>0)
            {
                this.GridView1.Columns.Clear();
            }
            this.GridView1.DataSource = this.GetTeacherData();
            this.GridView1.DataKeyNames = new string[] { "teacherid" };
            this.GridView1.DataBind();
            //
            BoundField bf = new BoundField();
            bf.DataField = "teacherid";
            bf.Visible = false;
            this.GridView1.Columns.Add(bf);
            //
            bf = new BoundField();
            bf.DataField = "teachername";
            bf.HeaderText = "教师姓名";
            this.GridView1.Columns.Add(bf);
            //
            bf = new BoundField();
            bf.DataField = "age";
            bf.HeaderText = "年龄";
            this.GridView1.Columns.Add(bf);
            this.DataBind();
        }
        //
        private DataTable GetTeacherData()
        {
            string connectstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connectstring);
            string selectstring = "select * from teacher";
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}