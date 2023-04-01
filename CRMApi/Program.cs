using CRMApi.Common;
using CRMApi.DBContext;
using CRMApi.Helpers.Logger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CRMApi;

var builder = WebApplication.CreateBuilder(args);

IWebHostEnvironment _env = builder.Environment;


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding log4net for manage all events in log files
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddLogging(config => config.AddLog4Net("log4net.config", true));

//Get enviorment appsetings configurations 
builder.Configuration.AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: false, reloadOnChange: true);

//Initializing global variables
Constants.ConnectionString = builder.Configuration.GetSection("ApplicationSettings:ConnectionStrings:DefaultConnection").Value ?? "";
Constants.SecretKey = builder.Configuration.GetSection("ApplicationSettings:Jwt:SecretKey").Value ?? "";
Constants.Issuer = builder.Configuration.GetSection("ApplicationSettings:Jwt:Issuer").Value ?? "" ;
Constants.Audience = builder.Configuration.GetSection("ApplicationSettings:Jwt:Audience").Value ?? "";


// Setting DbContext
builder.Services.AddDbContext<CrmContext>(options =>
{
    options.UseSqlServer(Constants.ConnectionString);
});


//Setting json web token for authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwtOptions =>
    {
        jwtOptions.RequireHttpsMetadata = false;
        jwtOptions.SaveToken = true;
        jwtOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.SecretKey)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = Constants.Issuer,
            ValidAudience = Constants.Audience,
            ValidateLifetime = true
        };
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
app.UseAuthentication();
app.MapControllers();

app.Run();
