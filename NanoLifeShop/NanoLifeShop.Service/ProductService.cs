using NanoLifeShop.Common;
using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Data.Repositories;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Service
{
    public interface IProductService
    {
        Product Add(Product Product);

        void Update(Product Product);

        Product Delete(int ID);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        IEnumerable<Product> GetMultiPaging(int pageIndex, int pageSize, out int total);

        Product GetSingleByID(int ID);

        Product GetSingleByCondition(Expression<Func<Product , bool>> expression);


        void Save();
    }

    public class ProductService: IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        private IProductTagRepository _productTagRepository;
        private ITagRepository _tagRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork,
            IProductTagRepository productTagRepository, ITagRepository tagRepository)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
        }
        public Product Add(Product Product)
        {
            
            var ProductNew = _productRepository.Add(Product);
            _unitOfWork.Commit();
            if (!String.IsNullOrEmpty(ProductNew.Tags))
            {
                string[] tag = ProductNew.Tags.Split(',');

                for (var i = 0; i < tag.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tag[i]);

                    //Add New Tag for Product
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag newtag = new Tag()
                        {
                            ID = tagID,
                            Name = tag[i],
                            Type = ConstTag.ProductTag

                        };
                        _tagRepository.Add(newtag);

                    }
                    ProductTag ProductTag = new ProductTag()
                    {
                        IDProduct = ProductNew.ID,
                        IDTag = tagID,
                    };
                    _productTagRepository.Add(ProductTag);
                }
            }

            return ProductNew;
        }

        public Product Delete(int ID)
        {
            return _productRepository.Delete(ID);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _productRepository.GetAll();
            }
        }

        public IEnumerable<Product> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _productRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public Product GetSingleByID(int ID)
        {
            return _productRepository.GetSingleById(ID);
        }


        public Product GetSingleByCondition(Expression<Func<Product, bool>> expression)
        {
            return _productRepository.GetSingleByCondition(expression);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product Product)
        {
            if (!String.IsNullOrEmpty(Product.Tags))
            {
                string[] tag = Product.Tags.Split(',');
                for (var i = 0; i < tag.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tag[i]);
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag tagNew = new Tag()
                        {
                            ID = tagID,
                            Name = tag[i],
                            Type = ConstTag.ProductTag
                        };
                        _tagRepository.Add(tagNew);
                    }
                    _productTagRepository.DeleteMulti(x => x.IDProduct == Product.ID);

                    ProductTag ProductTag = new ProductTag()
                    {
                        IDProduct = Product.ID,
                        IDTag = tagID
                    };

                    _productTagRepository.Add(ProductTag);
                }
            }

            _productRepository.Update(Product);
        }

    }
}
