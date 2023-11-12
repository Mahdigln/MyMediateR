using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyMediateR.Behaviors;
using MyMediateR.Context;
using MyMediateR.Contracts;
using MyMediateR.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "My Fist Swagger"
    });
    // swagger.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), @"bin\Debug\net6.0", "MshopApi.xml"));
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
#region DB Context
builder.Services.AddDbContext<MyMediateRContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediateRSqlConnection"));
});
#endregion
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My First Swagger");
    });
}



// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
