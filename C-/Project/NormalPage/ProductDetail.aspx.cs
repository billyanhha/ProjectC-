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
    public partial class ProductDetail : System.Web.UI.Page
    {

        private string connStr = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        private Product product;
        public string id;
        private string createdBy;
        protected void Page_Load(object sender, EventArgs e)
        {
            product = new Product();
            redirectIfUrlNotValid();
            loadProductInfo();
            editModal.product = product;
            deleteModal.createdBy = createdBy;
            deleteModal.id = id;
        }

        private void redirectIfUrlNotValid()
        {
            if (Page.RouteData.Values["id"] == null)
            {
                Response.Redirect("/error?message=404 Not found");
            }
        }

        private void loadItem()
        {
            if (Session["authenUser"] != null)
            {
                // add order button for login user
                order.Attributes["style"] = "display: block";

                User user = Session["authenUser"] as User;

                if (user.ID == int.Parse(createdBy)) // add edit icon to owner and remove order button
                {
                    order.Attributes["style"] = "display: none";
                    editProduct.Attributes["style"] = "display: block";
                }
            }
        }

        private bool checkAuthoriseForQuery()
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

        private void loadProductInfo()
        {
            id = Page.RouteData.Values["id"].ToString();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connStr);
                string query = "Select * from products where product_id = " + id + "and active = 1";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader rd = command.ExecuteReader();

                if (rd.HasRows)
                {
                    noProduct.Visible = false;
                    while (rd.Read())
                    {
                        getCategory();
                        //status intilialize
                        sold.Visible = false;
                        selling.Visible = true;

                        // get owner id
                        createdBy = rd["createdBy"].ToString();
                        increaseView();
                        loadItem();
                        loadOrderNumber();
                        // name
                        string product_name = rd["product_name"].ToString();
                        productName.InnerHtml = product_name;

                        // description
                        string description = rd["description"].ToString();
                        productDescription.InnerHtml = description;

                        // ship info
                        string ship = rd["ship_info"].ToString();
                        productShipInfo.InnerHtml = ship;

                        // ship info
                        string view = rd["viewNumber"].ToString();
                        productView.InnerHtml = view;

                        // status
                        bool status = Convert.ToBoolean(rd["status"]);
                        if (!status)
                        {
                            sold.Visible = true;
                            selling.Visible = false;
                        }

                        product.id = id;
                        product.createdBy = createdBy;
                        product.productName = product_name;
                        product.description = description;
                        product.shipInfo = ship;
                    }
                }
                else
                {
                    noProduct.Visible = true;
                    productDetail.Attributes["style"] = "display: none";
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

        private void increaseView()
        {
            if (!checkAuthoriseForQuery())
            {
                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(connStr);
                    string query = "Update products SET viewNumber = viewNumber + 1 Where product_id = " + id;
                    SqlCommand command = new SqlCommand(query, connection);
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
        }

        private void getCategory()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connStr);
                string query = "Select category_name , category.[category_id] from products , category , products_category where products.[product_id] = [products_category].[product_id] and category.[category_id] =  [products_category].[category_id] and products.[product_id] = " + id;
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string category = reader["category_name"].ToString();
                    string categoryId = reader["category_id"].ToString();
                    productCategory.InnerHtml = category;
                    product.category = categoryId;

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

        public int getProductImage()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connStr);
                string query = "SELECT count(product_id) as total FROM [dbo].[images] where product_id = " + id;
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int totalImage = int.Parse(reader["total"].ToString());
                    product.totalImage = totalImage;
                    return totalImage;
                }

                return 0;

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

        private void loadOrderNumber()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connStr);
                string query = "SELECT Count([order_id]) as productNumber FROM [dbo].[orders_products] where product_id =  " + id;
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productOrder.InnerHtml = reader["productNumber"].ToString() + " ";
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

        protected void switchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            if (checkAuthoriseForQuery())
            {
                try
                {
                    connection = new SqlConnection(connStr);
                    string query = "Update products Set status = status ^ 1 where product_id = " + id;
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    command.ExecuteNonQuery();
                    loadProductInfo();
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