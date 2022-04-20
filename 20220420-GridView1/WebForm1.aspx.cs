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
            this.GridView1.DataSource = this.GetTeacherData();
            this.GridView1.DataBind();

        }
        private DataTable GetTeacherData()
        {
            string connectstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connectstring);
            //string selectstring = "select * from teacher,title,role,authorized,office where teacher.titleid=title.titleid and teacher.roleid=role.roleid and teacher.officeid=office.officeid and teacher.authorizedid=authorized.authorizedid";
            string selectstring = "select * from view_teacher";
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}