using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using ChocuModel;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;


namespace Project
{
    public partial class Login : System.Web.UI.Page
    {

        private String connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["authenUser"] != null)
            {
                Response.Redirect("/home");
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disableButton", "$('.loginBtn').attr('disabled', '');", true);
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                String query = "Select username , id, active, isAdmin from users where username = @username and password = @password and ban = 0";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@username" , usernameTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@password", passwordTxt.Text));

                connection.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if(!dr.HasRows)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "show message", "$('.popup').addClass(\"appear\");", true);
                }
                else
                {
                    while (dr.Read())
                    {
                        User user = new User();
                        user.ID = int.Parse(dr["id"].ToString());
                        user.Username = dr["username"].ToString();
                        user.isAdmin = Convert.ToBoolean(dr["isAdmin"].ToString());
                        Session["authenUser"] = user;

                        if (dr["active"].ToString() == "False")
                        {
                            backtoActive(user.ID);
                        }

                        //set cookie
                        setCookie(user.ID , user.Username , user.isAdmin);
                        Response.Redirect(getRedirectUrl());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "removeAttr", "$('.loginBtn').removeAttr('disabled');", true);
                connection.Close();
            }
        }

        private string getRedirectUrl()
        {
            if(string.IsNullOrEmpty(Request.QueryString["fallbackUrl"]))
            {
                return "/home";
            } else
            {
                return Request.QueryString["fallbackUrl"];
            }
        }

        private void backtoActive(int id)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connStr);

                String query = "UPDATE [dbo].[users] SET " + " active = 1 " + "WHERE id = " + id;
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                command.ExecuteNonQuery();

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


        private void setCookie(int id , string username, bool isAdmin)
        {
            if(rembemberCb.Checked)
            {
                HttpCookie uid = new HttpCookie("id");
                uid.Value = id + "";
                uid.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(uid);


                HttpCookie un = new HttpCookie("username");
                un.Value = username;
                un.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(un);


                HttpCookie author = new HttpCookie("isAdmin");
                author.Value = isAdmin + "";
                author.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(author);
            }
        }

    }
}