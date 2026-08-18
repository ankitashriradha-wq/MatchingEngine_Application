using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MatchingEngine_Task.Utilities
{
    [TestFixture]
    public static class CommonHelper
    {
        // Returns the directory of the executing assembly; falls back to AppContext.BaseDirectory.
        public static string AssemblyDirectory =>
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? AppContext.BaseDirectory;
    }

    
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            // Basic ChromeDriver creation. Adjust options and service as needed.
            var options = new ChromeOptions();
            // Uncomment headless for CI environments
            // options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--start-maximized");
            options.AddArgument("--incognito");

            Console.WriteLine("Entering Chromesetup");
            // Let SeleniumManager resolve and download the matching driver at runtime
            // by not specifying a ChromeDriverService. This avoids using a bundled
            // chromedriver that may not match the browser version.
            return new ChromeDriver(options);
        }
    }
}
