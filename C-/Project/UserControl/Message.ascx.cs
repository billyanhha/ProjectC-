using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.UserControl
{
    public partial class Message : System.Web.UI.UserControl
    {

        public string icname { get; set; }
        public string msg { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

                icon.Attributes["class"] += (" " + icname);
                message.InnerHtml = msg;

        }
    }
}