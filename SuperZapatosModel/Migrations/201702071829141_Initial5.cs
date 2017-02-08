namespace SuperZapatosModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Articles");
            DropPrimaryKey("dbo.Stores");
            AlterColumn("dbo.Articles", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Articles", "name", c => c.String());
            AlterColumn("dbo.Stores", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Stores", "name", c => c.String());
            AddPrimaryKey("dbo.Articles", "id");
            AddPrimaryKey("dbo.Stores", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Stores");
            DropPrimaryKey("dbo.Articles");
            AlterColumn("dbo.Stores", "name", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Stores", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Articles", "name", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Articles", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Stores", "id");
            AddPrimaryKey("dbo.Articles", "id");
        }
    }
}
