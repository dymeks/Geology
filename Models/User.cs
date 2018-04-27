using System.ComponentModel.DataAnnotations;
using System.Linq;
using Geology.Models;
using System.Collections.Generic;
using System;

namespace Geology.Models
{

    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public User() {
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
        }
    }
}