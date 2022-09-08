export interface IAuthenticationCommand {
    login: string;
    password: string;
}

export interface IAuthenticationModel {
    accessToken: string;
    tokenType: string;
    expiresIn: number;
}
