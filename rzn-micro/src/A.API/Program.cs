using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RznMicro.Atlanta.Common;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Database.Feature;
using RznMicro.Atlanta.Database.Repository.Base;
using RznMicro.Atlanta.Database.Repository.Feature;
using RznMicro.Atlanta.Database.UnitOfWork.Feature;
using RznMicro.Atlanta.Feature.Address;
using RznMicro.Atlanta.Feature.User;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// RequestContext MediatR
builder.Services.AddScoped<IRequestContext, RequestContext>();
var assemblies = Assembly.Load("RznMicro.Atlanta.Command");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// MySQL
builder.Services.AddScoped<DefaultDataBaseContext>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<DefaultDataBaseContext>(opt =>
{
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
