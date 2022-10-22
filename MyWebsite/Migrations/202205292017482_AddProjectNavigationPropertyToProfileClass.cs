namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectNavigationPropertyToProfileClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Project_Id", c => c.Int());
            CreateIndex("dbo.Profiles", "Project_Id");
            AddForeignKey("dbo.Profiles", "Project_Id", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Profiles", new[] { "Project_Id" });
            DropColumn("dbo.Profiles", "Project_Id");
        }
    }
}
