using System;
using Coypu;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Xunit;
 
namespace SoftShop.Test.Application
{
    [CollectionDefinition(nameof(ApplicationAmbient))]
    public class ApplicationAmbient : ICollectionFixture<AmbientFixture>
    {
    }
 
    public class AmbientFixture : IDisposable
    {
        const string appHost = "https://localhost";
        const UInt16 appPort = 5002;
 
        private IHost webHost;
        public BrowserSession Browser { get; }
        public AmbientFixture()
        {
            webHost = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(ConfigureWebHost)
                .Build();
            webHost.RunAsync();
 
            Browser = new BrowserSession(ConfigureSession(), new ChromeSeleniumWebDriver(true));   
        }
 
        static SessionConfiguration ConfigureSession()
        {
            return new SessionConfiguration
            {
                AppHost = appHost,
                Port = appPort,
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(30)
            };
        }
 
        static void ConfigureWebHost(IWebHostBuilder webHost)
        {
            webHost.UseEnvironment("Testing")
                   .UseContentRoot($"../../../../../src/{nameof(SoftShop)}/")
                   .UseStartup<SoftShop.Startup>()
                   .UseUrls($"{appHost}:{appPort}")
                   .UseKestrel();
        }
 
        public void Dispose()
        {
            Browser.Dispose();
        }
    }
}