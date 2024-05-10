using Amazon;
using Amazon.DynamoDBv2;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RznMicro.Atlanta.AwsS3;
using RznMicro.Atlanta.AwsSQS;
using RznMicro.Atlanta.Command;
using RznMicro.Atlanta.Core.AppSetting;
using RznMicro.Atlanta.Core.AWS.S3;
using RznMicro.Atlanta.Core.AWS.SQS;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Database.Feature;
using RznMicro.Atlanta.Database.Repository.Feature;
using RznMicro.Atlanta.Database.UnitOfWork.Feature;
using RznMicro.Atlanta.DynamoDB.Repository.Feature;
using RznMicro.Atlanta.Feature.Address;
using RznMicro.Atlanta.Feature.User;
using RznMicro.Atlanta.Query;
using RznMicro.Atlanta.Query.Feature.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AWS Parameter Store
var envName = builder.Environment.EnvironmentName;
builder.Configuration.AddSystemsManager($"/{envName}", TimeSpan.FromMinutes(1));

// RequestContext MediatR
builder.Services.AddScoped<IRequestContext, RequestContext>();
builder.Services.AddApplicationCommand();
builder.Services.AddApplicationQuery();

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// MySQL
builder.Services.AddScoped<DefaultDataBaseContext>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<DefaultDataBaseContext>(opt =>
{
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// IOptions
var configOptions = builder.Configuration.GetSection(AppSettings.KeyName);
builder.Services.Configure<AppSettings>(configOptions);

// DynamoDB
builder.Services.AddSingleton<AmazonDynamoDBClient>(_ => new AmazonDynamoDBClient(RegionEndpoint.USEast1));
builder.Services.AddScoped<IUserQueryRepository, UserQueryRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
builder.Services.AddScoped<IAwsSQSService, AwsSQSService>();
builder.Services.AddScoped<IAwsS3Service, AwsS3Service>();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// Use this format only example of my applications
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
