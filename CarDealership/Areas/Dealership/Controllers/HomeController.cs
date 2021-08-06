using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using CarDealership.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Models.ViewModel.Enum;
using Microsoft.AspNetCore.Identity;
using CarDealership.Models.ViewModels;
using CarDealership.Utility;
using Microsoft.AspNetCore.Authorization;
using CarDealership.Models.UnitTestingDemo;

namespace CarDealership.Areas.Dealership.Controllers
{
    [Area("Dealership")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public HomeController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin, Manager")]
        public IActionResult Index()
        {
            var model = new Dashboard
            {
                NumberOfRepresentatives = _unitOfWork.CompanyRepresentative.Count(),
                NumberOfServices = _unitOfWork.CarService.Count(),
                NumberOfCars = _unitOfWork.Cars.Count(),
                NumberOfClients = _unitOfWork.Clients.Count(),
                Months = _unitOfWork.Transactions.GetAll(filter: t => t.TransactionDate.Year == DateTime.Today.Year).OrderBy(t => t.TransactionDate).GroupBy(t => t.TransactionDate.ToString("MMMM")).Select(t => StringExtensions.FirstCharToUpper(t.First().TransactionDate.ToString("MMMM"))).ToArray(),
                NumberOfTransactions = _unitOfWork.Transactions.GetAll(filter: t => t.TransactionDate.Year == DateTime.Today.Year).OrderBy(t => t.TransactionDate).GroupBy(t => t.TransactionDate.ToString("MMMM")).Select(t => t.Count()).ToArray()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(string term)
        {
            var searchResults = new List<SearchResult>();
            var clients = _unitOfWork.Clients.GetAll(filter:c => c.FirstName.Contains(term) || c.LastName.Contains(term)).ToList();
            var companyRepresentatives = _unitOfWork.CompanyRepresentative.GetAll(filter:r => r.FirstName.Contains(term) || r.LastName.Contains(term)).ToList();

            clients.ForEach(c =>
            {
                var searchResult = new SearchResult
                {
                    Id = c.ID,
                    Name = c.FullName,
                    Table = Table.Clients
                };
                searchResults.Add(searchResult);
            });

            companyRepresentatives.ForEach(r =>
            {
                var searchResult = new SearchResult
                {
                    Id = r.ID,
                    Name = r.FullName,
                    Table = Table.CompanyRepresentatives
                };
                searchResults.Add(searchResult);
            });
            return View(searchResults);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Manager));
                await _roleManager.CreateAsync(new IdentityRole(Helper.CompanyRepresentative));
            }
            return View();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync(); 
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
