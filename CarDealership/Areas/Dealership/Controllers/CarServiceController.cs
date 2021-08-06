using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Models.ViewModel.CarServices;
using CarDealership.Models.ViewModel;

namespace CarDealership.Areas.Dealership.Controllers
{
    [Area("Dealership")]
    public class CarServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var dbCarServices = _unitOfWork.CarService.GetAll();
            var carServices = new List<CarServices>();

            foreach (var dbCarService in dbCarServices)
            {
                var carService = new CarServices
                {
                    CarService = dbCarService,
                    Car = _unitOfWork.Cars.Get(dbCarService.CarID),
                    Client = _unitOfWork.Clients.Get(dbCarService.ClientID)
                };
                carServices.Add(carService);
            }
            return View("Index", carServices);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpGet]
        public JsonResult AutoComplete(string term)
        {
            var name = term;
           //var clientName = _unitOfWork.Clients.Where(c => c.FullName.Contains(name)).Select(c => c.Client.FullName).ToList();
           var clientsName = _unitOfWork.Clients.GetAll(filter: c => c.FirstName.Contains(name) || c.LastName.Contains(name)).Select(c => new AutoComplete { label =  c.FullName, id = c.ID , prop1 = c.Email}).ToList();
            return Json(clientsName);
        }

        [HttpPost]
        public JsonResult GetClientCars(int clientId)
        {
            var cars = _unitOfWork.Cars.GetAll(filter: c => c.ClientID == clientId);
            return Json(cars);
        }

        [HttpPost]
        public IActionResult AddService(CarService carService)
        {
            var carServices = new CarService
            {
                ClientID = carService.ClientID,
                CarID = carService.CarID,
                Price = carService.Price,
                ServiceIn = DateTime.Now,
                ServiceOut = DateTime.Now,
                ServiceType = carService.ServiceType

            };
            _unitOfWork.CarService.Add(carService);
            _unitOfWork.Save();
            return Index();
        }
    }
}
