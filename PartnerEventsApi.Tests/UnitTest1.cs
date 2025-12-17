using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerEventsApi.Controllers;
using PartnerEventsApi.Data;
using PartnerEventsApi.Models;
using Xunit;

namespace PartnerEventsApi.Tests
{
    public class PartnerEventsControllerTests
    {
        private static PartnerEventsDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<PartnerEventsDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // fresh DB per test
                .Options;

            return new PartnerEventsDbContext(options);
        }

        [Fact]
        public void CreateEvent_AddsEvent_AndReturnsOkWithEvent()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            var controller = new PartnerEventsController(context);

            var newEvent = new PartnerEvent
            {
                PartnerId = "ADT-01",
                EventType = "DEVICE_ONLINE",
                Timestamp = DateTime.UtcNow,
                Notes = "Device rebooted"
            };

            // Act
            var result = controller.CreateEvent(newEvent);

            // Assert (HTTP response)
            var ok = Assert.IsType<OkObjectResult>(result);
            var returned = Assert.IsType<PartnerEvent>(ok.Value);

            Assert.Equal("ADT-01", returned.PartnerId);

            // Assert (saved to DB)
            Assert.Equal(1, context.PartnerEvents.Count());
        }

        [Fact]
        public void GetEvents_ReturnsOk_WithListOfEvents()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            context.PartnerEvents.Add(new PartnerEvent
            {
                PartnerId = "TELGUARD",
                EventType = "ALARM_TRIGGERED",
                Timestamp = DateTime.UtcNow,
                Notes = "Test"
            });
            context.SaveChanges();

            var controller = new PartnerEventsController(context);

            // Act
            var result = controller.GetEvents();

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            var events = Assert.IsAssignableFrom<IEnumerable<PartnerEvent>>(ok.Value);

            Assert.Single(events);
            Assert.Equal("TELGUARD", events.First().PartnerId);
        }
    }
}
