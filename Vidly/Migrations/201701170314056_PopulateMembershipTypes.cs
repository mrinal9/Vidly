namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes values(1,0,0,0)");
            Sql("INSERT INTO MembershipTypes values(2,30,1,10)");
            Sql("INSERT INTO MembershipTypes values(3,90,3,20)");
            Sql("INSERT INTO MembershipTypes values(4,300,12,30)");
        }
        
        public override void Down()
        {
        }
    }
}
