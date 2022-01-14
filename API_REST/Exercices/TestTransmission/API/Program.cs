using AutoMapper;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Persistance;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Partie sécurité
//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate(); // ajout du schéma d'autorosiation via Negociation (donc via header)

//builder.Services.AddAuthorization(options => { // Gestion des authorizations

//    //By default, all incoming request will be authorized according to the default policy
//    options.FallbackPolicy = options.DefaultPolicy;
//}
//);
//Mapper.Initialize(cfg => cfg.AddProfile<TestProfile>());
// AutoMap
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(TestProfile).Assembly);
//builder.Services.AddAutoMapper(Assembly.GetEntryAssembly().GetReferencedAssemblies());
// Connection EFCore avec injection de dépendance, sinon il faut mettre la conection string dans 
// le optionBuilder du DbContext
builder.Services.AddDbContext<TestDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));
//builder.Services.AddDbContext<TestDbContext>();

var app = builder.Build();

//Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
