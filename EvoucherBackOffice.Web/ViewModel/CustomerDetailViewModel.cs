using System.ComponentModel.DataAnnotations;

namespace EvoucherBackOffice.Web.ViewModel
{
    public class CustomerDetailViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter a first name.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Invalid First Name.")]
        public string FirstName { get; set; }
        [Display(Name = "Second Name")]
        [Required(ErrorMessage = "Please enter a second name.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Invalid Second Name.")]
        public string SecondName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }     
    }
}