using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocuModel;

namespace Project.NormalPage
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!checkAuthen())
            {
                Response.Redirect("/error?message=/No authen");
            } else
            {
                User user = Session["authenUser"] as User;
                UserId.Value = user.ID + "";
                if(user.isAdmin)
                {
                    Response.Redirect("/error?message=/No authen");
                }
            }
        }


        private bool checkAuthen()
        {

            if (Session["authenUser"] != null)
            {
                return true;
            }

            return false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var hyperLink = e.Row.FindControl("HyperLink1") as HyperLink;
                if (hyperLink != null)
                    hyperLink.NavigateUrl = "/product/detail/" + DataBinder.Eval(e.Row.DataItem, "product_id");
            }
        }
    }
}