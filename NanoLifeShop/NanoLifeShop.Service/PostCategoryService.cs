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
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCate);

        void Update(PostCategory postCate);

        PostCategory Delete(int ID);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAll(string keyword);

        IEnumerable<PostCategory> GetParent();


        IEnumerable<PostCategory> GetMultiPaging(int pageIndex, int pageSize, out int total);

        PostCategory GetSingleByID(int ID);


        void Save();

    }

    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCate)
        {
            return _postCategoryRepository.Add(postCate);
        }

        public PostCategory Delete(int ID)
        {
            return _postCategoryRepository.Delete(ID);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _postCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _postCategoryRepository.GetAll();
            }
        }

        public IEnumerable<PostCategory> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _postCategoryRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public IEnumerable<PostCategory> GetParent()
        {
            return _postCategoryRepository.GetMulti(x => x.Status == true);
        }

        public PostCategory GetSingleByID(int ID)
        {
            return _postCategoryRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCate)
        {
            _postCategoryRepository.Update(postCate);
        }
    }
}
