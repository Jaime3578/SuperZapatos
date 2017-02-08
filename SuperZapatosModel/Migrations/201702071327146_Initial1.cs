namespace SuperZapatosModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "store_id", "dbo.Stores");
            DropIndex("dbo.Articles", new[] { "store_id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Articles", "store_id");
            AddForeignKey("dbo.Articles", "store_id", "dbo.Stores", "id");
        }
    }
}
