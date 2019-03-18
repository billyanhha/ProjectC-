using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.NormalPage
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Profile";
            getUserAvatar();
        }

        private void getUserAvatar()
        {
            string id = Page.RouteData.Values["id"].ToString();
            string url = "/user/avatar/" + id;
            //user avatar
            bgAvatar.Attributes["style"] = "background-image: url(" + url + ")";
        }
    }
}