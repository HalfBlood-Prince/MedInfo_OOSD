namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingIdentityToHospital : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Hospitals");
            AddColumn("dbo.Hospitals", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Hospitals", "Id");
            DropColumn("dbo.Hospitals", "HospitalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hospitals", "HospitalId", c => c.Guid(nullable: false, identity: true));
            DropPrimaryKey("dbo.Hospitals");
            DropColumn("dbo.Hospitals", "Id");
            AddPrimaryKey("dbo.Hospitals", "HospitalId");
        }
    }
}
