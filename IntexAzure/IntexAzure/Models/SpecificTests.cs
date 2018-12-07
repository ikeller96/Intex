using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Compound Test ID")]
        public int CompoundTestID { get; set; }

        [DisplayName("Assay ID")]
        public int AssayID { get; set; }

        [DisplayName("Test Type ID")]
        public int TestTypeID { get; set; }

        [DisplayName("Quantitative Results")]
        public string QuantitativeResults { get; set; }

        [DisplayName("Qualitative Results")]
        public string QualitativeResults { get; set; }

        [DisplayName("Compound SC")]
        public int CompoundSC { get; set; }

        [DisplayName("MaterialsListID")]
        public int MaterialsListID { get; set; }

        [DisplayName("Test Status")]
        public string testStatus { get; set; }

        [DisplayName("Test Type")]
        public virtual TestType TestType { get; set; }

        [DisplayName("Assays")]
        public virtual Assays Assays { get; set; }



    }
}