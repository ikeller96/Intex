using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    public class WorkOrdersPrice
    {
        public WorkOrders WorkOrder { get; set; }
        public decimal? WorkOrderPrice { get; set; }
        public decimal? CompleteTests { get; set; }
        public decimal? InProgressTests { get; set; }
        public decimal? BackLogTests { get; set; }
    }
}