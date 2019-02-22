
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Data.Infastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDBFactory dBFactory;

        private NanoLifeShopDBContext dBContext;
       

        public UnitOfWork(IDBFactory dBFactory)
        {
            this.dBFactory = dBFactory;
        }

       
        public NanoLifeShopDBContext DbContext
        {
            get { return dBContext ?? (dBContext = dBFactory.Initialize()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}