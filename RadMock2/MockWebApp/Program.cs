using Microsoft.EntityFrameworkCore;
using Tracker.WebAPIClient;
using MockConsoleApp.Data;

var builder = WebApplication.CreateBuilder(args);

ActivityAPIClient.Track(StudentID: "S00235207", StudentName: "EunanMurray",
activityName: "Rad301 January 2024", Task: "Q1 Part d");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FE23>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
