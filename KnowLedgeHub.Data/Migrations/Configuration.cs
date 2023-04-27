namespace KnowLedgeHub.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KnowLedgeHub.Data.KnowLedgeHubDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "KnowLedgeHub.Data.KnowLedgeHubDBContext";
        }

        protected override void Seed(KnowLedgeHub.Data.KnowLedgeHubDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
