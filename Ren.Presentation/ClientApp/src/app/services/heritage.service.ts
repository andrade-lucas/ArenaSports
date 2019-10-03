import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppHeader } from '../utils/header.util';
import { HeritageModel } from '../models/heritage.model';

@Injectable({
    providedIn: 'root'
})
export class HeritageService {
    constructor(private http: HttpClient) { }

    public get() {
        return this.http.get<HeritageModel[]>(`${AppHeader.url}/heritages`, { headers: AppHeader.composeHeader() });
    }
    
    public getById(id: String) {
        return this.http.get<HeritageModel>(`${AppHeader.url}/heritages/${id}`, { headers: AppHeader.composeHeader() });
    }

    public post(data: HeritageModel) {
        return this.http.post(`${AppHeader.url}/heritages`, data, { headers: AppHeader.composeHeader() });
    }

    public put(data: HeritageModel) {
        return this.http.put(`${AppHeader.url}/heritages`, data, { headers: AppHeader.composeHeader() });
    }

    public delete(id: String) {
        return this.http.delete(`${AppHeader.url}/heritages/${id}`, { headers: AppHeader.composeHeader() });
    }
}