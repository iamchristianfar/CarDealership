using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealership.Models.ViewModel.CarServices
{
    public class CarServices
    {
        public CarService CarService { get; set; }
        public Car Car { get; set; }
        public Client Client { get; set; }

     
    }

}
