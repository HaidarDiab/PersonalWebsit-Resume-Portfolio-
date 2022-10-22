namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagePathToProjectTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ImagePath");
        }
    }
}
