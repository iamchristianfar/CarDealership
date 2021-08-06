﻿using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.DataAccess.Data.Repository.IRepository
{
    public interface ICarServiceRepository : IRepository<CarService>
    {
        int Count();
    }
}
