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
    public interface IFeedBackService
    {
        FeedBack Add(FeedBack feedBack);

        IEnumerable<FeedBack> GetAll();

        IEnumerable<FeedBack> GetAll(string keyword);

        IEnumerable<FeedBack> GetMultiPaging(int pageIndex, int pageSize, out int total);

        IEnumerable<FeedBack> GetMulti();

        FeedBack Delete(int id);

        void Update(FeedBack feedBack);

        FeedBack GetSingleById(int id);

        void Save();
    }
    public class FeedBackService : IFeedBackService
    {
        IFeedBackRepository _feedBackRepository;
        IUnitOfWork _unitOfWork;

        public FeedBackService(IFeedBackRepository feedBackRepository, IUnitOfWork unitOfWork)
        {
            this._feedBackRepository = feedBackRepository;
            this._unitOfWork = unitOfWork;
        }


        public FeedBack Add(FeedBack feedBack)
        {
            return _feedBackRepository.Add(feedBack);
        }

        public FeedBack Delete(int id)
        {
            return _feedBackRepository.Delete(id);
        }

        public IEnumerable<FeedBack> GetAll()
        {
            return _feedBackRepository.GetAll();
        }

        public IEnumerable<FeedBack> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _feedBackRepository.GetMulti(x => x.Name.Contains(keyword) || x.Phone.Contains(keyword));

            }
            else
            {
                return _feedBackRepository.GetAll();
            }
        }

        public IEnumerable<FeedBack> GetMulti()
        {
            return _feedBackRepository.GetMulti(x => x.Status == true);
        }

        public IEnumerable<FeedBack> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _feedBackRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public FeedBack GetSingleById(int id)
        {
            return _feedBackRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(FeedBack feedBack)
        {
            _feedBackRepository.Update(feedBack);
        }
    }
}
