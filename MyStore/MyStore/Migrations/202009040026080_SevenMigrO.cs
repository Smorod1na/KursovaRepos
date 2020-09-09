namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SevenMigrO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Categorie", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Categorie");
        }
    }
}
