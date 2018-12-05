using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("WorkOrder")]
    public class WorkOrder
    {
        [Key]
      
        [Display(Name = "Work Order Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkOrderNumber { get; set; }
        
        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }
  
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
  
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }
     
        [Display(Name = "Payment Type")]
        public string PaymentInfo { get; set; }
  
        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "Compound Name")]
        public string CompoundName { get; set; }
 
        [Display(Name = "LT Number")]
        public int? LTNumber { get; set; }
 
        [Display(Name = "Sales Agent ID")]
        public int? SalesAgentID { get; set; }
    }
}