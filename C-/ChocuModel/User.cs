using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChocuModel
{
    public class User
    {

        public int ID { get; set; }
        public String Username { get; set; }

        public String Fullname { get; set; }

        public String address { get; set; }
        public String phone { get; set; }
        public String Description { get; set; }
        public Boolean isActive { get; set; }
        public Boolean isAdmin { get; set; }
        public int rate { get; set; }
        public int rateNumber { get; set; }
    }
}
