using Microsoft.VisualStudio.TestTools.UnitTesting;
using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Data.Repositories;
using NanoLifeShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.UnittTest.RepositoryTest
{
    [TestClass]
    public class MenuRepositoryTest
    {
        IDBFactory dBFactory;
        IMenuRepository MenuRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dBFactory = new DBFactory();
            MenuRepository = new MenuRepository(dBFactory);
            unitOfWork = new UnitOfWork(dBFactory);

        }


        [TestMethod]
        public void Menu_Repository_Add()
        {
            Menu Menu = new Menu();
            Menu.DisplayOder = 1;
            Menu.IDGroup = 3;
            Menu.Name = "Home";
            Menu.Status = true;
            Menu.Url = "/";
            Menu.Target = "_blank";


            var result = MenuRepository.Add(Menu);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);

        }
    }
}
