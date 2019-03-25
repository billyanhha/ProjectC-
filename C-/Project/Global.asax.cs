using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using ChocuModel;

namespace Project
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }




        protected void PageRedirect()
        {
        }


        protected void Session_Start(object sender, EventArgs e)
        {
            HttpCookie uid = Request.Cookies["id"];
            HttpCookie un = Request.Cookies["username"];
            HttpCookie author = Request.Cookies["isAdmin"];
            if (Session["authenUser"] == null && uid != null && un != null && author != null)
            {
                string id = uid.Value;
                string us = un.Value;
                string au = author.Value;
                User user = new User();
                user.ID = int.Parse(id);
                user.Username = us;
                user.isAdmin = Convert.ToBoolean(au);
                Session["authenUser"] = user;
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}