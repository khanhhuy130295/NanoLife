using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Data.Repositories
{
    public interface IPayMentMethodRepository : IRepository<PaymentMethod>
    {
         PaymentMethod GetSingleByID(string ID);

        PaymentMethod DeleteByPaymentMethod(PaymentMethod paymentMethod);
    }
    public class PayMentMethodRepository : RepositoryBase<PaymentMethod>, IPayMentMethodRepository
    {
        public PayMentMethodRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }

        public PaymentMethod DeleteByPaymentMethod(PaymentMethod paymentMethod)
        {
            return DbContext.PaymentMethods.Remove(paymentMethod);
        }

        public PaymentMethod GetSingleByID(string ID)
        {
            return DbContext.PaymentMethods.Find(ID);
        }
    }

}
