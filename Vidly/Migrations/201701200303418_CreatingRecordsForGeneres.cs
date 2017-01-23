namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingRecordsForGeneres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Generes values (1,'Comedy')");
            Sql("INSERT INTO Generes values (2,'Action')");
            Sql("INSERT INTO Generes values (3,'Family')");
            Sql("INSERT INTO Generes values (4,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
