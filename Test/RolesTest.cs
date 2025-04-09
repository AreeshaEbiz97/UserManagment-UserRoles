// using Microsoft.Playwright;
// using NUnit.Framework;
// using System.Threading.Tasks;
// using Pages;

// namespace Tests
// {
//     [TestFixture]
//     public class RoleTests : BaseTest
//     {
//         [Test]
//         public async Task TestRoleCreationAndPermissions()
//         {
//             var loginPage = new LoginPage(Page);
//             var rolePage = new RolePage(Page);

//             await loginPage.Login("areesha.ahmedebiz@gmail.com", "Aa1234567");
//             await rolePage.NavigateToRoles();
//             await rolePage.CreateRole("Pak321");
//             await rolePage.SelectRole("Pak321");

//             // Assign permissions
//             await rolePage.AssignCreatePermissions();
//             await rolePage.AssignEditPermissions();
//             await rolePage.AssignDeletePermissions();
//             await rolePage.AssignEmailPermissions();

//             await rolePage.SavePermissions();
//         }
//     }
// }
