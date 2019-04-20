namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            
            Sql(String.Format("INSERT INTO Movies (Name, GenreId, Stock, ReleaseDate, DateAdded) " +
                "VALUES('Avatar', 7, 7, CAST('2009-12-18' as DATE), CAST('{0}' as DATETIME))", DateTime.Now.ToString("yyyy-MM-dd HH:mm")));
            Sql(String.Format("INSERT INTO Movies (Name, GenreId, Stock, ReleaseDate, DateAdded) " +
                "VALUES('Deadpool', 2, 0, CAST('2016-02-12' as DATE), CAST('{0}' as DATETIME))", DateTime.Now.ToString("yyyy-MM-dd HH:mm")));
            Sql(String.Format("INSERT INTO Movies (Name, GenreId, Stock, ReleaseDate, DateAdded) " +
                "VALUES('Arrival', 4, 3, CAST('2016-11-11' as DATE), CAST('{0}' as DATETIME))", DateTime.Now.ToString("yyyy-MM-dd HH:mm")));
            Sql(String.Format("INSERT INTO Movies (Name, GenreId, Stock, ReleaseDate, DateAdded) " +
                "VALUES('The Martian', 1, 12, CAST('2015-10-02' as DATE), CAST('{0}' as DATETIME))", DateTime.Now.ToString("yyyy-MM-dd HH:mm")));
            Sql(String.Format("INSERT INTO Movies (Name, GenreId, Stock, ReleaseDate, DateAdded) " +
                "VALUES('Life of PI', 1, 9, CAST('2012-11-21' as DATE), CAST('{0}' as DATETIME))", DateTime.Now.ToString("yyyy-MM-dd HH:mm")));
        }
        
        public override void Down()
        {
        }
    }
}
