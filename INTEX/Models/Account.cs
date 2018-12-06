using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    //This model is linked to the Account table in the Database
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }
             
        public double AccountBalance { get; set; }

        public int NumberofOrders { get; set; }

        public DateTime ClientStartDate { get; set; }

        public int ClientID { get; set; }

        public int? SalesAgentID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}