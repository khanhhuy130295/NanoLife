using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Models.Entity
{
    [Table("PaymentMethods")]
    public class PaymentMethod
    {
        [Key]
        [Column(TypeName = "varchar")]
        public string ID_PaymentMethod { get; set; }

        public string DisplayName { get; set; }

        [Required]
        public bool Status { get; set; }


        public IEnumerable<Order> orders { get; set; }
    }
}
