export const SIDE_BAR_SETTING_ID: number = 1;
export const SESSION_TIME_SETTING_ID: number = 2;

export interface ISetting {
    id: number;
    key: string;
    value: string;
}

export interface ISettingUpdateCommand {
    id: number;
    value: string;
}