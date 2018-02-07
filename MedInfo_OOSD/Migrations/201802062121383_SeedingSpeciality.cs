namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingSpeciality : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Specialities] ON
INSERT INTO [dbo].[Specialities] ([Id], [Name]) VALUES (1, N'Child')
INSERT INTO [dbo].[Specialities] ([Id], [Name]) VALUES (2, N'Cancer')
INSERT INTO [dbo].[Specialities] ([Id], [Name]) VALUES (3, N'Medicine')
INSERT INTO [dbo].[Specialities] ([Id], [Name]) VALUES (4, N'Dermatologist')
SET IDENTITY_INSERT [dbo].[Specialities] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
