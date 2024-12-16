using CA2WFVoidWeatherSystems.Components;
using CA2WFVoidWeatherSystems.Services;
using Microsoft.AspNetCore.Components.Server;

namespace CA2WFVoidWeatherSystems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add configuration support for appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true);

            //Add local storage
            builder.Services.AddScoped<LocalStorageService>();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();


            //------------------------------------------------------------------------------
            //Add Twitter API Service
            builder.Services.AddHttpClient<TwitterService>();

            // Add Weather API Service
            builder.Services.AddHttpClient<WeatherAPIService>(client =>
            {
                var baseUrl = builder.Configuration["WeatherAPI:BaseUrl"];
                if (string.IsNullOrWhiteSpace(baseUrl))
                {
                    throw new Exception("WeatherAPI BaseUrl is not configured in appsettings.json");
                }
                client.BaseAddress = new Uri(baseUrl);
            });

            //------------------------------------------------------------------------------


            // Enable detailed errors for Blazor server-side
            builder.Services.Configure<CircuitOptions>(options =>
            {
                options.DetailedErrors = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
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
