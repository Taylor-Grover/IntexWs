using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        [Required]
        public int AssayID { get; set; }
        [Required]
        public string AssayDescription { set; get; }
        [Required]
        public string AssayProtocol { get; set; }
        [Required]
        public int CompletionEstimate { get; set; }

      
       
    }
}