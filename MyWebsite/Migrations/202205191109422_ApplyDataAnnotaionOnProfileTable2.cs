namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotaionOnProfileTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "Image", c => c.String(nullable: false));
        }
    }
}
