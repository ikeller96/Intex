using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    public class WorkOrderAssays
    {
        [Key]
        public int AssayID { get; set; }

        public int WorkOrderID { get; set; }

        public string AssayStatus { get; set; }

        public int AssayTypeID { get; set; }
    }
}