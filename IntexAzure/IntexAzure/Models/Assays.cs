using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Assay ID")]
        public int AssayID { get; set; }

        [DisplayName("Work Order ID")]
        public int WorkOrderID { get; set; }

        [DisplayName("Assay Status")]
        public string AssayStatus { get; set; }

        [DisplayName("Assay Type ID")]
        public int AssayTypeID { get; set; }

        [DisplayName("Work Orders")]
        public virtual WorkOrders WorkOrders { get; set; }
        
        public virtual AssayTypes AssayTypes { get; set; }

        
    }
}