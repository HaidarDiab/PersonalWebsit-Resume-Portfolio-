namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserNagigationPropertyToALLcLASSES : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeveloperSkills", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Educations", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Languages", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.PersonalSkills", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.SocialLinks", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.SoftwareSkills", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Summaries", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.WorkExperiences", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.WorkSpecialtis", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.DeveloperSkills", "ApplicationUserId");
            CreateIndex("dbo.Educations", "ApplicationUserId");
            CreateIndex("dbo.Languages", "ApplicationUserId");
            CreateIndex("dbo.PersonalSkills", "ApplicationUserId");
            CreateIndex("dbo.SocialLinks", "ApplicationUserId");
            CreateIndex("dbo.SoftwareSkills", "ApplicationUserId");
            CreateIndex("dbo.Summaries", "ApplicationUserId");
            CreateIndex("dbo.WorkExperiences", "ApplicationUserId");
            CreateIndex("dbo.WorkSpecialtis", "ApplicationUserId");
            AddForeignKey("dbo.DeveloperSkills", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Educations", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Languages", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PersonalSkills", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SocialLinks", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SoftwareSkills", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Summaries", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkExperiences", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkSpecialtis", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkSpecialtis", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperiences", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Summaries", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SoftwareSkills", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SocialLinks", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalSkills", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Languages", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Educations", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DeveloperSkills", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.WorkSpecialtis", new[] { "ApplicationUserId" });
            DropIndex("dbo.WorkExperiences", new[] { "ApplicationUserId" });
            DropIndex("dbo.Summaries", new[] { "ApplicationUserId" });
            DropIndex("dbo.SoftwareSkills", new[] { "ApplicationUserId" });
            DropIndex("dbo.SocialLinks", new[] { "ApplicationUserId" });
            DropIndex("dbo.PersonalSkills", new[] { "ApplicationUserId" });
            DropIndex("dbo.Languages", new[] { "ApplicationUserId" });
            DropIndex("dbo.Educations", new[] { "ApplicationUserId" });
            DropIndex("dbo.DeveloperSkills", new[] { "ApplicationUserId" });
            DropColumn("dbo.WorkSpecialtis", "ApplicationUserId");
            DropColumn("dbo.WorkExperiences", "ApplicationUserId");
            DropColumn("dbo.Summaries", "ApplicationUserId");
            DropColumn("dbo.SoftwareSkills", "ApplicationUserId");
            DropColumn("dbo.SocialLinks", "ApplicationUserId");
            DropColumn("dbo.PersonalSkills", "ApplicationUserId");
            DropColumn("dbo.Languages", "ApplicationUserId");
            DropColumn("dbo.Educations", "ApplicationUserId");
            DropColumn("dbo.DeveloperSkills", "ApplicationUserId");
        }
    }
}
