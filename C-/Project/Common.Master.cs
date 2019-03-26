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

        public string searchTxt { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            getUser();
            cartnNumber.InnerHtml = getNumberOfCart() + "";
            if(!string.IsNullOrEmpty(searchTxt) && !IsPostBack)
            {
                searchField.Text = searchTxt;
            }
        }

        public int getNumberOfCart()
        {
            if (Request.Cookies["cart"] != null)
            {
                HttpCookie cookie = Request.Cookies["cart"];
                List<String> list = new List<string>();
                list = cookie.Value.Split('-').ToList();
                list.RemoveAll(x => string.IsNullOrWhiteSpace(x) || string.IsNullOrEmpty(x));
                return list.Count;
            }
            else
            {
                return 0;
            }

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
                if (user.isAdmin)
                {
                    noAdmin1.Visible = false;
                    noAdmin2.Visible = false;
                    noAdmin4.Visible = false;
                    noAdmin5.Visible = false;
                    noAdmin3.InnerHtml = "Manage users and products";
                    noAdmin3.Attributes["href"] = "/admin/manage";
                }
            }
            else
            {
                username.InnerHtml = "Login";
                dropdownMenuButton.Attributes["data-toggle"] = "";
                string fallbackUrl = Page.Request.Url.ToString().Contains("error") ? "/home" : Page.Request.Url.ToString();
                dropdownMenuButton.Attributes["href"] = "/login?fallbackUrl=" + fallbackUrl;
            }
        }

    

        protected void logout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["id"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["isAdmin"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/login");
        }

        protected void hiddenSearchBtn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(searchField.Text))
            {
                Response.Redirect("/search?queryString=" + searchField.Text);
            }
        }
    }
}