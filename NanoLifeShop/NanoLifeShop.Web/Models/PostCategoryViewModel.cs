using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanoLifeShop.Web.Models
{
    public class PostCategoryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int? IdParent { get; set; }

        public int? DisplayOder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescriptions { get; set; }

        public string MetaKeyWord { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<PostViewModel> Posts { get; set; }
    }
}