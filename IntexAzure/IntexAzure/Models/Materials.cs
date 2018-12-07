using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("Materials")]
    public class Materials
    {
        [Key]
        [DisplayName("Material ID")]
        public int MaterialID { get; set; }

        public string Description { get; set; }

        [DisplayName("Quantity Available")]
        public int QuantityAvailable { get; set; }

        [DisplayName("Material Price")]
        public decimal MaterialPrice { get; set; }


    }
}