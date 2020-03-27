namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Context.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Context.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //context.Categories.Add(new Category { CategoryID = 1, CategoryName = "fruit", Description = "grow on tree" });
            //context.Categories.Add(new Category { CategoryID = 2, CategoryName = "vagetable", Description = "grow on bush" });
            //context.Suppliers.Add(new Supplier { SupplierID = 1, CompanyName = "Dolce" });
            //context.Suppliers.Add(new Supplier { SupplierID = 2, CompanyName = "SpanishFood" });
            //context.Products.Add(new Product() { ProductName = "Banana", Category = new Category { CategoryID = 1, CategoryName = "fruit", Description = "grow on tree" }, Supplier = new Supplier { SupplierID = 1, CompanyName = "Dolce" } });
            //context.Products.Add(new Product() { ProductName = "Onion", Category = new Category() { CategoryID = 2, CategoryName = "vagetable", Description = "grow on bush" }, Supplier = new Supplier() { SupplierID = 2, CompanyName = "SpanishFood" } });


        }
    }
}
