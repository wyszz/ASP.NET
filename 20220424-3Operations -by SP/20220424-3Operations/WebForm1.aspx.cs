using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _20220424_3Operations
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadGridView();
                this.MultiView1.SetActiveView(this.v_GV);
                // this.MultiView1.ActiveViewIndex=1;
            }
        }

        private void LoadGridView()
        {
            string connstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            //string selectstring = "select * from view_office order by officeid asc";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = new SqlCommand();
            sda.SelectCommand.Connection = sconn;
            sda.SelectCommand.CommandText = "spr_SelectViewOfficeorderbyOfficeid";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            sda.Fill(dt);
            this.gv_Office.DataSource = dt;
            this.gv_Office.DataKeyNames = new string[] { "officeid", "schoolid", "authorizedid" };
            this.gv_Office.DataBind();
        }

        private DataTable GetDataTable(string selectstring)
        {
            string connstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            SqlDataAdapter sda = new SqlDataAdapter(selectstring, sconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        protected void gv_Office_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gv_Office.EditIndex = e.NewEditIndex;
            string schoolid = this.gv_Office.Rows[e.NewEditIndex].Cells[1].Text;
            this.LoadGridView();
            //加载数据到gv里的两个ddl中
            DropDownList ddl = this.gv_Office.Rows[e.NewEditIndex].FindControl("ddl_gvschool") as DropDownList;
            //DropDownList ddl = (DropDownList)this.gv_Office.Rows[e.NewEditIndex].FindControl("ddl_gvschool");
            string selectstring = "select * from school";
            ddl.DataSource = this.GetDataTable(selectstring);
            ddl.DataValueField = "schoolid";
            ddl.DataTextField = "schoolname";
            //固定原来的选项
            ddl.SelectedValue = this.gv_Office.DataKeys[e.NewEditIndex].Values["schoolid"].ToString();
            ddl.DataBind();

            //
            ddl = this.gv_Office.Rows[e.NewEditIndex].FindControl("ddl_gvstatus") as DropDownList;
            selectstring = "select * from authorized";
            ddl.DataSource = this.GetDataTable(selectstring);
            ddl.DataValueField = "authorizedid";
            ddl.DataTextField = "authorizedname";
            //固定原来的选项
            ddl.SelectedValue = this.gv_Office.DataKeys[e.NewEditIndex].Values["authorizedid"].ToString();
            ddl.DataBind();
        }

        protected void gv_Office_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gv_Office.EditIndex = -1;
            this.LoadGridView();
        }

        private bool IsExistSameOfficeName(OfficeClass oc)
        {
            string connstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            //string selectstring = "select * from office where officename=@officename and schoolid=@schoolid and officeid<>@officeid";
            string spname = "spr_IsExistSameOfficeName";
            SqlCommand scd = new SqlCommand(spname, sconn);
            scd.CommandType = CommandType.StoredProcedure;
            scd.Parameters.AddWithValue("officeid", oc.OfficeID);
            scd.Parameters.AddWithValue("officename", oc.OfficeName);
            scd.Parameters.AddWithValue("schoolid", oc.SchoolID);
            if (sconn.State == ConnectionState.Closed)
            {
                sconn.Open();
            }
            object result = scd.ExecuteScalar();
            sconn.Close();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //
        private int DoUpdateOffice(OfficeClass oc)
        {
            string connstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            //string updatestring = "update office set officename=@officename,schoolid=@schoolid,authorizedid=@authorizedid where officeid=@officeid";
            string spname = "spr_UpdateOfficebyOfficeID";
            SqlCommand scd = new SqlCommand(spname, sconn);
            scd.CommandType = CommandType.StoredProcedure;
            scd.Parameters.AddWithValue("officeid", oc.OfficeID);
            scd.Parameters.AddWithValue("officename", oc.OfficeName);
            scd.Parameters.AddWithValue("schoolid", oc.SchoolID);
            scd.Parameters.AddWithValue("authorizedid", oc.AutorizedID);
            if (sconn.State == ConnectionState.Closed)
            {
                sconn.Open();
            }
            int r = scd.ExecuteNonQuery();
            sconn.Close();
            return r;
        }

        protected void gv_Office_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //首先，要获得GV里，本行的数据，最新数据
            //其次，判断下，按照当前的schoolid，和最新的officename，不能出现同时相等的情况，且officeid不是自己
            //最新数据按照officeid去更新，
            if (e.RowIndex >= 0)
            {
                OfficeClass oc = new OfficeClass();
                oc.OfficeID = this.gv_Office.DataKeys[e.RowIndex].Values["officeid"].ToString();
                oc.OfficeName = ((TextBox)this.gv_Office.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString();
                oc.SchoolID = ((DropDownList)this.gv_Office.Rows[e.RowIndex].FindControl("ddl_gvschool")).SelectedValue;
                oc.AutorizedID = ((DropDownList)this.gv_Office.Rows[e.RowIndex].FindControl("ddl_gvstatus")).SelectedValue;
                //
                if (this.IsExistSameOfficeName(oc))
                {
                    Response.Write("<script>alert('教研室名字已存在，请更换！')</script>");
                    return;
                }
                int r = DoUpdateOffice(oc);
                if (r > 0)
                {
                    Response.Write("<script>alert('更新成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('更新失败')</script>");
                }
                this.gv_Office.EditIndex = -1;
                this.LoadGridView();
            }
        }

        protected void btn_AddNews_Click(object sender, EventArgs e)
        {
            this.MultiView1.SetActiveView(this.v_AddNew);
            string selectstring = "select * from school";
            this.ddl_School.DataSource = this.GetDataTable(selectstring);
            this.ddl_School.DataValueField = "schoolid";
            this.ddl_School.DataTextField = "schoolname";
            this.ddl_School.DataBind();
            this.ddl_School.Items.Insert(0, "请选择...");
            //
            selectstring = "select * from authorized";
            this.ddl_Status.DataSource = this.GetDataTable(selectstring);
            this.ddl_Status.DataValueField = "authorizedid";
            this.ddl_Status.DataTextField = "authorizedname";
            this.ddl_Status.DataBind();
            this.ddl_Status.Items.Insert(0, "请选择...");
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.MultiView1.SetActiveView(this.v_GV);
        }


        //
        private string CreateNewOfficeID()
        {
            int officeid = 1;
            int length = this.gv_Office.DataKeys[0].Values["officeid"].ToString().Length;
            int key = 0;
            for (int i = 0; i < this.gv_Office.DataKeys.Count; i++)//i相当于行号
            {
                int curid = int.Parse(this.gv_Office.DataKeys[i].Values["officeid"].ToString());
                if (officeid==curid)
                {
                    officeid++;
                }
                else
                {
                    key = officeid;//key相当于想要的下标
                }
            }
            if (key==0)
            {
                key = officeid;
            }
            string newid = System.Convert.ToString(officeid).PadLeft(length, '0');//officeid可以用key,PadLeft方法补零
            return newid;
        }

        private int DoInsertOffice(OfficeClass oc)
        {
            string connstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            //string insertstring = "insert into office values (@officeid,@officename,@schoolid,@authorizedid)";
            //string insertstring = "insert into office((officeid,officename,schoolid,authorizedid) values (@officeid,@officename,@schoolid,@authorizedid)";
            SqlCommand scd = new SqlCommand();
            scd.Connection = sconn;
            scd.CommandText = "spr_InsertOffice";
            scd.CommandType = CommandType.StoredProcedure;
            scd.Parameters.AddWithValue("officeid", oc.OfficeID);
            scd.Parameters.AddWithValue("officename", oc.OfficeName);
            scd.Parameters.AddWithValue("schoolid", oc.SchoolID);
            scd.Parameters.AddWithValue("authorizedid", oc.AutorizedID);
            if (sconn.State == ConnectionState.Closed)
            {
                sconn.Open();
            }
            int r = scd.ExecuteNonQuery();
            sconn.Close();
            return r;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.tbx_Officename.Text.Trim() == "")
            {
                Response.Write("<script>alert('教研室名称不能为空！')</script>");
                return;
            }
            if (this.ddl_School.SelectedIndex == 0)
            {
                Response.Write("<script>alert('请选择所属学院！')</script>");
                return;
            }
            if (this.ddl_Status.SelectedIndex == 0)
            {
                Response.Write("<script>alert('请选择教研室状态！')</script>");
                return;
            }
            OfficeClass oc = new OfficeClass();
            oc.OfficeID = "";
            oc.OfficeName = this.tbx_Officename.Text.Trim();
            oc.SchoolID = this.ddl_School.SelectedValue;
            oc.AutorizedID = this.ddl_Status.SelectedValue;

            //
            if (this.IsExistSameOfficeName(oc))
            {
                Response.Write("<script>alert('教研室名字已存在，请更换！')</script>");
                return;
            }
            oc.OfficeID = this.CreateNewOfficeID();
            int r = DoInsertOffice(oc);
            if (r > 0)
            {
                Response.Write("<script>alert('新增成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('新增失败')</script>");
            }
            this.LoadGridView();
            this.MultiView1.SetActiveView(this.v_GV);
        }

        //
          private int DoDeleteOffice(string officeid)
        {
            string connstring = ConfigurationManager.ConnectionStrings["ScoreDBConn"].ConnectionString;
            SqlConnection sconn = new SqlConnection(connstring);
            //string deletestring = "delete from office where officeid=@officeid";
            string spname = "spr_DeleteOfficebyOfficeID";
            SqlCommand scd = new SqlCommand(spname, sconn);
            scd.CommandType = CommandType.StoredProcedure;
            scd.Parameters.AddWithValue("officeid", officeid);
            if (sconn.State == ConnectionState.Closed)
            {
                sconn.Open();
            }
            int r = scd.ExecuteNonQuery();
            sconn.Close();
            return r;
        }

        protected void gv_Office_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                string officeid = this.gv_Office.DataKeys[e.RowIndex].Values["officeid"].ToString();
                int r = DoDeleteOffice(officeid);
                if (r > 0)
                {
                    Response.Write("<script>alert('删除成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败')</script>");
                }
                this.LoadGridView();
            }
        }


        protected void gv_Office_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType==DataControlRowType.DataRow)
            {
                if (e.Row.RowState==DataControlRowState.Normal||e.Row.RowState==DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[7].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确定要删除么？')");
                }
            }
        }

        protected void gv_Office_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_Office.PageIndex = e.NewPageIndex;
            this.LoadGridView();
        }
    }
}