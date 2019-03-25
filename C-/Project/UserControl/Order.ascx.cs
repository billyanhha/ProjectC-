using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using ChocuModel;

namespace Project.UserControl
{
    public partial class Order : System.Web.UI.UserControl
    {

        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        private string orderId;
        public List<String> productIdList { get; set; }
        public string userId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitOrder_Click(object sender, EventArgs e)
        {
            if (checkAuthen())
            {
                addOrder();

            }
            else
            {
                Response.Redirect("/error?message=No authorise");
            }
        }

        private bool checkAuthen()
        {

            if (Session["authenUser"] != null)
            {
                User user = Session["authenUser"] as User;
                userId = user.ID + "";
                return true;
            }

            return false;
        }

        private void addOrder()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "addDisable", "$('.addOrderBtn').attr('disabled' , '');", true);
            try
            {
                addOrderInfo();
                addOrderProduct();
                addOrderUser();
                removeProductCart();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch (Exception)
            {
                throw;
            } finally
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "removeDisable", "$('.addOrderBtn').removeAttr('disabled');", true);
            }
        }

        private void addOrderInfo()
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                if (Page.IsValid)
                {
                    String query = @"INSERT INTO [dbo].[orders]
                           ([ship_location]
                           ,[phoneContact]
                           ,[otherContact]        
                           ,[status]
                           ,[active])
                           OUTPUT INSERTED.[order_id]
                     VALUES
                           (@location , @phone , @other , 0 , 1)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.Add(new SqlParameter("@location", location.Text));
                    command.Parameters.Add(new SqlParameter("@phone", phoneContact.Text));
                    command.Parameters.Add(new SqlParameter("@other", otherContact.Text));

                    connection.Open();
                    orderId = command.ExecuteScalar() + "";
                }
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


        private void addOrderProduct()
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                String query = "";
                foreach (String id in productIdList)
                {
                    query += @"INSERT INTO [dbo].[orders_products]
                               ([order_id]
                               ,[product_id])
                         VALUES
                               ("+ orderId + " , "  + id +") \n";
                }
                SqlCommand command = new SqlCommand(query, connection);


                connection.Open();
                command.ExecuteNonQuery();
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


        private void addOrderUser()
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                String query = @"INSERT INTO [dbo].[orders_users]
                           ([order_id]
                           ,[user_id])
                     VALUES
                               (" + orderId + " , " + userId + ") \n";

                SqlCommand command = new SqlCommand(query, connection);


                connection.Open();
                command.ExecuteNonQuery();
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

        private void removeProductCart()
        {
            Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-1);
        }
    }
}