namespace FamousQuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Menu_MenuIdAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubMenus", "Menu_MenuId", "dbo.Menus");
            DropIndex("dbo.SubMenus", new[] { "Menu_MenuId" });
            AddColumn("dbo.SubMenus", "Menu_MenuId1", c => c.Int());
            AlterColumn("dbo.SubMenus", "Menu_MenuId", c => c.Int(nullable: true));
            CreateIndex("dbo.SubMenus", "Menu_MenuId1");
            AddForeignKey("dbo.SubMenus", "Menu_MenuId1", "dbo.Menus", "MenuId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubMenus", "Menu_MenuId1", "dbo.Menus");
            DropIndex("dbo.SubMenus", new[] { "Menu_MenuId1" });
            AlterColumn("dbo.SubMenus", "Menu_MenuId", c => c.Int());
            DropColumn("dbo.SubMenus", "Menu_MenuId1");
            CreateIndex("dbo.SubMenus", "Menu_MenuId");
            AddForeignKey("dbo.SubMenus", "Menu_MenuId", "dbo.Menus", "MenuId");
        }
    }
}
