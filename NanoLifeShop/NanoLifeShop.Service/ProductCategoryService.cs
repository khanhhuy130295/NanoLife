using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Data.Repositories;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;

namespace NanoLifeShop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCate);

        void Update(ProductCategory productCate);

        ProductCategory Delete(int ID);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string keyword);

        IEnumerable<ProductCategory> GetParent();


        IEnumerable<ProductCategory> GetMultiPaging(int pageIndex, int pageSize, out int total);

        ProductCategory GetSingleByID(int ID);

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
      
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory productCate)
        {
            return _productCategoryRepository.Add(productCate);
        }

        public ProductCategory Delete(int ID)
        {
            return _productCategoryRepository.Delete(ID);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _productCategoryRepository.GetAll();
            }
        }

        public IEnumerable<ProductCategory> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _productCategoryRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public IEnumerable<ProductCategory> GetParent()
        {
            return _productCategoryRepository.GetMulti(x => x.Status == true);
        }

        public ProductCategory GetSingleByID(int ID)
        {
            return _productCategoryRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory productCate)
        {
            _productCategoryRepository.Update(productCate);
        }


    }
}