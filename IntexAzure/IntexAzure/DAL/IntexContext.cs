using IntexAzure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntexAzure.DAL
{
    public class IntexContext : DbContext
    {
        public IntexContext() : base("IntexContext")
        {
        }       

        public DbSet<Assays> Assay { get; set; }
        public DbSet<AssayTypes> AssayType { get; set; }
        public DbSet<Compounds> Compound { get; set; }
        public DbSet<CompoundSamples> CompoundSample { get; set; }
        public DbSet<Customers> Customer { get; set; }
        public DbSet<Employees> Employee { get; set; }
        public DbSet<Materials> Material { get; set; }
        public DbSet<MaterialsList> MaterialsLists { get; set; }
        public DbSet<SpecificTests> SpecificTest { get; set; }
        public DbSet<TestEmployees> TestEmployee { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<WorkOrders> WorkOrder { get; set; }
        

    }
}