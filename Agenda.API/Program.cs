using System.Reflection;
using Agenda.API.Data;
using Agenda.API.Mappers;
using Agenda.API.Models;
using Agenda.API.Repositories;
using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services;
using Agenda.API.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// PARA ACESSO AO BANCO EM MEMÓRIA
builder.Services.AddDbContext<DataContext>(o => o.UseInMemoryDatabase("dados"));

// Injeção de Dependência
// Tipos: Transient, Scoped, Singleton
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Agenda.API",
            Version = "v1",
            Contact = new OpenApiContact
            {
                Name = "Samuel B. Oldra",
                Email = "samuel.oldra@gmail.com",
                Url = new Uri("https://github.com/samuel-oldra")
            }
        }
    );

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    o.IncludeXmlComments(xmlPath);
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(ContatoMapper));
builder.Services.AddAutoMapper(typeof(EventoMapper));
builder.Services.AddAutoMapper(typeof(TarefaMapper));

// Fluent Validation
builder.Services.AddValidatorsFromAssemblyContaining<ContatoPostInputModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EventoPostInputModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TarefaPostInputModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ContatoPutInputModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EventoPutInputModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TarefaPutInputModelValidator>();
builder.Services.AddFluentValidationAutoValidation();

// Serilog
builder
    .Host.ConfigureAppConfiguration(
        (hostingContext, config) =>
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                // PARA LOG NO CONSOLE
                .WriteTo.Console()
                .CreateLogger();
        }
    )
    .UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
