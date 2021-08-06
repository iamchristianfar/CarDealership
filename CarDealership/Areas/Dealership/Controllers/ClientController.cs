using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Models.ViewModel;

namespace CarDealership.Areas.Dealership.Controllers
{
    [Area("Dealership")]
    public class ClientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Admin, Manager, CompanyRepresentative")]
        public IActionResult Index()
        {
            var clients = _unitOfWork.Clients.GetAll();
            foreach (var client in clients) 
            {
                client.CompanyRepresentativeName = _unitOfWork.CompanyRepresentative.Get(client.CompanyRepresentativeID).FullName;
            }
            return View("Index", clients);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddClients()
        {
            var model = new Clients 
            {
                CompanyRepresentatives = _unitOfWork.CompanyRepresentative.GetAll().ToList()
            };
            return View(model);
        } 

        [HttpPost]

        [Authorize(Roles = "Admin")]
        public IActionResult AddClients(Clients clients)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Clients.Add(clients.Client);
                _unitOfWork.Save();
                return Index();
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int clientId)
        {
            var client = _unitOfWork.Clients.Get(clientId);
            client.CompanyRepresentatives = _unitOfWork.CompanyRepresentative.GetAll().ToList();
            return View(client);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Client client)
        {
            _unitOfWork.Clients.Update(client);
            return Index();
        }
       
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int clientId)
        {

            _unitOfWork.Clients.Remove(clientId);
            _unitOfWork.Save();
            return Index();
        }
    }
}
