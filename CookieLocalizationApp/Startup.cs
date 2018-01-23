using CookieLocalizationApp.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookieLocalizationApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Adds JSON localization
                .AddJsonLocalization(options => options.ResourcesPath = "Resources")
                // Add MVC as usual
                .AddMvc()
                //Add localization provider for Views
                .AddViewLocalization();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region Default configuration

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();

            #endregion

            // Call the extension method (that extends IApplicationBuilder) to provide cookie localization. //
            app.UseCookieLocalization();
            // *******

            // Use MVC with default route '/Home/Index'
            app.UseMvcWithDefaultRoute();
        }
    }
}
