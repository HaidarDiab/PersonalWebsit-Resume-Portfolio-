namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSocilaLinkClassAndNavigationPropertytoProfileClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Profiles", new[] { "Project_Id" });
            RenameColumn(table: "dbo.Profiles", name: "Project_Id", newName: "ProjectId");
            AlterColumn("dbo.Profiles", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Profiles", "ProjectId");
            AddForeignKey("dbo.Profiles", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Profiles", new[] { "ProjectId" });
            AlterColumn("dbo.Profiles", "ProjectId", c => c.Int());
            RenameColumn(table: "dbo.Profiles", name: "ProjectId", newName: "Project_Id");
            CreateIndex("dbo.Profiles", "Project_Id");
            AddForeignKey("dbo.Profiles", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
