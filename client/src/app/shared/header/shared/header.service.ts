import { EventEmitter, Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class HeaderService {
    onRouteChanged: EventEmitter<string> = new EventEmitter<string>();
}
