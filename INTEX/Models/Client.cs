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

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please enter a company name")]
        [StringLength(50, ErrorMessage = "Company Name should be no longer than 50 characters")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Representative First Name")]
        [Required(ErrorMessage = "Please enter a first name")]
        [StringLength(50, ErrorMessage = "Company Representative First Name should be no longer than 50 characters")]
        public string ClientFirstName { get; set; }

        [Display(Name = "Company Representative Last Name")]
        [Required(ErrorMessage = "Please enter a last name")]
        [StringLength(50, ErrorMessage = "Company Representative Last Name should be no longer than 50 characters")]
        public string ClientLastName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter an address")]
        [StringLength(50, ErrorMessage = "Address should be no longer than 50 characters")]
        public string ClientAddress { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter a city")]
        [StringLength(50, ErrorMessage = "Too long!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "City should only have letters")]
        public string ClientCity { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Please enter a State")]
        [StringLength(2, ErrorMessage = "State should be abbreviated to 2 letters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "State should only have letters")]
        public string ClientState { get; set; }

        [Display(Name = "Zip")]
        [Required(ErrorMessage = "Please enter an address")]
        [StringLength(10, ErrorMessage = "Too long!")]
        [RegularExpression(@"^\d{5}([\-]\d{4})?$", ErrorMessage = "Enter a valid ZIP Code")]
        public string ClientZip { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter an email")]
        [StringLength(50, ErrorMessage = "Too long!")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        public string ClientEmail { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter a phone number")]
        [StringLength(15, ErrorMessage = "Too long!")]
        [RegularExpression(@"^\(?([0-9]{3})\)[-. ]([0-9]{3})[-. ]([0-9]{4})$", ErrorMessage = "Phone number must be (000) 000-0000")]
        public string ClientPhone { get; set; }

        [Display(Name = "Special Condition")]
        public string SpecialCondition { get; set; }
    }
}