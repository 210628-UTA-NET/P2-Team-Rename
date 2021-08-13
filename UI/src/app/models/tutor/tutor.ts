import { degreeOrCert } from "./degreeOrCert";
import { User } from "./user";

export interface Tutor extends User {
  about: string,
  hourlyRate: number,
  degreesOrCerts: degreeOrCert[],
  rating: number
}
