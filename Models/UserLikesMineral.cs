using System.ComponentModel.DataAnnotations;
using System.Linq;
using Geology.Models;
using System.Collections.Generic;
using System;

namespace Geology.Models
{

    public class UserLikesMineral : BaseEntity
    {
        [Key]
        public int UserLikesMineralId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int MineralId { get; set; }

        public Mineral Mineral { get; set; }
    }
}