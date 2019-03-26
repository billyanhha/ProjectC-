using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocuModel;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace Project.NormalPage
{
    public partial class Home : System.Web.UI.Page
    {

        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        public CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
        public List<Category> categories;
        protected void Page_Load(object sender, EventArgs e)
        {
            categories = new List<Category>();
            Page.Title = "Home";
            categories = getCategory();
        }

        public List<Category> getCategory()
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                List<Category> categories = new List<Category>();

                string query = @"SELECT [category_id]
                              ,[category_name]
                          FROM [dbo].[category]
                          order by [category_id] desc";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Category category = new Category();
                    category.ID = reader["category_id"].ToString();
                    category.CategoryName = reader["category_name"].ToString();
                    categories.Add(category);
                }

                return categories;

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

        public List<Product> getProductByCategory(string id)
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                List<Product> products = new List<Product>();

                string query = @"SELECT Top(20) [products].product_id
                          ,[product_name]
                          ,[description]
                          ,[price]
                      FROM [dbo].[products] , products_category
                      where [products].product_id = products_category.product_id
                      and active = 1
                      And products_category.category_id = " + id +
                      "order by products.viewNumber desc" ;
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.id = reader["product_id"].ToString();
                    product.productName = reader["product_name"].ToString();
                    product.price = Convert.ToDouble(reader["price"].ToString());
                    products.Add(product);
                }

                return products;

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