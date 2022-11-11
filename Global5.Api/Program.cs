using AutoMapper;
using FluentValidation;
using Global5.Api.Mappings;
using Global5.DataBase;
using Global5.ViewModels;
using Microsoft.EntityFrameworkCore;
using Global5.ViewModels.Validators;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuração das validações dos campos

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddTransient<IValidator<UserViewModel> , UserValidator>();

#endregion

#region Configuração do banco de dados

builder.Services.AddDbContext<ApplicationContext>( options =>
{
	options.UseNpgsql("Host=localhost;Port=5433;Database=db_teste;Username=postgres;Password=admin");
}, ServiceLifetime.Transient);

#endregion

#region Configuração do mapping

var mapperConfiguration = new MapperConfiguration( configure =>
{
    configure.AddProfile<DomainToViewModelMappingProfile>();
    configure.AddProfile<ViewModelToDomainMappingProfile>();
} );

builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
