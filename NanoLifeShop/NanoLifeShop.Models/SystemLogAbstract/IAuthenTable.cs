using System;

namespace NanoLifeShop.Models.SystemLogAbstract
{
    internal interface IAuthenTable
    {
        string CreateBy { get; set; }

        DateTime? CreateDate { get; set; }

        string UpdateBy { get; set; }

        DateTime? UpdateDate { get; set; }

        string MetaTitle { get; set; }

        string MetaDecriptions { get; set; }

        string MetaKeyWork { get; set; }

        bool Status { get; set; }
    }
}