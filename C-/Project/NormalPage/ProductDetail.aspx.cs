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

        public string id { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            redirectIfUrlNotValid();
            loadItem();
        }

        private void redirectIfUrlNotValid()
        {
            if (Page.RouteData.Values["id"] == null)
            {
                Response.Redirect("/error?msg=404 Not found");
            }
            else
            {
                id = Page.RouteData.Values["id"].ToString();
            }
        }

        private void loadItem()
        {
            if (Session["authenUser"] != null)
            {
                // add order button for login user
                order.Attributes["style"] = "display: block";

                User user = Session["authenUser"] as User;

                if (user.ID != int.Parse(id)) // add edit icon to owner and remove order button
                {
                    order.Attributes["style"] = "display: none";
                    editProduct.Attributes["style"] = "display: block";
                }
            }
        }

        private void loadProductInfo()
        {
            SqlConnection connection = null;
            try
            {

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