using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChocuModel
{
    public class Product
    {

        public string id { get; set; }
        public string productName { get; set; }

        public string createdBy { get; set; }

        public double price { get; set; }

        public string shipInfo { get; set; }

        public string category { get; set; }

        public string description { get; set; }

        public int totalImage { get; set; }
    }
}
