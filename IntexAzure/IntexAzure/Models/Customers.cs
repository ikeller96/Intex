using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Customer ID")]
        [Required(ErrorMessage = "Please select a customer")]
        public int CustID { get; set; }

        [StringLength(60, ErrorMessage = "Your Name must be less than 60 characters")]
        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string CustName { get; set; }

        [StringLength(30, ErrorMessage = "Your Street Address must be less than 30 characters")]
        [DisplayName("Street Address")]
        [Required(ErrorMessage = "Please enter your address")]
        public string CustAddress1 { get; set; }

        [DisplayName("Street Address 2")]
        public string CustAddress2 { get; set; }

        [StringLength(30, ErrorMessage = "Your City must be less than 30 characters")]
        [DisplayName("City")]
        [Required(ErrorMessage = "Please enter your City")]
        public string CustCity { get; set; }

        [StringLength(30, ErrorMessage = "Your State must be less than 30 characters")]
        [DisplayName("State")]
        [Required(ErrorMessage = "Please enter your State")]
        public string CustState { get; set; }

        [RegularExpression(@"\d{5}", ErrorMessage = "Your ZipCode must be 5 digits")]
        [DisplayName("Zip Code")]
        [Required(ErrorMessage = "Please enter your Zip")]
        public int CustZip { get; set; }

        [EmailAddress(ErrorMessage = "Please enter your email address")]
        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter your Email")]
        public string CustEmail { get; set; }

        //[RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Your phone number must have 10 numbers in the format ###-###-#### or (###)###-####")]
        //[DisplayName("Phone")]
        //[Required(ErrorMessage = "Please enter your Phone")]
        //public string CustPhone { get; set; }

        [StringLength(30, ErrorMessage = "Your payment info must be less than 30 characters")]
        [DisplayName("Payment Info")]
        [Required(ErrorMessage = "Please enter your payment info")]
        public string CustPaymentInfo { get; set; }

        [DisplayName("Employee ID")]
        [Required(ErrorMessage = "Please select on employee")]
        public int? EmpID { get; set; }

        [DisplayName("Employee")]
        public virtual Employees Employees { get; set; }

        public string UserName { get; set; }
    
        public string Password { get; set; }

    }
}


