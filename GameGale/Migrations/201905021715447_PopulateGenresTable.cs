namespace GameGale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Fighting')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Racing')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Shooter')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Sport')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Puzzles')");
        }
        
        public override void Down()
        {
        }
    }
}
