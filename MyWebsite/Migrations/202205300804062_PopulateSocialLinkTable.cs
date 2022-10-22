namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSocialLinkTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SocialLinks (Name, Link) Values ('Gmail', 'Haidar.Diab.Pu@gmail.com')");
        }
        
        public override void Down()
        {
        }
    }
}
