using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Data.Repositories;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;

namespace NanoLifeShop.Service
{
    public interface IMenuGroupService
    {
        MenuGroup Add(MenuGroup menuGroup);

        void Update(MenuGroup menuGroup);

        MenuGroup Delete(int ID);

        IEnumerable<MenuGroup> GetAll();

        IEnumerable<MenuGroup> GetAll(string keyword);

        IEnumerable<MenuGroup> GetParent();

        IEnumerable<MenuGroup> GetMultiPaging(int pageIndex, int pageSize, out int total);

        MenuGroup GetSingleByID(int ID);

        void Save();
    }

    public class MenuGroupService : IMenuGroupService
    {
        public IMenuGroupRepository _menuGroupRepository;

        public IUnitOfWork _unitOfWork;

        public MenuGroupService(IMenuGroupRepository menuGroupRepository, IUnitOfWork unitOfWork)
        {
            this._menuGroupRepository = menuGroupRepository;
            this._unitOfWork = unitOfWork;
        }

        public MenuGroup Add(MenuGroup menuGroup)
        {
            return _menuGroupRepository.Add(menuGroup);
        }

        public MenuGroup Delete(int ID)
        {
            return _menuGroupRepository.Delete(ID);
        }

        public IEnumerable<MenuGroup> GetAll()
        {
            return _menuGroupRepository.GetAll();
        }

        public IEnumerable<MenuGroup> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _menuGroupRepository.GetMulti(x => x.Name.Contains(keyword));
            }
            else
            {
                return _menuGroupRepository.GetAll();
            }
        }

        public IEnumerable<MenuGroup> GetMultiPaging(int pageIndex, int pageSize, out int total)
        {
            return _menuGroupRepository.GetMultiPaging(x => x.Status, out total, pageIndex, pageSize);
        }

        public IEnumerable<MenuGroup> GetParent()
        {
            return _menuGroupRepository.GetMulti(x => x.Status == true);
        }

        public MenuGroup GetSingleByID(int ID)
        {
            return _menuGroupRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(MenuGroup menuGroup)
        {
            _menuGroupRepository.Update(menuGroup);
        }
    }
}