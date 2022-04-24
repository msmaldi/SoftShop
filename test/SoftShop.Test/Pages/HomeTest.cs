using Coypu;
using SoftShop.Test.Application;
using Xunit;
 
namespace SoftShop.Test.Pages
{
    [Collection(nameof(ApplicationAmbient))]
    public class HomeTest
    {
        private BrowserSession browser;
 
        public HomeTest(AmbientFixture fixture)
        {
            browser = fixture.Browser;
        }
 
        [Fact]
        public void IndexTest()
        {
            browser.Visit("/");
            Assert.True(browser.HasContent("Welcome"));
        }        
 
        [Fact]
        public void PrivacyTest()
        {
            browser.Visit("/");
            browser.ClickLink("Privacy", Options.First);
            Assert.True(browser.HasContent("Privacy Policy"));
            Assert.True(browser.HasContent("Use this page to detail your site's privacy policy."));
        }     
    }
}