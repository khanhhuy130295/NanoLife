namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixSupportOnline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupportOnlines", "Address", c => c.String());
            AlterColumn("dbo.SupportOnlines", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SupportOnlines", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.SupportOnlines", "Address");
        }
    }
}
