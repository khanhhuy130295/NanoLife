using System.ComponentModel.DataAnnotations;

namespace NanoLifeShop.Web.Models
{
    public class MenuViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Target { get; set; }

        public int? DisplayOder { get; set; }

        public int IDGroup { get; set; }

        public bool Status { get; set; }

        public MenuGroupViewModel MenuGroups { get; set; }
    }
}