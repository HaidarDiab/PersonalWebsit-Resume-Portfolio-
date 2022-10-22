namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotaionOnProfileTable4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "FullName", c => c.String());
            AlterColumn("dbo.Profiles", "Email", c => c.String());
            AlterColumn("dbo.Profiles", "Phone", c => c.String());
            AlterColumn("dbo.Profiles", "Address", c => c.String());
            AlterColumn("dbo.Profiles", "Website", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "Website", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "FullName", c => c.String(nullable: false));
        }
    }
}
