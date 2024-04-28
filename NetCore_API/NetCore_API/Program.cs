using NetCore_API.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
string connectionString = config["ConnectionStrings:DefaultConnection"]!.ToString();

Environment.SetEnvironmentVariable("SQLCONNSTR_DefaultConnection", connectionString);

builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer(Environment.GetEnvironmentVariable("SQLCONNSTR_DefaultConnection")!.ToString());
});

builder.Services.AddControllers().
    AddJsonOptions(opt => {
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler("/api/Error/RegistrarError");

app.MapControllers();

app.Run();