using System.Collections.Generic;

namespace Entities.Dtos {
    public class RegistrationResponseDto {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}