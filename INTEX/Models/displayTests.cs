using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class displayTests
    {
        [Key]
        public int TestID { get; set; }
        public string TestName { get; set; }
        public double? BaseCost { get; set; }
        public string Description { get; set; }
        public bool? IsRequired { get; set; }
        public bool? Conditional { get; set; }
    }
}