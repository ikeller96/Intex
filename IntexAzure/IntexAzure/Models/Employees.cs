using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("Employees")]
    public class Employees
    {
        [Key]
        public int EmpID { get; set; }  

        public string EmpName { get; set; }

        public string EmpPosition { get; set; }

        public int Wage { get; set; }

    }
}