using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.UnitTestingDemo
{
    public class DataProvider : IDataProvider
    {
        public int FetchData(int x)
        {
            return 77;
        }
    }
}
