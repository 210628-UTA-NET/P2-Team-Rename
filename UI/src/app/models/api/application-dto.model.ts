import { DegreeOrCertDto } from "./degreeOrCert-dto.model";
import { UserDto } from "./user-dto.model";

export interface TutorApplicationDto {
  id: string,
  user: UserDto,
  about: string,
  degreeOrCerts: DegreeOrCertDto[],
  topics: string[],
  timestamp: Date,
}
