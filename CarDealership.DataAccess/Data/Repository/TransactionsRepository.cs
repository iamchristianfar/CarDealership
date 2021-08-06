using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository
{
    public class TransactionRepository : Repository<Transaction> , ITransactionRepository
    {
        private readonly ApplicationDbContext _db;
        public TransactionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public int[] Count()
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction transaction)
        {
            var dbTransaction = _db.Transactions.Find(transaction.ID);
            dbTransaction.Price = transaction.Price;
            dbTransaction.TransactionDate = transaction.TransactionDate;

            _db.SaveChanges();
        }
    }
}
