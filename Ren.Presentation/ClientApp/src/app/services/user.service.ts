import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppHeader } from '../utils/header.util';
import { UserModel } from '../models/user.model';
import { GetUsersModel } from '../models/getUsers.model';

@Injectable({
    providedIn: 'root'
})

export class UserService {
    constructor(public http: HttpClient) {
    }

    public get() {
        return this.http.get<GetUsersModel[]>(`${AppHeader.url}/users`, { headers: AppHeader.composeHeader() });
    }

    public getById(id: String) {
        return this.http.get<UserModel>(`${AppHeader.url}/users/${id}`, { headers: AppHeader.composeHeader() });
    }

    public post(data: UserModel) {
        return this.http.post(`${AppHeader.url}/users`, data, { headers: AppHeader.composeHeader() });
    }

    public put(data: UserModel) {
        return this.http.put(`${AppHeader.url}/users`, data, { headers: AppHeader.composeHeader() });
    }

    public delete(id: String) {
        return this.http.delete(`${AppHeader.url}/users/${id}`, { headers: AppHeader.composeHeader() });
    }
}