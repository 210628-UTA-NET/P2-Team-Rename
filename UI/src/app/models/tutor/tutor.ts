import { degreeOrCert } from "./degreeOrCert";
import { User } from "./user";

export interface Tutor {
  Id: string,
  User: User,
  About: string,
  HourlyRate: number,
  DegreesOrCerts: degreeOrCert[],
  Rating: number
}
