using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wright.Models.ListingModels
{
    public class ListingIndex
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public bool Status { get; set; }
    }
}