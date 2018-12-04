using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("WorkOrder_Compound")]
    public class WorkOrder_Compound
    {
        [Key]
        [Required]
        [Display(Name = "LT Number")]
        public int LTNumber { get; set; }
        [Display(Name = "Sequence Code")]
        public int SequenceCode { get; set; }
        [Display(Name = "Amount")]
        public double Amount { get; set; }
    }
}