using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("TestEmployees")]
    public class TestEmployees
    {
        [Key]
        public int TestEmployeesID { get; set; }

        [DisplayName("Employee ID")]
        public int EmployeeID { get; set; }

        [DisplayName("Compound Test Id")]
        public int CompoundTestID { get; set; }



    }
}