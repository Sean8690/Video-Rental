namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'215d2094-16c1-4879-8768-be5f2c893cba', N'guest@gmail.com', 0, N'APobuAeWDGHKsbCTWps1m7kXG5Kdh5DslFF8Erk9vy1cv761MhKnkQzC+KnJafaYHg==', N'fd640bac-abf7-4372-a2bf-0c81c4af5e8f', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6a72d675-39ec-4918-b48e-aaafedbdcac0', N'admin@vidiorentalstore.com', 0, N'AEuTyFbQKbebm6GnZYraaCArF71OpvdqHioRUghhd2OG3vUNg3ryXv5Ox6mnVUy/6A==', N'39dd882b-e7f0-45b4-9d74-c25e6dabb553', NULL, 0, 0, NULL, 1, 0, N'admin@vidiorentalstore.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'210fcfac-cc5e-42ba-ba1a-025417a52eb5', N'CanManageAllMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6a72d675-39ec-4918-b48e-aaafedbdcac0', N'210fcfac-cc5e-42ba-ba1a-025417a52eb5')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
