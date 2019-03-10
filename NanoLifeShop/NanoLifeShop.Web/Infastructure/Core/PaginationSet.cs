using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanoLifeShop.Web.Infastructure.Core
{
    public class PaginationSet<T>
    {
        /// <summary>
        /// page index
        /// </summary>
        public int Page { get; set; }

        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// pageSize
        /// </summary>
        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        /// <summary>
        /// Total pages math
        /// </summary>
        public int TotalPages { get; set; }


        public int MaxPage { set; get; }

        /// <summary>
        /// Total record of table
        /// </summary>
        public int TotalCount { get; set; }

    }
}