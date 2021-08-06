using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealership.Models
{
    public class Car
    {

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string CarName { get; set; }
        [Required]
        [StringLength(50)]
        public string CarModel { get; set; }
        [StringLength(50)]
        public string Colour { get; set; }
        [Required]
        public decimal Year { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public Client Clients { get; set; }

        public decimal Price { get; set; }
    }
}
