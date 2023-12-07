using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wright.Models.ListingModels
{
    public class ListingCreate
    {
        [Required]
        public int Category { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Type { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}