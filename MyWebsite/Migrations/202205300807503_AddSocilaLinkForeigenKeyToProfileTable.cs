namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSocilaLinkForeigenKeyToProfileTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "SocialLinkId", c => c.Int(nullable: false));
            CreateIndex("dbo.Profiles", "SocialLinkId");
            AddForeignKey("dbo.Profiles", "SocialLinkId", "dbo.SocialLinks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "SocialLinkId", "dbo.SocialLinks");
            DropIndex("dbo.Profiles", new[] { "SocialLinkId" });
            DropColumn("dbo.Profiles", "SocialLinkId");
        }
    }
}
