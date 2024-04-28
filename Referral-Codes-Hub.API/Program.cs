using Microsoft.EntityFrameworkCore;
using Referral_Codes_Hub.Application;
using Referral_Codes_Hub.Application.Abstractions;
using Referral_Codes_Hub.Infrastructure;
using Referral_Codes_Hub.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure();

var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ReferralCodeDBContext>(opt => opt.UseSqlServer(cs)); ;

builder.Services.AddScoped<IReferralCodeRepository, ReferralCodeRepository>();
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
