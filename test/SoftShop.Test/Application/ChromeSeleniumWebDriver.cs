using Coypu.Drivers.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
 
namespace SoftShop.Test.Application
{
    public class ChromeSeleniumWebDriver : SeleniumWebDriver
    {
        public ChromeSeleniumWebDriver(bool headless = true)
            : base(CustomProfileDriver(headless), Coypu.Drivers.Browser.Chrome)
        {
        }
 
        private static RemoteWebDriver CustomProfileDriver(bool headless = true)
        {
            var options = new ChromeOptions();
            if (headless)
                options.AddArguments("--headless", "--disable-gpu");
 
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            service.EnableVerboseLogging = false;
            service.SuppressInitialDiagnosticInformation = true;
             
            return new ChromeDriver(service, options);
        }
    }
}