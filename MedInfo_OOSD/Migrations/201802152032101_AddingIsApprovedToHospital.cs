namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIsApprovedToHospital : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hospitals", "IsApproved");
        }
    }
}
