using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;

namespace NanoLifeShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {

    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}