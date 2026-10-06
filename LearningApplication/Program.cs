using LearningApplication;

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
builder.Services.AddApiDI(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Swagger
app.UseSwagger();
app.UseSwaggerUI();

// ❌ COMMENT OUT OR REMOVE THIS LINE inside Docker:
// app.UseHttpsRedirection(); 

// 3. Enable CORS Middleware
app.UseCors(allowAngularOrigin);

app.UseAuthorization();
app.MapControllers();

app.Run();