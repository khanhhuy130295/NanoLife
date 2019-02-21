using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Data.Repositories
{
    public interface ITagRepository: IRepository<Tag>
    {

    }
    public class TagRepository: RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDBFactory dBFactory):base(dBFactory)
        {

        }
    }
}
