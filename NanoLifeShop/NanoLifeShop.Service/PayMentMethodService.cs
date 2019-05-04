using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Data.Repositories;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Service
{
    public interface IPayMentMethodService
    {
        PaymentMethod Add(PaymentMethod paymentMethod);

        void Update(PaymentMethod paymentMethod);

        PaymentMethod Delete(string ID);

        IEnumerable<PaymentMethod> GetAll();

        IEnumerable<PaymentMethod> GetAll(string keyword);

        IEnumerable<PaymentMethod> GetMultiPaging(int pageIndex, int pageSize, out int total);

        IEnumerable<PaymentMethod> ShowHomeData();

        IEnumerable<PaymentMethod> GetParent();

        PaymentMethod GetSingleByID(string ID);

        void Save();
    }
    public class PayMentMethodService : IPayMentMethodService
    {

        public IPayMentMethodRepository _payMentMethodRepository;

        public IUnitOfWork _unitOfWork;

        public PayMentMethodService(IPayMentMethodRepository payMentMethodRepository, IUnitOfWork unitOfWork)
        {
            this._payMentMethodRepository = payMentMethodRepository;
            this._unitOfWork = unitOfWork;
        }

        public PaymentMethod Add(PaymentMethod paymentMethod)
        {
            return _payMentMethodRepository.Add(paymentMethod);
        }

        public PaymentMethod Delete(string ID)
        {
            var entity = _payMentMethodRepository.GetSingleByID(ID);
            return _payMentMethodRepository.DeleteByPaymentMethod(entity);
        }

        public IEnumerable<PaymentMethod> GetAll()
        {
            return _payMentMethodRepository.GetAll();
        }

        public IEnumerable<PaymentMethod> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _payMentMethodRepository.GetMulti(x => x.DisplayName.Contains(keyword));
            }
            else
            {
                return _payMentMethodRepository.GetAll();
            }
        }

        public IEnumerable<PaymentMethod> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            throw new NotImplementedException();
        }

        public PaymentMethod GetSingleByID(string ID)
        {
            return _payMentMethodRepository.GetSingleByID(ID);
        }


        public IEnumerable<PaymentMethod> GetParent()
        {
            return _payMentMethodRepository.GetMulti(x => x.Status == true);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<PaymentMethod> ShowHomeData()
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentMethod paymentMethod)
        {
            _payMentMethodRepository.Update(paymentMethod);
        }
    }
}
