using ChocuModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Common : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            getUser();
        }


        private void getUser()
        {
            User user = Session["authenUser"] as User;
            if (user != null)
            {
                username.InnerHtml = user.Username;
                string url = "/user/avatar/" + user.ID;
                //href link to profile at navbar
                toProfile.Attributes["href"] = "/user/detail/" + user.ID;
                avatar.Attributes["style"] = "background-image: url(" + url + ")";
            }
            else
            {
                username.InnerHtml = "Login";
                dropdownMenuButton.Attributes["data-toggle"] = "";
                dropdownMenuButton.Attributes["href"] = "/login";
            }
        }

    





        protected void logout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["id"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/login");
        }


    }
}