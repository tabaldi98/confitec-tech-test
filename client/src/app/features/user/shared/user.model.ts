import { IGridModel } from "src/app/shared/grid/models/grid.model";

export interface User extends IGridModel {
  checked: boolean;
  id: number;
  name: string;
  surname: string;
  mail: string;
  birthDate: string;
  scholarity: UserScholarity;
}

export interface UserDeleteCommand {
  ids: number[];
}

export interface UserCreateCommand {
  name: string;
  surname: string;
  mail: string;
  birthDate: string;
  scholarity: UserScholarity;
}

export interface UserUpdateCommand {
  id: number;
  name: string;
  surname: string;
  mail: string;
  birthDate: string;
  scholarity: UserScholarity;
}

export enum UserScholarity {
  Infantile = 0,
  Fundamental = 1,
  Medium = 2,
  Higher = 3,
}

export const allUserScholarity: UserScholarity[] = [UserScholarity.Infantile, UserScholarity.Fundamental, UserScholarity.Medium, UserScholarity.Higher];

export function formatScholarity(scholarity: UserScholarity): string {
  switch (scholarity) {
    default:
    case UserScholarity.Infantile:
      return 'Infantil';
    case UserScholarity.Fundamental:
      return 'Fundamental';
    case UserScholarity.Medium:
      return 'Médio';
    case UserScholarity.Higher:
      return 'Superior';
  }
}