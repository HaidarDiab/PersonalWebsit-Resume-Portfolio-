namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletSocialandprojectNcigationproprtyfromprofile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Profiles", "SocialLinkId", "dbo.SocialLinks");
            DropIndex("dbo.Profiles", new[] { "ProjectId" });
            DropIndex("dbo.Profiles", new[] { "SocialLinkId" });
            DropColumn("dbo.Profiles", "ProjectId");
            DropColumn("dbo.Profiles", "SocialLinkId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "SocialLinkId", c => c.Int(nullable: false));
            AddColumn("dbo.Profiles", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Profiles", "SocialLinkId");
            CreateIndex("dbo.Profiles", "ProjectId");
            AddForeignKey("dbo.Profiles", "SocialLinkId", "dbo.SocialLinks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Profiles", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
