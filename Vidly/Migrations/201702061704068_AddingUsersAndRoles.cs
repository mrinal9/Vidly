namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1b148cf6-c2df-45ea-b61c-ef3ca20e9382', N'guest@gmail.com', 0, N'AAeC11lxZjmkr6gKS1dt8pAh9eD39xr9o/CxbWHYKHX/U4Iz+/K1afvTjckFki1opA==', N'a62b4343-9193-456c-8a37-842f88ee7866', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b959a29b-1841-4724-810d-7d7c4344ed26', N'admin@gmail.com', 0, N'AB+fSz4URK82HMbhxeblEF/oiEnuhymcqTCmgwg5Dsvzl/h6m90TZ007eKeXZYMMcQ==', N'e68efa8b-c2d1-4218-bd45-440d254c5cb6', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                     
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'939776b6-5d9b-4e6a-b4ad-708dd1d4e8b9', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b959a29b-1841-4724-810d-7d7c4344ed26', N'939776b6-5d9b-4e6a-b4ad-708dd1d4e8b9')
                        ");
        }
        
        public override void Down()
        {
        }
    }
}
