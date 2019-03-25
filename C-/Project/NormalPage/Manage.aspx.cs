using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocuModel;

namespace Project.NormalPage
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!checkAuthor())
            {
                Response.Redirect("/error?message=No author");
            }
        }

        private bool checkAuthor()
        {

            if (Session["authenUser"] != null)
            {
                User user = Session["authenUser"] as User;
                return user.isAdmin;
            }

            return false;
        }

    }
}