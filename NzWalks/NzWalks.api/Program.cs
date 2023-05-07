using Microsoft.EntityFrameworkCore;
using NzWalks.api.Data;

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
