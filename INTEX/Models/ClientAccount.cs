using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class ClientAccount
    {
        [Key]
        public int AccountID { get; set; }

        [RegularExpression(@"^\d+\.*\d*$", ErrorMessage = "Account Balance should be a number")]
        public double AccountBalance { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Number of Orders should be an integer")]
        public int NumberofOrders { get; set; }

        [RegularExpression(@"^\d{1,2}\/\d{1,2}\/\d{4}$", ErrorMessage = "Date should be mm/dd/yyyy")]
        public DateTime ClientStartDate { get; set; }

        public int ClientID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "First Name")]
        public string ClientFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string ClientLastName { get; set; }

        [Display(Name = "Address")]
        public string ClientAddress { get; set; }

        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "Too long!")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter a Valid Email Address")]
        public string ClientEmail { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(15, ErrorMessage = "Too long!")]
        [RegularExpression(@"^\(?([0-9]{3})\)[-. ]([0-9]{3})[-. ]([0-9]{4})$", ErrorMessage = "Phone number must be (000) 000-0000")]
        public string ClientPhone { get; set; }

    }
}