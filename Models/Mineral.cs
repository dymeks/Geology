using System.ComponentModel.DataAnnotations;
using System.Linq;
using Geology.Models;
using System.Collections.Generic;
using System;

namespace Geology.Models
{

    public class Mineral : BaseEntity
    {
        [Key]
        public int MineralId { get; set; }

        public string Name { get; set; }

        public int Hardness { get; set; }

        public string Color { get; set; }

        public string CrystalSystem { get; set; }

        public string Opacity { get; set; }

        public string Luster { get; set; }

        public string Streak { get; set; }

        public string CleavagePlanes { get; set; }

        public string Fracture { get; set; }

        public string Habit { get; set; }

        public int ChemicalFormulaId { get; set; }

        public Formula ChemicalFormula { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Mineral() {
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
        }
    }
}