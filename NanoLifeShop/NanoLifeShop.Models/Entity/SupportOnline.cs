using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NanoLifeShop.Models.Entity
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Department { get; set; }

        public string Address { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Skype { get; set; }

        [MaxLength(50)]
        public string Facebook { get; set; }

        [MaxLength(50)]
        public string Mobile { get; set; }

        [DefaultValue(0)]
        public double? Lng { get; set; }

        [DefaultValue(0)]
        public double? Lat { get; set; }

        public int DisplayOder { get; set; }

        public bool Status { get; set; }
    }
}