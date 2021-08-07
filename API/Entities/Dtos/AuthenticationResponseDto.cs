namespace API.Entities {
    public class AuthenticationResponseDto {
        public bool IsSuccessfulAuthentication{ get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}