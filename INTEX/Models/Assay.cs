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
        public int AssayDescription { set; get; }
        [Required]
        public int AssayProtocol { get; set; }
        [Required]
        public int Compensation { get; set; }
    }
}