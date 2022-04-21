using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _20220421_DropDownList
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadDDL_P(null, null);
                //this.ddl_Province.SelectedIndex = 5;
                //this.LoadDDL_C("provinceid", this.ddl_Province.SelectedValue);
                //this.ddl_City.SelectedIndex = 1;
            }
        }

        //省的加载方法
        private void LoadDDL_P(string colname, string colvalue)
        {
            string connstring = ConfigurationManager.ConnectionStrings["CNZipDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            string selectstring = "select * from provinces ";
            if (colname != null && colvalue != null)
            {
                selectstring += string.Format("where {0} = '{1}'", colname, colvalue);
            }
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            this.ddl_Province.DataSource = dt;
            this.ddl_Province.DataValueField = "provinceid";
            this.ddl_Province.DataTextField = "province";
            this.ddl_Province.DataBind();
            this.ddl_Province.Items.Insert(0, "请选择");
        }

        //市的加载方法
        private void LoadDDL_C(string colname, string colvalue)
        {
            string connstring = ConfigurationManager.ConnectionStrings["CNZipDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            string selectstring = "select * from cities ";
            if (colname != null && colvalue != null)
            {
                selectstring += string.Format("where {0} = '{1}'", colname, colvalue);
            }
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            this.ddl_City.DataSource = dt;
            this.ddl_City.DataValueField = "cityid";
            this.ddl_City.DataTextField = "city";
            this.ddl_City.DataBind();
            this.ddl_City.Items.Insert(0, "请选择");
        }

        //
        protected void ddl_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            string colname = "provinceid";
            string colvalue = this.ddl_Province.SelectedValue;
            this.LoadDDL_C(colname, colvalue);
        }

        //区县的加载方法
        private void LoadDDL_A(string colname, string colvalue)
        {
            string connstring = ConfigurationManager.ConnectionStrings["CNZipDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            string selectstring = "select * from areas ";
            if (colname != null && colvalue != null)
            {
                selectstring += string.Format("where {0} = '{1}'", colname, colvalue);
            }
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            this.ddl_Area.DataSource = dt;
            this.ddl_Area.DataValueField = "areaid";
            this.ddl_Area.DataTextField = "area";
            this.ddl_Area.DataBind();
            this.ddl_Area.Items.Insert(0, "请选择");
        }

        protected void ddl_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            string colname = "cityid";
            string colvalue = this.ddl_City.SelectedValue;
            this.LoadDDL_A(colname, colvalue);
        }

        //邮编加载
        private void LoadLabel(string colname, string colvalue)
        {
            string connstring = ConfigurationManager.ConnectionStrings["CNZipDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            string selectstring = "select zip from zipcode ";
            if (colname != null && colvalue != null)
            {
                selectstring += string.Format("where {0} = '{1}'", colname, colvalue);
            }
            SqlCommand cmd = new SqlCommand(selectstring, sconn);
            if (sconn.State==ConnectionState.Closed)
            {
                sconn.Open();
            }
            //this.Label1.Text = cmd.ExecuteScalar().ToString();
            object result = cmd.ExecuteScalar();
            sconn.Close();
            if (result==null)
            {
                Response.Write("<script>alert('邮编不存在,请核实')</script>");
                return;
            }
            this.Label1.Text = result.ToString();
        }

        protected void ddl_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            string colname = "areaid";
            string colvalue = this.ddl_Area.SelectedValue;
            this.LoadLabel(colname, colvalue);
        }
    }
}