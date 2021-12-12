namespace web_app_asp_net_mvc_export_xml.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<web_app_asp_net_mvc_export_xml.Models.TimetableContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "web_app_asp_net_mvc_export_xml.Models.TimetableContext";
        }

        protected override void Seed(web_app_asp_net_mvc_export_xml.Models.TimetableContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
