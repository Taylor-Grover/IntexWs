using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class NewWorkOrder
    {
        public Client client { get; set; }
        public Assay assay { get; set; }
        public Test test { get; set; }
        public Sample sample { get; set; }
    }
}