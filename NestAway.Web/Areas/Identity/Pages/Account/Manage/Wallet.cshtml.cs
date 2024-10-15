using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NestAway.Web.Data;
using NestAway.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace NestAway.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class WalletModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly AppContextDB _context;

        public WalletModel(UserManager<User> userManager, AppContextDB context)
        {
            _userManager = userManager;
            _context = context;
        }

        public double AccountBalance { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Credit Amount")]
            public double CreditAmount { get; set; }
        }

        private void Load(User user)
        {
            AccountBalance = user.Balance;

            Input = new InputModel();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Load(user);
            return Page();
        }

        public async Task<IActionResult> OnPostCreditAccountAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            else
            {
                user.Balance += Input.CreditAmount;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToPage();
        }
    }
}
