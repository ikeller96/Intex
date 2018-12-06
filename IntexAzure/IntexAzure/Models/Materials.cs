using System;
using System.Collections.Generic;
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
        public int MaterialID { get; set; }

        public string Description { get; set; }

        public int QuantityAvailable { get; set; }


    }
}