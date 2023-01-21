using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.Context;
using MovieManagement.DataAccess.Implementation;
using MovieManagement.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


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
