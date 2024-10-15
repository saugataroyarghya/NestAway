using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NestAway.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NestAway.Web.Controllers
{
    public class InitDBController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public InitDBController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            string returnText = "";

            if (_roleManager.Roles.Count() == 0)
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await _roleManager.CreateAsync(new IdentityRole() { Name = "Host" });
                await _roleManager.CreateAsync(new IdentityRole() { Name = "User" });

                returnText += "Roles created<br/>";

                var userUser = new User { UserName = "user@user.com", Email = "user@user.com", FirstName = "User", LastName = "User" };
                await _userManager.CreateAsync(userUser, "123aA_");
                await _userManager.AddToRoleAsync(userUser, "User");

                var hostUser = new User { UserName = "host@host.com", Email = "host@host.com", FirstName = "Host", LastName = "Host" };
                await _userManager.CreateAsync(hostUser, "123aA_");
                await _userManager.AddToRoleAsync(hostUser, "Host");

                var adminUser = new User { UserName = "admin@admin.com", Email = "admin@admin.com", FirstName = "Administrator", LastName = "Administrator" };
                await _userManager.CreateAsync(adminUser, "123aA_");
                await _userManager.AddToRoleAsync(adminUser, "Admin");

                returnText += "Default users created (User, Host and Admin)<br/>";
            }
            else
            {
                returnText += "Roles and users already created<br/>";
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                returnText += "Not connected. Can't add as Admin<br/>";
            }
            else
            {
                string actualRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                if (!actualRole.Equals("Admin"))
                {
                    await _userManager.RemoveFromRoleAsync(user, actualRole);
                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _signInManager.RefreshSignInAsync(user);

                    returnText += "Actual user set as Admin<br/>";
                }
                else
                {
                    returnText += "Actual user already set as Admin<br/>";
                }
            }


            return base.Content(returnText, "text/html");
        }
    }
}
