using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using ChocuModel;
namespace Project
{
    public partial class SignUp : System.Web.UI.Page
    {

        string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenUser"] != null)
            {
                Response.Redirect("/home");
            }
        }

        protected void SumbitBtn_Click(object sender , EventArgs e)
        {
            SqlConnection connection = null;
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "disableButton", "$('.loginBtn').attr('disabled', '');", true);
                connection = new SqlConnection(connStr);
                String query = "INSERT INTO [users] ([username] , [password]) VALUES (@username,  @password)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@username", usernameTxt.Text));
                command.Parameters.Add(new SqlParameter("@password", passwordTxt.Text));

                connection.Open();
                command.ExecuteNonQuery();
                getUserJustCreated();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show message", "$('.popup').addClass(\"appear\");", true);
            } finally
            {
                connection.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "removeAttr", "$('.loginBtn').removeAttr('disabled');", true);
            }
        }

        private void getUserJustCreated()
        {
            SqlConnection connection = new SqlConnection(connStr); ;
            String query = "Select username , id from users where username = @username and password = @password";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(new SqlParameter("@username", usernameTxt.Text));
            cmd.Parameters.Add(new SqlParameter("@password", passwordTxt.Text));

            connection.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                User user = new User();
                user.ID = int.Parse(dr["id"].ToString());
                user.Username = dr["username"].ToString();
                Session["authenUser"] = user;
                Response.Redirect("/home");
            }

            connection.Close();
        }


    }
}