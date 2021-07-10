using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication9.Models;

namespace WebApplication9.Areas.Identity.Pages.Account.Manage
{
    public class ChatModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChatModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public string UserID { get; set; }
        public IList<ApplicationUser> UserList { get; set; }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userID = await _userManager.GetUserIdAsync(user);
            UserID = userID;
            //UserList = (IList<ApplicationUser>)_userManager.Users.ToListAsync();

            var roles = await _userManager.GetRolesAsync(user);
            UserList = (_userManager.Users).ToList();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

    }
}
