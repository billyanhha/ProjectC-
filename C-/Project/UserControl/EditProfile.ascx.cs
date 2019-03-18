using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocuModel;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Project.UserControl
{
    public partial class EditProfile : System.Web.UI.UserControl
    {

        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getEditData();
            }
        }

        private void getEditData()
        {
            SqlConnection connection = null;
            try
            {
                User currentUser = Session["authenUser"] as User;

                connection = new SqlConnection(connStr);
                String query = "Select fullname, description, phoneNumber, address from users where id = @id and active = 1";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@id", currentUser.ID));

                connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                // check if user available or not
                while (reader.Read())
                {
                    string fn = (!string.IsNullOrEmpty(reader["fullname"].ToString())) ?
                           reader["fullname"].ToString() : ("Add your fullname");
                    fullname.Attributes["placeholder"] = fn;


                    des.Attributes["placeholder"] = (!string.IsNullOrEmpty(reader["description"].ToString())) ?
                        reader["description"].ToString() : ("Add something about you");

                    phoneTxt.Attributes["placeholder"] = (!string.IsNullOrEmpty(reader["phoneNumber"].ToString())) ?
                        reader["phoneNumber"].ToString() : ("Add your phone");

                    addressTxt.Attributes["placeholder"] = (!string.IsNullOrEmpty(reader["address"].ToString())) ?
                        reader["address"].ToString() : ("Add your address");
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

        private void editProfile()
        {
            if (!string.IsNullOrEmpty(fullname.Text) || !string.IsNullOrEmpty(des.Text) || !string.IsNullOrEmpty(phoneTxt.Text)
                || !string.IsNullOrEmpty(addressTxt.Text))
            {


                SqlConnection connection = null;
                try
                {
                    User currentUser = Session["authenUser"] as User;

                    connection = new SqlConnection(connStr);

                    String data = "";

                    List<String> querySet = new List<String>();
                    if (!string.IsNullOrEmpty(fullname.Text))
                    {
                        querySet.Add(" fullname =  " + "'" + fullname.Text + "'");
                    }

                    if (!string.IsNullOrEmpty(des.Text))
                    {
                        querySet.Add(" description =  " + "'" + des.Text + "'");
                    }

                    if (!string.IsNullOrEmpty(phoneTxt.Text))
                    {
                        querySet.Add(" phoneNumber =  " + "'" + phoneTxt.Text + "'");
                    }

                    if (!string.IsNullOrEmpty(addressTxt.Text))
                    {
                        querySet.Add(" address =  " + "'" + addressTxt.Text + "'");
                    }

                    for (int i = 0; i < querySet.Count; i++)
                    {
                        if (i < querySet.Count - 1)
                        {
                            data += querySet[i] + " , ";
                        }
                        else
                        {
                            data += querySet[i];
                        }
                    }

                    String query = "UPDATE [dbo].[users] SET " + data + "WHERE id = " + currentUser.ID;
                    SqlCommand command = new SqlCommand(query, connection);
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

        protected void edit(object sender, EventArgs e)
        {
            editProfile();
        }
    }
}