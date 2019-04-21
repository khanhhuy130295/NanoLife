using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanoLifeShop.Web.Models
{
    public class SupportOnlineViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Skype { get; set; }

        public string Facebook { get; set; }

        public string Mobile { get; set; }

        public double? Lng { get; set; }

        public double? Lat { get; set; }

        public int DisplayOder { get; set; }

        public bool Status { get; set; }
    }
}