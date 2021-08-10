import { Location } from './location';

export interface User {
  Id: string,
  FirstName: string,
  LastName: string,
  Email: string,
  UserName: string,
  Topics: string[],
  Location: Location
}
