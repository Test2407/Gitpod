using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.ScenarioOne.SimpleFormPag;

namespace TestProject.ScenarioOne.Tests
{
    public class TestScenarioOneWindows:PageTest
    {
        private SimpleFormPage page;
        public LambdaTestConfig config;
        public IPage resPage;

        [SetUp]
        public async Task Setup()
        {
            config = new LambdaTestConfig();
            String resUrl = config.GetURL(1);

            var browser = await Playwright.Chromium.ConnectAsync(resUrl);
            resPage = await browser.NewPageAsync();
            page = new SimpleFormPage(resPage);
            await page.GotoSimpleFormPage();
        }
        [Test]
        public async Task ValidateURL()
        {
            var URL = await page.getCurrentURL();
            if (URL.Contains("simple-form-demo"))
            {
                await LambdaTestConfig.SetTestStatus("passed", "URL Present", resPage);
            }
            else
            {
                await LambdaTestConfig.SetTestStatus("failed", "URL Invalid", resPage);
                throw new Exception("Fail");

            }

        }

        [Test]
        public async Task ValidateMessage()
        {
            var InputMessage = "Welcome to LambdaTest";
            await page.EnterMessage(InputMessage);
            await page.ClickCheckBtn();
            var textContent = await page.MessageOutput.TextContentAsync();
            if (textContent.Contains(InputMessage))
            {
                await LambdaTestConfig.SetTestStatus("passed", "Message Found", resPage);
            }
            else
            {
                await LambdaTestConfig.SetTestStatus("failed", "Message Not Found", resPage);
                throw new Exception("Fail");
            }
        }

    }
}
