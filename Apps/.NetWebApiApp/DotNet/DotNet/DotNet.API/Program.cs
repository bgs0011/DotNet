using DotNet.Core.Repositories;
using DotNet.Core.Services;
using DotNet.Core.UnitOfWork;
using DotNet.Repository;
using DotNet.Repository.Repositories;
using DotNet.Repository.UnitOfWorks;
using DotNet.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DotNet.Service.Services;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using DotNet.Service.Validations;
using DotNet.API.Abstraction;
using DotNet.API.Concrete;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region swagger iþlemleri
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

#endregion


//AppDb context islemleri
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<ArticleDtoValidator>();
    x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>();
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
