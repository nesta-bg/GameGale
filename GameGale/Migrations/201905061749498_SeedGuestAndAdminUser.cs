namespace GameGale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGuestAndAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"

            INSERT INTO[dbo].[AspNetUsers]
            ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
            VALUES(N'60ce19be-0110-44bc-8db5-9e7f6ce5e501', N'admin@gamegale.com', 0, N'APQe9SuJyAXN9cQzyaZ027NLkC7rHLMiy/kRGJT9HH7PypEo65I6wD0yt+GpCiXa8Q==', N'ed381e6f-55e4-45fe-9991-a124bec35ecf', NULL, 0, 0, NULL, 1, 0, N'admin@gamegale.com')


            INSERT INTO[dbo].[AspNetUsers]
            ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
            VALUES(N'73ed2ac6-1962-40cd-b195-325f7eb15380', N'guest@gamegale.com', 0, N'ADPWKKPAEWwK+xOOSkt9O6SaNLlM3QTfp0xpGe1xkrJ5oshTcM25Pfo7NiggzPwV+w==', N'a74887b8-38ab-4aaa-898c-a89e7945c78a', NULL, 0, 0, NULL, 1, 0, N'guest@gamegale.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b42195a2-9206-4142-bff6-2ac52fe820b9', N'CanManageGames')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'60ce19be-0110-44bc-8db5-9e7f6ce5e501', N'b42195a2-9206-4142-bff6-2ac52fe820b9')
            
            ");
        }

    public override void Down()
        {
        }
    }
}
