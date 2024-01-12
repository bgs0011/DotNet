using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.Core.Repositories;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;
using WebApi.Repository.Repositories;
using WebApi.Repository.UnitOfWorks;
using WebApi.Repository;
using WebApi.Services.Authorization.Abstraction;
using WebApi.Services.Authorization.Concrete;
using WebApi.Services.Mapping;
using WebApi.Services.Services;
using System.Reflection;
using FluentValidation.AspNetCore;
using WebApi.Services.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<ArticleDtoValidator>();
    x.RegisterValidatorsFromAssemblyContaining<PublisherDtoValidator>();
    x.RegisterValidatorsFromAssemblyContaining<CommentDtoValidator>();
}
);

//AppDbContext iþlemler
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


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
