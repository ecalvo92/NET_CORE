using NetCore_API.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
string connectionString = config["ConnectionStrings:DefaultConnection"]!.ToString();

builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddControllers().
    AddJsonOptions(opt => {
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler("/api/Error/RegistrarError");

app.MapControllers();

app.Run();