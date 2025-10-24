using DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmileSoft.Data;
using SmileSoft.Dominio;
using System;
using System.Text;

namespace SmileSoft.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpLogging(o => { });


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

                /*
                options.AddPolicy("RequireOdontologoRole", policy => policy.RequireRole("Odontologo"));
                options.AddPolicy("RequireSecretarioRole", policy => policy.RequireRole("Secretario"));
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                 */
            });


            //builder.Services.AddDbContext<MiDbContext>(options =>
            //     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpLogging();
            }


            app.UseHttpsRedirection();

            // Use Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            /*
            app.Use(async (context, next) =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint != null)
                {
                    var allowAnonymous = endpoint.Metadata.GetMetadata<IAllowAnonymous>();
                    if (allowAnonymous == null)
                    {
                        var authResult = await context.RequestServices
                            .GetRequiredService<IAuthorizationService>()
                            .AuthorizeAsync(context.User, null, new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build());
            
                        if (!authResult.Succeeded)
                        {
                            context.Response.StatusCode = 401;
                            return;
                        }
                    }
                }
                await next();
            });
            */
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
