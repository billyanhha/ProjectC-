using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using ChocuModel;

namespace Project.NormalPage
{
    public partial class Search : System.Web.UI.Page
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        private const int pageSize = 5;
        private const int gap = 2;
        private string textSearch;
        protected void Page_Load(object sender, EventArgs e)
        {
            textSearch = Request.QueryString["queryString"];
            if(string.IsNullOrEmpty(Request.QueryString["queryString"]))
            {
                Response.Redirect("/home");
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

                return Pagination.Pagger.generate(pageIndex, gap, maxPage, "/search?queryString="+textSearch , false);
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



                string query = @"SELECT Count([product_id]) as total From products
                      Where [product_name] like '%" + textSearch + "%'";
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

        public List<Product> getProductPerPage()
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

                string query = @"Select * From
                    (

                    Select ROW_NUMBER() over (order by [products].viewNumber desc) as rn,
                          [product_id]
                          ,[product_name]
                          ,[price]
	                      FROM [dbo].[products]
                      Where [product_name] like '%"+textSearch+@"%'
                    ) as x
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
    }
}