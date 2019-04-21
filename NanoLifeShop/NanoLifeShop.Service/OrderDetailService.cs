using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Data.Repositories;
using NanoLifeShop.Models.Entity;
using System.Collections.Generic;

namespace NanoLifeShop.Service
{
    public interface IOrderDetailService
    {
        OrderDetail Add(OrderDetail orderDetail);

        void Update(OrderDetail orderDetail);

        OrderDetail Delete(int ID);

        IEnumerable<OrderDetail> GetAll();

        IEnumerable<OrderDetail> GetAll(int idOrder);

        IEnumerable<OrderDetail> GetParent();

        IEnumerable<OrderDetail> GetMultiPaging(int pageIndex, int pageSize, out int total, int idOrder);

        OrderDetail GetSingleByID(int ID);

        void Save();
    }

    public class OrderDetailDetailService : IOrderDetailService
    {
        private IOrderDetailRepository _orderDetailDetailRepository;
        private IUnitOfWork _unitOfWork;

        public OrderDetailDetailService(IOrderDetailRepository orderDetailDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderDetailDetailRepository = orderDetailDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public OrderDetail Add(OrderDetail OrderDetail)
        {
            return _orderDetailDetailRepository.Add(OrderDetail);
        }

        public OrderDetail Delete(int IDOrder)
        {
            return _orderDetailDetailRepository.Delete(IDOrder);
        }

        public IEnumerable<OrderDetail> GetAll(int idOrder)
        {
            if (idOrder > 0)
            {
                return _orderDetailDetailRepository.GetMulti(x => x.ID_Order == idOrder);
            }
            else
            {
                return _orderDetailDetailRepository.GetAll();
            }
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _orderDetailDetailRepository.GetAll();
        }

        public IEnumerable<OrderDetail> GetMultiPaging(int pageIndex, int pageSize, out int total, int idOrder)
        {
            return _orderDetailDetailRepository.GetMultiPaging(x => x.ID_Order == idOrder, out total, pageIndex, pageSize);
        }

        public IEnumerable<OrderDetail> GetParent()
        {
            return _orderDetailDetailRepository.GetMulti(x => x.Order != null);
        }

        public OrderDetail GetSingleByID(int ID)
        {
            return _orderDetailDetailRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(OrderDetail OrderDetail)
        {
            _orderDetailDetailRepository.Update(OrderDetail);
        }
    }
}