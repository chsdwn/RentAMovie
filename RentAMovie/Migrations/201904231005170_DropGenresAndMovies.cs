namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropGenresAndMovies : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {
            
        }
    }
}
