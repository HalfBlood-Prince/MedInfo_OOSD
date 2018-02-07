namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingChemberAddressToDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "ChemberAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "ChemberAddress");
        }
    }
}
