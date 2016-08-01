using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Serverbooking.Models;
using System.Web.Services.Description;

namespace Serverbooking
{
    public partial class Edit : System.Web.UI.Page
    {
        string sCon = "Data Source=DNA;Persist Security Info=False;" +
     "Initial Catalog=DNA_Classified;User Id=sa;Password=;Connect Timeout=30;";


        public static DataTable DataSource { get; private set; }
        public static int EditData { get; private set; }
        public static int EditIndex { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid_With_Data();
            }
        }

        private void BindGrid_With_Data()
        {
            using (SqlConnection con = new SqlConnection(sCon))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM dbo.ServerInfo"))
                {

                    SqlDataAdapter sda = new SqlDataAdapter();
                    try
                    {
                        cmd.Connection = con;
                        con.Open();
                        sda.SelectCommand = cmd;

                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        // BIND DATABASE WITH THE GRIDVIEW.
                        if (dt.Rows.Count != 0)         // CHECK IF THE BOOKS TABLE HAS RECORDS.
                        {
                            Edit.DataSource = dt;
                            DataBind();
                        }
                        else
                        {

                        }
                    }
                    catch (Exception )
                    {
                        //
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        // INSERT A NEW RECORD.
        protected void InsertRecord(object sender, EventArgs e)
        {
            // GET THE ACTIVE GRIDVIEW ROW.
            Button bt = (Button)sender;
            GridViewRow grdRow = (GridViewRow)bt.Parent.Parent;

            // NOW GET VALUES FROM FIELDS FROM THE ACTIVE ROW.
            TextBox ServerID = (TextBox)grdRow.Cells[0].FindControl("ServerID");
            TextBox status = (TextBox)grdRow.Cells[0].FindControl("status");
            TextBox ServerName = (TextBox)grdRow.Cells[0].FindControl("ServerName");

            if (!string.IsNullOrEmpty(ServerID.Text.Trim()))
            {
                if (Perform_CRUD(0, ServerID.Text, status.Text, ServerName.Text, "INSERT"))
                {
                    BindGrid_With_Data();    // REFRESH THE GRIDVIEW.
                }
            }
        }

        protected void Edit_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            // GRIDVIEW PAGING.
            Edit.EditIndex = e.NewPageIndex;
            BindGrid_With_Data();
        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Edit.EditIndex = e.NewEditIndex;
            BindGrid_With_Data();
        }

        protected void GridView_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            Edit.EditIndex = -1;
            BindGrid_With_Data();
        }

        // EXTRACT DETAILS FOR UPDATING.

        private bool Perform_CRUD(int v1, string v2, string v3, int v4, string v5)
        {
            throw new NotImplementedException();
        }


       
    }
}
