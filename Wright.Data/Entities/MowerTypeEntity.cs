using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wright.Data.Entities
{
    public class MowerTypeEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool RidingMower { get; set; }
        public bool PoweredAssist { get; set; }
        public bool Electric { get; set; }
        public virtual List<MowerTypeEntity>? MowerTypes { get; set; }
    }
}