using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using ChocuModel;
using System.IO;

namespace Project.NormalPage
{
    public partial class Profile : System.Web.UI.Page
    {

        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        public int id { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["id"] == null)
            {
                Response.Redirect("/error");
            }
            else
            {
                openChangeAvaModal.Visible = false;
                int fixId;
                bool tryParse = int.TryParse(Page.RouteData.Values["id"].ToString(), out fixId);
                if (tryParse && fixId > 0)
                {
                    id = fixId;
                    Page.Title = "Profile";
                    getUserData();
                    validateAuthorise();
                }
                else
                {
                    Response.Redirect("/error");
                }
            }
        }

        // check current user have authorise to make change to this profile
        private bool validateAuthorise()
        {
            rateDiv.Visible = false;
            settingIcon.Visible = false;
            User currentUser = Session["authenUser"] as User;
            if (currentUser != null && currentUser.ID == (id))
            {
                openChangeAvaModal.Visible = true;
                settingIcon.Visible = true;
                //disable rateDiv
                return true;
            }
            else if (currentUser != null && currentUser.ID != (id))
            {
                rateDiv.Visible = true;
            }
            return false;
        }

        // get user data
        private void getUserData()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connStr);
                String query = "Select username, fullname, address, description,joined, rate, rate_numbers from users where id = @id and active = 1";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@id", id));

                connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                // check if user available or not
                if (reader.HasRows)
                {
                    getUserAvatar();
                    getUserTotalProduct();
                    while (reader.Read())
                    {
                        string username = reader["username"].ToString();
                        usernameLabel.InnerHtml = username;

                        string fullname = (!string.IsNullOrEmpty(reader["fullname"].ToString())) ? 
                            reader["fullname"].ToString() : ("*This user didn't provide fullname yet");
                        fullnameLabel.InnerHtml = fullname;
                        joinedDateLabel.InnerHtml = Convert.ToDateTime(reader["joined"].ToString()).ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(reader["rate_numbers"].ToString()))
                        {
                            int rateScore = int.Parse(reader["rate"].ToString());
                            int rateNum = int.Parse(reader["rate_numbers"].ToString());
                            ratedLabel.InnerHtml = (rateNum != 0) ? (rateScore / rateNum + "rateNum") : ("N/A");
                        }
                        else
                        {
                            ratedLabel.InnerHtml = "N/A";
                        }
                    }
                }
                else
                {
                    Response.Redirect("/error?message=User not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        // get user avatar
        private void getUserAvatar()
        {
            string url = "/user/avatar/" + id;
            //user avatar
            bgAvatar.Attributes["style"] = "background-image: url(" + url + ")";
        }


        //get user total product
        private void getUserTotalProduct()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connStr);
                String query = "SELECT Count([product_id]) as Total FROM [dbo].[products] where createdBy = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@id", id));

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productLabel.InnerHtml = reader["Total"].ToString();
                    }
                }
                else
                {
                    productLabel.InnerHtml = reader["Total"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void changeAvaButton_Click(object sender, EventArgs e)
        {
            changeAvatar();
        }

        private void changeAvatar()
        {
            if (validateAuthorise())
            {
                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(connStr);
                    String query = "UPDATE [dbo].[users] SET [avatar] = @avatar ,  [contentType] = @contentType WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("@id", id));
                    //get image data
                    // The byte[] to save the data in
                    byte[] avatar = avatarFile.FileBytes;
                    command.Parameters.Add(new SqlParameter("@avatar", avatar));
                    string contentType = Path.GetExtension(avatarFile.FileName);
                    command.Parameters.Add(new SqlParameter("@contentType", contentType));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }


            }
        }
    }
}