using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanoLifeShop.Models.Entity
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        [Column(Order = 1)]
        public int IDProduct { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "varchar")]
        public string IDTag { get; set; }

        [ForeignKey("IDProduct")]
        public virtual Product Product { get; set; }

        [ForeignKey("IDTag")]
        public virtual Tag Tag { get; set; }
    }
}