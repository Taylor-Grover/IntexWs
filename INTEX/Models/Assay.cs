using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    //This model is linked to the Assay table in the Database
    [Table("Assay")]
    public class Assay
    {
        [Key]
        [Required]
        
        public int AssayID { get; set; }
        [Required]
        [DisplayName("Assay Description")]
        public string AssayDescription { set; get; }
        [Required]
        [DisplayName("Assay Protocol")]
        public string AssayProtocol { get; set; }
        [Required]
        [DisplayName("Completion Estimate")]
        public int CompletionEstimate { get; set; }

      
       
    }
}