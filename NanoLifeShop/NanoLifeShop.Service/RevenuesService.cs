using NanoLifeShop.Common.Models;
using NanoLifeShop.Data.Infastructures;
using NanoLifeShop.Data.Repositories;
using System;
using System.Collections.Generic;

namespace NanoLifeShop.Service
{
    public interface IRevenuesService
    {
        IEnumerable<Revenues> GetRevenues(string fromDate, string toDate);
    }

    public class RevenuesService : IRevenuesService
    {
        IRevenuesRepository _revenuesRepository;
        IUnitOfWork _unitOfWork;
        public RevenuesService(IRevenuesRepository revenuesRepository, IUnitOfWork unitOfWork)
        {
            this._revenuesRepository = revenuesRepository;
            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<Revenues> GetRevenues(string fromDate, string toDate)
        {
            var result = _revenuesRepository.GetRevenueStatistic(fromDate, toDate);
            return result;
        }
    }
}