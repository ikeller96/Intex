using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    public class WorkOrdersPrice
    {
        public WorkOrders WorkOrder { get; set; }
        public decimal WorkOrderPrice { get; set; }
    }
}