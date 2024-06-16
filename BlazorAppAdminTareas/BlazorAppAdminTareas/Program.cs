using BlazorAppAdminTareas.Client.Pages;
using BlazorAppAdminTareas.Components;
using BlazorAppAdminTareas.Contracts;
using BlazorAppAdminTareas.Entities;
using BlazorAppAdminTareas.Repository;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppAdminTareas
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TareasContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ITareaRepository, TareasRepository>();
            builder.Services.AddScoped<ITareasService, TareasService>();
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
