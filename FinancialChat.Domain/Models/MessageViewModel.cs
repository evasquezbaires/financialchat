using System.ComponentModel.DataAnnotations;

namespace FinancialChat.Domain.Models
{
    public class MessageViewModel
    {
        [Display(Name = "User sender")]
        [Required(ErrorMessage = "{0} is required.")]
        public int FromUser { get; set; }

        [Display(Name = "User receiver")]
        [Required(ErrorMessage = "{0} is required.")]
        public int ToUser { get; set; }
    }
}
