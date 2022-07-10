using System.ComponentModel.DataAnnotations;

namespace ChatApp.Presentation.ViewModel
{
    public class AppUser
    {
        [Required] public string Name { get; set; }
        [Required] public string Password { get; set; }
    }
}
