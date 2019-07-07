using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Models.Entity
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int ID_Order { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ID_Product { get; set; }
     
        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        [ForeignKey("ID_Product")]
        public virtual Product Product { get; set; }

        [ForeignKey("ID_Order")]
        public virtual Order Order { get; set; }
    }
}
