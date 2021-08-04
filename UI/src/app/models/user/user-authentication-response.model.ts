export interface AuthenticationResponse {
  isSuccessfulRegistration: boolean;
  error: string;
  token: string;
}