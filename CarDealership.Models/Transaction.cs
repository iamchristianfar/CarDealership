using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealership.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int SellerClientID { get; set; }
        [Required]
        public int BuyerClientID { get; set; }
        [Required]
        public int CarID { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public decimal Price { get; set; }

        [NotMapped]
        public string SellerClientName { get; set; }
        [NotMapped]
        public string BuyerClientName { get; set; }
        [NotMapped]
        public string CarName { get; set; }
        [NotMapped]
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
