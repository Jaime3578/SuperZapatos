namespace SuperZapatosModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Articles");
            DropPrimaryKey("dbo.Stores");
            AlterColumn("dbo.Articles", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Stores", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Articles", "id");
            AddPrimaryKey("dbo.Stores", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Stores");
            DropPrimaryKey("dbo.Articles");
            AlterColumn("dbo.Stores", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Articles", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Stores", "id");
            AddPrimaryKey("dbo.Articles", "id");
        }
    }
}
