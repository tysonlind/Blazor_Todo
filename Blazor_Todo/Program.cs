using Blazor_Todo.Components;
using Blazor_Todo.Data.Handlers;
using Blazor_Todo.Data.Models;
using Blazor_Todo.Data.Services;

namespace Blazor_Todo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddScoped<TikTokRecommendedDataService>();
            builder.Services.AddScoped<TikTokAPIHandler>();

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
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
