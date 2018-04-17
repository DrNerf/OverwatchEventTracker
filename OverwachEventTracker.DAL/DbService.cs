using System;
using System.Collections.Generic;
using System.Linq;

namespace OverwachEventTracker.DAL
{
    public class DbService : IDisposable
    {
        private OverwatchEventTrackerContext m_DbContext = new OverwatchEventTrackerContext();

        public NextEventModel GetNextEvent()
        {
            var pastEvents = m_DbContext.Events
                .Include("EventType")
                .ToList();
            var currentYearMap = pastEvents
                .Select(pe => new KeyValuePair<Event, DateTime>(pe, MapToCurrentYear(pe.StartDate)))
                .OrderBy(cym => cym.Value)
                .ToList();
            var nextEvent = currentYearMap.Where(cym => cym.Value > DateTime.UtcNow)
                .Select(cym => cym.Key)
                .FirstOrDefault();
            if (nextEvent == null)
            {
                nextEvent = currentYearMap.First().Key;
            }

            var nextEventInstances = pastEvents
                .Where(pe => pe.EventType.SystemName == nextEvent.EventType.SystemName);
            var estimatedStartDate = new DateTime(
                (long)nextEventInstances.Select(nei => nei.StartDate.Ticks).Average());
            var estimatedEndDate = new DateTime(
                (long)nextEventInstances.Select(nei => nei.EndDate.Ticks).Average());
            return new NextEventModel()
            {
                DisplayName = nextEvent.EventType.DisplayName,
                OccursAt = estimatedStartDate,
                EndsAt = estimatedEndDate,
                IsCurrent = estimatedStartDate >= DateTime.UtcNow
            };
        }

        public void Dispose()
        {
            if (m_DbContext != null)
            {
                m_DbContext.Dispose();
                m_DbContext = null; 
            }
        }

        private DateTime MapToCurrentYear(DateTime date)
        {
            return new DateTime(
                DateTime.Now.Year,
                date.Month,
                date.Day,
                date.Hour,
                date.Minute,
                date.Second);
        }
    }
}
