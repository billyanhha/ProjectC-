using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.NormalPage
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Error";
            if (!String.IsNullOrEmpty(Request.QueryString["message"]))
            {
                errMsg.InnerHtml = Request.QueryString["message"];
            }
        }
    }
}