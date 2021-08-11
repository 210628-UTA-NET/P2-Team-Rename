export interface RegistrationResponse {
  isSuccessfulRegistration: boolean;
  errors: string[];
  token: string;
}