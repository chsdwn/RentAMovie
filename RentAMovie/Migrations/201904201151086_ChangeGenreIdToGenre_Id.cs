namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenreIdToGenre_Id : DbMigration
    {
        public override void Up()
        {
            Sql("SP_RENAME 'Movies.GenreId', 'Genre_Id'");
        }
        
        public override void Down()
        {
        }
    }
}
