using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace CarDealership.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        public DateTime DateRegistered { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int CompanyRepresentativeID { get; set; }
        [ForeignKey("CompanyRepresentativeID")]
        public CompanyRepresentative CompanyRepresentative { get; set; }
        [NotMapped]
        public string CompanyRepresentativeName { get; set; }

        public string Car { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

        }
        [NotMapped]
        public List<CompanyRepresentative> CompanyRepresentatives { get; set; } = new List<CompanyRepresentative>();
    }
}
