using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<DatabaseContext>(
//    options => options.UseInMemoryDatabase(databaseName: "InMemDb"));

// dotnet ef migrations add Initial --context=DatabaseContext --project=WebApplication1/WebApplication1.csproj
// dotnet ef database update  --context=DatabaseContext --project=WebApplication1/WebApplication1.csproj

var connectionString = builder.Configuration
    .GetConnectionString("DbConnection");
// https://docs.microsoft.com/ru-ru/ef/core/get-started/overview/install#get-the-net-core-cli-tools
builder.Services.AddDbContext<DatabaseContext>(options => options
    .UseSqlServer(connectionString)
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging());

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<NoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
