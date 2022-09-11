export type GridConfig = {
    columns: GridColumn[];
    actions: GridAction[];
}

export interface GridColumn {
    field: string;
    title: string;
    size: string;
    type: GridColumnType;
    callback?: Function;
    cell?: any;
    customFormat?: any;
    hideOnMobile: boolean;
    iconAction?: string;
    filtered: boolean;
}

export interface GridAction {
    title: string;
    icon: string;
    callback: Function;
}

export enum GridColumnType {
    LinkButton = 0,
    Text = 1,
    Date = 2,
    Enum = 3,
    Action = 4,
    Number = 5,
}