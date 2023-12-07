using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wright.Data.Entities
{
    public class ListingEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<ListingEntity>? Listings { get; set; }
        
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual CategoryEntity? Category { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set;}
        public virtual MowerTypeEntity? Type { get; set; }
    }
}