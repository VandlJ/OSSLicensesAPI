using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the database context using Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Retrieve the connection string from appsettings.json
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
    if (connectionString != null)
    {
        // Use MySQL database provider with the retrieved connection string
        options.UseMySQL(connectionString);
    }
    else
    {
        // Use a default connection string if the one from appsettings.json is not found
        var defaultConnectionString = "DefaultConnection string goes here";
        options.UseMySQL(defaultConnectionString);
        
        // Alternatively, throw an exception if DefaultConnection is not configured
        throw new Exception("DefaultConnection is not configured");
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger middleware for development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map controllers
app.MapControllers();

// Run the application
app.Run();