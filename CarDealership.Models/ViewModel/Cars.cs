using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealership.Models.ViewModel
{
    public class Cars
    {
        public Car Car { get; set; }
        public List<Client> Clients { get; set; }

     
    }

}
