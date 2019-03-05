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
    public interface IOrderDetailService
    {
        OrderDetail Add(OrderDetail orderDetail);

        void Update(OrderDetail orderDetail);

        OrderDetail Delete(int ID);

        IEnumerable<OrderDetail> GetAll();

        IEnumerable<OrderDetail> GetAll(string keyword);

        IEnumerable<OrderDetail> GetParent();

        IEnumerable<OrderDetail> GetMultiPaging(int pageIndex, int pageSize, out int total);

        OrderDetail GetSingleByID(int ID);

        void Save();
    }
    public class OrderDetailDetailService : IOrderDetailService
    {
        IOrderDetailRepository _orderDetailDetailRepository;
        IUnitOfWork _unitOfWork;
        public OrderDetailDetailService(IOrderDetailRepository orderDetailDetailRepository,IUnitOfWork unitOfWork)
        {
            this._orderDetailDetailRepository = orderDetailDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public OrderDetail Add(OrderDetail OrderDetail)
        {
            return _orderDetailDetailRepository.Add(OrderDetail);
        }

        public OrderDetail Delete(int ID)
        {
            return _orderDetailDetailRepository.Delete(ID);
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _orderDetailDetailRepository.GetAll();
        }

        public IEnumerable<OrderDetail> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _orderDetailDetailRepository.GetMulti(x => x.Order.CustomerName.Contains(keyword)||x.Product.Name.Contains(keyword));
            }
            else
            {
                return _orderDetailDetailRepository.GetAll();
            }
        }

        public IEnumerable<OrderDetail> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _orderDetailDetailRepository.GetMultiPaging(x => x.Order != null, out total, pageIndex, pageSize);
        }

        public IEnumerable<OrderDetail> GetParent()
        {
            return _orderDetailDetailRepository.GetMulti(x => x.Order  != null);
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
