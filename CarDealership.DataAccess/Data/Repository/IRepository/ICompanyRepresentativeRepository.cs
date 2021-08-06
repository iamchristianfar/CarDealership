using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository.IRepository
{
    public interface ICompanyRepresentativeRepository : IRepository<CompanyRepresentative>
    {
        void Update(CompanyRepresentative companyRepresentatives);
        int Count();
    }
}
    