namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgainAddingIdentityToHospital : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Hospitals");
            AddColumn("dbo.Hospitals", "HospitalId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Hospitals", "HospitalId");
            DropColumn("dbo.Hospitals", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hospitals", "Id", c => c.Guid(nullable: false, identity: true));
            DropPrimaryKey("dbo.Hospitals");
            DropColumn("dbo.Hospitals", "HospitalId");
            AddPrimaryKey("dbo.Hospitals", "Id");
        }
    }
}
