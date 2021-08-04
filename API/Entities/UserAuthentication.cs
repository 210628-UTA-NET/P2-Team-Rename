using System.ComponentModel.DataAnnotations;

namespace API {
    public class UserAuthentication {

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}