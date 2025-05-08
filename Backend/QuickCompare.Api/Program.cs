using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuickCompare.Application.Interfaces;
using QuickCompare.Application.Services;
using QuickCompare.Domain.Interfaces;
using QuickCompare.Infra.Data.Data;
using QuickCompare.Infra.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 41));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("defaultConnection"), serverVersion));

builder.Services.AddScoped<ICelularService, CelularService>();
builder.Services.AddScoped<ICelularRepository, CelularRepository>();
builder.Services.AddScoped<INotebookService, NotebookService>();
builder.Services.AddScoped<INotebookRepository, NotebookRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "QuickCompare API",
        Version = "v1"
    });
});

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