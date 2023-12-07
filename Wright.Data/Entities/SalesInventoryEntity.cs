using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wright.Data.Entities
{
    public class SalesInventoryEntity
    {
        [Key]
        public int Id { get; set; }
        public int ListingNumber { get; set; }

        [ForeignKey(nameof(Listing))]
        public int ListingId { get; set; }
        public virtual ListingEntity? Listing { get; set; }
    }
}