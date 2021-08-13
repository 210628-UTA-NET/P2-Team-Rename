import { UserDto } from "../api/user-dto.model";

export interface RegistrationResponse {
  success: boolean;
  errors: string[];
  token: string;
  user: UserDto;
}