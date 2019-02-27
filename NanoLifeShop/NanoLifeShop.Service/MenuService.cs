using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Data.Repositories;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;

namespace NanoLifeShop.Service
{
    public interface IMenuService
    {
        Menu Add(Menu Menu);

        void Update(Menu Menu);

        Menu Delete(int ID);

        IEnumerable<Menu> GetAll();

        IEnumerable<Menu> GetAll(string keyword);

        IEnumerable<Menu> GetMultiPaging(int pageIndex, int pageSize, out int total);

        Menu GetSingleByID(int ID);

        void Save();
    }

    public class MenuService : IMenuService
    {
        public IMenuRepository _menuRepository;

        public IUnitOfWork _unitOfWork;

        public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this._menuRepository = menuRepository;
            this._unitOfWork = unitOfWork;
        }

        public Menu Add(Menu Menu)
        {
            return _menuRepository.Add(Menu);
        }

        public Menu Delete(int ID)
        {
            return _menuRepository.Delete(ID);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public IEnumerable<Menu> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _menuRepository.GetMulti(x => x.Name.Contains(keyword));
            }
            else
            {
                return _menuRepository.GetAll();
            }
        }

        public IEnumerable<Menu> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _menuRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public Menu GetSingleByID(int ID)
        {
            return _menuRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Menu Menu)
        {
            _menuRepository.Update(Menu);
        }
    }
}