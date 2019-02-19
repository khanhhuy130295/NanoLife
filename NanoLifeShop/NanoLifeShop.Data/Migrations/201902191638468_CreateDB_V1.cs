namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB_V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Erros",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Url = c.String(maxLength: 256),
                        Tagert = c.String(maxLength: 10),
                        DisplayOder = c.Int(),
                        IDGroup = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroups", t => t.IDGroup, cascadeDelete: true)
                .Index(t => t.IDGroup);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID_Order = c.Int(nullable: false),
                        ID_Product = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.ID_Order, t.ID_Product })
                .ForeignKey("dbo.Orders", t => t.ID_Order, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ID_Product, cascadeDelete: true)
                .Index(t => t.ID_Order)
                .Index(t => t.ID_Product);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 256),
                        CustomerAddress = c.String(nullable: false, maxLength: 200),
                        CustomerPhone = c.String(nullable: false, maxLength: 10),
                        CustomerEmail = c.String(nullable: false, maxLength: 150),
                        CustomerMessages = c.String(nullable: false, maxLength: 500),
                        PaymentMethod = c.String(maxLength: 256),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(),
                        PaymentStatus = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(maxLength: 500),
                        Detail = c.String(),
                        Image = c.String(maxLength: 256),
                        MoreImage = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Warrnary = c.Int(),
                        IncludeTaxes = c.Boolean(),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        IDCategory = c.Int(nullable: false),
                        Tags = c.String(),
                        CreateBy = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        MetaTitle = c.String(),
                        MetaDecriptions = c.String(),
                        MetaKeyWork = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategories", t => t.IDCategory, cascadeDelete: true)
                .Index(t => t.IDCategory);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(maxLength: 500),
                        IdParent = c.Int(),
                        DisplayOder = c.Int(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        CreateBy = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        MetaTitle = c.String(),
                        MetaDecriptions = c.String(),
                        MetaKeyWork = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(maxLength: 500),
                        IdParent = c.Int(),
                        DisplayOder = c.Int(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        CreateBy = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        MetaTitle = c.String(),
                        MetaDecriptions = c.String(),
                        MetaKeyWork = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(maxLength: 500),
                        Detail = c.String(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        Tags = c.String(),
                        IDCategory = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        MetaTitle = c.String(),
                        MetaDecriptions = c.String(),
                        MetaKeyWork = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategories", t => t.IDCategory, cascadeDelete: true)
                .Index(t => t.IDCategory);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        IDPost = c.Int(nullable: false),
                        IDTag = c.String(nullable: false, maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => new { t.IDPost, t.IDTag })
                .ForeignKey("dbo.Posts", t => t.IDPost, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.IDTag, cascadeDelete: true)
                .Index(t => t.IDPost)
                .Index(t => t.IDTag);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        IDProduct = c.Int(nullable: false),
                        IDTag = c.String(nullable: false, maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => new { t.IDProduct, t.IDTag })
                .ForeignKey("dbo.Products", t => t.IDProduct, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.IDTag, cascadeDelete: true)
                .Index(t => t.IDProduct)
                .Index(t => t.IDTag);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256),
                        DisplayOder = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupportOnlines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Department = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Skype = c.String(maxLength: 50),
                        Facebook = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        DisplayOder = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfigs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50, unicode: false),
                        ValueString = c.String(),
                        ValueInt = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Adress = c.String(maxLength: 256),
                        Image = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.VisitorStatistics",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.ProductTags", "IDTag", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "IDProduct", "dbo.Products");
            DropForeignKey("dbo.PostTags", "IDTag", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "IDPost", "dbo.Posts");
            DropForeignKey("dbo.Posts", "IDCategory", "dbo.PostCategories");
            DropForeignKey("dbo.OrderDetails", "ID_Product", "dbo.Products");
            DropForeignKey("dbo.Products", "IDCategory", "dbo.ProductCategories");
            DropForeignKey("dbo.OrderDetails", "ID_Order", "dbo.Orders");
            DropForeignKey("dbo.Menus", "IDGroup", "dbo.MenuGroups");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ProductTags", new[] { "IDTag" });
            DropIndex("dbo.ProductTags", new[] { "IDProduct" });
            DropIndex("dbo.PostTags", new[] { "IDTag" });
            DropIndex("dbo.PostTags", new[] { "IDPost" });
            DropIndex("dbo.Posts", new[] { "IDCategory" });
            DropIndex("dbo.Products", new[] { "IDCategory" });
            DropIndex("dbo.OrderDetails", new[] { "ID_Product" });
            DropIndex("dbo.OrderDetails", new[] { "ID_Order" });
            DropIndex("dbo.Menus", new[] { "IDGroup" });
            DropTable("dbo.VisitorStatistics");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.Slides");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.ProductTags");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Pages");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuGroups");
            DropTable("dbo.Footers");
            DropTable("dbo.Erros");
        }
    }
}
