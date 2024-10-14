using Blazor_Todo.Components;
using Blazor_Todo.Data.Handlers;
using Blazor_Todo.Data.Models;
using Blazor_Todo.Data.Services;
using Blazor_Todo.Client.Shared;
using Blazor_Todo.Application;
using Blazor_Todo.Infrastructure;

namespace Blazor_Todo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();
            builder.Services.AddScoped<TikTokRecommendedDataService>();
            builder.Services.AddScoped<TikTokAPIHandler>();
            builder.Services.AddScoped<MyStateService>();

            builder.Services.Configure<TikTokApiOptions>(builder.Configuration.GetSection("TikTokApi"));

            builder.Services.AddHttpClient();

            var app = builder.Build();

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
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(ClientComponentDemo).Assembly);

            app.Run();
        }
    }
}
