using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Project.NormalPage
{
    public partial class ProductOrder : System.Web.UI.Page
    {

        private string id;

        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            redirectIfUrlNotValid();
        }

        public int getTotalOrderProduct()
        {
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                String query = @"SELECT Count([order_id]) as total
                  FROM[dbo].[orders_products]
                  where[product_id] = 45";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    return int.Parse(reader["total"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            } finally
            {
                connection.Close();
            }
            return 0;
        }

        private void redirectIfUrlNotValid()
        {
            if (Page.RouteData.Values["id"] == null)
            {
                Response.Redirect("/error?message=404 Not found");
            }
            else
            {
                id = Page.RouteData.Values["id"].ToString();
                HiddenField1.Value = id;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var hyperLink = e.Row.FindControl("HyperLink1") as HyperLink;
                if (hyperLink != null)
                    hyperLink.NavigateUrl = "/user/detail/" + DataBinder.Eval(e.Row.DataItem, "user_id");
            }
        }
    }
}