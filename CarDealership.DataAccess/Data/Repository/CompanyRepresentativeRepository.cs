using CarDealership.DataAccess.Data.Repository.IRepository;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository
{
    public class CompanyRepresentativeRepository : Repository<CompanyRepresentative> , ICompanyRepresentativeRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepresentativeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public int Count()
        {
            return _db.CompanyRepresentative.Count();
           
        }

        public void Update(CompanyRepresentative companyRepresentatives)
        {
            var dbCompanyRepresentatives = _db.CompanyRepresentative.Find(companyRepresentatives.ID);
            dbCompanyRepresentatives.PhoneNumber = companyRepresentatives.PhoneNumber;
            dbCompanyRepresentatives.ManagerID = companyRepresentatives.ManagerID;
            dbCompanyRepresentatives.LastName = companyRepresentatives.LastName;
            dbCompanyRepresentatives.FirstName = companyRepresentatives.FirstName;
            dbCompanyRepresentatives.Email = companyRepresentatives.Email;
            dbCompanyRepresentatives.Salary = companyRepresentatives.Salary;
            _db.SaveChanges();
        }
    }
}
