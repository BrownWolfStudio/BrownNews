using System.ComponentModel.DataAnnotations;

namespace BrownNews.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
