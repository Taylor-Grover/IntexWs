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
        [Required]
        [Display(Name = "Work Order Number")]
        public int  WorkOrderNumber { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        [Required]
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }
        [Required]
        [Display(Name = "Payment Type")]
        public string PaymentInfo { get; set; }
        [Required]
        [Display(Name = "Comments")]
        public string Comments { get; set; }
        [Required]
        [Display(Name = "LT Number")]
        public int LTNumber { get; set; }
        [Required]
        [Display(Name = "Sales Agent ID")]
        public int SalesAgentID { get; set; }
    }
}