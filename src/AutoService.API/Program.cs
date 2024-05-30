using AutoService.Application;
using AutoService.Domain.Entities.Models.UserModels;
using AutoService.Infrastracture;
using AutoService.Infrastracture.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRateLimiter(x =>
{
    x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    x.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(60);
        options.PermitLimit = 60;
        options.QueueLimit = 20;
    });
});





builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddRateLimiter(x =>
{
    x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
     
    x.AddTokenBucketLimiter("bucket", options =>
    {
        options.ReplenishmentPeriod = TimeSpan.FromSeconds(60);
        options.TokenLimit = 60;
        options.TokensPerPeriod = 20;
        options.AutoReplenishment = true;
    });
});

builder.Services.AddIdentity<User, IdentityRole>()
   .AddEntityFrameworkStores<ServiceDbContext>()
   .AddDefaultTokenProviders();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors();

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            roleManager.CreateAsync(new IdentityRole(role)).Wait();
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    string email = "admin@gmail.com";
    string password = "Adminaka1!";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new User()
        {
            FirstName = email,
            LastName = email,
            UserName = email,
            Email = email,
            Role = "Admin",
            EmailConfirmed = true
        };

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}
app.Run();
