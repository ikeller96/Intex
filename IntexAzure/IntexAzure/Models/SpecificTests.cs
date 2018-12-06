using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("SpecificTests")]
    public class SpecificTests
    {
        [Key]
        public int CompoundTestID { get; set; }

        public int AssayID { get; set; }

        public int TestTypeID { get; set; }

        public string QuantitativeResults { get; set; }

        public string QualitativeResults { get; set; }

        public int CompoundSC { get; set; }

        public int MaterialsListID { get; set; }




    }
}