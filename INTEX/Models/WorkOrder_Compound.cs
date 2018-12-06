using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    //This model is linked to the WorkOrder_Compound table in the Database
    [Table("WorkOrder_Compound")]
    public class WorkOrder_Compound
    {
        [Key]
        [Required]
        [Display(Name = "LT Number")]
        [RegularExpression(@"\d{6}$", ErrorMessage = "LT Number should only have 6 numbers")]
        public int LTNumber { get; set; }

        [Display(Name = "Sequence Code")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Sequence Code should only have numbers")]
        public int SequenceCode { get; set; }
        [Display(Name = "Amount")]
        public double Amount { get; set; }
    }
}