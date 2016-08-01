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

                      
                        if (dt.Rows.Count != 0)     
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
                        
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        
        protected void InsertRecord(object sender, EventArgs e)
        {
            
            Button bt = (Button)sender;
            GridViewRow grdRow = (GridViewRow)bt.Parent.Parent;

            
            TextBox ServerID = (TextBox)grdRow.Cells[0].FindControl("ServerID");
            TextBox status = (TextBox)grdRow.Cells[0].FindControl("status");
            TextBox ServerName = (TextBox)grdRow.Cells[0].FindControl("ServerName");

            if (!string.IsNullOrEmpty(ServerID.Text.Trim()))
            {
                if (Perform_CRUD(0, ServerID.Text, status.Text, ServerName.Text, "INSERT"))
                {
                    BindGrid_With_Data(); 
                }
            }
        }

        private bool Perform_CRUD(int v1, string text1, string text2, string text3, string v2)
        {
            throw new NotImplementedException();
        }

        protected void Edit_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
           
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

       
        private bool Perform_CRUD(int v1, string v2, string v3, int v4, string v5)
        {
            throw new NotImplementedException();
        }


        private bool Perform_CRUD(int iServerID, string sStatus, string sServerName, string sEnvironment, string sActiveBookingID, string sOperation)
        {

            using (SqlConnection con = new SqlConnection(sCon))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM dbo.InfoServer"))
                {

                    cmd.Connection = con;
                    con.Open();

                    switch (sOperation)
                    {
                        case "INSERT":
                            cmd.CommandText = "INSERT INTO dbo.InfoServer (Status, ServerName, Environment) " + "VALUES(@Status, @ServerName, @Environment)";

                            cmd.Parameters.AddWithValue("@Satus", sStatus.Trim());
                            cmd.Parameters.AddWithValue("@ServerName", sServerName.Trim());
                            cmd.Parameters.AddWithValue("@Environment", sEnvironment);

                            break;
                        case "UPDATE":
                            cmd.CommandText = "UPDATE dbo.InfoServer SET ServerID = @ServerID, Status= @Status,  " + "Price = @Price WHERE BookID = @BookID";

                            cmd.Parameters.AddWithValue("@Status", sStatus.Trim());
                            cmd.Parameters.AddWithValue("@ServerName", sServerName.Trim());
                            cmd.Parameters.AddWithValue("@Environment", sEnvironment);
                            cmd.Parameters.AddWithValue("@ServerID", iServerID);

                            break;
                        case "DELETE":
                            cmd.CommandText = "DELETE FROM dbo.InfoServer WHERE ServerID= @ServerID";
                            cmd.Parameters.AddWithValue("@ServerID", iServerID);
                            break;
                    }

                    cmd.ExecuteNonQuery();
                    Edit.EditData = -1;
                }
            }

            return true;
        }
    }
}
