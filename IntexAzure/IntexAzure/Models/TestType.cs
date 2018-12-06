using System;
using System.Collections.Generic;
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
        public int testTypeID { get; set; }

        public string testTypeName { get; set; }

        public string testTypeDescription { get; set; }

        public decimal? testTypeCost { get; set; }

        public string testTypeConditionality { get; set; }

        public decimal HoursNeeded { get; set; }

        public int MaterialsListID { get; set; }


    }
}