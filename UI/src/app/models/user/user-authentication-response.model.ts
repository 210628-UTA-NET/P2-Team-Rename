import { UserDto } from "../api/user-dto.model";

export interface AuthenticationResponse {
  success: boolean;
  error: string;
  token: string;
  user: UserDto;
}