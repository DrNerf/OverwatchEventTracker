using System;

namespace OverwachEventTracker.DAL
{
    /// <summary>
    /// Next Event Model.
    /// </summary>
    public class NextEventModel
    {
        /// <summary>
        /// Gets or sets the occurs at.
        /// </summary>
        public DateTime OccursAt { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is current.
        /// </summary>
        public bool IsCurrent { get; set; }

        /// <summary>
        /// Gets or sets the ends at.
        /// </summary>
        public DateTime EndsAt { get; set; }
    }
}
