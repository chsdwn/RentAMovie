namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES('Action')");
            Sql("INSERT INTO Genres (Name) VALUES('Adventure')");
            Sql("INSERT INTO Genres (Name) VALUES('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES('Horror')");
            Sql("INSERT INTO Genres (Name) VALUES('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES('Sport')");
            Sql("INSERT INTO Genres (Name) VALUES('Superhero')");
            Sql("INSERT INTO Genres (Name) VALUES('Thriller')");
            Sql("INSERT INTO Genres (Name) VALUES('War')");
        }
        
        public override void Down()
        {
        }
    }
}
