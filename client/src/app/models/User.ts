import { UserScholarity } from './user.scholarity.enum';

export interface User {
  id: number;
  name: string;
  surname: string;
  mail: string;
  birthDate: string;
  scholarity: UserScholarity,
}
