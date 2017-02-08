namespace SuperZapatosModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "name", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Stores", "name", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "name", c => c.String());
            AlterColumn("dbo.Articles", "name", c => c.String());
        }
    }
}
