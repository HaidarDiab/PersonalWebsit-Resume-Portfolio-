namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotaionOnProfileTable3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Profiles", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Profiles", "ApplicationUserId");
            AddForeignKey("dbo.Profiles", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Profiles", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Profiles", "ApplicationUserId");
            AddForeignKey("dbo.Profiles", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
