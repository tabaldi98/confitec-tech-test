export const RoleNameCanManageObjects: string = 'CanManageObjects'
export const RoleNameCanManageSystemUsers: string = 'CanManageSystemUsers'
export const RoleNameCanChangeGeneralSettings: string = 'CanChangeGeneralSettings'

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
    role: string[];
}

export interface IRecoveryPassCommand {
    userNameOrLogin: string;
}

export interface IRecoveryPassCheckCommand {
    userName: string;
    code: string;
}

export interface IUpdatePassOnRecoveryCommand {
    userName: string;
    password: string;
    code: string;
}

export interface IUpdatePassCommand {
    currentPassword: string;
    password: string;
}

export interface IUpdateMySelfCommand {
    fullName: string;
    mail: string;
}


export interface IMyInformationsModel {
    id: number;
    fullName: string;
    userName: string;
    mail: string;
    createDate: Date;
    lastLoginDate: Date;
    lastUpdatePasswordDate: Date;
    permissions: string[];
}
