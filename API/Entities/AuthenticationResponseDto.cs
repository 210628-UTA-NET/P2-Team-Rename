using System.Collections.Generic;

namespace API {
    public class AuthenticationResponseDto {
        public bool IsSuccessfulAuthentication{ get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}