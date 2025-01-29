using System.Text;
using Application;
using Application.Services;
using Application.UseCases.Game;
using Application.UseCases.GameSession;
using Application.UseCases.Support;
using Application.UseCases.User;
using Infrastructure.Ef;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("Jwt");

// Add services to the container.

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["jwt_token"];
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddDbContext<GamerHistoryDatabaseContext>(cfg => cfg.UseSqlServer(
    builder.Configuration.GetConnectionString("db")
));
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISupportRepository, SupportRepository>();
builder.Services.AddScoped<IGameSessionRepository, GameSessionRepository>();

// Use cases games
builder.Services.AddScoped<UseCaseFetchAllGames>();
builder.Services.AddScoped<UseCaseCreateGame>();

// Use cases users
builder.Services.AddScoped<UseCaseFetchAllUsers>();
builder.Services.AddScoped<UseCaseFetchUserById>();
builder.Services.AddScoped<UseCaseCreateUser>();
builder.Services.AddScoped<UseCaseLogin>();
builder.Services.AddScoped<UseCaseLogout>();

// Use cases supports
builder.Services.AddScoped<UseCaseFetchAllSupports>();
builder.Services.AddScoped<UseCaseFetchSupportById>();
builder.Services.AddScoped<UseCaseFetchGamesBySupport>();

// Use cases game sessions
builder.Services.AddScoped<UseCaseFetchAllGameSessions>();

builder.Services.AddScoped<UseCaseGetUserHistory>();

builder.Services.AddScoped<TokenService>();

var corsPolicyName = "AllowSpecificOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicyName);

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Urls.Add("http://*:5037");

app.Run();