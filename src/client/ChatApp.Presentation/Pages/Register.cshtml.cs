using ChatApp.Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatApp.Presentation.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public AppUser AppUser { get; set; }


        public void OnGet()
        {
            ViewData["AddUserFeedback"] = "";
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["AddUserFeedback"] = "All fields are required";
                return Page();
            }

            if (await Services.AddUser(AppUser)) return RedirectToPage("./LogIn");

            ViewData["AddUserFeedback"] = "Invalid user";
            return Page();
        }
    }
}