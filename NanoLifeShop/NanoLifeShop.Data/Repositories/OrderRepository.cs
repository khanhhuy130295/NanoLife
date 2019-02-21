using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Data.Repositories
{
    public interface  IOrderRepository : IRepository<Order>
    {

    }
  public  class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDBFactory dBFactory):base(dBFactory)
        {

        }
    }
}
