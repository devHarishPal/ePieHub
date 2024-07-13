using System.ComponentModel.DataAnnotations;

namespace ePieHut.WebApplication.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="Please type the Email Address")]
        [EmailAddress(ErrorMessage ="Please type the Correct Email I'd")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please type the Email Address")]
        
        public string Password { get; set; }


    }
}
