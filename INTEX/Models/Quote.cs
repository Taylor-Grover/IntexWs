using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class Quote
    {
        [Key]
        
        public int AssayID { get; set; }
        [Display(Name = "Assay Description")]
        public string AssayDescription { set; get; }
        [Display(Name = "Protocol")]
        public string AssayProtocol { set; get; }
        [Display(Name = "Estimated Cost")]

        public double AssayCost { set; get; }




    }
}