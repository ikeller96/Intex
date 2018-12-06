using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Employee")]
        [Required(ErrorMessage = "Please select an employee")]
        public int EmpID { get; set; }

        [DisplayName("Employee")]
        [Required(ErrorMessage = "Please select a employee")]
        public string EmpName { get; set; }

        public string EmpPosition { get; set; }

        public int Wage { get; set; }

    }
}