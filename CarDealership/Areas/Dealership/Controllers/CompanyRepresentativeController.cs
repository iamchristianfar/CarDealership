using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Areas.Dealership.Controllers
{
    [Area("Dealership")]
    public class CompanyRepresentativeController : Controller
    {
      
        private readonly IUnitOfWork _unitOfWork;
        public CompanyRepresentativeController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Admin, Manager, CompanyRepresentative")]
        public IActionResult Index() 
        {
            var companyRepresentatives = _unitOfWork.CompanyRepresentative.GetAll(); 
            return View("Index", companyRepresentatives); 
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult AddCompanyRepresentative()
        {
            return View();

        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult AddCompanyRepresentative(CompanyRepresentative companyRepresentative) 
        {
            _unitOfWork.CompanyRepresentative.Add(companyRepresentative); 
            _unitOfWork.Save();
            return Index();
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Update(int companyRepresentativeId)
        {
            var companyRepresentative = _unitOfWork.CompanyRepresentative.Get(companyRepresentativeId);
            return View(companyRepresentative);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Update(CompanyRepresentative companyRepresentative)
        {
            _unitOfWork.CompanyRepresentative.Update(companyRepresentative);
            return Index();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int companyRepresentativeId)
        {

            _unitOfWork.CompanyRepresentative.Remove(companyRepresentativeId);
            _unitOfWork.Save();
            return Index();
        }


        [HttpGet]
       
        public IActionResult Upsert(int? companyRepresentativeId = null)
        {
            if(companyRepresentativeId == null)
            {
                return View(new CompanyRepresentative());
            }

            var companyRepresentative = _unitOfWork.CompanyRepresentative.Get((int)companyRepresentativeId);
            return View(companyRepresentative);
        }

        [HttpPost]
       
        public IActionResult Upsert(CompanyRepresentative companyRepresentative)
        {
            if(companyRepresentative.ID == 0)
            {
                _unitOfWork.CompanyRepresentative.Add(companyRepresentative);
            }
            else
            {
                _unitOfWork.CompanyRepresentative.Update(companyRepresentative);
            }
            _unitOfWork.Save();
            return Index();
        }

        

    }
}
