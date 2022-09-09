export interface IAuthenticationCommand {
    login: string;
    password: string;
}

export interface IAuthenticationModel {
    accessToken: string;
    tokenType: string;
    expiresIn: number;
}

export interface ITokenModel {
    id: number;
    fullname: string;
    name: string;
    email: string;
}

export interface IRecoveryPassCommand {
    userNameOrLogin: string;
}

export interface IRecoveryPassCheckCommand {
    userName: string;
    code: string;
}

export interface IUpdatePassCommand {
    userName: string;
    password: string;
}

