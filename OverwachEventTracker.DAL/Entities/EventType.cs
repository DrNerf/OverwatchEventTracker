using System.ComponentModel.DataAnnotations;

namespace OverwachEventTracker.DAL
{
    internal class EventType
    {
        [Key]
        [MaxLength(50)]
        public string SystemName { get; set; }

        [MaxLength(100)]
        public string DisplayName { get; set; }

        public static explicit operator EventTypeModel(EventType src)
        {
            return new EventTypeModel(src.SystemName, src.DisplayName);
        }
    }
}
