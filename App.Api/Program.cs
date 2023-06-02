using App.Domain.Entities;
using App.Domain.RequestValidators;
using App.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.Api", Version = "v1" })
);

builder.Services.AddCors();
builder.Services.AddOptions();

builder.Services.AddDbContext<AppDbContext>(options =>
    //options.UseNpgsql(builder.Configuration.GetConnectionString("AppHoursDb"))
    options.UseInMemoryDatabase("AppHoursDb")
);

builder.Services.AddTransient<IValidator<Collaborator>, CollaboratorValidator>();

App.Persistence.DependencyInjectionConfig.Inject(builder.Services);
App.Application.DependencyInjectionConfig.Inject(builder.Services);
App.Infraetructure.DependencyInjectionConfig.Inject(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App.Api v1"));
}

app.UseRouting();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.MapControllers();


app.Run();