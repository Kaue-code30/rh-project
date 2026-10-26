using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using RhProject.Api.Authorization;
using RhProject.Api.Middlewares;
using RhProject.Api.Services.Authorization;
using RhProject.Application.Behaviors;
using RhProject.Application.Commands.Base.CriarBase;
using RhProject.Application.Commands.Cooperado.CriarCooperado;
using RhProject.Application.Interfaces.Authorization;
using RhProject.Application.Service.Authorization;
using RhProject.Domain.Enums;
using RhProject.Infrastructure;
using RhProject.Infrastructure.Configurations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Description = "Informe o token JWT."
        });

    options.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference(
                "Bearer",
                document)] = new List<string>()
        });
});

// MediatR
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(
        typeof(CriarBaseCommand).Assembly);
});

// Tratamento global de exceções
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IPermissaoService, PermissaoService>();
builder.Services.AddScoped<IPerfilUsuarioService, PerfilUsuarioService>();
builder.Services.AddScoped<IUsuarioLogadoService,UsuarioLogadoService>();

// Handler de autorização por permissões
builder.Services.AddScoped<
    IAuthorizationHandler,
    PermissaoAuthorizationHandler>();

// FluentValidation
builder.Services.AddValidatorsFromAssembly(
    typeof(CriarCooperadoCommandValidator).Assembly);

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

// Configurações JWT
var jwtSettings = builder.Configuration
    .GetSection("JwtSettings")
    .Get<JwtSettings>()
    ?? throw new InvalidOperationException(
        "Configurações JWT não encontradas.");

if (string.IsNullOrWhiteSpace(jwtSettings.SecretKey) ||
    Encoding.UTF8.GetByteCount(jwtSettings.SecretKey) < 32)
{
    throw new InvalidOperationException(
        "A chave JWT deve possuir pelo menos 32 bytes.");
}

if (string.IsNullOrWhiteSpace(jwtSettings.Issuer) ||
    string.IsNullOrWhiteSpace(jwtSettings.Audience) ||
    jwtSettings.ExpirationMinutes <= 0)
{
    throw new InvalidOperationException(
        "Configurações JWT inválidas.");
}

var key = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

// Autenticação JWT
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.MapInboundClaims = false;

        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,

                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,

                ValidateLifetime = true,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,

                RequireSignedTokens = true,
                RequireExpirationTime = true,

                ClockSkew = TimeSpan.Zero
            };
    });

// Autorização
builder.Services.AddAuthorization(options =>
{
    foreach (var permissao in Enum.GetValues<PermissaoEnum>())
    {
        var codigoPermissao = permissao.ToString();

        options.AddPolicy(codigoPermissao, policy =>
        {
            policy.RequireAuthenticatedUser();

            policy.AddRequirements(
                new PermissaoRequirement(codigoPermissao));
        });
    }
});



var app = builder.Build();

// Middleware de exceções
app.UseExceptionHandler();

// Swagger somente em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Autenticação antes da autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();