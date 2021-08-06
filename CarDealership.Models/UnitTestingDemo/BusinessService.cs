using CarDealership.Models.UnitTestingDemo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models
{
    public class BusinessService
    {
        private IDataProvider _dataProvider;

        public BusinessService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public int Add(int x, int y)
        {
            var result = _dataProvider.FetchData(x);

            return x + y + result;
        }
    }
}
