namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePaymentMethod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentMethods", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaymentMethods", "Status");
        }
    }
}
