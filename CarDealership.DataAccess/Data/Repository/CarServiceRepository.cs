using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository
{
    public class CarServiceRepository : Repository<CarService>, ICarServiceRepository
    {
        private readonly ApplicationDbContext _db;
        public CarServiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public int Count()
        {
            return _db.CarService.Count();
        }
    }
}
