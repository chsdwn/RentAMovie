namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'8348f6c4-da5b-4fde-94c4-1dc72e5deaad', N'admin@rentamovie.com', 0, N'ACcBmTdTYuXffKld2r6drfBKNR8221r9ButXCawfnSFQOyhSMlKuiGBtqpQjwajTOg==', N'c714439c-5978-43f1-8fbd-eafa401e102b', NULL, 0, 0, NULL, 1, 0, N'admin@rentamovie.com', N'a', N'+905123456789')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'b8a94347-70a9-47ff-a540-824182c1090a', N'guest@rentamovie.com', 0, N'AGwoxmrPuxVLfVR8EjOXw7qfmSDcZuI5t8HPfWUySb8Ovef7fhqa4sPsTiSIAY4U5g==', N'2afe0313-ba35-4824-ae05-d29ab6041c90', NULL, 0, 0, NULL, 1, 0, N'guest@rentamovie.com', N'B2', N'+905123456789')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'539d9b1d-5b53-4880-a96b-8f18641d6125', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8348f6c4-da5b-4fde-94c4-1dc72e5deaad', N'539d9b1d-5b53-4880-a96b-8f18641d6125')");
        }
        
        public override void Down()
        {
        }
    }
}
