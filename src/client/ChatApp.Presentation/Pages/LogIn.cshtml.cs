using ChatApp.Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatApp.Presentation.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public AppUser AppUser { get; set; }

        public void OnGet()
        {
            ViewData["LogInFeedback"] = string.Empty;
            ViewData["CurrentUser"] = null;
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["LogInFeedback"] = "All fields are required";
                return Page();
            }

            if (await Services.Login(AppUser))
            {
                return RedirectToPage("./Chat", new { userName = AppUser.Name });
            }
            ViewData["LogInFeedback"] = "Invalid user or password";
            return Page();
        }
    }
}