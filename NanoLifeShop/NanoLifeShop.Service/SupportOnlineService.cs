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

    public interface ISupportOnlineService
    {
        SupportOnline Add(SupportOnline supportOnline);

        IEnumerable<SupportOnline> GetAll();

        IEnumerable<SupportOnline> GetAll(string keyword);

        IEnumerable<SupportOnline> GetMultiPaging(int pageIndex, int pageSize, out int total);

        IEnumerable<SupportOnline> GetMulti();

        SupportOnline Delete(int id);

        void Update(SupportOnline supportOnline);

        SupportOnline GetSingleById(int id);

        void Save();

    }

    public class SupportOnlineService : ISupportOnlineService
    {

        ISupportOnlineRepository _supportOnlineRepository;
        IUnitOfWork _unitOfWork;

        public SupportOnlineService(ISupportOnlineRepository supportOnlineRepository, IUnitOfWork unitOfWork)
        {
            this._supportOnlineRepository = supportOnlineRepository;
            this._unitOfWork = unitOfWork;
        }

        public SupportOnline Add(SupportOnline supportOnline)
        {
            return _supportOnlineRepository.Add(supportOnline);
        }

        public SupportOnline Delete(int id)
        {
            return _supportOnlineRepository.Delete(id);
        }

        public IEnumerable<SupportOnline> GetAll()
        {
            return _supportOnlineRepository.GetAll();
        }

        public IEnumerable<SupportOnline> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _supportOnlineRepository.GetMulti(x => x.Name.Contains(keyword) || x.Department.Contains(keyword));

            }
            else
            {
                return _supportOnlineRepository.GetAll();
            }
        }

        public IEnumerable<SupportOnline> GetMulti()
        {
            return _supportOnlineRepository.GetMulti(x => x.Status == true);
        }

        public IEnumerable<SupportOnline> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _supportOnlineRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public SupportOnline GetSingleById(int id)
        {
            return _supportOnlineRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SupportOnline supportOnline)
        {
            _supportOnlineRepository.Update(supportOnline);
        }
    }
}
