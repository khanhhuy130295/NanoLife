using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanoLifeShop.Web.Models
{
    public class SlideViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public int DisplayOder { get; set; }

        public bool Status { get; set; }
    }
}