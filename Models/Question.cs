using System.ComponentModel.DataAnnotations;
using System.Linq;
using Geology.Models;
using System.Collections.Generic;
using System;

namespace Geology.Models
{

    public class Question : BaseEntity
    {
        [Key]
        public int questionId { get; set; }

        public int MyProperty { get; set; }

    }
}