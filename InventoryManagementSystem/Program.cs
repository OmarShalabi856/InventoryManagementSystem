using dotenv.net;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Repository;
using InventoryManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages(); // <-- Add Razor Pages

// Add SQLite EF Core DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=inventory.db"));

// Register repository and service as scoped
builder.Services.AddScoped<ItemRepository>();
builder.Services.AddScoped<OpenAIService>();




// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGet("/", context => {
    context.Response.Redirect("/Index");
    return Task.CompletedTask;
});

app.MapControllers();
app.MapRazorPages(); // <-- Map Razor Pages

app.Run();
