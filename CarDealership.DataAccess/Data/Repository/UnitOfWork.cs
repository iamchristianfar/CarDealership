using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Clients = new ClientRepository(_db);
            CompanyRepresentative = new CompanyRepresentativeRepository(_db);
            Cars = new CarRepository(_db);
            CarService = new CarServiceRepository(_db);
            Transactions = new TransactionRepository(_db);
        }

        public IClientRepository Clients { get; private set; }
        public ICompanyRepresentativeRepository CompanyRepresentative { get; private set; }
        public ICarRepository Cars { get; private set; }
        public ICarServiceRepository CarService { get; private set; }
        public ITransactionRepository Transactions { get; set; }
        public void Dispose()
        {
            _db.Dispose();
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
