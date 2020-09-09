namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AditionalMigro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserAditional",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserAditional", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.tblUserAditional", new[] { "Id" });
            DropTable("dbo.tblUserAditional");
        }
    }
}
