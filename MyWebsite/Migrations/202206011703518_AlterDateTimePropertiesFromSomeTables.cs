namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDateTimePropertiesFromSomeTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educations", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Educations", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkExperiences", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkExperiences", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Educations", "Date");
            DropColumn("dbo.WorkExperiences", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkExperiences", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Educations", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.WorkExperiences", "EndDate");
            DropColumn("dbo.WorkExperiences", "StartDate");
            DropColumn("dbo.Educations", "EndDate");
            DropColumn("dbo.Educations", "StartDate");
        }
    }
}
