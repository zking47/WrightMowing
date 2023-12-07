using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wright.Models.ListingModels
{
    public class ListingDetail
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Type { get; set; }
        public bool Status { get; set; }
    }
}