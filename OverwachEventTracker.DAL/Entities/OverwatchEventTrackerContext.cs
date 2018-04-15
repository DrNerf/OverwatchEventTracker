using System.Data.Entity;

namespace OverwachEventTracker.DAL
{
    internal class OverwatchEventTrackerContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<EventType> EventTypes { get; set; }
    }
}
