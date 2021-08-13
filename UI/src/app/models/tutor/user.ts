import { Location } from './location';

export interface User {
  id: string,
  firstName: string,
  lastName: string,
  email: string,
  userName: string,
  topics: string[],
  location: Location
}
