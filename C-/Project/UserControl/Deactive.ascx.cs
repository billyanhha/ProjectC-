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
    public partial class Deactive : System.Web.UI.UserControl
    {

        string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void deactiveAccount_Click(object sender, EventArgs e)
        {
            checkPass();
        }

        private void checkPass()
        {

            User currentUser = Session["authenUser"] as User;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "disableButton", "$('.changeBtn').attr('disabled', '');", true);
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                String query = "Select id from users where id = @id and password = @password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@id", currentUser.ID));
                cmd.Parameters.Add(new SqlParameter("@password", passwordDeactive.Text));

                connection.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "show message", "$('.popup').addClass(\"appear\");", true);
                }
                else
                {
                    deactive();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "removeAttr", "$('.changeBtn').removeAttr('disabled');", true);
                connection.Close();
            }
        }

        private void deactive()
        {
            SqlConnection connection = null;
            try
            {
                User currentUser = Session["authenUser"] as User;

                connection = new SqlConnection(connStr);

                String query = "UPDATE [dbo].[users] SET " + " active = 0 " + "WHERE id = " + currentUser.ID;
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                command.ExecuteNonQuery();

                // logout after deactive
                logout();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        protected void logout()
        {
            Session.Abandon();
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["id"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/login");
        }
    }
}