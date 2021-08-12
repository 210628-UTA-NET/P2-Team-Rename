namespace Entities.Dtos {
    public class AuthenticationResponseDto {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}