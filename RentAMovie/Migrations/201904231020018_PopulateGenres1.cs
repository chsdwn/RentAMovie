namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES(1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(2, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(3, 'Crime')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(4, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(5, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(6, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(7, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(8, 'Sport')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(9, 'Superhero')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(10, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(11, 'War')");
        }
        
        public override void Down()
        {
        }
    }
}
