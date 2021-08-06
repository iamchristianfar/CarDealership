using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealership.Models.ViewModel.Transactions
{
    public class Transactions
    {
        public Transaction Transaction { get; set; }
        public Client Buyer { get; set; }
        public Client Seller { get; set; }
        public Car Car { get; set; }

    }
}
