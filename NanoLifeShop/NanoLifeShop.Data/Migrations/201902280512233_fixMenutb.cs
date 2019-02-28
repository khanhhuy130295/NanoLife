namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixMenutb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Target", c => c.String(maxLength: 10));
            DropColumn("dbo.Menus", "Tagert");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Tagert", c => c.String(maxLength: 10));
            DropColumn("dbo.Menus", "Target");
        }
    }
}
