using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task Login(string email, string password)
        {
            await _page.GotoAsync("https://qaerequisition.e-bizsoft.net/Login.aspx");
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Email Address" }).FillAsync(email);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync(password);
            await _page.GetByRole(AriaRole.Button, new() { Name = "Sign In" }).ClickAsync();
        }
    }
}
