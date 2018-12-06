using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    //This model is being used to gather all the test ids linked to a specific assay and to display those tests. It allows the system to store a list of test ids
    public class testid
    {
        [Key]
        public int TestID { get; set; }
    }
}