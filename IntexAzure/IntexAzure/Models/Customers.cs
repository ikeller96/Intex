using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int CustID { get; set; }

        public string CustName { get; set; }

        public string CustAddress1 { get; set; }

        public string CustAddress2 { get; set; }

        public string CustCity { get; set; }

        public string CustState { get; set; }

        public int CustZip { get; set; }

        public string CustEmail { get; set; }

        public string CustPhone { get; set; }
        
        public string CustPaymentInfo { get; set; }

        public int? EmpID { get; set; }
        public virtual Employees Employees { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


    }


}