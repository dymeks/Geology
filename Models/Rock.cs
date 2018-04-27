using System.ComponentModel.DataAnnotations;
using System.Linq;
using Geology.Models;
using System.Collections.Generic;
using System;

namespace Geology.Models
{

    public class Rock : BaseEntity
    { 
        [Key]
        public int RockId { get; set; }

        public string Name { get; set; }

        public string GroupName { get; set; }

        public string Family { get; set; }

        public string Type { get; set; }

        public string Texture { get; set; }

        public string Structure { get; set; }

        public List<RockHasMineral> minerals { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Rock() {
            minerals = new List<RockHasMineral>();
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
        }
    }
}