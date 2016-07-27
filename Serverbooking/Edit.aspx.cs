using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



namespace Serverbooking
{
    public partial class Edit : System.Web.UI.Page
    {
        string sCon = "Data Source=DNA;Persist Security Info=False;" +
     "Initial Catalog=DNA_Classified;User Id=sa;Password=;Connect Timeout=30;";

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
                            GridView1.DataBind();
                        }
                        else
                        {
                            // CREATE A BLANK ROW IF THE BOOKS TABLE IS EMPTY.

                            DataRow aBlankRow = dt.NewRow();
                            dt.Rows.Add(aBlankRow);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            // SHOW A SINGLE COLUMN WITH A MESSAGE.
                            int col = GridView1.Rows[0].Cells.Count;
                            GridView1.Rows[0].Cells.Clear();
                            GridView1.Rows[0].Cells.Add(new TableCell());
                            GridView1.Rows[0].Cells[0].ColumnSpan = col;
                            GridView1.Rows[0].Cells[0].Text = "Table is Empty";
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
            TextBox tbBookName = (TextBox)grdRow.Cells[0].FindControl("tbBookName");
            TextBox tbCategory = (TextBox)grdRow.Cells[0].FindControl("tbCategory");
            TextBox tbPrice = (TextBox)grdRow.Cells[0].FindControl("tbPrice");

            if (!string.IsNullOrEmpty(tbBookName.Text.Trim()))
            {
                if (Perform_CRUD(0, tbBookName.Text, tbCategory.Text, double.Parse(tbPrice.Text), "INSERT"))
                {
                    BindGrid_With_Data();    // REFRESH THE GRIDVIEW.
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            // GRIDVIEW PAGING.
            Edit.PageIndex = e.NewPageIndex;
            BindGrid_With_Data();
        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid_With_Data();
        }

        protected void GridView_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid_With_Data();
        }

        // EXTRACT DETAILS FOR UPDATING.
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            Label lblBookID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblBookID");
            TextBox tbBookName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("tbEd_Book");
            TextBox tbCategory = (TextBox)GridView1.Rows[e.RowIndex].FindControl("tbEd_Cate");
            TextBox tbPrice = (TextBox)GridView1.Rows[e.RowIndex].FindControl("tbEd_Price");

            if (int.Parse(lblBookID.Text) != 0)
            {
                if (Perform_CRUD(int.Parse(lblBookID.Text), tbBookName.Text, tbCategory.Text, double.Parse(tbPrice.Text), "UPDATE"))
                {
                    BindGrid_With_Data();       // REFRESH THE GRIDVIEW.
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            Label lblBookID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblBookID");

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

        private bool Perform_CRUD(int iBookID, string sBookName, string sCategory, double dPrice, string sOperation)
        {

            using (SqlConnection con = new SqlConnection(sCon))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *FROM dbo.Books"))
                {

                    cmd.Connection = con;
                    con.Open();

                    switch (sOperation)
                    {
                        case "INSERT":
                            cmd.CommandText = "INSERT INTO dbo.Books (BookName, Category, Price) " + "VALUES(@BookName, @Category, @Price)";

                            cmd.Parameters.AddWithValue("@BookName", sBookName.Trim());
                            cmd.Parameters.AddWithValue("@Category", sCategory.Trim());
                            cmd.Parameters.AddWithValue("@Price", dPrice);

                            break;
                        case "UPDATE":
                            cmd.CommandText = "UPDATE dbo.Books SET BookName = @BookName, Category = @Category, " + "Price = @Price WHERE BookID = @BookID";

                            cmd.Parameters.AddWithValue("@BookName", sBookName.Trim());
                            cmd.Parameters.AddWithValue("@Category", sCategory.Trim());
                            cmd.Parameters.AddWithValue("@Price", dPrice);
                            cmd.Parameters.AddWithValue("@BookID", iBookID);

                            break;
                        case "DELETE":
                            cmd.CommandText = "DELETE FROM dbo.Books WHERE BookID = @BookID";
                            cmd.Parameters.AddWithValue("@BookID", iBookID);
                            break;
                    }

                    cmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                }
            }

            return true;
        }
    }
}
}