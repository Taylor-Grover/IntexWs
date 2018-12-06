using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    //This model is linked to the Test table in the Database
    [Table("Test")]
    public class Test
    {
        [Key]
        public int TestID { get; set; }

        public string TestName { get; set; }
        public double BaseCost { get; set; }

    
    }
}