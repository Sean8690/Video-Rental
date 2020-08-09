namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataForNameColumn : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you Go' where Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' where Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you Go' where Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' where Id = 4");
        }
        
        public override void Down()
        {
           
        }
    }
}
