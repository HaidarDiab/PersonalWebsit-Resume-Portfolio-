namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSocilaLinkClassAndNavigationPropertytoProfileClass2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SocialLinks", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SocialLinks", "Name", c => c.Int(nullable: false));
        }
    }
}
