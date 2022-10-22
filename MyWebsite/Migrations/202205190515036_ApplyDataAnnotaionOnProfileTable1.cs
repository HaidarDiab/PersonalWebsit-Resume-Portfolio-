namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotaionOnProfileTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Profiles", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Profiles", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Website", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Image", c => c.String(nullable: false));
            CreateIndex("dbo.Profiles", "ApplicationUserId");
            AddForeignKey("dbo.Profiles", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Profiles", "Image", c => c.String());
            AlterColumn("dbo.Profiles", "Website", c => c.String());
            AlterColumn("dbo.Profiles", "Address", c => c.String());
            AlterColumn("dbo.Profiles", "Phone", c => c.String());
            AlterColumn("dbo.Profiles", "Email", c => c.String());
            AlterColumn("dbo.Profiles", "FullName", c => c.String());
            AlterColumn("dbo.Profiles", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Profiles", "ApplicationUserId");
            AddForeignKey("dbo.Profiles", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
