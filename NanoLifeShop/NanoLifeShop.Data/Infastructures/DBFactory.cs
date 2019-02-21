using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Data.Infastructures
{
    public class DBFactory : Disposable, IDBFactory
    {
        private NanoLifeShopDBContext dBContext;
        /// <summary>
        /// Initialize DB 
        /// </summary>
        /// <returns></returns>
        public NanoLifeShopDBContext Initialize()
        {
            return dBContext ?? (dBContext = new NanoLifeShopDBContext());
        }

        protected override void DisposeCore()
        {
            if (dBContext != null)
            {
                dBContext.Dispose();
            }
        }
    }
}
