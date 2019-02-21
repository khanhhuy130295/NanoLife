using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;

namespace NanoLifeShop.Data.Repositories
{
    public interface ISlideRepository : IRepository<Slide>
    {
    }

    public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
    {
        public SlideRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}