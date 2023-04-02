using Application;
using Application.Common.Behaviors;
using FluentValidation;
using Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("front" ,policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
});

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
builder.Services.AddValidatorsFromAssembly(Application.DependencyInjection.Assembly, includeInternalTypes: true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("front");

app.MapControllers();

app.Run();