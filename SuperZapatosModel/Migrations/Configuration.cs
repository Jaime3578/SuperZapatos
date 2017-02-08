namespace SuperZapatosModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperZapatosModel.SuperZapatosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SuperZapatosModel.SuperZapatosContext context)
        {
           
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Store.AddOrUpdate(
            //  p => p.name,
            //  new Store { name = "Andrew Peters" },
            //  new Store { name = "Brice Lambson" },
            //  new Store { name = "Rowan Miller" }
            //);
            
        }
    }
}
