using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository
{
    public class CarRepository : Repository<Car> , ICarRepository
    {
        private readonly ApplicationDbContext _db;
        public CarRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }


        public void Update(Car cars)
        {
            var dbCar = _db.Cars.Find(cars.ID);
            dbCar.CarName = cars.CarName;
            dbCar.CarModel = cars.CarModel;
            dbCar.Colour = cars.Colour;
            dbCar.Year = cars.Year;
            _db.SaveChanges();
        }

        public int Count()
        {
            return _db.Cars.Count();
        }
    }
}
