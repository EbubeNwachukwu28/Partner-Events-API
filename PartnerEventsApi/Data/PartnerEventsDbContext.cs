using Microsoft.EntityFrameworkCore;
using PartnerEventsApi.Models;

namespace PartnerEventsApi.Data
{
    public class PartnerEventsDbContext : DbContext
    {
        public PartnerEventsDbContext(DbContextOptions<PartnerEventsDbContext> options)
            : base(options)
        {
        }

        public DbSet<PartnerEvent> PartnerEvents { get; set; }
    }
}
