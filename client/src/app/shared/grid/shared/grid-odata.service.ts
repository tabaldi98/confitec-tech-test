import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IODataModel } from 'src/app/shared/grid/models/odata.model';

@Injectable({
    providedIn: 'root'
})
export class GridODataService {
    constructor(
        private http: HttpClient) { }

    get(url: string): Observable<IODataModel<any>> {
        return this.http.get<IODataModel<any>>(`${environment.odataUrl}${url}`);
    }
}

