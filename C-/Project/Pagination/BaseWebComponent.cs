using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Pagination
{
    public class BaseWebComponent
    {

        public static String generateHyperlink(String url, String label)
        {
            return "<a style=\"margin-right: 10px  ; font-weight: bold ; color:#bababa\" href=\"" + url + "\">" + label + "</a>";
        }

        public static String generateTextBase(String text)
        {
            return "<span style=\"margin-right: 10px ; font-weight: bold ; \" >" + text + "</span>";
        }

    }
}