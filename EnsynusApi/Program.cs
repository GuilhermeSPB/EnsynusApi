using EnsynusApi.Data;
using EnsynusApi.Dtos.Aluno;
using EnsynusApi.Dtos.Professor;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using EnsynusApi.Repository;
using EnsynusApi.Repository.Aluno;
using EnsynusApi.Repository.Professor;
using EnsynusApi.Repository.Turma;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using EnsynusApi.Repository.Ingresso;
using EnsynusApi.Service.Auth;
using EnsynusApi.Service.Token;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("Connection => " +
    builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ensynus API", Version = "v1" });
});

builder.Services.AddControllers();



builder.Services.AddDbContext<EnsynusContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
        )
    );

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

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IIngressoRepository, IngressoRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

Console.WriteLine("Connection => " +
    builder.Configuration.GetConnectionString("DefaultConnection"));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontEndPolicy"); 

//app.UseHttpsRedirection();

app.MapControllers();

app.Run(); ;
