namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerAddress", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerAddress", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
