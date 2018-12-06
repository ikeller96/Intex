using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("Compounds")]
    public class Compounds
    {
        [Key]
        public int CompoundLT { get; set; }

        public string CompoundName { get; set; }

        public decimal MolecularMass { get; set; }

        public decimal QuantitySamples { get; set; }



    }
}