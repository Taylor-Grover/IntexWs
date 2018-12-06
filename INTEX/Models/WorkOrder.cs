using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    //This model is linked to the WorkOrder table in the Database
    [Table("WorkOrder")]
    public class WorkOrder
    {
        [Key]
      
        [Display(Name = "Work Order Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkOrderNumber { get; set; }

        [Display(Name = "Order Date")]
        [RegularExpression(@"^\d{1,2}\/\d{1,2}\/\d{4}$", ErrorMessage = "Date should be mm/dd/yyyy")]
        public DateTime? OrderDate { get; set; }
  
        [Display(Name = "Due Date")]
        [RegularExpression(@"^\d{1,2}\/\d{1,2}\/\d{4}$", ErrorMessage = "Date should be mm/dd/yyyy")]
        public DateTime? DueDate { get; set; }
  
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }
     
        [Display(Name = "Payment Type")]
        public string PaymentInfo { get; set; }
  
        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "Compound Name")]
        public string CompoundName { get; set; }

        [Display(Name = "Completion Status")]
        public bool? Complete { get; set; }

        [Display(Name = "LT Number")]
        [RegularExpression(@"\d{6}$", ErrorMessage = "LT Number should only have 6 numbers")]
        public int? LTNumber { get; set; }
 
        [Display(Name = "Sales Agent ID")]
        public int? SalesAgentID { get; set; }
    }
}