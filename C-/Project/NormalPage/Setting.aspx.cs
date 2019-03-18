using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocuModel;

namespace Project.NormalPage
{
    public partial class Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && checkAuthen())
            {
                SettingView.ActiveViewIndex = 0;
                Menu1.Items[0].Selected = true;
            }
            else if(!checkAuthen()) {
                Response.Redirect("/error?message=No authorization");
            }
        }

        private bool checkAuthen()
        {
            User currentUser = Session["authenUser"] as User;
            if (currentUser == null)
            {
                return false;
            }
            return true;
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = int.Parse(e.Item.Value);
            SettingView.ActiveViewIndex = index;
        }
    }
}