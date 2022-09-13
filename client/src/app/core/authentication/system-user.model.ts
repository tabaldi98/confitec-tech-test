export interface ISystemUserCreateCommand {
    fullName: string;
    userName: string;
    password: string;
    mail: string;
}

export interface ISystemUserUpdateCommand {
    id: number;
    permissions: string[];
    isAproved: boolean;
}

export interface ISystemUserDeleteCommand{
    iDs: number[];
}