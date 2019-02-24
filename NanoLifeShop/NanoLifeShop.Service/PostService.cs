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
    public interface IPostService
    {
        Post Add(Post post);

        void Update(Post post);

        Post Delete(int ID);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAll(string keyword);

        IEnumerable<Post> GetMultiPaging(int pageIndex, int pageSize, out int total);

        Post GetSingleByID(int ID);

        void Save();
    }

    public class PostService : IPostService
    {
         IPostRepository _postRepository;
         IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public Post Add(Post post)
        {
            return _postRepository.Add(post);
        }

        public Post Delete(int ID)
        {
            return _postRepository.Delete(ID);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public IEnumerable<Post> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _postRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _postRepository.GetAll();
            }
        }

        public IEnumerable<Post> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public Post GetSingleByID(int ID)
        {
            return _postRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}