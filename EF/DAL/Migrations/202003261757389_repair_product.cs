namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repair_product : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.Int(nullable: false));
        }
    }
}
