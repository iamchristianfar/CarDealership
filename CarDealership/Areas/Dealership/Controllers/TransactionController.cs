using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Models.ViewModel.Transactions;
using CarDealership.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CarDealership.Areas.Dealership.Controllers
{
    [Area("Dealership")]
    public class TransactionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Manager , Admin")]
        public IActionResult Index() 
        {
            var dbTransactions = _unitOfWork.Transactions.GetAll();
            var transactions = new List<Transactions>();

            foreach (var dbTransaction in dbTransactions)
            {
                var transaction = new Transactions
                {
                    Transaction = dbTransaction,
                    Car = _unitOfWork.Cars.Get(dbTransaction.CarID),
                    Seller = _unitOfWork.Clients.Get(dbTransaction.SellerClientID),
                    Buyer = _unitOfWork.Clients.Get(dbTransaction.BuyerClientID),
                   
                };
                transactions.Add(transaction);
            }
            return View("Index", transactions);
        }

        [HttpGet]
        public IActionResult AddTransaction( int? transactionId=null)
        {
            var transaction = new Transaction();
            if (transactionId != null)
            {
                transaction = _unitOfWork.Transactions.Get((int)transactionId);
                transaction.SellerClientName = _unitOfWork.Clients.Get(transaction.SellerClientID).FullName;
                transaction.BuyerClientName = _unitOfWork.Clients.Get(transaction.BuyerClientID).FullName;
                transaction.CarName = _unitOfWork.Cars.Get(transaction.CarID).CarName;
                transaction.Cars = _unitOfWork.Cars.GetAll(filter: c => c.ClientID == transaction.SellerClientID).ToList();
                
            }
            else
            {
                transaction.TransactionDate = DateTime.Now;
            }

            return View(transaction);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddTransaction(Transaction transaction)
        {
            if (transaction.ID != 0)
            {
                _unitOfWork.Transactions.Update(transaction);
            }
            else
            {
                _unitOfWork.Transactions.Add(transaction);

            }
            _unitOfWork.Save();
            return Index();
        }

        [HttpGet]
        public JsonResult AutoComplete(string term)
        {
            var name = term;
            var clientsName = _unitOfWork.Clients.GetAll(filter: c => c.FirstName.Contains(name) || c.LastName.Contains(name)).Select(c => new AutoComplete { label = c.FullName, id = c.ID, prop2 = c.Email }).ToList();
            return Json(clientsName);
        }

        [HttpPost]
        public JsonResult GetClientCars(int clientId)
        {
           var cars = _unitOfWork.Cars.GetAll(filter: c => c.ClientID == clientId);
            return Json(cars);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddTransactions(Transaction transaction)
        {
            var transactions = new Transaction
            {
                SellerClientID = transaction.SellerClientID,
                BuyerClientID = transaction.BuyerClientID,
                CarID = transaction.CarID,
                Price = transaction.Price,
                TransactionDate = DateTime.Now
            };

            _unitOfWork.Transactions.Add(transaction);
            _unitOfWork.Save();
            return Index();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int transactionId)
        {
            var transaction = _unitOfWork.Transactions.Get(transactionId);
            return View(transaction);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Transaction transaction)
        {
            _unitOfWork.Transactions.Update(transaction);
            return Index();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int transactionId)
        {

            _unitOfWork.Transactions.Remove(transactionId);
            _unitOfWork.Save();
            return Index();
        }
    }
}
