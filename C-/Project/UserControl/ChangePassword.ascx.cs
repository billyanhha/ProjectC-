using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Data.SqlClient;
using ChocuModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.UserControl
{
    public partial class ChangePassword : System.Web.UI.UserControl
    {

        string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void changePwBtn_Click(object sender, EventArgs e)
        {

            checkOldPassword();
        }

        private void checkOldPassword()
        {

            User currentUser = Session["authenUser"] as User;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "disableButton", "$('.changeBtn').attr('disabled', '');", true);
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                String query = "Select id from users where id = @id and password = @password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@id", currentUser.ID));
                cmd.Parameters.Add(new SqlParameter("@password", oldPassword.Text));

                connection.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "show message", "$('.popup').addClass(\"appear\");", true);
                }
                else
                {
                    changePsw();
                }
            }
            catch (Exception)
            {
                throw ;
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "removeAttr", "$('.changeBtn').removeAttr('disabled');", true);
                connection.Close();
            }
        }

        private void changePsw()
        {
            SqlConnection connection = null;
            try
            {
                User currentUser = Session["authenUser"] as User;

                connection = new SqlConnection(connStr);

                String query = "UPDATE [dbo].[users] SET " + " password = @password " + "WHERE id = " + currentUser.ID;
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@password", passwordTxt.Text));

                connection.Open();

                command.ExecuteNonQuery();

                Response.Redirect("/user/detail/" + currentUser.ID);
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
    }
}