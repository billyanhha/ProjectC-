using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChocuModel
{
    public class Category
    {

        private string id;

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }


        public string ID
        {
            get { return id;; }
            set { id = value; }
        }


    }
}
