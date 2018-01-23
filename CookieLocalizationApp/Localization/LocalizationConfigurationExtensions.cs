using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace CookieLocalizationApp.Localization
{
    public static class LocalizationConfigurationExtensions
    {
        /// <summary>
        /// Extension method that we call in 'Startup' to add cookie localization
        /// </summary>
        /// <param name="app">Instance of IApplicationBuilder</param>
        /// <returns></returns>
        public static IApplicationBuilder UseCookieLocalization(this IApplicationBuilder app)
        {
            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-GB"),
                SupportedCultures = LocalizationConfiguration.SupportedCultures,
                SupportedUICultures = LocalizationConfiguration.SupportedCultures
            };

            // Here is where the magic happends that adds a cookie localization provider
            options.RequestCultureProviders = new List<IRequestCultureProvider>
            {
                new CookieRequestCultureProvider { Options = options}
            };

            app.UseRequestLocalization(options);

            return app;
        }
    }
}
