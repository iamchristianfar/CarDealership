using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository
{
    public class ClientRepository : Repository<Client> , IClientRepository
    {
        private readonly ApplicationDbContext _db;
        public ClientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
           
        }
       
        public void Update(Client clients)
        {
            var dbClient = _db.Clients.Find(clients.ID);
            dbClient.FirstName = clients.FirstName;
            dbClient.LastName = clients.LastName;
            dbClient.Email = clients.Email;
            dbClient.PhoneNumber = clients.PhoneNumber;
            dbClient.Address = clients.Address;
            
            _db.SaveChanges();
        }

        public int Count()
        {
            return _db.Clients.Count();
        }
    }
}
