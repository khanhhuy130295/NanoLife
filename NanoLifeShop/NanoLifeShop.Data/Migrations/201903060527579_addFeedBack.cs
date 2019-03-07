namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFeedBack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Messages = c.String(),
                        CreateDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FeedBacks");
        }
    }
}
