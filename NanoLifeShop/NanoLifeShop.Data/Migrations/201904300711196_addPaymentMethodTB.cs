namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPaymentMethodTB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        ID_PaymentMethod = c.String(nullable: false, maxLength: 128, unicode: false),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.ID_PaymentMethod);
            
            AddColumn("dbo.Orders", "ID_PaymentMethod", c => c.String(maxLength: 128, unicode: false));
            CreateIndex("dbo.Orders", "ID_PaymentMethod");
            AddForeignKey("dbo.Orders", "ID_PaymentMethod", "dbo.PaymentMethods", "ID_PaymentMethod");
            DropColumn("dbo.Orders", "PaymentMethod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "PaymentMethod", c => c.String(maxLength: 256));
            DropForeignKey("dbo.Orders", "ID_PaymentMethod", "dbo.PaymentMethods");
            DropIndex("dbo.Orders", new[] { "ID_PaymentMethod" });
            DropColumn("dbo.Orders", "ID_PaymentMethod");
            DropTable("dbo.PaymentMethods");
        }
    }
}
