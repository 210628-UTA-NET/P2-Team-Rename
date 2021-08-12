import { LocationDto } from "./location-dto.model";
import { TopicDto } from "./topic-dto.model";

export interface UserDto {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  userName: string;
  topics: TopicDto[] | null;
  location: LocationDto | null;
}
