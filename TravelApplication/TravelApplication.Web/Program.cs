using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TravelApplication.Domain.Domain.MappingModels;
using TravelApplication.Domain.Identity;
using TravelApplication.Repository;
using TravelApplication.Repository.Implementation;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Implementation;
using TravelApplication.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Server=travelapp-mysql-db.mysql.database.azure.com;User=travelapp;Password=Diellza123$;Database=travelapp-mysql-db;SslMode=Required;";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddDefaultIdentity<TravelApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddTransient<IAccommodationService, AccommodationService>();
builder.Services.AddTransient<IActivityService, ActivityService>();
builder.Services.AddTransient<IAttractionService, AttractionService>();
builder.Services.AddTransient<IDestinationService, DestinationService>();
builder.Services.AddTransient<IMealService, MealService>();
builder.Services.AddTransient<ITransportService, TransportService>();
builder.Services.AddTransient<ITravelPackageService, TravelPackageService>();
builder.Services.AddTransient<IBookingService, BookingService>();



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});



var app = builder.Build();
app.UseCors("AllowReactApp");


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
