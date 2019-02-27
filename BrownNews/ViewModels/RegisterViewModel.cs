using System.ComponentModel.DataAnnotations;

namespace BrownNews.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(15, ErrorMessage = "{0} should be smaller than 15 letters.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Password)]
        [MaxLength(15, ErrorMessage = "{0} should be smaller than 15 letters.")]
        [MinLength(8, ErrorMessage = "{0} should be greater than 8 letters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
