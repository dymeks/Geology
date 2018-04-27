using System.ComponentModel.DataAnnotations;
using System.Linq;
using Geology.Models;
using System.Collections.Generic;
using System;

namespace Geology.Models
{

    public class RockHasMineral : BaseEntity
    { 
        [Key]
        public int RockHasMineralId { get; set; }

        public int RockId { get; set; }

        public Rock Rock { get; set; }

        public int MineralId { get; set; }
        
        public Mineral Mineral { get; set; }
    }
}