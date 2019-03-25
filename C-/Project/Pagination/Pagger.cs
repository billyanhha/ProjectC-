using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Pagination
{
    public class Pagger
    {

        public static String generate(int pageIndex, int gap, int maxPage, String currentUrl , bool isFirstQuery)
        {

            string query = isFirstQuery ? "?page=" : "&page=";

            String result = "";

            if(pageIndex < 0 || pageIndex > maxPage)
            {
                return result;
            }

            if (pageIndex > gap + 1)
            {
                result += BaseWebComponent.generateHyperlink(currentUrl + query +"1", "First");
            }
            for (int i = pageIndex - gap; i < pageIndex; i++)
            {
                if (i > 0)
                    result += BaseWebComponent.generateHyperlink(currentUrl + query + i, i + "");
            }
            result += BaseWebComponent.generateTextBase("" + pageIndex);
            for (int i = pageIndex + 1; i <= pageIndex + gap; i++)
            {
                if (i <= maxPage)
                    result += BaseWebComponent.generateHyperlink(currentUrl + query + i, i + "");
            }

            if (pageIndex < maxPage - gap)
            {
                result += BaseWebComponent.generateHyperlink(currentUrl + query + maxPage, "Last");
            }
            return result;
        }

    }
}