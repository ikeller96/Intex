using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntexAzure.Models
{
    public class WorkOrdersPrice
    {
        [DisplayName("Work Order")]
        public WorkOrders WorkOrder { get; set; }

        [DisplayName("Work Order Price")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? WorkOrderPrice { get; set; }

        [DisplayName("Complete Tests")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal? CompleteTests { get; set; }

        [DisplayName("In Progress Tests")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal? InProgressTests { get; set; }

        [DisplayName("Backlog Tests")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal? BackLogTests { get; set; }
    }
}