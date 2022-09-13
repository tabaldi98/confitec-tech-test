import { IGridModel } from "src/app/shared/grid/models/grid.model";

export interface SystemUser extends IGridModel {
    checked: boolean;
    id: number;
    fullName: string;
    userName: string;
    mail: string;
    createDate: Date;
    lastLoginDate: Date;
    lastUpdatePasswordDate: Date;
    isAproved: boolean;
    permissions: string[];
}