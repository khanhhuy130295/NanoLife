using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Models.Entity
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Url { get; set; }

        [MaxLength(10)]
        public string Target { get; set; }

        public int? DisplayOder { get; set; }

        public int IDGroup { get; set; }

        [Required]
        public bool Status { get; set; }

        [ForeignKey("IDGroup")]
        public MenuGroup MenuGroups { get; set; }

    }
}
