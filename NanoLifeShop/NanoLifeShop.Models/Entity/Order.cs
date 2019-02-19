using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Models.Entity
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(256)]
        [Required]
        public string CustomerName { get; set; }

        [MaxLength(200)]
        [Required]
        public string CustomerAddress { get; set; }

        [MaxLength(10)]
        [Required]
        public string CustomerPhone { get; set; }

        [MaxLength(150)]
        [Required]
        public string CustomerEmail { get; set; }

        [MaxLength(500)]
        [Required]
        public string CustomerMessages { get; set; }

        [MaxLength(256)]
        public string PaymentMethod { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public string PaymentStatus { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
