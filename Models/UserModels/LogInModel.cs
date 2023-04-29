using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.API.Models.UserModels
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
