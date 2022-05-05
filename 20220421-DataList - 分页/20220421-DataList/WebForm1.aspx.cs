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
            if (!IsPostBack)
            {
                ViewState["pageindex"] = "0";
                this.LoadDataList();
            }
        }

        private void LoadDataList()
        {
            string connstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            string selectstring = "select * from view_teacher";
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //
            DataView dv = dt.DefaultView;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.PageSize = 1;
            pds.CurrentPageIndex = Convert.ToInt32(ViewState["pageindex"].ToString());
            ViewState["pagecount"] = pds.PageCount;
            if (pds.IsFirstPage)
            {
                this.lkbtn_pre.Enabled = false;
            }
            else
            {
                this.lkbtn_pre.Enabled = true;
            }
            if (pds.IsLastPage)
            {
                this.lkbtn_next.Enabled = false;
            }
            else
            {
                this.lkbtn_next.Enabled = true;
            }
            //
            this.DataList1.DataSource = pds;
            this.DataList1.DataBind();
        }

        protected void lkbtn_Click(object sender, EventArgs e)
        {
            LinkButton lkbtn = (LinkButton)sender;
            string cmda = lkbtn.CommandArgument;
            int pageindex = Convert.ToInt32(ViewState["pageindex"].ToString());
            if (cmda == "pre")
            {
                pageindex = pageindex - 1;
            }
            else
            {
                pageindex = pageindex + 1;
            }

            ViewState["pageindex"] = pageindex;
            this.LoadDataList();
            this.tbx_pagenum.Text = (pageindex + 1).ToString();
        }

        protected void btn_go_Click(object sender, EventArgs e)
        {
            int pagenum = Convert.ToInt32(this.tbx_pagenum.Text.Trim());
            int pageindex = pagenum - 1;
            int pagecount = Convert.ToInt32(ViewState["pagecount"]);
            //int.TryParse
            if (pageindex < 0)
            {
                Response.Write("<script>alert('页数必须大于0！将回到首页')</script>");
                pageindex = 0;
            }
            if (pageindex >= pagecount)
            {
                Response.Write("<script>alert('页数不能超过总页数！将达到最后一页')</script>");
                pageindex = pagecount - 1;
            }
            ViewState["pageindex"] = pageindex;
            this.LoadDataList();
            this.tbx_pagenum.Text = (pageindex + 1).ToString();
        }
    }
}