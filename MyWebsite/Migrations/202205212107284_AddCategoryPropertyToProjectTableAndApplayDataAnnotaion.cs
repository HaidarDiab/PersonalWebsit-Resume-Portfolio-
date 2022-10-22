namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryPropertyToProjectTableAndApplayDataAnnotaion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Category", c => c.String(maxLength: 100));
            AlterColumn("dbo.Projects", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Projects", "Link", c => c.String(maxLength: 250));
            AlterColumn("dbo.Projects", "Description", c => c.String(maxLength: 550));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Description", c => c.String());
            AlterColumn("dbo.Projects", "Link", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String());
            DropColumn("dbo.Projects", "Category");
        }
    }
}
