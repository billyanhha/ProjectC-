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
            setSession();
            getUser();
        }

        public void setSession()
        {
            HttpCookie uid = Request.Cookies["id"];
            HttpCookie un = Request.Cookies["username"];
            if (Session["authenUser"] == null && uid != null && un != null)
            {
                string id = uid.Value;
                string us = un.Value;
                User user = new User();
                user.ID = int.Parse(id);
                user.Username = us;
                Session["authenUser"] = user;
            } 
        }

        private void getUser()
        {
            User user = Session["authenUser"] as User;
            if (user != null)
            {
                username.InnerHtml = user.Username;
                string url = "/user/avatar/" + user.ID;
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