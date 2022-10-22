namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotaionAndAddHttpPostedFileBaseImageFileToProfileProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "ImageName", c => c.String());
            AddColumn("dbo.Profiles", "ImagePath", c => c.String());
            DropColumn("dbo.Profiles", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Image", c => c.String());
            DropColumn("dbo.Profiles", "ImagePath");
            DropColumn("dbo.Profiles", "ImageName");
        }
    }
}
