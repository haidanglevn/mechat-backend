using System.Text;
using Business.Interfaces;
using Business.Services;
using Business.Shared;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using WebAPI.Database;
using WebAPI.Hubs;
using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Cors Options
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod().AllowCredentials();
      
    });
});

// Add services to the container.
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<IConversationRepo, ConversationRepo>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IMessageRepo, MessageRepo>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IParticipantRepo, ParticipantRepo>();
//builder.Services.AddScoped<IChatHub, ChatHub>();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

// Add database context 
var connectionString = builder.Configuration.GetConnectionString("LocalDb");
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
var dataSource = dataSourceBuilder.Build();

// add database context service
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(dataSource).UseSnakeCaseNamingConvention();           
});

// config for authentication
var jwtTokenKey = builder.Configuration.GetValue<string>("Jwt:Token");
if (string.IsNullOrEmpty(jwtTokenKey) || jwtTokenKey.Length < 16)
{
    throw new InvalidOperationException("JWT Token key is not set or too short in configuration.");
}
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenKey)),
        ValidateIssuer = false,
        ValidateAudience = false
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

app.MapControllers();
app.MapHub<TestHub>("/test");

app.Run();
