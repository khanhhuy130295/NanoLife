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
    public interface IOrderService
    {
        Order Add(Order order);

        void Update(Order order);

        Order Delete(int ID);

        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetAll(string keyword);

        IEnumerable<Order> GetParent();

        IEnumerable<Order> GetMultiPaging(int pageIndex, int pageSize, out int total);

        Order GetSingleByID(int ID);

        void Save();
    }
    public class OrderService: IOrderService
    {
        IOrderRepository _orderRepository;
        IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository orderRepository,IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._unitOfWork = unitOfWork;
        }

        public Order Add(Order order)
        {
            return _orderRepository.Add(order);
        }

        public Order Delete(int ID)
        {
            return _orderRepository.Delete(ID);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _orderRepository.GetMulti(x => x.CustomerName.Contains(keyword)||x.CustomerPhone.Contains(keyword));
            }
            else
            {
                return _orderRepository.GetAll();
            }
        }

        public IEnumerable<Order> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _orderRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public IEnumerable<Order> GetParent()
        {
            return _orderRepository.GetMulti(x => x.Status == true);
        }

        public Order GetSingleByID(int ID)
        {
            return _orderRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }

    }
}
