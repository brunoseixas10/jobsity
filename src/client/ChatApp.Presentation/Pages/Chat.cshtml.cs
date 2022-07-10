using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatApp.Presentation.Pages
{
    public class ChatModel : PageModel
    {
        [BindProperty]
        public string currentUser { get; set; }

        public async Task OnGet(string userName)
        {
            currentUser = userName;
        }
    }
}
