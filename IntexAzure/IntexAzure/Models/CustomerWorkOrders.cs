using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    public class CustomerWorkOrders
    {

        [Key]
        public int WorkOrderID { get; set; }

        public DateTime OrderDueDate { get; set; }

        public string OrderRushed { get; set; }

        public string OrderStatus { get; set; }

        public DateTime OrderCreationDate { get; set; }

        public string OrderDiscounts { get; set; }

        public int CustID { get; set; }
    }
}