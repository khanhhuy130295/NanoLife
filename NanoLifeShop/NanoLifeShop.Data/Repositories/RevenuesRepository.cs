using NanoLifeShop.Data.Infastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoLifeShop.Common.Models;
using System.Data.SqlClient;

namespace NanoLifeShop.Data.Repositories
{
    public interface IRevenuesRepository: IRepository<Revenues>
    {
        IEnumerable<Revenues> GetRevenueStatistic(string fromDate, string toDate);

    }
    public class RevenuesRepository: RepositoryBase<Revenues>, IRevenuesRepository
    {
        public RevenuesRepository(IDBFactory dBFactory):base(dBFactory)
        {

        }

        public IEnumerable<Revenues> GetRevenueStatistic(string fromDate, string toDate)
        {
            var parameters = new SqlParameter[]{
               new SqlParameter("@fromDate",fromDate),
               new SqlParameter("@toDate",toDate)
            };
            var result = DbContext.Database.SqlQuery<Revenues>("GetRevenuesStatistic @fromDate,@toDate", parameters).AsQueryable();
            return result.ToList();
         }
    }
}
