namespace SuperZapatosModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "name", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Stores", "name", c => c.String(nullable: false, maxLength: 250, unicode: false));
            CreateIndex("dbo.Articles", "store_id");
            AddForeignKey("dbo.Articles", "store_id", "dbo.Stores", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "store_id", "dbo.Stores");
            DropIndex("dbo.Articles", new[] { "store_id" });
            AlterColumn("dbo.Stores", "name", c => c.String());
            AlterColumn("dbo.Articles", "name", c => c.String());
        }
    }
}
