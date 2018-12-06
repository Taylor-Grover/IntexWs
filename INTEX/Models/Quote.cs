using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class Quote
    {
        [Key]
        public int AssayID { get; set; }
 
        public string AssayDescription { set; get; }

        public string AssayProtocol { set; get; }

        public double AssayCost { set; get; }




    }
}