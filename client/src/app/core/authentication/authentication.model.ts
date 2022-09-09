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
