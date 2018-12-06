using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("Assays")]
    public class Assays
    {
        [Key]
        public int AssayID { get; set; }

        public int WorkOrderID { get; set; }

        public string AssayStatus { get; set; }

        public int AssayTypeID { get; set; }

        public virtual WorkOrders WorkOrders { get; set; }
        

        //NEED TO add the assaytype virtual thing
    }
}