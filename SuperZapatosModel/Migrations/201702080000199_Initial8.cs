namespace SuperZapatosModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "store_id", "dbo.Stores");
            AddForeignKey("dbo.Articles", "store_id", "dbo.Stores", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "store_id", "dbo.Stores");
            AddForeignKey("dbo.Articles", "store_id", "dbo.Stores", "id");
        }
    }
}
