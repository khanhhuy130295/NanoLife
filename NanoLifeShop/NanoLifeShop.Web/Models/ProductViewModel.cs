using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanoLifeShop.Web.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }


        public string Description { get; set; }

        public string Detail { get; set; }


        public string Image { get; set; }


        public string MoreImage { get; set; }


        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warrnary { get; set; }

        public bool? IncludeTaxes { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescriptions { get; set; }

        public string MetaKeyWord { get; set; }

        public bool Status { get; set; }

        public int IDCategory { get; set; }

        public string Tags { get; set; }


        public virtual ProductCategoryViewModel ProductCategory { get; set; }

        public virtual IEnumerable<ProductTagViewModel> ProductTags { get; set; }
    }
}