using Microsoft.EntityFrameworkCore;
using PlacementTask.Data;
using PlacementTask.Infrastructure.Middleware;
using PlacementTask.Model;
using PlacementTask.Services;
using PlacementTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var cosmosOptions = builder.Configuration.GetSection("CosmosDb");
builder.Services.Configure<CosmosDbSettings>(cosmosOptions);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseCosmos(cosmosOptions["ConnectionString"], cosmosOptions["DatabaseName"]);
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProgramService, ProgramService>();

var app = builder.Build();
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
await context.Database.EnsureCreatedAsync();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.MapControllers();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseExceptionHandler();

app.Run();