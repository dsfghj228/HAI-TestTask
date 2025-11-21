using System.Reflection;
using Back.Data;
using Back.Exceptions;
using Back.Interfaces;
using Back.PipelineBehaviors;
using Back.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails(o =>
    {
        o.IncludeExceptionDetails = (_, _) => false;

        o.Map<CustomExceptions.DoctorNotFoundException>(ex => new ProblemDetails
        {
            Type = ex.Type,
            Title = ex.Title,
            Status = (int)ex.StatusCode,
            Detail = ex.Message
        });
        
        o.Map<CustomExceptions.PatientNotFoundException>(ex => new ProblemDetails
        {
            Type = ex.Type,
            Title = ex.Title,
            Status = (int)ex.StatusCode,
            Detail = ex.Message
        });
        
        o.Map<CustomExceptions.DiseaseNotFoundException>(ex => new ProblemDetails
        {
            Type = ex.Type,
            Title = ex.Title,
            Status = (int)ex.StatusCode,
            Detail = ex.Message
        });
    });

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo {Title = "HAI-Back", Version = "v1"});
    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});


builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IDiseaseRepository, DiseaseRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseProblemDetails();
app.UseMiddleware<ValidationExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "HAI-Back V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();