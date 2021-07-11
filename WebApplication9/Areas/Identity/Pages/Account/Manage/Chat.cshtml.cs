using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication9.Interface;
using WebApplication9.Models;
using WebApplication9.ViewModel;

namespace WebApplication9.Areas.Identity.Pages.Account.Manage
{
    public class ChatModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMessage _iMessage;

        public ChatModel(
            UserManager<ApplicationUser> userManager,
            IMessage iMessage)
        {
            _userManager = userManager;
            _iMessage = iMessage;
        }

        public string UserID { get; set; }
        public IList<ApplicationUser> UserList { get; set; }
        public IList<Message> Messages { get; set; }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userID = await _userManager.GetUserIdAsync(user);
            UserID = userID;

            UserList = _userManager.Users.Where(x => x.Id != userID).ToList();
            Messages = await _iMessage.GetMessagesByUserId(userID);
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
