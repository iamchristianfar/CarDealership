using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealership.Models
{
    public class CarService
    {

        [Key]
        public int ID { get; set; }
     
        public int CarID { get; set; }
        [ForeignKey("CarID")]

        public int ClientID { get; set; }
        [ForeignKey("ClientID")]

        [Required]
        public string ServiceType { get; set; }
        [Required]

        public string Price { get; set; }
        public DateTime ServiceIn { get; set; }

        [Required]
        public DateTime ServiceOut { get; set; }

    }
}

