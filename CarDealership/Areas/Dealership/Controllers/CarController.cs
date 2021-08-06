using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Areas.Dealership.Controllers
{
    [Area("Dealership")]
    public class CarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var cars = _unitOfWork.Cars.GetAll(includeProperties:"Clients");
            return View("Index",cars);
        }

        [HttpGet]

        public IActionResult AddCar()
        {
            var car = new CarDealership.Models.ViewModel.Cars
            {
                Clients = _unitOfWork.Clients.GetAll().ToList()
            };
            return View(car);
        }

        [HttpPost]
        public IActionResult AddCar(CarDealership.Models.ViewModel.Cars model)
        {
            _unitOfWork.Cars.Add(model.Car);
            _unitOfWork.Save();
            return Index();
        }

        [HttpGet]
        public IActionResult Update(int carId)
        {
            var car = _unitOfWork.Cars.Get(carId);
            return View(car);
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            _unitOfWork.Cars.Update(car);
            return Index();
        }

        [HttpPost]
        public IActionResult Delete(int carId)
        {
            _unitOfWork.Cars.Remove(carId);
            _unitOfWork.Save();
            return Index();
        }

        [HttpGet]

        public JsonResult GetClientCars(int clientId)
        {
            var cars = _unitOfWork.Cars.GetAll(filter: c => c.ClientID == clientId);
            return Json(cars);
            
        }


    }
}
