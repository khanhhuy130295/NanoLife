using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Models.Entity
{
    [Table("FeedBacks")]
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        public string Messages { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool Status { get; set; }

    }
}
