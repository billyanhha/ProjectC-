using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using ChocuModel;
using System.Data;

namespace Project.NormalPage
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        public string uid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            handleIfNoAuthorise();
            if (!IsPostBack)
            {
                getUserOrder();
            }
        }

        private bool checkAuthen()
        {

            if (Session["authenUser"] != null)
            {
                return true;
            }

            return false;
        }

        private void handleIfNoAuthorise()
        {
            if (!checkAuthen())
            {
                Response.Redirect("/login?fallbackUrl=/order");
            }
            else
            {
                User user = Session["authenUser"] as User;
                uid = user.ID + "";
            }
        }

        private void getUserOrder()
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                String query = @"SELECT [orders].[order_id]
                      ,[ship_location]
                      ,[phoneContact]
                      ,[otherContact]
                  FROM [dbo].[orders] , orders_users
                  where [orders].[order_id]= orders_users.order_id
                  and active = 1
                  and orders_users.user_id =  " + uid;
                SqlDataAdapter adpater = new SqlDataAdapter(query, connection);
                connection.Open();
                DataTable table = new DataTable();
                adpater.Fill(table);
                if (table.Rows.Count == 0)
                {
                    noOrder.Attributes["style"] = "display: block;";
                }

                OrderList.DataSource = table;
                OrderList.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        protected void OrderList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                GridViewRow row = OrderList.Rows[e.RowIndex];
                int idx = Convert.ToInt32(OrderList.DataKeys[e.RowIndex].Value.ToString());
                string query = @"UPDATE [dbo].[orders]
                       SET[active] = 0
                     WHERE order_id = " + idx;
                SqlCommand comman = new SqlCommand(query, connection);
                connection.Open();
                comman.ExecuteNonQuery();
                getUserOrder();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        protected void OrderList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            OrderList.EditIndex = -1;
            getUserOrder();
        }

        protected void OrderList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                GridViewRow row = OrderList.Rows[e.RowIndex];
                int idx = Convert.ToInt32(OrderList.DataKeys[e.RowIndex].Value.ToString());
                TextBox ship = row.FindControl("TextBox1") as TextBox;
                TextBox phone = row.FindControl("TextBox2") as TextBox;
                TextBox other = row.FindControl("TextBox3") as TextBox;

                string query = @"UPDATE [dbo].[orders]
               SET [ship_location] = @ship
                  ,[phoneContact] = @phone
                  ,[otherContact] = @other
             WHERE [orders].order_id =  " + idx;
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@ship", ship.Text));
                command.Parameters.Add(new SqlParameter("@phone", phone.Text));
                command.Parameters.Add(new SqlParameter("@other", other.Text));

                connection.Open();
                command.ExecuteNonQuery();
                OrderList.EditIndex = -1;
                getUserOrder();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

        }

        protected void OrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OrderList.PageIndex = e.NewPageIndex;
            getUserOrder();
        }

        protected void OrderList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            OrderList.EditIndex = e.NewEditIndex;
            getUserOrder();
        }

    }
}