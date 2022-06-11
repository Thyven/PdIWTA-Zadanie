using FluentValidation.AspNetCore;
using Lab4;
using Lab4.DTO.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Lab4.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();

builder.Services.AddControllers();
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AddProductDTOValidator>());
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UpdateDTOValidator>());
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<TestUserDTOValidator>());




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidIssuer = "test",
            ClockSkew = TimeSpan.FromMinutes(0),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("w+1alOGke7bSPTgeMVlDXS5FRg3jcjRxkBtG0u3NrOo="))
        };
    });



builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
