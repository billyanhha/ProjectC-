using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocuModel;
using System.Web.Configuration;
using System.Data.SqlClient;


namespace Project.UserControl
{
    public partial class DeletProduct : System.Web.UI.UserControl
    {

        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        public string createdBy { get; set; }
        public string id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Boolean checkAuthor()
        {

            if (Session["authenUser"] != null)
            {
                User user = Session["authenUser"] as User;

                if (user.ID == int.Parse(createdBy))
                {
                    return true;
                }
            }

            return false;

        }

        protected void deleteButtonModal_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            if (checkAuthor())
            {
                try
                {
                    connection = new SqlConnection(connStr);
                    string query = "Update products Set active = 0 where product_id = " + id;
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    command.ExecuteNonQuery();

                    Response.Redirect("/home");

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
            else
            {
                Response.Redirect("/error?message=No authorise");

            }
        }
    }
}