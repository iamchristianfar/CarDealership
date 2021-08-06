using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.ViewModel
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enum.Table Table { get; set; }
    }
}
