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

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TravelApplication.Repository")));


builder.Services.AddDefaultIdentity<TravelApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>() 
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IAccommodationRepository, AccommodationRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<ITransportRepository, TransportRepository>();
builder.Services.AddScoped<IDestinationActivityRepository, DestinationActivityRepository>();
builder.Services.AddScoped<IDestinationTransportRepository, DestinationTransportRepository>();
builder.Services.AddScoped<IDestinationTransportRepository, DestinationTransportRepository>();

builder.Services.AddScoped<IDestinationService, DestinationServices>(); 
builder.Services.AddScoped<IAccommodationService, AccommodationServices>(); 
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<ITransportService, TransportService>();
builder.Services.AddScoped<IDestinationActivityService, DestinationActivityService>();
builder.Services.AddScoped<IDestinationTransportService, DestinationTransportService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    Console.WriteLine($"Connected to Database: {dbContext.Database.GetDbConnection().ConnectionString}");
}


app.Run();
