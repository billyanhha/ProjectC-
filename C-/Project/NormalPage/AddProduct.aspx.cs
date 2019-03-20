using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocuModel;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace Project.NormalPage
{
    public partial class AddProduct : System.Web.UI.Page
    {

        public int uid { get; set; }
        public int insertId { get; set; }

        SqlConnection connection = null;

        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            redirect();
        }

        private void redirect()
        {
          
            if (checkAuthen())
            {
                uid = (currentUser.ID);
                // intilize connection
                connection = new SqlConnection(connStr);
            }
            else
            {
                Response.Redirect("/error?message=No authorization");
            }
        }

        private bool checkAuthen()
        {
            currentUser = Session["authenUser"] as User;
            if (currentUser != null)
            {
                return true;
            }
            return false;
        }

        

        protected void addProduct_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "disableButton", "$('.addProductBtn').attr('disabled', '');", true);
                if (Page.IsValid)
                {
                    insertInfo();
                    insertCategory();
                    insertImage();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "removeDisable", "$('.addProductBtn').removeAttr('disabled');", true);
            }
        }

        private void insertInfo()
        {
            try
            {
                String query = "INSERT  INTO [dbo].[products]([product_name],[description],[ship_info], createdBy) OUTPUT INSERTED.[product_id] VALUES(@name , @des, @info , @uid)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@name", productName.Text));
                command.Parameters.Add(new SqlParameter("@des", productDes.Text));
                command.Parameters.Add(new SqlParameter("@info", shipInfo.Text));
                command.Parameters.Add(new SqlParameter("@uid", uid));

                connection.Open();
                insertId = (int)command.ExecuteScalar();

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

        private void insertCategory()
        {
            try
            {
                String query = "INSERT INTO [dbo].[products_category] ([category_id],[product_id]) VALUES (@cid,@pid)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@cid", DropDownList1.SelectedValue));
                command.Parameters.Add(new SqlParameter("@pid", insertId));

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

        private void insertImage()
        {

            try
            {
                String query = "";
                if (fileImages.HasFiles)
                {
                    int index = 0;
                    foreach (HttpPostedFile uploadedFile in fileImages.PostedFiles)
                    {
                        index++;

                        query += "INSERT INTO [dbo].[images] ([image_data] , [contentType] , [product_id] , [index]) VALUES (@data" + index+ ", @type"+index+ " , @id" + index + " , @index" + index +  " ) \n";

                    }

                    SqlCommand command = new SqlCommand(query, connection);

                    int index1= 0;

                    foreach (HttpPostedFile uploadedFile in fileImages.PostedFiles)
                    {
                        index1++;
                        byte[] data = null;
                        using (var binaryReader = new BinaryReader(uploadedFile.InputStream))
                        {
                            data = binaryReader.ReadBytes(uploadedFile.ContentLength);
                        }


                        string mimeType = Path.GetExtension(uploadedFile.FileName);

                        command.Parameters.Add(new SqlParameter("@data"+index1 , data));
                        command.Parameters.Add(new SqlParameter("@type" + index1, mimeType));
                        command.Parameters.Add(new SqlParameter("@id" + index1, insertId));
                        command.Parameters.Add(new SqlParameter("@index" + index1, index1));

                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                }
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