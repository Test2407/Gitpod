using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.ScenarioOne.SimpleFormPag
{
    public class SimpleFormPage
    {
        private IPage page;
        private ILocator MessageInput;
        private ILocator GetCheckedbtn;
        private ILocator Message;

        public ILocator MessageOutput { get => Message; set => Message = value; }

        public SimpleFormPage(IPage _page) {
            this.page = _page;
            this.MessageInput = _page.GetByPlaceholder("Please enter your Message");
            this.GetCheckedbtn = _page.GetByRole(AriaRole.Button, new()
            {
                Name = "Get Checked Value"
            });
            this.Message = _page.Locator("#message");
        }
        public async Task GotoSimpleFormPage()
        {
            await page.GotoAsync("https://www.lambdatest.com/selenium-playground/");
            await page.GetByRole(AriaRole.Link, new() { Name= "Simple Form Demo" }).ClickAsync();
        }
        public async Task EnterMessage(String message)
        {
            await  MessageInput.FillAsync(message);
        }
        public async  Task ClickCheckBtn()
        {
            await GetCheckedbtn.ClickAsync();
        }

        public async Task<String> getMessage()
        {
            var message = Message.TextContentAsync();
            Console.WriteLine(message);
            return await message;
        }

        public async Task<String> getCurrentURL()
        {
            return page.Url;
        }
    }
}
