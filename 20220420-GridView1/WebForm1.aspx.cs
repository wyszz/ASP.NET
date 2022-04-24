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

        private void Function()
        {
            //连接数据库，构建连接数据库字符串
            string connectstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connectstring);
            //初始化 sda
            string selectstring = "select * from view_teacher ";
            //1
            {
                SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            }
            //2
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                {//2-1
                    sda.SelectCommand = new SqlCommand();
                    sda.SelectCommand.Connection = sconn;
                    sda.SelectCommand.CommandText = selectstring;
                }
                {//2-2
                    sda.SelectCommand = new SqlCommand(selectstring, sconn);
                }
                //3
                {
                    SqlCommand scd = new SqlCommand();
                    scd.Connection = sconn;
                    scd.CommandText = selectstring;
                    {//3-1
                        SqlDataAdapter sda = new SqlDataAdapter(scd);
                    }
                    {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        sda.SelectCommand = scd;
                    }
                }
                DataTable dt = new DataTable();
                sda.Fill(dt);
            }
        }
    }
}