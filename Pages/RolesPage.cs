using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Pages
{
    public class RolePage
    {
        private readonly IPage _page;

        public RolePage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToRoles()
        {
             await _page.Locator("#menuimage").ClickAsync();
            await _page.GetByRole(AriaRole.Link, new() { Name = "Admin & Settings" }).ClickAsync();
            await _page.GetByRole(AriaRole.Link, new() { Name = "Roles" }).ClickAsync();
        }

        public async Task CreateRole(string roleName)
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "+" }).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "* Role Name Role Name:" }).FillAsync(roleName);
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
        }

        public async Task SelectRole(string roleName)
        {
            await _page.Locator(".vscomp-toggle-button").ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = roleName }).Locator("span").ClickAsync(); 
        }

        // Methods for permissions
         public async Task AssignCreatePermissions()
    {
        string[] createPermissions = new[]
        {
            "Create Receiving Records",
            "Add new Customers",
            "Add new Items",
            "Setup Users",
            "Design Workflows",
            "Setup Roles"
        };

        foreach (var permission in createPermissions)
        {
            await _page.GetByRole(AriaRole.Cell, new() { Name = permission }).GetByRole(AriaRole.Checkbox).CheckAsync();
        }

        // Ensure requisition permission is removed if present
        var requisition = _page.GetByRole(AriaRole.Cell, new() { Name = "Create new requisitions" }).GetByRole(AriaRole.Checkbox);
        if (await requisition.IsCheckedAsync())
        {
            await requisition.UncheckAsync();
        }
    }

         public async Task AssignEditPermissions()
    {
        string[] editPermissions = new[]
        {
            "Modify Users",
            "Modify Roles",
            "Modify Company Settings",
            "Modify Subscription Details",
            "Able to modify purchase order"
        };

        foreach (var permission in editPermissions)
        {
            await _page.GetByRole(AriaRole.Cell, new() { Name = permission }).GetByRole(AriaRole.Checkbox).CheckAsync();
        }
    }

         public async Task AssignDeletePermissions()
    {
        string[] deletePermissions = new[]
        {
            "Delete Users",
            "Delete Roles",
            "Delete Purchase Order"
        };

        foreach (var permission in deletePermissions)
        {
            await _page.GetByRole(AriaRole.Cell, new() { Name = permission }).GetByRole(AriaRole.Checkbox).CheckAsync();
        }
    }
        public async Task AssignEmailPermissions()
    {
        string[] emailPermissions = new[]
        {
            "Email Purchase Order to Vendor",
            "Email User Details",
            "Email Billing Information",
            "View everyone's history"
        };

        foreach (var permission in emailPermissions)
        {
            await _page.GetByRole(AriaRole.Cell, new() { Name = permission }).GetByRole(AriaRole.Checkbox).CheckAsync();
        }
    }
        public async Task SavePermissions()
    {
        await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
        await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
    }
    }
}
