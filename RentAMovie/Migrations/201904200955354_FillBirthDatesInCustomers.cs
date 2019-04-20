namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillBirthDatesInCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate=CAST('1989-02-23' AS DATE) WHERE Id=1");
            Sql("UPDATE Customers SET BirthDate=CAST('1989-05-07' AS DATE) WHERE Id=3");
        }
        
        public override void Down()
        {
        }
    }
}
