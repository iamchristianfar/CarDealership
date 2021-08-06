using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        ICompanyRepresentativeRepository CompanyRepresentative { get; } 
     
        ICarRepository Cars { get; }
        ICarServiceRepository CarService { get; }
      
        ITransactionRepository Transactions { get; }
        void Save();
    }
}
