using backend.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console();
    });

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services
        .AddDbContext<UsersDbContext>(config =>
        {
            config.UseInMemoryDatabase("MemoryDataBase");
        });

    builder.Services.AddDbContext<ApplicationDbContext>(config =>
    {
        config.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), x =>
        {

        });
    });

    builder.Services
        .AddIdentity<AppUser, IdentityRole>(config =>
        {
            config.Password = new PasswordOptions
            {
                RequireDigit = false,
                RequiredLength = 3,
                RequireLowercase = false,
                RequireUppercase = false,
                RequireNonAlphanumeric = false,
            };
        })
        .AddEntityFrameworkStores<UsersDbContext>()
        .AddDefaultTokenProviders();

    builder.Services
        .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(opts =>
        {
            opts.Cookie.Name = "ReferenceAppAuth";
            opts.LoginPath = "/login";
        });

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        using (var context = scope.ServiceProvider.GetRequiredService<UsersDbContext>())
        {
            context.Database.EnsureCreated();
        }
    }

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception e)
{
    Log.Fatal(e, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
