using _2022MVC.Data;
using _2022MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using _2022PracticePaper.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDbContext<DbContext2022>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    var roles = new[] { "Registrar", "Team Manager" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var users = new[]
    {
        new { FirstName = "Paul", LastName = "Dalton", Email = "admin@bufc.ie", Password = "Padmin$1", Role = "Registrar" },
        new { FirstName = "Bill", LastName = "Martin", Email = "bloggsm@bufc.ie", Password = "Employee$1", Role = "Team Manager" },
        new { FirstName = "Mary", LastName = "Bligh", Email = "blighm@bufc.ie", Password = "Employee$1", Role = "Team Manager" },
        new { FirstName = "Martha", LastName = "Rotter", Email = "rotterm@bufc.ie", Password = "Employee$1", Role = "Team Manager" }
    };

    foreach (var userInfo in users)
    {
        if (await userManager.FindByEmailAsync(userInfo.Email) == null)
        {
            var user = new ApplicationUser
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Email = userInfo.Email,
                UserName = userInfo.Email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, userInfo.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, userInfo.Role);
            }
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
