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
    public partial class Categories : System.Web.UI.Page
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        public string id { get; set; }
        public string category { get; set; }

        private const int pageSize = 30;

        public List<Category> categories;

        protected void Page_Load(object sender, EventArgs e)
        {
            redirectIfUrlNotValid();
            categories = getCategory();

        }

        private void redirectIfUrlNotValid()
        {
            if (Page.RouteData.Values["id"] == null || Page.RouteData.Values["name"] == null)
            {
                Response.Redirect("/error");
            }
            else if (!(Page.RouteData.Values["id"] == null || Page.RouteData.Values["name"] == null))
            {
                id = Page.RouteData.Values["id"].ToString();
                category = Page.RouteData.Values["name"].ToString();
                Page.Title = category;

            }
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


        public List<Product> getProductByCategory()
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {

                string page = "";
                if (string.IsNullOrEmpty(Request.QueryString["page"]))
                {
                    page = "1";
                }
                else
                {
                    page = Request.QueryString["page"];
                }
                int pageIndex = int.Parse(page);

                int pageStartIndex = pageSize * (pageIndex - 1) + 1;
                int pageEndIndex = pageSize * (pageIndex);

                List<Product> products = new List<Product>();

                string query = @"Select * from (

                        Select ROW_NUMBER() over (order by products.viewNumber desc) as rn ,
                        [products].product_id
                              ,[product_name]
                              ,[description]
                              ,[price]
                          FROM [dbo].[products] , products_category
                          where [products].product_id = products_category.product_id
                      And products.active = 1
                          And products_category.category_id = " + id +
                          @") as x
                                            Where rn between @start and @end
                             ";


                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                command.Parameters.Add(new SqlParameter("@start", pageStartIndex));
                command.Parameters.Add(new SqlParameter("@end", pageEndIndex));

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

        public string generatePagination()
        {
            try
            {
                string page = "";
                if (string.IsNullOrEmpty(Request.QueryString["page"]))
                {
                    page = "1";
                }
                else
                {
                    page = Request.QueryString["page"];
                }
                int pageIndex = int.Parse(page);

                int gap = 2;
                int totalPage = getTotalProductPerCategory();
                int maxPage = totalPage / pageSize + (totalPage % pageSize == 0 ? 0 : 1);

                if (maxPage == 1)
                {
                    return "";
                }

                return Pagination.Pagger.generate(pageIndex, gap, maxPage, "/category/" + id + "/" + category);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public int getTotalProductPerCategory()
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {



                string query = @"SELECT Count([products].product_id) as total
                      FROM [dbo].[products] , products_category
                      where [products].product_id = products_category.product_id
                      And products.active = 1
                      And products_category.category_id = " + id;
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return int.Parse(reader["total"].ToString());
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
            return 0;
        }

    }
}