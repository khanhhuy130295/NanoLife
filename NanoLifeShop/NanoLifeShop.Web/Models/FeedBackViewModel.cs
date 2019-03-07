using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanoLifeShop.Web.Models
{
    public class FeedBackViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Messages { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool Status { get; set; }
    }
}