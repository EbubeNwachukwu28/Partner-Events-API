namespace PartnerEventsApi.Models
{
    public class PartnerEvent
    {
        public string PartnerId { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty:
        public Datetime Timestamp { get; set; }
        public string? Notes { get; set; }

    }
}