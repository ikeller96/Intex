using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Compound LT")]
        public int CompoundLT { get; set; }

        [DisplayName("Compound Name")]
        public string CompoundName { get; set; }

        [DisplayName("Molecular Mass")]
        public decimal MolecularMass { get; set; }

        [DisplayName("Quantity Samples")]
        public decimal QuantitySamples { get; set; }



    }
}