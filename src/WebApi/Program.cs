using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infra;
using Infra.Repository;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
DatabaseConfig.ConfigureDatabase(builder.Services,builder.Configuration);
builder.Services.AddTransient<INotificationsAppService, NotificationsAppService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IEmailRepository,EmailRepository>();
builder.Services.AddScoped<IMongoDbContext, MongoDbContext>();


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

