using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Data.Repositories
{
    public interface IFeedBackRepository :IRepository<FeedBack>
    {

    }
    public class FeedBackRepository : RepositoryBase<FeedBack> ,IFeedBackRepository
    {
        public FeedBackRepository(IDBFactory dBFactory):base(dBFactory)
        {

        }
    }
}
