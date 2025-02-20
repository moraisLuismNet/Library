using FluentValidation;
using Library.DTOs;
using Library.Models;
using Library.Services;
using Library.Validators;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

/* Configure the connection string globally so that it can be used throughout the entire application, we add support for SQL Server by 
indicating in the dependency injection that the context will use SQL Server with the following connection string */
// Add services to the container.
builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
    // Disable tracking
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Avoid circular references when using includes in controllers
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Validators
builder.Services.AddScoped<IValidator<AuthorInsertDTO>, AuthorInsertValidator>();
builder.Services.AddScoped<IValidator<AuthorUpdateDTO>, AuthorUpdateValidator>();
builder.Services.AddScoped<IValidator<PublishingHouseInsertDTO>, PublishingHouseInsertValidator>();
builder.Services.AddScoped<IValidator<PublishingHouseUpdateDTO>, PublishingHouseUpdateValidator>();
builder.Services.AddScoped<IValidator<BookInsertDTO>, BookInsertValidator>();
builder.Services.AddScoped<IValidator<BookUpdateDTO>, BookUpdateValidator>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IManagerFiles, ManagerFiles>();

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

app.UseStaticFiles();

app.Run();
