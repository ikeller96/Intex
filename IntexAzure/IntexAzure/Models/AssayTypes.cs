using System;
using System.Collections.Generic;
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
        public int AssayTypeID { get; set; }

        public string AssayTypeDescription { get; set; }

        //Not sure this should be an int
        public int AssayTypeTime { get; set; }
    }
}