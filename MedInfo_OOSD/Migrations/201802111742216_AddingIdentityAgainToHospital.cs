namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIdentityAgainToHospital : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Hospitals");
            AlterColumn("dbo.Hospitals", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Hospitals", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Hospitals");
            AlterColumn("dbo.Hospitals", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Hospitals", "Id");
        }
    }
}
