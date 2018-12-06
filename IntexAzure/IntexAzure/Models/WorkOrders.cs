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
        public int WorkOrderID { get; set; }


        [DisplayName("Due Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime OrderDueDate { get; set; }

        [StringLength(1, ErrorMessage = "Order Rushed must be 1 character, Y or N")]
        [DisplayName("Order Rushed? Y or N")]
        public string OrderRushed { get; set; }

        [StringLength(30, ErrorMessage = "Your Order status must be less than 30 characters")]
        [DisplayName("Status")]
        public string OrderStatus { get; set; }


        [DisplayName("Creation Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime OrderCreationDate { get; set; }

        [StringLength(30, ErrorMessage = "Discounts must be less than 30 characters")]
        [DisplayName("Discounts")]
        public string OrderDiscounts { get; set; }

        public int CustID { get; set; }
        public virtual Customers Customers { get; set; }
    }
}