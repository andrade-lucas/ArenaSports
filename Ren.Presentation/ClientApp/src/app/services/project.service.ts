import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppHeader } from '../utils/header.util';
import { ProjectModel } from '../models/project.model';

@Injectable({
    providedIn: 'root'
})
export class ProjectService {
    constructor(private http: HttpClient) {
    }

    public get() {
        return this.http.get<ProjectModel[]>(`${AppHeader.url}/projects`, { headers: AppHeader.composeHeader() });
    }

    public getById(id: String) {
        return this.http.get<ProjectModel>(`${AppHeader.url}/projects/${id}`, { headers: AppHeader.composeHeader() });
    }

    public post(data: any) {
        return this.http.post(`${AppHeader.url}/projects`, data, { headers: AppHeader.composeHeader() });
    }

    public put(data: any) {
        return this.http.put(`${AppHeader.url}/projects`, data, { headers: AppHeader.composeHeader() });
    }

    public delete(id: String) {
        return this.http.delete(`${AppHeader.url}/projects/${id}`, { headers: AppHeader.composeHeader() });
    }
}