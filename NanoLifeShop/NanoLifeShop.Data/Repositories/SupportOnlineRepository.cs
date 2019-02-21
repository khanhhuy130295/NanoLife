using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;

namespace NanoLifeShop.Data.Repositories
{
    public interface ISupportOnlineRepository : IRepository<SupportOnline>
    {
    }

    public class SupportOnlineRepository : RepositoryBase<SupportOnline>, ISupportOnlineRepository
    {
        public SupportOnlineRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}