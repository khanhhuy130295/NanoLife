namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixSupport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupportOnlines", "Lng", c => c.Double());
            AddColumn("dbo.SupportOnlines", "Lat", c => c.Double());
            AlterColumn("dbo.SupportOnlines", "Email", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SupportOnlines", "Email", c => c.String(maxLength: 50));
            DropColumn("dbo.SupportOnlines", "Lat");
            DropColumn("dbo.SupportOnlines", "Lng");
        }
    }
}
