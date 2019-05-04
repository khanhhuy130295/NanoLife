namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOriginalPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "OriginalPrice");
        }
    }
}
