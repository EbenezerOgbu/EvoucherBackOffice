using System.ComponentModel.DataAnnotations;

namespace EvoucherBackOffice.Web.ViewModel.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}