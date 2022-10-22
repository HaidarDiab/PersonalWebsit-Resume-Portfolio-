namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProjectTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Projects (Name, ReleaseDate, Link, Description, Image) VALUES ('School', '1 Apr 2020', 'www.google.com', 'Web', '~/images/prof1')");
            Sql("INSERT INTO Projects (Name, ReleaseDate, Link, Description, Image) VALUES ('Project Managment', '1 Mar 2020', 'www.google.com', 'Web', '~/images/prof1')");
            Sql("INSERT INTO Projects (Name, ReleaseDate, Link, Description, Image) VALUES ('Midcin', '1 Apr 2021', 'www.google.com', 'Web', '~/images/prof1')");
            Sql("INSERT INTO Projects (Name, ReleaseDate, Link, Description, Image) VALUES ('Social', '1 Apr 2022', 'www.google.com', 'Web', '~/images/prof1')");

        }

        public override void Down()
        {
        }
    }
}
