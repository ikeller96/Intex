using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("CompoundSamples")]
    public class CompoundSamples
    {
        [DisplayName("Compound LT")]
        public int CompoundLT { get; set; }

        [Key]
        [DisplayName("Compound SC")]
        public int CompoundSC { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Date Arrived")]
        public DateTime DateArrived { get; set; }

        [DisplayName("Received By")]
        public string ReceivedBy { get; set; }

        [DisplayName("Appearance")]
        public string Appearance { get; set; }

        [DisplayName("Weight")]
        public decimal Weight { get; set; }

    }
}