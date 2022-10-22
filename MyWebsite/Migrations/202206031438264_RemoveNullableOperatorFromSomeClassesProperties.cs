namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNullableOperatorFromSomeClassesProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Educations", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Educations", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WorkExperiences", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WorkExperiences", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkExperiences", "EndDate", c => c.DateTime());
            AlterColumn("dbo.WorkExperiences", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Educations", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Educations", "StartDate", c => c.DateTime());
        }
    }
}
