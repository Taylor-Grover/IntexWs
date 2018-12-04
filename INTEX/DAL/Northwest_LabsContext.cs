using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace INTEX.DAL
{
    public class Northwest_LabsContext : DbContext
    {
        public Northwest_LabsContext() : base("Northwest_LabsContext")
        {

        }

        public System.Data.Entity.DbSet<INTEX.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.Assay> Assays { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.Order_Assay_Test> Order_Assay_Test { get; set; }
    }

  
}