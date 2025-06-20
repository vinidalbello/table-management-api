using Microsoft.EntityFrameworkCore;
using TableManagement.Data;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var dbHost = Env.GetString("DB_HOST");
var dbPort = Env.GetString("DB_PORT");
var dbName = Env.GetString("DB_DATABASE");
var dbUser = Env.GetString("DB_USER");
var dbPassword = Env.GetString("DB_PASSWORD");

var connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowFrontend",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();
app.MapControllers();
app.Run();