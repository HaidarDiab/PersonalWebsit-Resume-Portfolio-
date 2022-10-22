namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Description", c => c.String());
            DropColumn("dbo.Projects", "Descrition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Descrition", c => c.String());
            DropColumn("dbo.Projects", "Description");
        }
    }
}
