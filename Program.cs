using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineBookstore.API.Database.Context;
using OnlineBookstore.API.Interfaces;
using OnlineBookstore.API.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OnlineBookstoreContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBookstoreDB")));

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "JWT Token authentication API",
        Description = "ASP.NET core web api"
    });
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWTBearer",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n  "
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference=new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        } ,
        new string[] {}
    }
    });
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:44371",//Homework:Get from configuration
        ValidAudience = "https://localhost:44371",//Homework:Get from configuration
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tagsbg128xsh#9ujhiunjdsra"))//Homework:Get from configuration
    };
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authorization API v1");
});

app.Run();
