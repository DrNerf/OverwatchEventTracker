using System;
using System.ComponentModel.DataAnnotations;

namespace OverwachEventTracker.DAL
{
    internal class Event
    {
        public int EventId { get; set; }

        [MaxLength(100)]
        public string SeasonalName { get; set; }

        public virtual EventType EventType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public static explicit operator EventModel(Event src)
        {
            return new EventModel()
            {
                EndDate = src.EndDate,
                EventId = src.EventId,
                EventType = (EventTypeModel)src.EventType,
                SeasonalName = src.SeasonalName,
                StartDate = src.StartDate
            };
        }
    }
}
