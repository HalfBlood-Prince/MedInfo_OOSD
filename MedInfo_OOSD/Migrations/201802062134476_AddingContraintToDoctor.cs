namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingContraintToDoctor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Doctors", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Doctors", "ChemberAddress", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Doctors", "AvailableDays", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "AvailableDays", c => c.String());
            AlterColumn("dbo.Doctors", "ChemberAddress", c => c.String());
            AlterColumn("dbo.Doctors", "Email", c => c.String());
            AlterColumn("dbo.Doctors", "Name", c => c.String());
        }
    }
}
