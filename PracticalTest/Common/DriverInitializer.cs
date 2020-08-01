using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace PracticalTest.Common
{
    public static class DriverInitializer
    {
        public static IWebDriver StartDriver(string driverType)
        {
            if (string.IsNullOrEmpty(driverType))
                throw new AutomationException("Driver type is not provided. Please check test setting file.");

            switch(driverType.ToUpper())
            {
                case "CHROME":
                    return new ChromeDriver();
                case "IE":
                    var options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.EnableNativeEvents = false;
                    options.PageLoadStrategy = PageLoadStrategy.Eager;
                    options.RequireWindowFocus = true;
                    options.EnablePersistentHover = true;
                    options.IgnoreZoomLevel = true;
                    options.EnsureCleanSession = true;
                    options.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
                    return new InternetExplorerDriver(options);
                case "FIREFOX":
                    return new FirefoxDriver();
                default:
                    throw new AutomationException($"Failed initilizing driver. " +
                                                  $"Given driver type {driverType} is not supported.");

            }
        }
    }
}