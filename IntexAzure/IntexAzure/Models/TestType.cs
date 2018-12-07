using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("TestType")]
    public class TestType
    {
        [Key]
        [DisplayName("Test Type ID")]
        public int testTypeID { get; set; }

        [DisplayName("Test Type Name")]
        public string testTypeName { get; set; }

        [DisplayName("Test Type Description")]
        public string testTypeDescription { get; set; }

        [DisplayName("Test Type Cost")]
        public decimal? testTypeCost { get; set; }

        [DisplayName("Test Type Conditionality")]
        public string testTypeConditionality { get; set; }

        [DisplayName("Hours Needed")]
        public decimal HoursNeeded { get; set; }

        [DisplayName("Materials List ID")]
        public int MaterialsListID { get; set; }


    }
}