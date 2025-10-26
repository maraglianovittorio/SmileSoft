using SmileSoft.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmileSoft.Data;
using SmileSoft.Dominio;
using System;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Text.Json;

namespace SmileSoft.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmileSoft API", Version = "v1" });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter 'Bearer {token}'",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                };
                c.AddSecurityDefinition("Bearer", securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement { { securityScheme, Array.Empty<string>() } });
            });

            builder.Services.AddHttpLogging(o => { });

            // Make JSON binding tolerant and consistent
            builder.Services.ConfigureHttpJsonOptions(o =>
            {
                o.SerializerOptions.PropertyNameCaseInsensitive = true;
                o.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            // Add JWT Authentication
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpLogging();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapGet("/", () => $"Ir a /swagger para probar");
            app.MapPacienteEndpoints();
            app.MapAuthEndpoints();
            app.MapObraSocialEndpoints();
            app.MapUsuarioEndpoints();
            app.MapTipoPlanesEndpoints();
            app.MapTipoAtencionEndpoints();
            app.MapOdontologoEndpoints();
            app.MapPersonaEndpoints();
            app.MapAtencionEndpoints();

            app.Run();
        }
    }
}