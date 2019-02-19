using System;
using System.ComponentModel.DataAnnotations;

namespace NanoLifeShop.Models.SystemLogAbstract
{
    public abstract class AuthenTable : IAuthenTable
    {
        [MaxLength(256)]
        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        [MaxLength(256)]
        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDecriptions { get; set; }

        public string MetaKeyWork { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}