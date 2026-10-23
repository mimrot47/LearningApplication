using LearningApplication;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastrature.Percestency; // Keep your namespace

var builder = WebApplication.CreateBuilder(args);

// 1. Define CORS Policy Name
var allowAngularOrigin = "_allowAngularOrigin";

// 2. Register CORS Service
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAngularOrigin,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();

// NOTE: Ensure your AddApiDI extension method registers your DbContext correctly!
builder.Services.AddApiDI(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ─── 1. AUTO-RUN MIGRATIONS ON CONTAINER STARTUP (WITH SAFE ERROR CATCHING) ───
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<MyAppDbcontext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        // This will now print the exact root cause instead of failing silently or generically
        logger.LogError(ex, "An error occurred while migrating the database: {Message}", ex.Message);

        if (ex.InnerException != null)
        {
            logger.LogError("Inner Exception: {InnerMessage}", ex.InnerException.Message);
        }

        throw; // Rethrow to stop startup if the DB is completely unreachable
    }
}
// ───────────────────────────────────────────────────

// Configure Swagger (Enabled globally, including Production)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // c.RoutePrefix = string.Empty; // Uncomment if you want Swagger at root URL (e.g. http://localhost:5000/)
});

// ❌ COMMENT OUT OR REMOVE THIS LINE inside Docker:
// app.UseHttpsRedirection(); 

// 3. Enable CORS Middleware
app.UseCors(allowAngularOrigin);

app.UseAuthorization();
app.MapControllers();

app.Run();