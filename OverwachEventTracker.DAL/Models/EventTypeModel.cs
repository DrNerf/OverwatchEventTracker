namespace OverwachEventTracker.DAL
{
    /// <summary>
    /// Event Type Model.
    /// </summary>
    public class EventTypeModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeModel"/> class.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <param name="displayName">The display name.</param>
        public EventTypeModel(string systemName, string displayName)
        {
            SystemName = systemName;
            DisplayName = displayName;
        }

        /// <summary>
        /// Gets or sets the name of the system.
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }
    }
}
