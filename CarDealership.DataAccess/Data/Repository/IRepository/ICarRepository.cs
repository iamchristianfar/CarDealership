using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository.IRepository
{
    public interface ICarRepository : IRepository<Car>
    {
        void Update(Car cars);
        int Count();
    }
}
