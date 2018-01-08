namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRateToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "RateVal", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Rate_Id", c => c.Byte());
            CreateIndex("dbo.Movies", "Rate_Id");
            AddForeignKey("dbo.Movies", "Rate_Id", "dbo.Rates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Rate_Id", "dbo.Rates");
            DropIndex("dbo.Movies", new[] { "Rate_Id" });
            DropColumn("dbo.Movies", "Rate_Id");
            DropColumn("dbo.Movies", "RateVal");
            DropTable("dbo.Rates");
        }
    }
}
