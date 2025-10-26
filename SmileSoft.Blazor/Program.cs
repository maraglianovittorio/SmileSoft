using SmileSoft.Blazor.Components;
using Microsoft.AspNetCore.Components.Web;
using SmileSoft.API.Clients;
using SmileSoft.Services;
using SmileSoft.API.Auth.Blazor.Server;

namespace SmileSoft.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Configurar autenticación
            builder.Services.AddSingleton<IAuthService, BlazorServerAuthService>();
            
            var app = builder.Build();

            //Configurar AuthServiceProvider para ApiClients
            var authService = app.Services.GetRequiredService<IAuthService>();
            AuthServiceProvider.Register(authService);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
