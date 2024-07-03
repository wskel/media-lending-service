using MediaLendingService.Server.Data;
using MediaLendingService.Server.Dto;
using MediaLendingService.Server.Exceptions;
using MediaLendingService.Server.Identity;
using MediaLendingService.Server.Serializers;
using MediaLendingService.Server.Services;
using MediaLendingService.Server.Startup;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(connectionString)
);

// register assertions to be validated on startup
builder.Services.RegisterStartupAssertions();

#region Authorization

builder.Services.AddAuthorizationBuilder()
    .AddPolicyRequireRole(UserRoleDto.Customer)
    .AddPolicyRequireRole(UserRoleDto.Librarian);

#endregion

#region Identity

builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

#endregion

#region Services

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILiteraryCategoryService, LiteraryCategoryService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IJsonSerializer, SystemTextJsonSerializer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
builder.Services.AddProblemDetails();

# endregion

builder.Services.AddSingleton<IStartupAssertionValidator, StartupAssertionValidator>();

var app = builder.Build();

#region Startup assertions

using (var scope = app.Services.CreateScope())
{
    // Validate startup assertions that have been registered
    scope.ServiceProvider.GetRequiredService<IStartupAssertionValidator>().Validate();
}

#endregion

#region Apply migrations

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

#endregion

#region Middleware configuration

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapGroup("/api/v0").MapApplicationIdentityApi();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseExceptionHandler();

#endregion

app.Run();