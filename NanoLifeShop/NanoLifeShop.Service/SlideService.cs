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
    public interface ISlideService
    {
        Slide Add(Slide Slide);

        void Update(Slide Slide);

        Slide Delete(int ID);

        IEnumerable<Slide> GetAll();

        IEnumerable<Slide> GetAll(string keyword);

        IEnumerable<Slide> GetMultiPaging(int pageIndex, int pageSize, out int total);

        IEnumerable<Slide> ShowHomeData();


        Slide GetSingleByID(int ID);

        void Save();
    }
    public class SlideService : ISlideService
    {
        private ISlideRepository _slideRepository;
        private IUnitOfWork _unitOfWork;
        public SlideService(ISlideRepository slideRepository, IUnitOfWork unitOfWork)
        {
            this._slideRepository = slideRepository;
            this._unitOfWork = unitOfWork;
        }

        public Slide Add(Slide slide)
        {
            return _slideRepository.Add(slide);
        }

        public Slide Delete(int ID)
        {
            return _slideRepository.Delete(ID);
        }

        public IEnumerable<Slide> GetAll()
        {
            return _slideRepository.GetAll();
        }

        public IEnumerable<Slide> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _slideRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _slideRepository.GetAll();
            }
        }

        public IEnumerable<Slide> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _slideRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public Slide GetSingleByID(int ID)
        {
            return _slideRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Slide> ShowHomeData()
        {
            return _slideRepository.GetMulti(x => x.Status == true);
        }

        public void Update(Slide slide)
        {
            _slideRepository.Update(slide);
        }
    }
}
