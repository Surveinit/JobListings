using JobListings.Data;
using JobListings.Helpers;
using JobListings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add an Entity framework with SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity setup
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

// Role Seeder call
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleSeeder.SeedRoles(services);
}

// Configure the HTTP request pipeline. (Middleware Order is CRITICAL)
// 1. Error Handling (should be near the top, after app.Build())
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 2. HTTP Redirection (e.g., HTTP to HTTPS)
app.UseHttpsRedirection();

// 3. Serve Static Files (from wwwroot)
app.UseStaticFiles();

// 4. Routing (Must be before Authentication/Authorization and Endpoint Mapping)
app.UseRouting();

// 5. Authentication and Authorization (Must be after UseRouting)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=JobListings}/{action=Index}/{sd?}");

app.MapRazorPages();

app.Run();
