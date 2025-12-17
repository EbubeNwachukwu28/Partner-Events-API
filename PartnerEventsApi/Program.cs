using Microsoft.EntityFrameworkCore;
using PartnerEventsApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PartnerEventsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
