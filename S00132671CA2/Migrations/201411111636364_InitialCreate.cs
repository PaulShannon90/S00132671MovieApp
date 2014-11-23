namespace S00132671CA2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        PosterURL = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.CastLists",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        CastName = c.String(),
                    })
                .PrimaryKey(t => new { t.MovieId, t.ActorId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        ActorName = c.String(),
                    })
                .PrimaryKey(t => t.ActorId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CastLists", new[] { "ActorId" });
            DropIndex("dbo.CastLists", new[] { "MovieId" });
            DropForeignKey("dbo.CastLists", "ActorId", "dbo.Actors");
            DropForeignKey("dbo.CastLists", "MovieId", "dbo.Movies");
            DropTable("dbo.Actors");
            DropTable("dbo.CastLists");
            DropTable("dbo.Movies");
        }
    }
}
