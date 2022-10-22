namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePopEmailAndAttachementClassesFromModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attachments", "POPEmail_Id", "dbo.POPEmails");
            DropIndex("dbo.Attachments", new[] { "POPEmail_Id" });
            DropTable("dbo.Attachments");
            DropTable("dbo.POPEmails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.POPEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageNumber = c.Int(nullable: false),
                        From = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateSent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        POPEmail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Attachments", "POPEmail_Id");
            AddForeignKey("dbo.Attachments", "POPEmail_Id", "dbo.POPEmails", "Id");
        }
    }
}
