using NanoLifeShop.Common;
using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Data.Repositories;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;

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
        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;
        private ITagRepository _tagRepository;
        private IPostTagRepository _postTagRepository;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork, ITagRepository tagRepository, IPostTagRepository postTagRepository)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
            this._tagRepository = tagRepository;
            this._postTagRepository = postTagRepository;
        }

        public Post Add(Post post)
        {
            var PostNew = _postRepository.Add(post);
            _unitOfWork.Commit();
            if (!String.IsNullOrEmpty(PostNew.Tags))
            {
                string[] tag = PostNew.Tags.Split(',');

                for (var i = 0; i < tag.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tag[i]);

                    //Add New Tag for post
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag newtag = new Tag()
                        {
                            ID = tagID,
                            Name = tag[i],
                            Type = ConstTag.PostTag
                        };
                        _tagRepository.Add(newtag);
                    }
                    PostTag postTag = new PostTag()
                    {
                        IDPost = PostNew.ID,
                        IDTag = tagID,
                    };
                    _postTagRepository.Add(postTag);
                }
            }

            return PostNew;
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
            if (!String.IsNullOrEmpty(post.Tags))
            {
                string[] tag = post.Tags.Split(',');
                for (var i = 0; i < tag.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tag[i]);
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag tagNew = new Tag()
                        {
                            ID = tagID,
                            Name = tag[i],
                            Type = ConstTag.PostTag
                        };
                        _tagRepository.Add(tagNew);
                    }
                    _postTagRepository.DeleteMulti(x => x.IDPost == post.ID);

                    PostTag postTag = new PostTag()
                    {
                        IDPost = post.ID,
                        IDTag = tagID
                    };

                    _postTagRepository.Add(postTag);
                }
            }

            _postRepository.Update(post);
        }
    }
}