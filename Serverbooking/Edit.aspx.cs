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
                            // CREATE A BLANK ROW IF THE BOOKS TABLE IS EMPTY.

                            DataRow aBlankRow = dt.NewRow();
                            dt.Rows.Add(aBlankRow);
                           Edit.DataSource = dt;
                            DataBind();

                            // SHOW A SINGLE COLUMN WITH A MESSAGE.
                            int col = InfoServer.Rows[0].Cells.Count;
                            InfoServer.Rows[0].Cells.Clear();
                            InfoServer.Rows[0].Cells.Add(new TableCell());
                            InfoServer.Rows[0].Cells[0].ColumnSpan = col;
                            InfoServer.Rows[0].Cells[0].Text = "Table is Empty";
                        }
                    }
                    catch (Exception ex)
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

            if (!string.IsNullOrEmpty(tbBookName.Text.Trim()))
            {
                if (Perform_CRUD(0, tbBookName.Text, tbCategory.Text, double.Parse(tbPrice.Text), "INSERT"))
                {
                    BindGrid_With_Data();    // REFRESH THE GRIDVIEW.
                }
            }
        }

        protected void Edit_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            // GRIDVIEW PAGING.
            Edit.PageIndex = e.NewPageIndex;
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
        protected void Edit_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            Label lblBookID = (Label)Edit.Rows[e.RowIndex].FindControl("lblServerID");
            TextBox tbBookName = (TextBox)Edit.Rows[e.RowIndex].FindControl("tbEd_Book");
            TextBox tbCategory = (TextBox)Edit.Rows[e.RowIndex].FindControl("tbEd_Cate");
            TextBox tbPrice = (TextBox)Edit.Rows[e.RowIndex].FindControl("tbEd_Price");

            if (int.Parse(lblBookID.Text) != 0)
            {
                if (Perform_CRUD(int.Parse(lblBookID.Text), tbBookName.Text, tbCategory.Text, double.Parse(tbPrice.Text), "UPDATE"))
                {
                    BindGrid_With_Data();       // REFRESH THE GRIDVIEW.
                }
            }
        }

        protected void Edit_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            Label lblBookID = (Label)Edit.Rows[e.RowIndex].FindControl("lblServerID");

            if (int.Parse(lblBookID.Text) != 0)
            {
                if (Perform_CRUD(int.Parse(lblBookID.Text), "", "", 0, "DELETE"))
                {
                    BindGrid_With_Data();   // REFRESH THE GRIDVIEW.
                }
            }
        }

        // PRIVATE FUNCTION THAT WILL DO "CRUD" OPERATION.
        // IT TAKES FOUR PARAMETERS FOR UPDATE, DELETE AND INSERT.
        // THE LAST PARAMETER "sOperation" IS THE TYPE OF OPERATION.

        private bool Perform_CRUD(int iServerID, string sStatus, string sServerName, string sEnvironment, string sActiveBookingID)
        {

            using (SqlConnection con = new SqlConnection(sCon))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM dbo.InfoServer"))
                {

                    cmd.Connection = con;
                    con.Open();

                    switch (Operation)
                    {
                        case "INSERT":
                            cmd.CommandText = "INSERT INTO dbo.InfoServer (Status, ServerName, Environment) " + "VALUES(@Status, @ServerName, @Environment)";

                            cmd.Parameters.AddWithValue("@Satus", sStatus.Trim());
                            cmd.Parameters.AddWithValue("@ServerName", sServerName.Trim());
                            cmd.Parameters.AddWithValue("@Environment", sEnvironment);

                            break;
                        case "UPDATE":
                            cmd.CommandText = "UPDATE dbo.Books SET BookName = @BookName, Category = @Category, " + "Price = @Price WHERE BookID = @BookID";

                            cmd.Parameters.AddWithValue("@Status", sStatus.Trim());
                            cmd.Parameters.AddWithValue("@ServerName", sServerName.Trim());
                            cmd.Parameters.AddWithValue("@Environment", sEnvironment);
                            cmd.Parameters.AddWithValue("@ServerID", ServerID);

                            break;
                        case "DELETE":
                            cmd.CommandText = "DELETE FROM dbo.InfoServer WHERE ServerID= @ServerID";
                            cmd.Parameters.AddWithValue("@ServerID", ServerID);
                            break;
                    }

                    cmd.ExecuteNonQuery();
                    Edit.EditIndex = -1;
                }
            }

            return true;
        }
    }
}
}