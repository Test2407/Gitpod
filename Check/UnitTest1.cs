using TestProject;
using Microsoft.Playwright.NUnit;
namespace Check
{
    public class Tests:PageTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var config= new LambdaTestConfig();
            var url=config.GetURL(0);
            var browser=await Playwright.Chromium.ConnectAsync(url);
            var page=await browser.NewPageAsync();
            await page.GotoAsync("https://example.com");
        }
    }
}