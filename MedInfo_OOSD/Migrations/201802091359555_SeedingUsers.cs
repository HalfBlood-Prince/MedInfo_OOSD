namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd873b980-b4c8-4735-9c61-1da3bd9ee038', N'admin@medinfo.com', 0, N'AD5yce4Q0JuAl0jELS8Z8FJeDwGz5EYvxU4unHm9NWta7JkG7aZ8n3o+eW6EkEfzCQ==', N'1713e875-9561-43ef-beea-98df4aaa4924', NULL, 0, 0, NULL, 1, 0, N'admin@medinfo.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e2c1e30f-7542-4747-b512-bd2e52631054', N'tanim@trtanim.me', 0, N'ACIqEwtBqA9YiKUo+T59h/0E4hvxSzsiX/aKwCD/5cdzL5qAKI1I+Di/gX20cpZODw==', N'fa3f5e63-3077-4411-9d81-401d33ba42d4', NULL, 0, 0, NULL, 1, 0, N'tanim@trtanim.me')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e628c06d-fc45-4e0a-9fb5-e0083e3403ba', N'SuperAdmin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd873b980-b4c8-4735-9c61-1da3bd9ee038', N'e628c06d-fc45-4e0a-9fb5-e0083e3403ba')


");
        }
        
        public override void Down()
        {
        }
    }
}
