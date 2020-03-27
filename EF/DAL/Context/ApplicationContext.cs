using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.Context
{
    public class ApplicationContext:DbContext
    {
        internal DbSet<Product> Products { get; set; }
        internal DbSet<Category> Categories { get; set; }
        internal DbSet<Supplier> Suppliers { get; set; }

        //static ApplicationContext()
        //{
        //    Database.SetInitializer(new ApplicationDbInitializer());
        //}
        public ApplicationContext()
        {

        }
        public ApplicationContext(string connectionString) : base(connectionString)
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, DAL.Migrations.Configuration>());
        }

        
        
        //public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
        //{
        //    protected override void Seed(ApplicationContext context)
        //    {
        //        context.Products.Add(new Product { ProductName = "Banana", CategoryID = 1, SupplierID = 1 });
        //        context.Products.Add(new Product { ProductName = "Onion", CategoryID = 2, SupplierID = 2 });
        //        context.Categories.Add(new Category { CategoryName = "fruit", Description = "grow on tree" });
        //        context.Categories.Add(new Category { CategoryName = "vagetable", Description = "grow on bush" });
        //        context.Suppliers.Add(new Supplier { CompanyName = "Dolce" });
        //        context.Suppliers.Add(new Supplier { CompanyName = "SpanishFood" });
        //    }
        //}
    }
}
