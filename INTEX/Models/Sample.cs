using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    //This model is linked to the Sample table in the Database
    [Table("Sample")]
    public class Sample
    {
        [Key]
        [RegularExpression(@"^\d+", ErrorMessage = "Sequence Code should be an integer")]
        public int SequenceCode { get; set; }

        [Display(Name = "Compound Name")]
        public string CompoundName { get; set; }

        [Display(Name = "Quantity")]
        [RegularExpression(@"^\d+\.*\d*$", ErrorMessage = "Quantity should be a number")]
        public double Quantity { get; set; }

        [Display(Name = "Date Arrived")]
        public DateTime DateArrived { get; set; }

        [Display(Name = "Employee who received order")]
        public string ReceivedBy { get; set; }

        [Display(Name = "Date confirmation sent")]
        public DateTime DateTimeConfirmed { get; set; }

        [Display(Name = "Appearance of Sample")]
        public string Appearance { get; set; }

        [Display(Name = "Weight listed by Client")]
        [RegularExpression(@"^\d+\.*\d*$", ErrorMessage = "Weight should be a number")]
        public double ClientWeight { get; set; }

        [Display(Name = "Molecular Mass")]
        [RegularExpression(@"^\d+\.*\d*$", ErrorMessage = "Molecular Mass should be a number")]
        public double MolecularMass { get; set; }

        [Display(Name = "Actual Weight")]
        [RegularExpression(@"^\d+\.*\d*$", ErrorMessage = "Actual Weight should be a number")]
        public double ActualWeight { get; set; }

        [Display(Name = "Maximum Tolerated Dose")]
        [RegularExpression(@"^\d+\.*\d*$", ErrorMessage = "MTD should be a number")]
        public double MTD { get; set; }
    }
}