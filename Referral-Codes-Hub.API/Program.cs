using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Referral_Codes_Hub.Application;
using Referral_Codes_Hub.Application.Abstractions;
using Referral_Codes_Hub.Application.Helper;
using Referral_Codes_Hub.Infrastructure;
using Referral_Codes_Hub.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using IdentityDbContext = Referral_Codes_Hub.Infrastructure.IdentityDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option => {
    option.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In =Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name="Authorization",
        Type= Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Referral Hub API", Version = "v1" });

    option.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services
    .AddApplication()
    .AddInfrastructure();



var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<IdentityDbContext>(opt => opt.UseSqlServer(cs));

builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>();

builder.Services.AddScoped<IReferralCodeRepository, ReferralCodeRepository>();
builder.Services.AddScoped<IRoleRepository, RolesRepository>();

builder.Services.AddCors(options =>
                options.AddPolicy("AllowAll", policy =>
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapIdentityApi<IdentityUser>();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<IdentityDbContext>();
    context.Database.Migrate();
}


AppSettingsHelper.AppSettingsConfigure(builder.Configuration);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
