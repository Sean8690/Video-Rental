namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDBColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "birthday", c => c.DateTime(nullable: false));
        }
    }
}
