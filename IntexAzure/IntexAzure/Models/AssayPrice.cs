using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntexAzure.Models
{
    public class AssayPrice
    {
        public Assays Assay { get; set; }

        [DisplayName("Assay Price")]
        public decimal? EstimatedPrice { get; set; }
    }
}