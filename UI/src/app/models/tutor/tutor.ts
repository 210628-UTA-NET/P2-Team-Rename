import { degreeOrCert } from "./degreeOrCert";
import { User } from "./user";

export interface Tutor extends User {
  About: string,
  HourlyRate: number,
  DegreesOrCerts: degreeOrCert[],
  Rating: number
}
