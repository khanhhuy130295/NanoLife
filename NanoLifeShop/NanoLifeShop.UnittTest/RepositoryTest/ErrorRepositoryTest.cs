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
    public class ErrorRepositoryTest
    {
        IDBFactory dBFactory;
        IErrorRepository errorRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dBFactory = new DBFactory();
            errorRepository = new ErrorRepository(dBFactory);
            unitOfWork = new UnitOfWork(dBFactory);

        }


        [TestMethod]
        public void Error_Repository_Add()
        {
            Error error = new Error();
            error.CreateDate = DateTime.Now;
            error.Message = "Lỗi 2";
            error.StackTrace = "Test lỗi 3";


            var result = errorRepository.Add(error);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(12, result.ID);

        }
    }
}
