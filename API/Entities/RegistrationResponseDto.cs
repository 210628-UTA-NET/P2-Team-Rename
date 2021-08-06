using System.Collections.Generic;

namespace API.Entities {
    public class RegistrationResponseDto {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public UserDto User { get; set; }
    }
}