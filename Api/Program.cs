using Application.Services.Mappers;
using Application.Services.Tarea;
using Domain.Models.Interfaces;
using Infraestructura;
using Infraestructura.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PJENL.Shared.Kernel.EntityFramework.Interceptor;
using PJENL.Shared.Kernel.InfrastructureUtils.Logs;
using PJENL.Shared.Kernel.MongoDb.Data.MongoDb;
using PJENL.Shared.Kernel.MongoInterceptor;
using PJENL.Shared.Kernel.MongoInterceptor.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection(nameof(MongoSettings)));
builder.Services.AddSingleton<IMongoSettings>(d => d.GetRequiredService<IOptions<MongoSettings>>().Value);
builder.Services.AddDbContext<TareaContext>(c => c.UseSqlServer("Server=localhost;Database=Tareas; Trusted_Connection=True;"));
builder.Services.AddScoped<ITareaRepository, TareaRepository>();
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
builder.Services.AddSingleton<IMongoDbContext, InterceptorContext>();
builder.Services.AddScoped<IRepositoryTracker, ChangeTrackerRepository>();
builder.Services.AddScoped<IEFInterceptor, EFInterceptor>();






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
