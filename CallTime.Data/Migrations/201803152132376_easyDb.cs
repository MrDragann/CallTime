namespace CallTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class easyDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageContentLangs",
                c => new
                    {
                        PageContentId = c.Int(nullable: false),
                        Lang = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => new { t.PageContentId, t.Lang })
                .ForeignKey("dbo.PageContents", t => t.PageContentId, cascadeDelete: true)
                .Index(t => t.PageContentId);
            
            CreateTable(
                "dbo.PageContents",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ContentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageSettingLangs",
                c => new
                    {
                        PageSettingId = c.Int(nullable: false),
                        Lang = c.Int(nullable: false),
                        Title = c.String(),
                        Keywords = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.PageSettingId, t.Lang })
                .ForeignKey("dbo.PageSettings", t => t.PageSettingId, cascadeDelete: true)
                .Index(t => t.PageSettingId);
            
            CreateTable(
                "dbo.PageSettings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 128),
                        Email = c.String(nullable: false, maxLength: 128),
                        PasswordHash = c.String(nullable: false, maxLength: 128),
                        ConfirmationToken = c.Guid(),
                        TokenExpireDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Page = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PageSettingLangs", "PageSettingId", "dbo.PageSettings");
            DropForeignKey("dbo.PageContentLangs", "PageContentId", "dbo.PageContents");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.PageSettingLangs", new[] { "PageSettingId" });
            DropIndex("dbo.PageContentLangs", new[] { "PageContentId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Visits");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.PageSettings");
            DropTable("dbo.PageSettingLangs");
            DropTable("dbo.PageContents");
            DropTable("dbo.PageContentLangs");
        }
    }
}
