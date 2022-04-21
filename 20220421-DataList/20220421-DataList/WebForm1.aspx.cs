using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _20220421_DataList
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadDataList();
        }

    private void LoadDataList()
        {
            string connstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            string selectstring = "select * from view_teacher";
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            this.DataList1.DataSource = dt;
            this.DataList1.DataBind();
        }
    }
}