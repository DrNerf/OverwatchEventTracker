namespace OverwachEventTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OverwachEventTracker.DAL.OverwatchEventTrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OverwachEventTracker.DAL.OverwatchEventTrackerContext";
        }

        protected override void Seed(OverwachEventTracker.DAL.OverwatchEventTrackerContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (!context.EventTypes.Any())
            {
                var summerGames = new EventType()
                {
                    SystemName = "SummerGames",
                    DisplayName = "Summer Games"
                };
                context.EventTypes.AddOrUpdate(
                    summerGames,
                    new EventType() { SystemName = "Halloween", DisplayName = "Halloween Terror" },
                    new EventType() { SystemName = "Winter", DisplayName = "Winter Wonderland" },
                    new EventType() { SystemName = "LunarNewYear", DisplayName = "Lunar New Year" },
                    new EventType() { SystemName = "Archives", DisplayName = "Archives" },
                    new EventType() { SystemName = "Anniversary", DisplayName = "Anniversary" });

                context.Events.AddOrUpdate(new Event()
                {
                    EventType = summerGames,
                    SeasonalName = "Summer Games",
                    StartDate = DateTime.Parse("August 2, 2016"),
                    EndDate = DateTime.Parse("August 22, 2016")
                });
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
