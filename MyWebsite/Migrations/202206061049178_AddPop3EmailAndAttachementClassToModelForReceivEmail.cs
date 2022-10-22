namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPop3EmailAndAttachementClassToModelForReceivEmail : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.POPEmails", t => t.POPEmail_Id)
                .Index(t => t.POPEmail_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "POPEmail_Id", "dbo.POPEmails");
            DropIndex("dbo.Attachments", new[] { "POPEmail_Id" });
            DropTable("dbo.POPEmails");
            DropTable("dbo.Attachments");
        }
    }
}
