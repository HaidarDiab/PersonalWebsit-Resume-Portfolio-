namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyRequiredDataAnnotaionOnProjectClassProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Projects", "Category", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Projects", "Link", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Projects", "Description", c => c.String(nullable: false, maxLength: 550));
            AlterColumn("dbo.Projects", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Projects", "ApplicationUserId");
            AddForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Projects", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projects", "Image", c => c.String());
            AlterColumn("dbo.Projects", "Description", c => c.String(maxLength: 550));
            AlterColumn("dbo.Projects", "Link", c => c.String(maxLength: 250));
            AlterColumn("dbo.Projects", "Category", c => c.String(maxLength: 100));
            AlterColumn("dbo.Projects", "Name", c => c.String(maxLength: 100));
            CreateIndex("dbo.Projects", "ApplicationUserId");
            AddForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
