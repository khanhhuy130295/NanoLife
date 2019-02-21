using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;

namespace NanoLifeShop.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}