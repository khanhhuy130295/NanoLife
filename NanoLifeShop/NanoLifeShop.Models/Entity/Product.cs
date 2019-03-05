using NanoLifeShop.Models.SystemLogAbstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Models.Entity
{
    [Table("Products")]
    public class Product:AuthenTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public string Detail { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }


        public string MoreImage { get; set; }


        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warrnary { get; set; }

        public bool? IncludeTaxes { get; set; }

        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        [Required]
        public int IDCategory { get; set; }

        public string Tags { get; set; }

        [ForeignKey("IDCategory")]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual IEnumerable<ProductTag> ProductTags { get; set; }


    }
}
