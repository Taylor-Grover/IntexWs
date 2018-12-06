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
        [DisplayName("Assay Description")]
        public string AssayDescription { set; get; }
        [DisplayName("Assay Protocol")]
        public string AssayProtocol { set; get; }
        [DisplayName("Assay Cost")]
        public double AssayCost { set; get; }




    }
}