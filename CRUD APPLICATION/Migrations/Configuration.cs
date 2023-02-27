namespace CRUD_APPLICATION.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //internal sealed class Configuration : DbMigrationsConfiguration<CRUD_APPLICATION.Models.Context>
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.DataContexts>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(CRUD_APPLICATION.Models.Context context)
        protected override void Seed(DAL.Models.DataContexts dataContexts)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
