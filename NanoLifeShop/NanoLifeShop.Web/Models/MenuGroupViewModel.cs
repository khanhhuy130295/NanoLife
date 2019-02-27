using System.Collections.Generic;

namespace NanoLifeShop.Web.Models
{
    public class MenuGroupViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<MenuViewModel> Menus { get; set; }
    }
}