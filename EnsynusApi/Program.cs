using EnsynusApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EnsynusApi.Repository.Aluno;
using EnsynusApi.Repository.Professor;
using EnsynusApi.Repository.Turma;
using EnsynusApi.Repository.Ingresso;
using EnsynusApi.Service.Auth;
using EnsynusApi.Service.Token;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);


//Config
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("Connection => " +
    builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ensynus API", Version = "v1" });
});


//Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
    };
});

builder.Services.AddAuthorization();


builder.Services.AddControllers();


//Database
builder.Services.AddDbContext<EnsynusContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
        )
    );


//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndPolicy", policy =>
    {
        policy
        .WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


//Repositórios
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IIngressoRepository, IngressoRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

Console.WriteLine("Connection => " +
    builder.Configuration.GetConnectionString("DefaultConnection"));


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontEndPolicy");


app.MapControllers();

app.Run(); ;
