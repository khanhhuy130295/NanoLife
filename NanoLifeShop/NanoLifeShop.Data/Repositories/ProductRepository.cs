using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Data.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {

    }
    public class ProductRepository:RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDBFactory dBFactory):base(dBFactory)
        {

        }
    }
}
