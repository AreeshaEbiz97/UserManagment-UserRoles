using TechTalk.SpecFlow;
using Microsoft.Playwright;
using Pages;
using NUnit.Framework;

namespace Tests
{
    [Binding]
    public class RoleTestsSteps
    {
        private readonly IPage _page;
        private readonly LoginPage _loginPage;
        private readonly RolePage _rolePage;

        // Inject ScenarioContext into the step definition class
        public RoleTestsSteps(ScenarioContext scenarioContext)
        {
            _page = (IPage)scenarioContext["Page"];  // Get Playwright Page from ScenarioContext
            _loginPage = new LoginPage(_page);
            _rolePage = new RolePage(_page);
        }

        [Given(@"I am logged in as an admin with valid credentials")]
        public async Task GivenIAmLoggedInAsAdminWithValidCredentials()
        {
            await _loginPage.Login("areesha.ahmedebiz@gmail.com", "Aa1234567");
        }

        [When(@"I navigate to the ""(.*)"" page")]
        public async Task WhenINavigateToThePage(string pageName)
        {
            if (pageName == "Roles")
            {
                await _rolePage.NavigateToRoles();
            }
        }

        [When(@"I create a new role named ""(.*)""")]
        public async Task WhenICreateANewRoleNamed(string roleName)
        {
            await _rolePage.CreateRole(roleName);
        }

        [When(@"I select the role ""(.*)""")]
        public async Task WhenISelectTheRole(string roleName)
        {
            await _rolePage.SelectRole(roleName);
        }

        [When(@"I assign the ""(.*)"" permission to the role")]
        public async Task WhenIAssignThePermissionToTheRole(string permission)
        {
            switch (permission)
            {
                case "Create":
                    await _rolePage.AssignCreatePermissions();
                    break;
                case "Edit":
                    await _rolePage.AssignEditPermissions();
                    break;
                case "Delete":
                    await _rolePage.AssignDeletePermissions();
                    break;
                case "Email":
                    await _rolePage.AssignEmailPermissions();
                    break;
                default:
                    throw new ArgumentException($"Permission {permission} not recognized");
            }
        }

        [Then(@"the role permissions should be saved successfully")]
        public async Task ThenTheRolePermissionsShouldBeSavedSuccessfully()
        {
            await _rolePage.SavePermissions();
            // You can add assertions here to verify that the permissions have been saved.
            Assert.Pass("Permissions saved successfully");
        }
    }
}
