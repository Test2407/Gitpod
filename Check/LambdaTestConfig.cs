using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProject
{
   
    public class LambdaTestConfig:PageTest
    {
        
        public  String GetURL(int index) {
            System.Environment.SetEnvironmentVariable("LT_USERNAME", "theotech24");
            System.Environment.SetEnvironmentVariable("LT_ACCESS_KEY", "cQakHM2vlDP8tDpyzAnSwfu557u5BFsWaeSc5qrRHa8Zm1G0Bl");

            string? user, accessKey;
            user = Environment.GetEnvironmentVariable("LT_USERNAME");
            accessKey = Environment.GetEnvironmentVariable("LT_ACCESS_KEY");

            Dictionary<string, object>[] capabilitiesArray = new Dictionary<string, object>[2];


            capabilitiesArray[0] = new Dictionary<string, object>
        {
            { "browserName", "Chrome" },
            { "browserVersion", "latest" },
            { "LT:Options", new Dictionary<string, object>
                {
                    { "platform", "MacOS Big sur" },
                    { "build", "Playwright Sample Build" },
                    { "name", "Playwright Sample Test on MacOS Big sur - Chrome" },
                    { "user", user },
                    { "accessKey", accessKey },
                    { "network", true },
                    { "video", true },
                    { "console", true }
                }
            }
        };

            // Second JSON object (similar structure)
            capabilitiesArray[1] = new Dictionary<string, object>
        {
            { "browserName", "MicrosoftEdge" },
            { "browserVersion", "latest" },
            { "LT:Options", new Dictionary<string, object>
                {
                    { "platform", "Windows 10" },
                    { "build", "Firefox Sample Build" },
                    { "name", "Firefox Sample Test on Windows 10" },
                    { "user",user },
                    { "accessKey", accessKey },
                    { "network", true },
                    { "video", true },
                    { "console", true }
                }
            }
        };

            string capabilitiesJson = JsonConvert.SerializeObject(capabilitiesArray[index]);
           
            string cdpUrl = "wss://cdp.lambdatest.com/playwright?capabilities=" + Uri.EscapeDataString(capabilitiesJson);
            return cdpUrl;
            
           
        }

        public static async Task SetTestStatus(string status, string remark, IPage page)
        {
            await page.EvaluateAsync("_ => {}", "lambdatest_action: {\"action\": \"setTestStatus\", \"arguments\": {\"status\":\"" + status + "\", \"remark\": \"" + remark + "\"}}");
        }
    }
}
