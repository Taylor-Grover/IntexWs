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

        public System.Data.Entity.DbSet<INTEX.Models.WorkOrder_Compound> WorkOrder_Compound { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.WorkOrder> WorkOrders { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.Sample> Samples { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.Test> Tests { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.displayTests> displayTests { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.ClientAccount> ClientAccounts { get; set; }
    }

  
}