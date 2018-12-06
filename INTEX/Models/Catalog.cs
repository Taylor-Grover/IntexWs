using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class Catalog
    {
        [Key]
        public int AssayID { get; set; }
        [Display(Name = "Assay Description")]
        public string AssayDescription { get; set; }
        [Display(Name = "Protocol")]
        public string AssayProtocol { get; set; }
        [Display(Name = "Average hours to complete Assay")]
        public int CompletionEstimate { get; set; }
        [Display(Name = "Required?")]
        public bool? IsRequired { get; set; }
        [Display(Name = "Conditional on other test results?")]
        public bool? Conditional { get; set; }
        [Display(Name = "Test Description")]
        public string TestName { get; set; }
        [Display(Name = "Base cost of test")]
        public double BaseCost { get; set; }
        [Display(Name = "Procedure")]
        public string Description { get; set; }
    }
}