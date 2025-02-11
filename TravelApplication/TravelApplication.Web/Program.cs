using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelApplication.Domain.Identity;
using TravelApplication.Repository;

using TravelApplication.Repository.Implementation;
using TravelApplication.Service.Interfaces;
using TravelApplication.Service.Implementation;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Get Connection String from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 🔹 Configure Database Context with Explicit Migrations Assembly
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TravelApplication.Repository")));

// 🔹 Configure Identity (Authentication)
builder.Services.AddDefaultIdentity<TravelApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>() // ✅ Enables Role-Based Authorization
.AddEntityFrameworkStores<ApplicationDbContext>();

// 🔹 Register Repositories (Dependency Injection)
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IAccommodationRepository, AccommodationRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<ITransportRepository, TransportRepository>();

// 🔹 Register Services (Dependency Injection) ✅ Fixed naming issues
builder.Services.AddScoped<IDestinationService, DestinationServices>(); // 🔹 Corrected from DestinationServices
builder.Services.AddScoped<IAccommodationService, AccommodationServices>(); // 🔹 Corrected from AccommodationServices
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<ITransportService, TransportService>();
// 🔹 Add Controllers & Views for MVC Support
builder.Services.AddControllersWithViews();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware Configuration
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configure MVC Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    Console.WriteLine($"Connected to Database: {dbContext.Database.GetDbConnection().ConnectionString}");
}


app.Run();
