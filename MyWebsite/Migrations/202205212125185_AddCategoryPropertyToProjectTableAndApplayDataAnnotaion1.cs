namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryPropertyToProjectTableAndApplayDataAnnotaion1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "ApplicationUserId");
            AddForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "ApplicationUserId" });
            DropColumn("dbo.Projects", "ApplicationUserId");
        }
    }
}
