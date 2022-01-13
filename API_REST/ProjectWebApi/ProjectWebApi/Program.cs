using Microsoft.EntityFrameworkCore;
using ProjectWebApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // pour ajouter un/des mappeur (ici entre project et projectDto)
                                                                         // Nécessite AutoMappeur et Autaomappeur.Extension.Microsoft.DependancyInjection
// Connexion à la BDD via entity framework
builder.Services.AddDbContext<YourAPiContext>(options => // nécessite EnityFrameWork
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext"))); // va chercher dans le appsettings.Development

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
