using MediaLendingService.Server.Data;
using MediaLendingService.Server.Exceptions;
using MediaLendingService.Server.Serializers;
using MediaLendingService.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(connectionString)
);

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILiteraryCategoryService, LiteraryCategoryService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IJsonSerializer, SystemTextJsonSerializer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseExceptionHandler();

app.Run();
