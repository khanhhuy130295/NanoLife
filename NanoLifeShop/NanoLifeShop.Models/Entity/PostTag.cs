using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanoLifeShop.Models.Entity
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(Order = 1)]
        public int IDPost { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "varchar")]
        public string IDTag { get; set; }

        [ForeignKey("IDPost")]
        public virtual Post Post { get; set; }

        [ForeignKey("IDTag")]
        public virtual Tag Tag { get; set; }
    }
}