using System.ComponentModel.DataAnnotations;

namespace FinancialChat.App.Models
{
    public class RegisterModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(20, ErrorMessage = "{0} is too long.")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(20, ErrorMessage = "{0} is too long.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
