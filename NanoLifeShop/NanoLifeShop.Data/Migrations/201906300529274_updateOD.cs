namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "OriginalPrice");
        }
    }
}
