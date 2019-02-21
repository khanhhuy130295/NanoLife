using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;

namespace NanoLifeShop.Data.Repositories
{
    public interface IMenuGroupRepository : IRepository<MenuGroup>
    {
    }

    public class MenuGroupRepository : RepositoryBase<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}