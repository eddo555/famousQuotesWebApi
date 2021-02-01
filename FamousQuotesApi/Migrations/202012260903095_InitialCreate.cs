namespace FamousQuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        SubMenuId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Quote = c.String(),
                        Menu_MenuId = c.Int(),
                    })
                .PrimaryKey(t => t.SubMenuId)
                .ForeignKey("dbo.Menus", t => t.Menu_MenuId)
                .Index(t => t.Menu_MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubMenus", "Menu_MenuId", "dbo.Menus");
            DropIndex("dbo.SubMenus", new[] { "Menu_MenuId" });
            DropTable("dbo.SubMenus");
            DropTable("dbo.Menus");
        }
    }
}
