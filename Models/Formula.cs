using System.ComponentModel.DataAnnotations;
using System;

namespace Geology.Models
{ 
    public class Formula : BaseEntity 
    {
        [Key]
        public int ChemicalFormulaId { get; set; }

        public string FormulaName { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Formula() {
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
        }

    }

}