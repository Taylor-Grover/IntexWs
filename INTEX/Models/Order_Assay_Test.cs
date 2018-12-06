using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    //This model is linked to the Order_Assay_Test table in the Database
    [Table("Order_Assay_Test")]
    public class Order_Assay_Test
    {
        [Key, Column(Order = 0)]
        [DisplayName("Order Number")]
        public int WorkOrderNumber { get; set; }

        [Key, Column(Order = 1)]
        public int AssayID { get; set; }

        [Key, Column(Order = 2)]
        public int TestID { get; set; }

        [RegularExpression(@"\d+$", ErrorMessage = "Employee ID must be an integer")]
        public int? EmployeeID { get; set; }

        [DisplayName("Complete?")]
        public bool? IsComplete  { get; set; }

        [DisplayName("Total Cost")]
        [RegularExpression(@"^\d+\.*\d*$", ErrorMessage = "Total cost should be a number")]
        public double? TotalCost { get; set; }

        
        public int? ResultID { get; set; }

    }
}