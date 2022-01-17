using Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using Perstistance;
using Perstistance.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mapper profiles utilisé
builder.Services.AddAutoMapper(typeof(DtoEntityProfile).Assembly);

// Context Manager utilisé (non -> Context utilisé directement : on ne peut pas passer par un repository comme sa!)
//builder.Services.AddDbContext<WikiBeerSqlContext>(options =>
//   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));
// a creuser à la place de ce qu'il y a au dessu: https://www.c-sharpcorner.com/blogs/net-core-mvc-with-entity-framework-core-using-dependency-injection-and-repository
//builder.Services.AddScoped<IBeerRepository, BddBeerManager>();
//builder.Services.AddDbContextPool<WikiBeerSqlContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));
//builder.Services.AddDbContextPool<WikiBeerSqlContext>(opt => opt.UseSqlServer(ConnectionStrings, b => b.MigrationsAssembly("Persistance")));

//builder.Services.AddScoped<IBeerRepository, BddBeerManager>();
//builder.Services.AddScoped<IBeerRepository, BeerRepository>();
builder.Services.AddDbContext<WikiBeerSqlContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));
// a creuser à la place de ce qu'il y a au dessu: https://www.c-sharpcorner.com/blogs/net-core-mvc-with-entity-framework-core-using-dependency-injection-and-repository
//builder.Services.AddDbContextPool<WikiBeerSqlContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));


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
