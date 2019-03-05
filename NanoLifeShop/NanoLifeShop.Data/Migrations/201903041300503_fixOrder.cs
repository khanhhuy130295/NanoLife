namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerMessages", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerMessages", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
