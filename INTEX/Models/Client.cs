using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        [Display(Name ="Client ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter a first name")]
        public string ClientFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter a last name")]
        public string ClientLastName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter an address")]
        public string ClientAddress { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter an email")]
        public string ClientEmail { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter a phone number")]
        public string ClientPhone { get; set; }

        [Display(Name = "Special Condition")]
        public string SpecialCondition { get; set; }
    }
}