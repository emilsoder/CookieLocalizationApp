using System.Collections.Generic;
using System.Globalization;

namespace CookieLocalizationApp.Localization
{
    public class LocalizationConfiguration
    {
        /// <summary>
        /// The cultures that we will support in the application
        /// </summary>
        public static List<CultureInfo> SupportedCultures => new List<CultureInfo>
        {
            new CultureInfo("en-GB"),
            new CultureInfo("sv-SE"),
            new CultureInfo("nb-NO") 
        };
    }
}
