using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    public class AssayPrice
    {
        public Assays Assay { get; set; }
        public decimal EstimatedPrice { get; set; }
    }
}