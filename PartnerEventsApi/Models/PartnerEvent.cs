using System;
using System.ComponentModel.DataAnnotations;

namespace PartnerEventsApi.Models
{
    public class PartnerEvent
    {
        [Key] // Primary key for EF Core
        public int Id { get; set; }

        [Required]
        public string PartnerId { get; set; }

        public string EventType { get; set; }

        public DateTime Timestamp { get; set; }

        public string Notes { get; set; }
    }
}
