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

        public double AccountBalance { get; set; }

        public int NumberofOrders { get; set; }

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

        public string ClientEmail { get; set; }

        [Display(Name = "Phone Number")]
        public string ClientPhone { get; set; }

    }
}