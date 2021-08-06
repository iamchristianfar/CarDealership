using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository.IRepository
{
    public interface IClientRepository : IRepository<Client>
    {
        void Update(Client clients);
        int Count();
       
    }
}
