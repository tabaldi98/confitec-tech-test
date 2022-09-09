import {
    Inject,
    Injectable,
} from '@angular/core';
import { LocalStorageKeys } from './local-storage.model';


@Injectable()
export class LocalStorageService {

    public setValue(key: LocalStorageKeys, value: string): void {
        localStorage.setItem(key.toString(), value);
    }

    public setBoolValue(key: LocalStorageKeys, value: boolean): void {
        localStorage.setItem(key.toString(), value ? 'True' : 'False');
    }

    public getValue(key: LocalStorageKeys): any {
        return localStorage.getItem(key.toString());
    }

    public getBoolValue(key: LocalStorageKeys): boolean {
        return localStorage.getItem(key.toString()) === 'True' ? true : false;
    }

    public deleteValue(key: LocalStorageKeys): void {
        delete localStorage[key.toString()];
    }
}
