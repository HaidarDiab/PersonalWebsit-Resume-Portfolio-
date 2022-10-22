namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyRequiredDataAnnotaionOnProjectClassProperties1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Image", c => c.String(nullable: false));
        }
    }
}
