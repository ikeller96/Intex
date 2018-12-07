using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("AssayTypes")]
    public class AssayTypes
    {
        [Key]
        [DisplayName("Assay Type ID")]
        public int AssayTypeID { get; set; }

        [DisplayName("Assay Type Description")]
        public string AssayTypeDescription { get; set; }

        //Not sure this should be an int
        [DisplayName("Assay Type Time")]
        public int AssayTypeTime { get; set; }
    }
}