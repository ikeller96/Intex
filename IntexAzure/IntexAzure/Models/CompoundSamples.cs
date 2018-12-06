using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("CompoundSamples")]
    public class CompoundSamples
    {
        public int CompoundLT { get; set; }

        [Key]
        public int CompoundSC { get; set; }       

        public int Quantity { get; set; }

        public DateTime DateArrived { get; set; }

        public string ReceivedBy { get; set; }

        public string Appearance { get; set; }

        public decimal Weight { get; set; }




    }
}