using System.ComponentModel.DataAnnotations;
using TanpooshStore.Common.Utilities;

namespace EndPoint.Site.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = ErrorMessage.RequierdMsg)]
        [Display(Name ="ایمیل")]
        [EmailAddress(ErrorMessage = ErrorMessage.RegExpMsg)]
        public string Email { get; set; }
    }
}
