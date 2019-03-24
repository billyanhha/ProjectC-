using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocuModel;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

namespace Project.UserControl
{
    public partial class EditProduct : System.Web.UI.UserControl
    {

        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        public Product product { get; set; }
        SqlConnection connection;


        public EditProduct()
        {
            connection = new SqlConnection(connStr);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadData();
            }
        }


        private void loadData()
        {
            if (product != null)
            {
                productName.Text = product.productName;
                productDes.Text = product.description;
                price.Text = product.price + "";
                shipInfo.Text = product.shipInfo;
                categoryDropDown.SelectedValue = product.category;
            }
        }

        private Boolean checkAuthor()
        {

            if (Session["authenUser"] != null)
            {
                User user = Session["authenUser"] as User;

                if (user.ID == int.Parse(product.createdBy))
                {
                    return true;
                }
            }

            return false;

        }


        protected void editProductBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (!checkAuthor())
                {
                    Response.Redirect("/error?message=No authorise");
                }
                else
                {
                    editInfo();
                    editCategory();
                    editImage();
                    Response.Redirect("/product/detail/" + product.id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void editInfo()
        {
            try
            {
                String query = "Update [dbo].[products] Set [product_name] = @name,[description] = @des,[ship_info] = @info , price = @price Where products.[product_id] = " + product.id;
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@name", productName.Text));
                command.Parameters.Add(new SqlParameter("@des", productDes.Text));
                command.Parameters.Add(new SqlParameter("@info", shipInfo.Text));
                command.Parameters.Add(new SqlParameter("@price", price.Text));


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


        private void editCategory()
        {
            try
            {
                String query = "UPDATE [dbo].[products_category] Set [category_id] = @cid Where [product_id] = @pid ";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@cid", categoryDropDown.SelectedValue));
                command.Parameters.Add(new SqlParameter("@pid", product.id));

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

        private void editImage()
        {
            try
            {
                String query = "";
                if (fileImages.HasFiles)
                {
                    query += "Delete From [dbo].[images] where product_id = " + product.id;
                    query += "\n";
                    int index = 0;
                    foreach (HttpPostedFile uploadedFile in fileImages.PostedFiles)
                    {
                        index++;
                        query += "INSERT INTO [dbo].[images] ([image_data] , [contentType] , [product_id] , [index]) VALUES (@data" + index + ", @type" + index + " , @id" + index + " , @index" + index + " ) \n";

                    }

                    SqlCommand command = new SqlCommand(query, connection);

                    int index1 = 0;
                    foreach (HttpPostedFile uploadedFile in fileImages.PostedFiles)
                    {
                        index1++;
                        byte[] data = null;
                        using (var binaryReader = new BinaryReader(uploadedFile.InputStream))
                        {
                            data = binaryReader.ReadBytes(uploadedFile.ContentLength);
                        }


                        string mimeType = Path.GetExtension(uploadedFile.FileName);

                        command.Parameters.Add(new SqlParameter("@data" + index1, data));
                        command.Parameters.Add(new SqlParameter("@type" + index1, mimeType));
                        command.Parameters.Add(new SqlParameter("@id" + index1, product.id));
                        command.Parameters.Add(new SqlParameter("@index" + index1, index1));

                    }

                    connection.Open();
                    command.ExecuteNonQuery();
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

    }
}