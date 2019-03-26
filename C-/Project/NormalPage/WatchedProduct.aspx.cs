using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocuModel;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Project.NormalPage
{
    public partial class WatchedProduct : System.Web.UI.Page
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<String> getProductId()
        {
            if (Request.Cookies["cart"] != null)
            {
                HttpCookie cookie = Request.Cookies["cart"];
                List<String> list = new List<string>();
                list = cookie.Value.Split('-').ToList();
                list.RemoveAll(x => string.IsNullOrWhiteSpace(x) || string.IsNullOrEmpty(x));
                return list;
            }
            else
            {
                return null;
            }

        }

        public Product getProductById(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            SqlConnection connection = new SqlConnection(connStr);
            try
            {

                string query = @"SELECT [product_name]
                      ,[price]
                  FROM [dbo].[products]
                  Where product_id = @id and active = 1";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("@id", id));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.productName = reader["product_name"].ToString();
                    product.price = Convert.ToDouble(reader["price"].ToString());
                    return product;
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

            return null;

        }
    }
}