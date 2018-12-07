using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Work Order ID")]
        public int WorkOrderID { get; set; }


        [DisplayName("Due Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDueDate { get; set; }

        [DisplayName("Order Rushed? Y or N")]
        [Required(ErrorMessage = "Please select an option")]
        public string OrderRushed { get; set; }


        [DisplayName("Status")]
        [Required(ErrorMessage = "Please select a status")]
        public string OrderStatus { get; set; }


        [DisplayName("Creation Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderCreationDate { get; set; }


        [DisplayName("Discounts")]
        [Required(ErrorMessage = "Please select a discount")]
        public string OrderDiscounts { get; set; }

        [DisplayName("Customer")]
        [Required(ErrorMessage = "Please select a customer")]
        public int CustID { get; set; }

        public virtual Customers Customers { get; set; }
    }
}