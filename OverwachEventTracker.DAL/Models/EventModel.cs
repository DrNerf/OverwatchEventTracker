using System;

namespace OverwachEventTracker.DAL
{
    /// <summary>
    /// Event Model.
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the name of the seasonal.
        /// </summary>
        public string SeasonalName { get; set; }

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        public virtual EventTypeModel EventType { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
