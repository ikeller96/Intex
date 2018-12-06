using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    [Table("WorkOrders")]
    public class WorkOrders
    {
        [Key]
        public int WorkOrderID { get; set; } 

        public DateTime OrderDueDate { get; set; }

        public string OrderRushed { get; set; }

        public string OrderStatus { get; set; }

        public DateTime OrderCreationDate { get; set; }

        public string OrderDiscounts { get; set; }

        public int CustID { get; set; }
        public virtual Customers Customers { get; set; }
    }
}