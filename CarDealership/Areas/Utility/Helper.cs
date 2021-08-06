using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Utility
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string CompanyRepresentative = "Company Representative";
        public static string Manager = "Manager";
       
        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {   
                new SelectListItem{Value=Helper.Admin, Text=Helper.Admin },
                new SelectListItem{Value=Helper.CompanyRepresentative, Text=Helper.CompanyRepresentative },
                new SelectListItem{Value=Helper.Manager, Text=Helper.Manager },
              
            };
        }
    }
}
