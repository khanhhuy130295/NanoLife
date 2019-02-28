namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixErrorTB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Erros", newName: "Errors");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Errors", newName: "Erros");
        }
    }
}
