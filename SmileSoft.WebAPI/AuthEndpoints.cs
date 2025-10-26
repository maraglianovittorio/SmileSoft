using Azure.Core;
using SmileSoft.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmileSoft.Services;

namespace SmileSoft.WebAPI
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/auth/login", async ([FromBody] LoginRequest request, IConfiguration configuration) =>
            {
                try
                {
                    var authService = new AuthService(configuration);
                    var response = await authService.LoginAsync(request);

                    if (response == null)
                    {
                        return Results.Unauthorized();
                    }

                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error durante el login: {ex.Message}");
                }
            })
            .WithName("Login")
            .Accepts<LoginRequest>("application/json")
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status500InternalServerError)
            .AllowAnonymous();
        }
    }
}