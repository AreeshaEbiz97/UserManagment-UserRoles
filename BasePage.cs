using Microsoft.Playwright;

namespace Pages
{
    public class BasePage
    {
        protected IPage Page { get; }

        public BasePage(IPage page)
        {
            Page = page;
        }
    }
}
