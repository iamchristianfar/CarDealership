using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealership.Models.ViewModel
{
    public class Clients
    {
        public Client Client { get; set; }
        public List<CompanyRepresentative> CompanyRepresentatives { get; set; }

     
    }

}
