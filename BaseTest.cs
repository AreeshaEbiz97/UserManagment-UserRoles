using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class BaseTest
    {
        protected IPlaywright? Playwright;
        protected IBrowser? Browser;
        protected IBrowserContext? Context;
        protected IPage? Page;

        [SetUp]
        public async Task Setup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            // Use LaunchAsync for creating a browser instance
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to true if running on CI/CD
            });

            // Now create a browser context from the browser instance
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync(); // Get the first page
        }

         [TearDown]
        public async Task Teardown()
        {
            if (Context != null)
            {
                await Context.CloseAsync(); // Close the context
            }

            if (Browser != null)
            {
                await Browser.CloseAsync(); // Close the browser
            }

            Playwright?.Dispose(); // Dispose of Playwright
        }
    }
}
