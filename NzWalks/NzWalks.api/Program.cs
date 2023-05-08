using Microsoft.EntityFrameworkCore;
using NzWalks.api.Data;
using NzWalks.api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding dependency injection for the db context
//the type this takes is NzWalksDbContext
//help, notes
builder.Services.AddDbContext<NzWalksDbContext>(options =>
{
    //this is the key from the appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalks"));
});

//help / note - when ask for the IRegionsRepository, give the SqlRegionRepository
//now we can add the sqlregionrepository in the controller
builder.Services.AddScoped<IRegionsRepository, SqlRegionRepository>();

//when the app start, automapper will look a the files folders(aka assembly) and look for all profiles to use the maps to map data
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
