using app.Services;
using app.Invocables;
using Coravel;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<InfluxDBService>();
builder.Services.AddTransient<WriteRandomPlaneAltitudeInvocable>();
builder.Services.AddScheduler();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Enable Coravel Scheduler

app.Services.UseScheduler(scheduler =>
{
    scheduler
        .Schedule<WriteRandomPlaneAltitudeInvocable>()
        .EveryFiveSeconds();
});

// Middleware & endpoints
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();